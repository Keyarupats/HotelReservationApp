using Model;
using HotelReservation.BusinessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UI.Dialogs.Reservation;

namespace UI.Controls
{
    public partial class ReservationControl : UserControl
    {
        private ReservationController reservationController;
        private RoomController roomController;
        private GuestController guestController;
        private int resolvedGuestId = 0;
        private bool isMultiRoomMode = false;
        private int multiRoom1Id = 0;
        private decimal multiRoom1Rate = 0m;
        private int multiRoom2Id = 0;
        private decimal multiRoom2Rate = 0m;

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
            if (nudNights.Value < 1) nudNights.Value = 1;

            ResetFormState();
            ComputeAndDisplayCheckOut();
            LoadAvailableRooms();
            LoadReservationsGrid();
        }

        private void ResetFormState()
        {
            isMultiRoomMode = false;
            multiRoom1Id = 0;
            multiRoom2Id = 0;

            cmbAvailableRooms.Visible = true;
            lblFirstRoomChoice.Visible = false;
            lblSecondRoomChoice.Visible = false;
            btnEditMultiRoom.Visible = false;

            nudChildren.Enabled = true;
            nudChildren.Maximum = 8;
            nudChildren.Value = 0;

            nudAdults.Maximum = 8;
            nudAdults.Value = 1;
            nudAdults.Enabled = false;

            nudNights.Value = 1;
            nudNights.Enabled = false;

            lblTotalAmount.Text = "₱0.00";
            nudChildren.Focus();
        }

        private void nudChildren_ValueChanged(object sender, EventArgs e)
        {
            if (isMultiRoomMode) return;

            if (!nudAdults.Enabled)
            {
                nudAdults.Enabled = true;
            }

            ApplyOccupancyRules();
        }

        private void nudChildren_Leave(object sender, EventArgs e)
        {
            if (isMultiRoomMode) return;

            if (!nudAdults.Enabled)
            {
                nudAdults.Enabled = true;
            }
        }

        private void nudAdults_ValueChanged(object sender, EventArgs e)
        {
            if (isMultiRoomMode) return;

            if (!nudNights.Enabled)
            {
                nudNights.Enabled = true;
            }

            ApplyOccupancyRules();
        }

        private void ApplyOccupancyRules()
        {
            int children = (int)nudChildren.Value;
            int adults = (int)nudAdults.Value;

            if (children > 4)
            {
                int extraChildren = children - 4;
                nudAdults.Maximum = Math.Max(1, 8 - extraChildren);
                adults = (int)nudAdults.Value;
            }
            else
            {
                nudAdults.Maximum = 8;
            }
            bool triggersMultiRoom = (adults + children >= 12) || (children > 4 && nudAdults.Maximum <= 5);

            if (triggersMultiRoom && !isMultiRoomMode)
            {
                OpenMultiRoomDialog();
                return;
            }

            if (!isMultiRoomMode)
            {
                LoadAvailableRooms();
                UpdateTotalQuote();
            }
        }

