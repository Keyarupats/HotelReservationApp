using Model;
using HotelReservation.BusinessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Repository;

namespace UI.Controls
{
    public partial class ReservationControl : UserControl
    {
        private ReservationController reservationController;
        private RoomController roomController;
        private GuestController guestController;
        private int resolvedGuestId = 0;

        public ReservationControl()
        {
            InitializeComponent();
            reservationController = new ReservationController();
            roomController = new RoomController();
            guestController = new GuestController();
        }

        private void ReservationControl_Load(object sender, EventArgs e)
        {
            dtpCheckIn.Value = DateTime.Now;
            if (nudNights.Value < 1) nudNights.Value = 1; // Default to at least 1 night
            ComputeAndDisplayCheckOut();
            LoadAvailableRooms();
            LoadReservationsGrid();
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            ComputeAndDisplayCheckOut();
            LoadAvailableRooms();
        }

        private void nudNights_ValueChanged(object sender, EventArgs e)
        {
            ComputeAndDisplayCheckOut();
            UpdateTotalQuote();
        }

        private void Criteria_ValueChanged(object sender, EventArgs e)
        {
            LoadAvailableRooms();
            UpdateTotalQuote();
        }

        private void ComputeAndDisplayCheckOut()
        {
            int nights = (int)nudNights.Value;
            if (nights < 1) nights = 1;

            // Professor's Rule: (24 hours * number of nights) - 2 hours cleaning buffer
            int totalHours = (24 * nights) - 2;
            DateTime checkOutTime = dtpCheckIn.Value.AddHours(totalHours);

            lblCheckOut.Text = checkOutTime.ToString("MMM dd, yyyy  hh:mm tt");
        }

