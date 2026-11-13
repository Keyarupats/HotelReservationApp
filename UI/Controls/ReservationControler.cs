using Model;
using HotelReservation.BusinessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        private string resolvedGuestDisplay = string.Empty;

        private bool isMultiRoomMode = false;
        private int multiRoom1Id = 0;
        private decimal multiRoom1Rate = 0m;
        private string multiRoom1Summary = string.Empty;
        private int multiRoom2Id = 0;
        private decimal multiRoom2Rate = 0m;
        private string multiRoom2Summary = string.Empty;

        public ReservationControl()
        {
            InitializeComponent();
            reservationController = new ReservationController();
            roomController = new RoomController();
            guestController = new GuestController();
        }

        private void ReservationControl_Load(object sender, EventArgs e)
        {
            SetInitialCheckInTime(DateTime.Now);
            if (nudNights.Value < 1) nudNights.Value = 1;

            ResetFormState();
            ComputeAndDisplayCheckOut();
            LoadAvailableRooms();
            LoadReservationsGrid();
        }

        private void SetInitialCheckInTime(DateTime dt)
        {
            dtpCheckIn.Value = dt.Date;
            int hour12 = dt.Hour % 12;
            if (hour12 == 0) hour12 = 12;

            nudHour.Value = hour12;
            nudMinute.Value = dt.Minute;
            rdoPM.Checked = dt.Hour >= 12;
            rdoAM.Checked = dt.Hour < 12;
        }

        private DateTime GetCombinedCheckInDateTime()
        {
            DateTime datePart = dtpCheckIn.Value.Date;
            int hour = (int)nudHour.Value;
            int minute = (int)nudMinute.Value;

            if (rdoPM.Checked && hour < 12) hour += 12;
            if (rdoAM.Checked && hour == 12) hour = 0;

            return datePart.AddHours(hour).AddMinutes(minute);
        }

        private void ResetFormState()
        {
            isMultiRoomMode = false;
            multiRoom1Id = 0;
            multiRoom2Id = 0;
            multiRoom1Summary = string.Empty;
            multiRoom2Summary = string.Empty;

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

            bool triggersMultiRoom = (children > 4) || (adults + children >= 12);

            if (triggersMultiRoom && !isMultiRoomMode)
            {
                OpenMultiRoomDialog();
                return;
            }

            if (!isMultiRoomMode)
            {
                nudAdults.Maximum = 8;
                LoadAvailableRooms();
                UpdateTotalQuote();
            }
        }

        private void OpenMultiRoomDialog()
        {
            try
            {
                var allAvailableRooms = roomController.GetAvailableRooms(GetCombinedCheckInDateTime(), 1, 0);

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
                        multiRoom1Summary = dialog.SelectedRoom1Text;
                        multiRoom2Id = dialog.SelectedRoom2Id;
                        multiRoom2Rate = dialog.Room2Rate;
                        multiRoom2Summary = dialog.SelectedRoom2Text;

                        nudAdults.Maximum = 16;
                        nudChildren.Maximum = 8;
                        nudAdults.Value = dialog.FinalAdults;
                        nudChildren.Value = dialog.FinalChildren;
                        nudNights.Value = dialog.FinalNights;

                        nudAdults.Enabled = false;
                        nudChildren.Enabled = false;
                        nudNights.Enabled = false;

                        cmbAvailableRooms.Visible = false;
                        lblFirstRoomChoice.Text = "1st Room: " + multiRoom1Summary;
                        lblSecondRoomChoice.Text = "2nd Room: " + multiRoom2Summary;
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

        private void CheckInDateTime_Changed(object sender, EventArgs e)
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
            DateTime checkOutTime = GetCombinedCheckInDateTime().AddHours(totalHours);

            lblCheckOut.Text = checkOutTime.ToString("MMM dd, yyyy  hh:mm tt");
        }

        private void LoadAvailableRooms()
        {
            lblTotalAmount.Text = "₱0.00";

            try
            {
                int requestedAdults = (int)nudAdults.Value;
                int requestedChildren = (int)nudChildren.Value;
                DateTime checkIn = GetCombinedCheckInDateTime();

                var availableRooms = roomController.GetAvailableRooms(checkIn, requestedAdults, requestedChildren);

                var displayList = availableRooms.Select(r => new
                {
                    r.RoomId,
                    r.TypeName,
                    r.RatePerAdult,
                    r.MaxAdults,
                    r.MaxChildren,
                    DisplayText = $"Room {r.RoomId} - {r.TypeName} - ₱{r.RatePerAdult:N2}/adult"
                }).ToList();

                cmbAvailableRooms.DataSource = null;
                cmbAvailableRooms.DataSource = displayList;
                cmbAvailableRooms.DisplayMember = "DisplayText";
                cmbAvailableRooms.ValueMember = "RoomId";

                if (availableRooms.Count == 0 && (requestedAdults > 1 || requestedChildren > 0))
                {
                    OpenMultiRoomDialog();
                    return;
                }
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
                var allGuests = guestController.GetGuests(false);

                var grouped = list
                    .GroupBy(r => new
                    {
                        r.GuestId,
                        CheckInMinute = new DateTime(
                            r.CheckInDateTime.Year,
                            r.CheckInDateTime.Month,
                            r.CheckInDateTime.Day,
                            r.CheckInDateTime.Hour,
                            r.CheckInDateTime.Minute,
                            0),
                        r.Status
                    })
                    .Select(g =>
                    {
                        var guest = allGuests.FirstOrDefault(x => x.GuestId == g.Key.GuestId);
                        string guestDisplay = guest != null
                            ? $"{guest.FirstName} {guest.LastName} ({guest.ContactNo})"
                            : $"Guest #{g.Key.GuestId}";

                        DateTime checkIn = g.First().CheckInDateTime;
                        DateTime checkOut = g.First().ExpectedCheckOutDateTime;
                        int nights = Math.Max(1, (int)Math.Round((checkOut - checkIn).TotalHours / 24.0));
                        decimal totalQuote = g.Sum(x => x.Adults * x.RatePerAdult * nights);

                        return new
                        {
                            PrimaryReservationId = g.Min(x => x.ReservationId),
                            AllReservationIds = string.Join(",", g.Select(x => x.ReservationId)),
                            GuestId = g.Key.GuestId,
                            GuestDisplay = guestDisplay,
                            RoomsDisplay = g.Count() > 1
                                ? $"{string.Join(", ", g.Select(x => x.RoomId))} ({g.Count()} Rooms)"
                                : $"Room {g.First().RoomId}",
                            AllRoomIds = string.Join(",", g.Select(x => x.RoomId)),
                            TotalAdults = g.Sum(x => x.Adults),
                            TotalChildren = g.Sum(x => x.Children),
                            Nights = nights,
                            TotalQuote = totalQuote,
                            CheckInRaw = checkIn,
                            CheckOutRaw = checkOut,
                            CheckIn = checkIn.ToString("MMM dd, yyyy hh:mm tt"),
                            CheckOut = checkOut.ToString("MMM dd, yyyy hh:mm tt"),
                            Status = g.Key.Status
                        };
                    })
                    .ToList();

                DataTable dt = new DataTable();
                dt.Columns.Add("ReservationId", typeof(int));
                dt.Columns.Add("GuestId", typeof(int));
                dt.Columns.Add("Rooms", typeof(string));
                dt.Columns.Add("Adults", typeof(int));
                dt.Columns.Add("CheckIn Date", typeof(string));
                dt.Columns.Add("CheckOut Date", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Columns.Add("AllReservationIds", typeof(string));
                dt.Columns.Add("AllRoomIds", typeof(string));
                dt.Columns.Add("GuestDisplay", typeof(string));
                dt.Columns.Add("TotalChildren", typeof(int));
                dt.Columns.Add("Nights", typeof(int));
                dt.Columns.Add("TotalQuote", typeof(decimal));
                dt.Columns.Add("CheckInRaw", typeof(DateTime));
                dt.Columns.Add("CheckOutRaw", typeof(DateTime));

                foreach (var item in grouped)
                {
                    dt.Rows.Add(
                        item.PrimaryReservationId,
                        item.GuestId,
                        item.RoomsDisplay,
                        item.TotalAdults,
                        item.CheckIn,
                        item.CheckOut,
                        item.Status,
                        item.AllReservationIds,
                        item.AllRoomIds,
                        item.GuestDisplay,
                        item.TotalChildren,
                        item.Nights,
                        item.TotalQuote,
                        item.CheckInRaw,
                        item.CheckOutRaw);
                }

                dgvReservations.DataSource = dt;

                string[] hiddenCols = { "AllReservationIds", "AllRoomIds", "GuestDisplay", "TotalChildren", "Nights", "TotalQuote", "CheckInRaw", "CheckOutRaw" };
                foreach (string col in hiddenCols)
                {
                    if (dgvReservations.Columns[col] != null)
                        dgvReservations.Columns[col].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveReservation_Click(object sender, EventArgs e)
        {
            string searchInput = txtGuestSearch.Text.Trim();

            int targetGuestId = resolvedGuestId;
            string guestDisplay = resolvedGuestDisplay;

            if (targetGuestId <= 0 && !string.IsNullOrWhiteSpace(searchInput))
            {
                try
                {
                    if (long.TryParse(searchInput, out _) && searchInput.Length > 9)
                    {
                        var allGuests = guestController.GetGuests(true);
                        var found = allGuests.Find(g => g.ContactNo == searchInput);
                        if (found != null)
                        {
                            targetGuestId = found.GuestId;
                            guestDisplay = $"{found.FirstName} {found.LastName} ({found.ContactNo})";
                        }
                    }
                    else
                    {
                        var matchedGuests = guestController.SearchGuests(searchInput, true);
                        if (matchedGuests != null && matchedGuests.Count == 1)
                        {
                            targetGuestId = matchedGuests[0].GuestId;
                            guestDisplay = $"{matchedGuests[0].FirstName} {matchedGuests[0].LastName} ({matchedGuests[0].ContactNo})";
                        }
                    }
                }
                catch { }
            }

            List<string> errors = new List<string>();
            if (targetGuestId <= 0)
                errors.Add("• Valid registered guest (Code, Name, or Mobile)");
            if (!isMultiRoomMode && cmbAvailableRooms.SelectedIndex == -1)
                errors.Add("• An available room selection");
            if (isMultiRoomMode && (multiRoom1Id <= 0 || multiRoom2Id <= 0))
                errors.Add("• Both rooms in the 2-room selection");

            if (errors.Count > 0)
            {
                MessageBox.Show("Please complete the following before saving:\n\n" + string.Join("\n", errors),
                                "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime checkInDateTime = GetCombinedCheckInDateTime();
            int nights = (int)nudNights.Value;
            int totalHours = (24 * nights) - 2;
            DateTime checkOutDateTime = checkInDateTime.AddHours(totalHours);
            int totalAdults = (int)nudAdults.Value;
            int totalChildren = (int)nudChildren.Value;

            string roomSummary = isMultiRoomMode
                ? $"1st: {multiRoom1Summary}{Environment.NewLine}2nd: {multiRoom2Summary}"
                : cmbAvailableRooms.Text;

            using (ReservationConfirmDialog confirmDialog = new ReservationConfirmDialog(
                guestDisplay,
                checkInDateTime,
                checkOutDateTime,
                roomSummary,
                totalAdults,
                totalChildren,
                nights,
                lblTotalAmount.Text))
            {
                if (confirmDialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
            }

            try
            {
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
                        CheckInDateTime = checkInDateTime,
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
                        CheckInDateTime = checkInDateTime,
                        ExpectedCheckOutDateTime = checkOutDateTime,
                        Status = "Pending"
                    };

                    int id1 = reservationController.CreateBooking(res1);
                    int id2 = reservationController.CreateBooking(res2);

                    if (id1 <= 0 || id2 <= 0)
                    {
                        MessageBox.Show("Failed to save one or both reservations. Please verify inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
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
                        CheckInDateTime = checkInDateTime,
                        ExpectedCheckOutDateTime = checkOutDateTime,
                        Status = "Pending"
                    };

                    int newId = reservationController.CreateBooking(newReservation);

                    if (newId <= 0)
                    {
                        MessageBox.Show("Failed to save reservation. Please verify inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                txtGuestSearch.Clear();
                resolvedGuestId = 0;
                resolvedGuestDisplay = string.Empty;
                ResetFormState();
                LoadReservationsGrid();
                LoadAvailableRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving reservation: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0) return;

            try
            {
                var row = dgvReservations.SelectedRows[0];
                string currentStatus = row.Cells["Status"].Value.ToString();
                if (currentStatus != "Pending")
                {
                    MessageBox.Show($"Only 'Pending' reservations can be confirmed. Current status: '{currentStatus}'.",
                                    "Invalid Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int[] reservationIds = row.Cells["AllReservationIds"].Value.ToString().Split(',').Select(int.Parse).ToArray();
                int[] roomIds = row.Cells["AllRoomIds"].Value.ToString().Split(',').Select(int.Parse).ToArray();

                string guestDisplay = row.Cells["GuestDisplay"].Value.ToString();
                DateTime checkIn = Convert.ToDateTime(row.Cells["CheckInRaw"].Value);
                DateTime checkOut = Convert.ToDateTime(row.Cells["CheckOutRaw"].Value);
                string roomsText = row.Cells["Rooms"].Value.ToString();
                int adults = Convert.ToInt32(row.Cells["Adults"].Value);
                int children = Convert.ToInt32(row.Cells["TotalChildren"].Value);
                int nights = Convert.ToInt32(row.Cells["Nights"].Value);
                decimal totalQuote = Convert.ToDecimal(row.Cells["TotalQuote"].Value);

                using (ReservationConfirmDialog confirmDialog = new ReservationConfirmDialog(
                    guestDisplay,
                    checkIn,
                    checkOut,
                    roomsText,
                    adults,
                    children,
                    nights,
                    $"₱{totalQuote:N2}",
                    "Confirm Pending Reservation",
                    "Verify booking details to lock in room(s) as Reserved:",
                    "✔️ Confirm Booking"))
                {
                    if (confirmDialog.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }
                }

                bool allUpdated = true;
                for (int i = 0; i < reservationIds.Length; i++)
                {
                    if (reservationController.ConfirmBooking(reservationIds[i]))
                    {
                        roomController.ChangeRoomStatus(roomIds[i], "Reserved");
                    }
                    else
                    {
                        allUpdated = false;
                    }
                }

                if (!allUpdated)
                {
                    MessageBox.Show("One or more linked reservations failed to update in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                LoadReservationsGrid();
                LoadAvailableRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error confirming reservation: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0) return;

            try
            {
                var row = dgvReservations.SelectedRows[0];
                int[] reservationIds = row.Cells["AllReservationIds"].Value.ToString()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                int[] roomIds = row.Cells["AllRoomIds"].Value.ToString()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                string roomsText = row.Cells["Rooms"].Value.ToString();
                string prompt = reservationIds.Length > 1
                    ? $"Cancel all {reservationIds.Length} linked reservations (Rooms {roomsText}) and restore room availability?"
                    : $"Cancel Reservation #{reservationIds[0]} and restore Room {roomsText} availability?";

                if (MessageBox.Show(prompt, "Cancel Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool allCancelled = true;
                    for (int i = 0; i < reservationIds.Length; i++)
                    {
                        if (!reservationController.CancelBooking(reservationIds[i], roomIds[i]))
                        {
                            allCancelled = false;
                        }
                    }

                    if (!allCancelled)
                    {
                        MessageBox.Show("One or more linked reservations failed to cancel in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    LoadReservationsGrid();
                    LoadAvailableRooms();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to cancel reservation: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGuestSearch_TextChanged(object sender, EventArgs e)
        {
            string searchInput = txtGuestSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                resolvedGuestId = 0;
                resolvedGuestDisplay = string.Empty;
                txtGuestSearch.ForeColor = Color.Red;
                return;
            }

            try
            {
                bool isMatchFound = false;

                if (long.TryParse(searchInput, out _) && searchInput.Length > 9)
                {
                    var allGuests = guestController.GetGuests(true);
                    var found = allGuests.Find(g => g.ContactNo == searchInput);
                    if (found != null)
                    {
                        resolvedGuestId = found.GuestId;
                        resolvedGuestDisplay = $"{found.FirstName} {found.LastName} ({found.ContactNo})";
                        isMatchFound = true;
                    }
                }
                else
                {
                    var matchedGuests = guestController.SearchGuests(searchInput, true);
                    if (matchedGuests != null && matchedGuests.Count == 1)
                    {
                        resolvedGuestId = matchedGuests[0].GuestId;
                        resolvedGuestDisplay = $"{matchedGuests[0].FirstName} {matchedGuests[0].LastName} ({matchedGuests[0].ContactNo})";
                        isMatchFound = true;
                    }
                }

                if (isMatchFound)
                {
                    txtGuestSearch.ForeColor = Color.Blue;
                }
                else
                {
                    resolvedGuestId = 0;
                    resolvedGuestDisplay = string.Empty;
                    txtGuestSearch.ForeColor = Color.Red;
                }
            }
            catch
            {
                resolvedGuestId = 0;
                resolvedGuestDisplay = string.Empty;
                txtGuestSearch.ForeColor = Color.Red;
            }
        }

        private void btnEditMultiRoom_Click(object sender, EventArgs e)
        {
            OpenMultiRoomDialog();
        }
    }
}