        private void OpenMultiRoomDialog()
        {
            try
            {
                var allAvailableRooms = roomController.GetAvailableRooms(dtpCheckIn.Value, 1, 0);

                if (allAvailableRooms == null || allAvailableRooms.Count < 2)
                {
                    MessageBox.Show("At least 2 available rooms are required for a group of 12 or more, but fewer than 2 rooms are available.",
                                    "Insufficient Rooms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MultiRoomBookingDialog dialog = new MultiRoomBookingDialog(
                    allAvailableRooms,
                    (int)nudAdults.Value,
                    (int)nudChildren.Value,
                    (int)nudNights.Value,
                    isMultiRoomMode,
                    multiRoom1Id,
                    multiRoom2Id))
                {
                    DialogResult result = dialog.ShowDialog(this);

                    if (result == DialogResult.OK)
                    {
                        isMultiRoomMode = true;
                        multiRoom1Id = dialog.SelectedRoom1Id;
                        multiRoom1Rate = dialog.Room1Rate;
                        multiRoom2Id = dialog.SelectedRoom2Id;
                        multiRoom2Rate = dialog.Room2Rate;

                        nudAdults.Maximum = 16;
                        nudChildren.Maximum = 8;
                        nudAdults.Value = dialog.FinalAdults;
                        nudChildren.Value = dialog.FinalChildren;
                        nudNights.Value = dialog.FinalNights;

                        nudAdults.Enabled = false;
                        nudChildren.Enabled = false;
                        nudNights.Enabled = false;

                        cmbAvailableRooms.Visible = false;
                        lblFirstRoomChoice.Text = "1st Room: " + dialog.SelectedRoom1Text;
                        lblSecondRoomChoice.Text = "2nd Room: " + dialog.SelectedRoom2Text;
                        lblFirstRoomChoice.Visible = true;
                        lblSecondRoomChoice.Visible = true;
                        btnEditMultiRoom.Visible = true;

                        lblTotalAmount.Text = $"₱{dialog.CombinedTotal:N2}";
                        ComputeAndDisplayCheckOut();
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        return;
                    }
                    else
                    {
                        ResetFormState();
                        LoadAvailableRooms();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening 2-room selection dialog: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            ComputeAndDisplayCheckOut();
            if (!isMultiRoomMode)
            {
                LoadAvailableRooms();
            }
        }

        private void nudNights_ValueChanged(object sender, EventArgs e)
        {
            ComputeAndDisplayCheckOut();
            UpdateTotalQuote();
        }

        private void ComputeAndDisplayCheckOut()
        {
            int nights = (int)nudNights.Value;
            if (nights < 1) nights = 1;

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

                var availableRooms = roomController.GetAvailableRooms(checkIn, requestedAdults, requestedChildren);

                var displayList = availableRooms.Select(r => new
                {
                    r.RoomId,
                    r.RatePerAdult,
                    r.MaxAdults,
                    r.MaxChildren,
                    DisplayText = $"Room {r.RoomId}"
                }).ToList();

                cmbAvailableRooms.DataSource = null;
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
            int adults = (int)nudAdults.Value;
            int nights = (int)nudNights.Value;
            if (nights < 1) nights = 1;

            if (isMultiRoomMode)
            {
                int room1Adults = (adults + 1) / 2;
                int room2Adults = adults - room1Adults;
                decimal combined = ((room1Adults * multiRoom1Rate) + (room2Adults * multiRoom2Rate)) * nights;
                lblTotalAmount.Text = $"₱{combined:N2}";
                return;
            }

            if (cmbAvailableRooms.SelectedItem != null)
            {
                dynamic selectedRoom = cmbAvailableRooms.SelectedItem;
                decimal ratePerAdult = selectedRoom.RatePerAdult;

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

            if (string.IsNullOrWhiteSpace(searchInput))
            {
                MessageBox.Show("Please provide a guest search keyword.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isMultiRoomMode && cmbAvailableRooms.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an available room.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isMultiRoomMode && (multiRoom1Id <= 0 || multiRoom2Id <= 0))
            {
                MessageBox.Show("Please complete the 2-room selection first.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Save this advance reservation as Pending?", "Confirm Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int targetGuestId = resolvedGuestId;
                    if (targetGuestId <= 0)
                    {
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
                            var matchedGuests = guestController.SearchGuests(searchInput, true);
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

                    int nights = (int)nudNights.Value;
                    int totalHours = (24 * nights) - 2;
                    DateTime checkOutDateTime = dtpCheckIn.Value.AddHours(totalHours);
                    int totalAdults = (int)nudAdults.Value;
                    int totalChildren = (int)nudChildren.Value;

                    if (isMultiRoomMode)
                    {
                        int room1Adults = (totalAdults + 1) / 2;
                        int room1Children = (totalChildren + 1) / 2;
                        int room2Adults = totalAdults - room1Adults;
                        int room2Children = totalChildren - room1Children;

                        ReservationModel res1 = new ReservationModel
                        {
                            GuestId = targetGuestId,
                            RoomId = multiRoom1Id,
                            Adults = room1Adults,
                            Children = room1Children,
                            RatePerAdult = multiRoom1Rate,
                            CheckInDateTime = dtpCheckIn.Value,
                            ExpectedCheckOutDateTime = checkOutDateTime,
                            Status = "Pending"
                        };

                        ReservationModel res2 = new ReservationModel
                        {
                            GuestId = targetGuestId,
                            RoomId = multiRoom2Id,
                            Adults = room2Adults,
                            Children = room2Children,
                            RatePerAdult = multiRoom2Rate,
                            CheckInDateTime = dtpCheckIn.Value,
                            ExpectedCheckOutDateTime = checkOutDateTime,
                            Status = "Pending"
                        };

                        int id1 = reservationController.CreateBooking(res1);
                        int id2 = reservationController.CreateBooking(res2);

                        if (id1 > 0 && id2 > 0)
                        {
                            MessageBox.Show("Both reservations saved successfully with status 'Pending'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtGuestSearch.Clear();
                            resolvedGuestId = 0;
                            ResetFormState();
                            LoadReservationsGrid();
                            LoadAvailableRooms();
                        }
                        else
                        {
                            MessageBox.Show("Failed to save one or both reservations. Please verify inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        dynamic selectedRoom = cmbAvailableRooms.SelectedItem;

                        ReservationModel newReservation = new ReservationModel
                        {
                            GuestId = targetGuestId,
                            RoomId = selectedRoom.RoomId,
                            Adults = totalAdults,
                            Children = totalChildren,
                            RatePerAdult = selectedRoom.RatePerAdult,
                            CheckInDateTime = dtpCheckIn.Value,
                            ExpectedCheckOutDateTime = checkOutDateTime,
                            Status = "Pending"
                        };

                        int newId = reservationController.CreateBooking(newReservation);

                        if (newId > 0)
                        {
                            MessageBox.Show("Reservation saved successfully with status 'Pending'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtGuestSearch.Clear();
                            resolvedGuestId = 0;
                            ResetFormState();
                            LoadReservationsGrid();
                            LoadAvailableRooms();
                        }
                        else
                        {
                            MessageBox.Show("Failed to save reservation. Please verify inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
                txtGuestSearch.ForeColor = Color.Red; 
                return;
            }

            try
            {
                bool isMatchFound = false;

                if (long.TryParse(searchInput, out long mobileCheck) && searchInput.Length > 9)
                {
                    var allGuests = guestController.GetGuests(true);
                    var found = allGuests.Find(g => g.ContactNo == searchInput);
                    if (found != null)
                    {
                        resolvedGuestId = found.GuestId;
                        isMatchFound = true;
                    }
                    else
                    {
                        resolvedGuestId = 0;
                    }
                }
                else
                {
                    var matchedGuests = guestController.SearchGuests(searchInput, true);
                    if (matchedGuests != null && matchedGuests.Count == 1)
                    {
                        resolvedGuestId = matchedGuests[0].GuestId;
                        isMatchFound = true;
                    }
                    else
                    {
                        resolvedGuestId = 0;
                    }
                }

                if (isMatchFound)
                {
                    txtGuestSearch.ForeColor = Color.Blue; 
                }
                else
                {
                    txtGuestSearch.ForeColor = Color.Red;  
                }
            }
            catch
            {
                resolvedGuestId = 0;
                txtGuestSearch.ForeColor = Color.Red;
            }
        }

        private void btnEditMultiRoom_Click(object sender, EventArgs e)
        {
            OpenMultiRoomDialog();
        }
    }
}