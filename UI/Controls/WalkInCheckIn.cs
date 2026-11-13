using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Controller;
using Model;
using UI.Dialogs.Reservation;

namespace UI
{
    public partial class WalkInCheckIn : UserControl
    {
        private GuestController guestController;
        private RoomController roomController;
        private ReservationController reservationController;

        private GuestModel activeGuest;
        private DateTime walkInTimestamp;

        // Multi-room selection state (matches ReservationControl)
        private bool isMultiRoomMode = false;
        private int multiRoom1Id = 0;
        private decimal multiRoom1Rate = 0m;
        private string multiRoom1Summary = string.Empty;
        private int multiRoom2Id = 0;
        private decimal multiRoom2Rate = 0m;
        private string multiRoom2Summary = string.Empty;
        private bool isOpeningMultiRoomDialog = false;

        public WalkInCheckIn()
        {
            InitializeComponent();
            guestController = new GuestController();
            roomController = new RoomController();
            reservationController = new ReservationController();

            ResetGuestState();
            ResetStayState();
        }

        private void ResetGuestState()
        {
            activeGuest = null;
            txtSearchGuest.Clear();
            ClearGuestInputFields();
            SetGuestFieldsEditable(true);

            lblGuestStatusNotice.Text = " Search an existing guest above, or fill in details to register a new guest.";
            lblGuestStatusNotice.ForeColor = Color.DimGray;

            lblActiveGuestName.Text = "Guest: (None Selected)";
            lblActiveGuestName.ForeColor = Color.DimGray;
            panelStayDetails.Enabled = false;
        }

        private void ClearGuestInputFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMiddleInitial.Clear();
            txtMobileNumber.Clear();
            txtAge.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmbIdType.SelectedIndex = -1;
            txtIdNumber.Clear();
        }

        private void SetGuestFieldsEditable(bool editable)
        {
            txtFirstName.ReadOnly = !editable;
            txtLastName.ReadOnly = !editable;
            txtMiddleInitial.ReadOnly = !editable;
            txtMobileNumber.ReadOnly = !editable;
            txtAge.ReadOnly = !editable;
            txtEmail.ReadOnly = !editable;
            txtAddress.ReadOnly = !editable;
            txtIdNumber.ReadOnly = !editable;
            cmbIdType.Enabled = editable;
            btnRegisterGuest.Enabled = editable;

            Color fieldColor = editable ? Color.White : Color.WhiteSmoke;
            txtFirstName.BackColor = fieldColor;
            txtLastName.BackColor = fieldColor;
            txtMiddleInitial.BackColor = fieldColor;
            txtMobileNumber.BackColor = fieldColor;
            txtAge.BackColor = fieldColor;
            txtEmail.BackColor = fieldColor;
            txtAddress.BackColor = fieldColor;
            txtIdNumber.BackColor = fieldColor;
        }

        private void BindActiveGuest(GuestModel guest, string statusMessage)
        {
            activeGuest = guest;
            string code = string.IsNullOrWhiteSpace(guest.GuestCode)
                ? $"G-{guest.GuestId:D4}"
                : guest.GuestCode;

            txtFirstName.Text = guest.FirstName;
            txtLastName.Text = guest.LastName;
            txtMiddleInitial.Text = guest.MI;
            txtMobileNumber.Text = guest.ContactNo;
            txtAge.Text = guest.Age.ToString();
            txtEmail.Text = guest.Email;
            txtAddress.Text = guest.Address;
            cmbIdType.SelectedItem = guest.IDType;
            txtIdNumber.Text = guest.IDNum;

            SetGuestFieldsEditable(false);

            lblGuestStatusNotice.Text = $" ✓ {statusMessage} ({code})";
            lblGuestStatusNotice.ForeColor = Color.ForestGreen;

            lblActiveGuestName.Text = $"Guest: {guest.FullName} ({code})";
            lblActiveGuestName.ForeColor = Color.FromArgb(15, 23, 42);

            panelStayDetails.Enabled = true;
            ComputeAndDisplayCheckOut();
            if (!isMultiRoomMode)
            {
                LoadAvailableRooms();
            }
        }