        private void LoadAvailableRooms()
        {
            lblTotalAmount.Text = "₱0.00";

            try
            {
                int requestedAdults = (int)nudAdults.Value;
                int requestedChildren = (int)nudChildren.Value;
                DateTime checkIn = dtpCheckIn.Value;

                // Fetch available rooms
                var availableRooms = roomController.GetAvailableRooms(checkIn, requestedAdults, requestedChildren);

                // Format the display text to show only Room ID and Room Type
                var displayList = availableRooms.Select(r => new
                {
                    r.RoomId,
                    r.RatePerAdult,
                    DisplayText = $"Room {r.RoomId} - {r.TypeName}"
                }).ToList();

                cmbAvailableRooms.DataSource = null; // Clear the data source binding first
                cmbAvailableRooms.DataSource = displayList;
                cmbAvailableRooms.DisplayMember = "DisplayText";
                cmbAvailableRooms.ValueMember = "RoomId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading available rooms from database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbAvailableRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalQuote();
        }

        private void UpdateTotalQuote()
        {
            if (cmbAvailableRooms.SelectedItem != null)
            {
                dynamic selectedRoom = cmbAvailableRooms.SelectedItem;
                decimal ratePerAdult = selectedRoom.RatePerAdult;
                int adults = (int)nudAdults.Value;
                int nights = (int)nudNights.Value;
                if (nights < 1) nights = 1;

                // Multiply quote calculation by the number of nights selected
                decimal baseTotal = reservationController.CalculateTotalQuote(ratePerAdult, adults);
                decimal total = baseTotal * nights;

                lblTotalAmount.Text = $"₱{total:N2}";
            }
        }

        private void LoadReservationsGrid()
        {
            try
            {
                List<ReservationModel> list = reservationController.GetReservations(null, null);

                DataTable dt = new DataTable();
                dt.Columns.Add("ReservationId", typeof(int));
                dt.Columns.Add("GuestId", typeof(int));
                dt.Columns.Add("RoomId", typeof(int));
                dt.Columns.Add("Adults", typeof(int));
                dt.Columns.Add("CheckIn Date", typeof(string));
                dt.Columns.Add("CheckOut Date", typeof(string));
                dt.Columns.Add("Status", typeof(string));

                foreach (var r in list)
                {
                    dt.Rows.Add(r.ReservationId, r.GuestId, r.RoomId, r.Adults, r.CheckInDateTime.ToString("MMM dd, yyyy hh:mm tt"), r.ExpectedCheckOutDateTime.ToString("MMM dd, yyyy hh:mm tt"), r.Status);
                }

                dgvReservations.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveReservation_Click(object sender, EventArgs e)
        {
            string searchInput = txtGuestSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchInput) || cmbAvailableRooms.SelectedIndex == -1)
            {
                MessageBox.Show("Please provide a guest search keyword and select an available room.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Save this advance reservation as Pending?", "Confirm Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int targetGuestId = resolvedGuestId;
                    if (targetGuestId <= 0)
                    {
                        List<GuestModel> matchedGuests = null;

                        if (long.TryParse(searchInput, out long mobileCheck) && searchInput.Length > 9)
                        {
                            var allGuests = guestController.GetGuests(true);
                            var found = allGuests.Find(g => g.ContactNo == searchInput);
                            if (found != null)
                            {
                                targetGuestId = found.GuestId;
                            }
                        }
                        else
                        {
                            matchedGuests = guestController.SearchGuests(searchInput, true);
                            if (matchedGuests != null && matchedGuests.Count > 0)
                            {
                                targetGuestId = matchedGuests[0].GuestId;
                            }
                        }
                    }

                    if (targetGuestId <= 0)
                    {
                        MessageBox.Show("Guest not found. Please verify the name, email, or mobile number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dynamic selectedRoom = cmbAvailableRooms.SelectedItem;
                    int nights = (int)nudNights.Value;
                    int totalHours = (24 * nights) - 2;
                    DateTime checkOutDateTime = dtpCheckIn.Value.AddHours(totalHours);

                    ReservationModel newReservation = new ReservationModel
                    {
                        GuestId = targetGuestId,
                        RoomId = selectedRoom.RoomId,
                        Adults = (int)nudAdults.Value,
                        Children = (int)nudChildren.Value,
                        RatePerAdult = selectedRoom.RatePerAdult,
                        CheckInDateTime = dtpCheckIn.Value,
                        ExpectedCheckOutDateTime = checkOutDateTime,
                        Status = "Pending"
                    };

                    int newId = reservationController.CreateBooking(newReservation);

                    if (newId > 0)
                    {
                        MessageBox.Show("Reservation saved successfully with status 'Pending'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReservationsGrid();
                        LoadAvailableRooms();
                        txtGuestSearch.Clear();
                        resolvedGuestId = 0;
                    }
                    else
                    {
                        MessageBox.Show("Failed to save reservation. Please verify inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0) return;

            try
            {
                string currentStatus = dgvReservations.SelectedRows[0].Cells["Status"].Value.ToString();
                if (currentStatus != "Pending")
                {
                    MessageBox.Show($"Only 'Pending' reservations can be confirmed. This reservation is currently '{currentStatus}'.", "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int reservationId = Convert.ToInt32(dgvReservations.SelectedRows[0].Cells["ReservationId"].Value);
                int roomId = Convert.ToInt32(dgvReservations.SelectedRows[0].Cells["RoomId"].Value);

                if (MessageBox.Show("Transition this reservation to 'Confirmed' status?", "Confirm Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool isReservationUpdated = reservationController.ConfirmBooking(reservationId);

                    if (isReservationUpdated)
                    {
                        bool isRoomUpdated = roomController.ChangeRoomStatus(roomId, "Reserved");

                        MessageBox.Show("Reservation confirmed and room status updated to 'Reserved'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadReservationsGrid();
                        LoadAvailableRooms();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update reservation status in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadReservationsGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Are you sure you want to cancel this booking? This will restore room availability.", "Cancel Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    int reservationId = Convert.ToInt32(dgvReservations.SelectedRows[0].Cells["ReservationId"].Value);
                    int roomId = Convert.ToInt32(dgvReservations.SelectedRows[0].Cells["RoomId"].Value);

                    bool success = reservationController.CancelBooking(reservationId, roomId);

                    if (success)
                    {
                        MessageBox.Show("Reservation Cancelled. Room availability restored.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReservationsGrid();
                        LoadAvailableRooms();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to cancel reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadReservationsGrid();
        }

        private void txtGuestSearch_TextChanged(object sender, EventArgs e)
        {
            string searchInput = txtGuestSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                resolvedGuestId = 0;
                return;
            }

            try
            {
                // Check if input matches a mobile number
                if (long.TryParse(searchInput, out long mobileCheck) && searchInput.Length > 9)
                {
                    var allGuests = guestController.GetGuests(true);
                    var found = allGuests.Find(g => g.ContactNo == searchInput);
                    if (found != null)
                    {
                        resolvedGuestId = found.GuestId;
                        return;
                    }
                }

                // Search by name or guest code
                var matchedGuests = guestController.SearchGuests(searchInput, true);
                if (matchedGuests != null && matchedGuests.Count == 1)
                {
                    // Automatically resolve if a unique match is found
                    resolvedGuestId = matchedGuests[0].GuestId;
                }
                else
                {
                    resolvedGuestId = 0; 
                }
            }
            catch
            {
                resolvedGuestId = 0;
            }
        }
    }
}