        private void txtSearchGuest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnFindGuest.PerformClick();
            }
        }

        private void btnFindGuest_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchGuest.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a name, mobile number, email, or guest code to search.",
                                "Search Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearchGuest.Focus();
                return;
            }

            try
            {
                List<GuestModel> activeGuests = guestController.GetGuests(false);
                GuestModel matched = activeGuests.FirstOrDefault(g =>
                {
                    string formattedCode = string.IsNullOrWhiteSpace(g.GuestCode)
                        ? $"G-{g.GuestId:D4}"
                        : g.GuestCode;

                    return g.ContactNo.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                        || formattedCode.Equals(keyword, StringComparison.OrdinalIgnoreCase)
                        || g.GuestId.ToString().Equals(keyword, StringComparison.OrdinalIgnoreCase)
                        || (!string.IsNullOrWhiteSpace(g.Email) && g.Email.Equals(keyword, StringComparison.OrdinalIgnoreCase))
                        || g.FullName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                        || $"{g.FirstName} {g.LastName}".IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
                });

                if (matched != null)
                {
                    BindActiveGuest(matched, "Returning guest loaded");
                }
                else
                {
                    activeGuest = null;
                    ClearGuestInputFields();
                    SetGuestFieldsEditable(true);

                    if (keyword.Length == 11 && keyword.All(char.IsDigit))
                    {
                        txtMobileNumber.Text = keyword;
                    }

                    lblGuestStatusNotice.Text = " No guest found. Fill in the details below and click Register Guest.";
                    lblGuestStatusNotice.ForeColor = Color.DarkOrange;

                    lblActiveGuestName.Text = "Guest: (Register Guest First)";
                    lblActiveGuestName.ForeColor = Color.DimGray;
                    panelStayDetails.Enabled = false;
                    txtFirstName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching guest directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegisterGuest_Click(object sender, EventArgs e)
        {
            if (!ValidateNewGuestInputs())
                return;

            try
            {
                string mobile = txtMobileNumber.Text.Trim();
                if (guestController.IsMobileNumberRegistered(mobile, 0))
                {
                    MessageBox.Show($"Mobile number {mobile} is already registered. Use Find Guest to load the existing profile.",
                                    "Duplicate Mobile Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                GuestModel newGuest = new GuestModel
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    MI = txtMiddleInitial.Text.Trim(),
                    ContactNo = mobile,
                    Age = Convert.ToInt32(txtAge.Text.Trim()),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    IDType = cmbIdType.SelectedItem.ToString(),
                    IDNum = txtIdNumber.Text.Trim(),
                    IsActive = true
                };

                int newGuestId = guestController.RegisterGuest(newGuest);
                if (newGuestId > 0)
                {
                    newGuest.GuestId = newGuestId;
                    newGuest.GuestCode = $"G-{newGuestId:D4}";
                    BindActiveGuest(newGuest, "New guest registered & selected");
                }
                else
                {
                    MessageBox.Show("Failed to register guest. Please check all required fields.",
                                    "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering guest: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateNewGuestInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }
            string mobile = txtMobileNumber.Text.Trim();
            if (mobile.Length != 11 || !mobile.All(char.IsDigit))
            {
                MessageBox.Show("Mobile number must be exactly 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNumber.Focus();
                return false;
            }
            if (!int.TryParse(txtAge.Text.Trim(), out int age) || age < 18)
            {
                MessageBox.Show("Guest age must be a valid number of 18 or older.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }
            if (cmbIdType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an ID type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbIdType.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtIdNumber.Text))
            {
                MessageBox.Show("ID number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIdNumber.Focus();
                return false;
            }
            return true;
        }

        private void ResetStayState()
        {
            isOpeningMultiRoomDialog = true;
            try
            {
                isMultiRoomMode = false;
                multiRoom1Id = 0;
                multiRoom1Rate = 0m;
                multiRoom1Summary = string.Empty;
                multiRoom2Id = 0;
                multiRoom2Rate = 0m;
                multiRoom2Summary = string.Empty;

                cmbAvailableRooms.Visible = true;
                lblFirstRoomChoice.Visible = false;
                lblSecondRoomChoice.Visible = false;
                btnEditMultiRoom.Visible = false;

                numChildren.Enabled = true;
                numChildren.Maximum = 8;
                numChildren.Value = 0;

                numAdults.Enabled = true;
                numAdults.Maximum = 8;
                numAdults.Value = 1;

                numNights.Enabled = true;
                numNights.Value = 1;

                lblErrorMsg.Text = "";
                txtRateAdult.Text = "₱0.00";
                txtTotalAmount.Text = "₱0.00";
            }
            finally
            {
                isOpeningMultiRoomDialog = false;
            }

            ComputeAndDisplayCheckOut();
            LoadAvailableRooms();
        }

        private void numChildren_ValueChanged(object sender, EventArgs e)
        {
            if (isMultiRoomMode || isOpeningMultiRoomDialog) return;
            ApplyOccupancyRules();
        }

        private void numAdults_ValueChanged(object sender, EventArgs e)
        {
            if (isMultiRoomMode || isOpeningMultiRoomDialog) return;
            ApplyOccupancyRules();
        }

        private void numNights_ValueChanged(object sender, EventArgs e)
        {
            ComputeAndDisplayCheckOut();
            UpdateTotalQuote();
        }

        private void ApplyOccupancyRules()
        {
            int children = (int)numChildren.Value;
            int adults = (int)numAdults.Value;

            bool triggersMultiRoom = (children > 4) || (adults + children >= 12);

            if (triggersMultiRoom && !isMultiRoomMode)
            {
                OpenMultiRoomDialog();
                return;
            }

            if (!isMultiRoomMode)
            {
                numAdults.Maximum = 8;
                LoadAvailableRooms();
                UpdateTotalQuote();
            }
        }

        private void OpenMultiRoomDialog()
        {
            if (isOpeningMultiRoomDialog) return;
            isOpeningMultiRoomDialog = true;

            try
            {
                walkInTimestamp = DateTime.Now;
                var allAvailableRooms = roomController.GetAvailableRooms(walkInTimestamp, 1, 0);

                if (allAvailableRooms == null || allAvailableRooms.Count < 2)
                {
                    MessageBox.Show("At least 2 available rooms are required for a group of 12 or more, but fewer than 2 rooms are available.",
                                    "Insufficient Rooms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MultiRoomBookingDialog dialog = new MultiRoomBookingDialog(
                    allAvailableRooms,
                    (int)numAdults.Value,
                    (int)numChildren.Value,
                    (int)numNights.Value,
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

                        numAdults.Maximum = 16;
                        numChildren.Maximum = 8;
                        numAdults.Value = dialog.FinalAdults;
                        numChildren.Value = dialog.FinalChildren;
                        numNights.Value = dialog.FinalNights;

                        numAdults.Enabled = false;
                        numChildren.Enabled = false;
                        numNights.Enabled = false;

                        cmbAvailableRooms.Visible = false;
                        lblFirstRoomChoice.Text = "1st Room: " + multiRoom1Summary;
                        lblSecondRoomChoice.Text = "2nd Room: " + multiRoom2Summary;
                        lblFirstRoomChoice.Visible = true;
                        lblSecondRoomChoice.Visible = true;
                        btnEditMultiRoom.Visible = true;

                        lblErrorMsg.Text = "";
                        txtRateAdult.Text = $"₱{multiRoom1Rate:N2} / ₱{multiRoom2Rate:N2}";
                        txtTotalAmount.Text = $"₱{dialog.CombinedTotal:N2}";
                        lblRoomStatusTransition.Text = $"Room: {multiRoom1Id}, and {multiRoom2Id} Statuses after check-in:";
                        ComputeAndDisplayCheckOut();
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        return;
                    }
                    else
                    {
                        isOpeningMultiRoomDialog = false;
                        ResetStayState();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening 2-room selection dialog: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isOpeningMultiRoomDialog = false;
            }
        }

        private void ComputeAndDisplayCheckOut()
        {
            walkInTimestamp = DateTime.Now;
            int nights = (int)numNights.Value;
            if (nights < 1) nights = 1;

            int totalHours = (24 * nights) - 2;
            DateTime checkOutTime = walkInTimestamp.AddHours(totalHours);

            txtCheckInTime.Text = walkInTimestamp.ToString("MMM dd, yyyy  hh:mm tt");
            txtCheckOutTime.Text = checkOutTime.ToString("MMM dd, yyyy  hh:mm tt");
        }

        private void LoadAvailableRooms()
        {
            if (isMultiRoomMode) return;

            txtRateAdult.Text = "₱0.00";
            txtTotalAmount.Text = "₱0.00";

            try
            {
                int requestedAdults = (int)numAdults.Value;
                int requestedChildren = (int)numChildren.Value;
                walkInTimestamp = DateTime.Now;

                var availableRooms = roomController.GetAvailableRooms(walkInTimestamp, requestedAdults, requestedChildren);

                var displayList = availableRooms.Select(r => new
                {
                    r.RoomId,
                    r.TypeName,
                    r.RatePerAdult,
                    r.MaxAdults,
                    r.MaxChildren,
                    DisplayText = $"Room {r.RoomId} - {r.TypeName} (Max {r.MaxAdults}A / {r.MaxChildren}C) - ₱{r.RatePerAdult:N2}/adult"
                }).ToList();

                cmbAvailableRooms.DataSource = null;
                cmbAvailableRooms.DataSource = displayList;
                cmbAvailableRooms.DisplayMember = "DisplayText";
                cmbAvailableRooms.ValueMember = "RoomId";

                if (availableRooms.Count == 0 && (requestedAdults > 1 || requestedChildren > 0))
                {
                    lblErrorMsg.Text = "No single room fits this headcount. Opening 2-room setup...";
                    OpenMultiRoomDialog();
                    return;
                }

                lblErrorMsg.Text = availableRooms.Count == 0 ? "No rooms currently available." : "";
                UpdateTotalQuote();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = "Error loading available rooms: " + ex.Message;
            }
        }

        private void cmbAvailableRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalQuote();
        }

        private void UpdateTotalQuote()
        {
            int adults = (int)numAdults.Value;
            int nights = (int)numNights.Value;
            if (nights < 1) nights = 1;

            if (isMultiRoomMode)
            {
                int room1Adults = (adults + 1) / 2;
                int room2Adults = adults - room1Adults;
                decimal combined = ((room1Adults * multiRoom1Rate) + (room2Adults * multiRoom2Rate)) * nights;
                txtRateAdult.Text = $"₱{multiRoom1Rate:N2} / ₱{multiRoom2Rate:N2}";
                txtTotalAmount.Text = $"₱{combined:N2}";
                lblRoomStatusTransition.Text = $"Room: {multiRoom1Id}, and {multiRoom2Id} Statuses after check-in:";
                return;
            }

            if (cmbAvailableRooms.SelectedItem != null)
            {
                dynamic selectedRoom = cmbAvailableRooms.SelectedItem;
                decimal ratePerAdult = selectedRoom.RatePerAdult;
                int roomId = selectedRoom.RoomId;

                decimal baseTotal = reservationController.CalculateTotalQuote(ratePerAdult, adults);
                decimal total = baseTotal * nights;

                txtRateAdult.Text = $"₱{ratePerAdult:N2}";
                txtTotalAmount.Text = $"₱{total:N2}";
                lblRoomStatusTransition.Text = $"Room: {roomId} Status after check-in:";
            }
        }

        private void btnEditMultiRoom_Click(object sender, EventArgs e)
        {
            OpenMultiRoomDialog();
        }

        private void btnCompleteCheckIn_Click(object sender, EventArgs e)
        {
            if (activeGuest == null || activeGuest.GuestId <= 0)
            {
                MessageBox.Show("Please find or register a guest first before completing check-in.",
                                "Guest Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isMultiRoomMode && cmbAvailableRooms.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an available room for this walk-in stay.",
                                "Room Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isMultiRoomMode && (multiRoom1Id <= 0 || multiRoom2Id <= 0))
            {
                MessageBox.Show("Please select both rooms in the 2-room selection.",
                                "Rooms Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                walkInTimestamp = DateTime.Now;
                int nights = (int)numNights.Value;
                int totalHours = (24 * nights) - 2;
                DateTime expectedCheckOut = walkInTimestamp.AddHours(totalHours);
                int totalAdults = (int)numAdults.Value;
                int totalChildren = (int)numChildren.Value;

                string guestCode = string.IsNullOrWhiteSpace(activeGuest.GuestCode)
                    ? $"G-{activeGuest.GuestId:D4}"
                    : activeGuest.GuestCode;
                string guestDisplay = $"{activeGuest.FullName} ({activeGuest.ContactNo} • {guestCode})";

                string roomSummary = isMultiRoomMode
                    ? $"1st: {multiRoom1Summary}{Environment.NewLine}2nd: {multiRoom2Summary}"
                    : cmbAvailableRooms.Text;

                using (ReservationConfirmDialog confirmDialog = new ReservationConfirmDialog(
                    guestDisplay,
                    walkInTimestamp,
                    expectedCheckOut,
                    roomSummary,
                    totalAdults,
                    totalChildren,
                    nights,
                    txtTotalAmount.Text,
                    "Confirm Walk-In Check-In",
                    "Verify walk-in details to immediately assign room(s) as Occupied:",
                    "🛎️ Complete Walk-In Check-In"))
                {
                    if (confirmDialog.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }
                }

                bool savedSuccessfully;

                if (isMultiRoomMode)
                {
                    int room1Adults = (totalAdults + 1) / 2;
                    int room1Children = (totalChildren + 1) / 2;
                    int room2Adults = totalAdults - room1Adults;
                    int room2Children = totalChildren - room1Children;

                    var res1 = new ReservationModel
                    {
                        GuestId = activeGuest.GuestId,
                        RoomId = multiRoom1Id,
                        Adults = room1Adults,
                        Children = room1Children,
                        CheckInDateTime = walkInTimestamp,
                        ExpectedCheckOutDateTime = expectedCheckOut,
                        RatePerAdult = multiRoom1Rate,
                        TotalAmount = room1Adults * multiRoom1Rate * nights,
                        Status = "Occupied"
                    };

                    var res2 = new ReservationModel
                    {
                        GuestId = activeGuest.GuestId,
                        RoomId = multiRoom2Id,
                        Adults = room2Adults,
                        Children = room2Children,
                        CheckInDateTime = walkInTimestamp,
                        ExpectedCheckOutDateTime = expectedCheckOut,
                        RatePerAdult = multiRoom2Rate,
                        TotalAmount = room2Adults * multiRoom2Rate * nights,
                        Status = "Occupied"
                    };

                    int id1 = reservationController.CreateWalkInBooking(res1);
                    int id2 = reservationController.CreateWalkInBooking(res2);
                    savedSuccessfully = id1 > 0 && id2 > 0;
                }
                else
                {
                    dynamic selectedRoom = cmbAvailableRooms.SelectedItem;

                    var res = new ReservationModel
                    {
                        GuestId = activeGuest.GuestId,
                        RoomId = selectedRoom.RoomId,
                        Adults = totalAdults,
                        Children = totalChildren,
                        CheckInDateTime = walkInTimestamp,
                        ExpectedCheckOutDateTime = expectedCheckOut,
                        RatePerAdult = selectedRoom.RatePerAdult,
                        TotalAmount = (decimal)selectedRoom.RatePerAdult * totalAdults * nights,
                        Status = "Occupied"
                    };

                    savedSuccessfully = reservationController.CreateWalkInBooking(res) > 0;
                }

                if (savedSuccessfully)
                {
                    ResetGuestState();
                    ResetStayState();
                }
                else
                {
                    MessageBox.Show("Failed to complete walk-in check-in in the database. Please try again.",
                                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Walk-in check-in error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearStay_Click(object sender, EventArgs e)
        {
            ResetStayState();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetGuestState();
            ResetStayState();
        }
    }
}