using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace UI.Dialogs.Reservation
{
    public partial class MultiRoomBookingDialog : Form
    {
        private bool hasPreviousSelection;
        private bool isBindingDropdowns = false;

        public class RoomOption
        {
            public int RoomId { get; set; }
            public decimal RatePerAdult { get; set; }
            public int MaxAdults { get; set; }
            public int MaxChildren { get; set; }
            public string DisplayText { get; set; }
        }

        private List<RoomOption> allAvailableRooms;

        public int SelectedRoom1Id { get; private set; }
        public string SelectedRoom1Text { get; private set; }
        public decimal Room1Rate { get; private set; }

        public int SelectedRoom2Id { get; private set; }
        public string SelectedRoom2Text { get; private set; }
        public decimal Room2Rate { get; private set; }

        public int FinalAdults { get; private set; }
        public int FinalChildren { get; private set; }
        public int FinalNights { get; private set; }
        public decimal CombinedTotal { get; private set; }

        public MultiRoomBookingDialog(
            List<RoomModel> availableRooms,
            int initialAdults,
            int initialChildren,
            int initialNights,
            bool hasPreviousSelection = false,
            int prevRoom1Id = 0,
            int prevRoom2Id = 0)
        {
            InitializeComponent();
            this.hasPreviousSelection = hasPreviousSelection;

            allAvailableRooms = availableRooms.Select(r => new RoomOption
            {
                RoomId = r.RoomId,
                RatePerAdult = r.RatePerAdult,
                MaxAdults = r.MaxAdults,
                MaxChildren = r.MaxChildren,
                DisplayText = $"Room {r.RoomId} - {r.TypeName} - ₱{r.RatePerAdult:N2}/adult"
            }).ToList();

            nudDialogAdults.ValueChanged += OnOccupancyChanged;
            nudDialogChildren.ValueChanged += OnOccupancyChanged;
            nudDialogNights.ValueChanged += OnNightsChanged;

            nudDialogAdults.Minimum = 2;
            nudDialogAdults.Value = Math.Min(16, Math.Max(2, initialAdults));
            nudDialogChildren.Value = Math.Min(8, Math.Max(0, initialChildren));
            nudDialogNights.Value = Math.Min(30, Math.Max(1, initialNights));

            RefreshFilteredRooms(prevRoom1Id, prevRoom2Id);
        }

        private void OnOccupancyChanged(object sender, EventArgs e)
        {
            if (isBindingDropdowns) return;
            RefreshFilteredRooms();
        }

        private void OnNightsChanged(object sender, EventArgs e)
        {
            if (isBindingDropdowns) return;
            UpdateCombinedTotal();
        }

        private bool CanPairFitOccupancy(RoomOption r1, RoomOption r2, int totalAdults, int totalChildren)
        {
            if (r1.RoomId == r2.RoomId) return false;

            // Combined capacity check across both selected rooms
            if (r1.MaxAdults + r2.MaxAdults < totalAdults) return false;
            if (r1.MaxChildren + r2.MaxChildren < totalChildren) return false;

            // Ensure the split fits inside each individual room's capacity
            int highAdults = (totalAdults + 1) / 2;
            int lowAdults = totalAdults - highAdults;
            bool adultsFit = (r1.MaxAdults >= highAdults && r2.MaxAdults >= lowAdults)
                          || (r1.MaxAdults >= lowAdults && r2.MaxAdults >= highAdults);

            int highChildren = (totalChildren + 1) / 2;
            int lowChildren = totalChildren - highChildren;
            bool childrenFit = (r1.MaxChildren >= highChildren && r2.MaxChildren >= lowChildren)
                            || (r1.MaxChildren >= lowChildren && r2.MaxChildren >= highChildren);

            return adultsFit && childrenFit;
        }

        private void RefreshFilteredRooms(int preferredRoom1Id = 0, int preferredRoom2Id = 0)
        {
            isBindingDropdowns = true;
            try
            {
                int totalAdults = (int)nudDialogAdults.Value;
                int totalChildren = (int)nudDialogChildren.Value;

                int currentR1Id = preferredRoom1Id > 0
                    ? preferredRoom1Id
                    : (cmbRoom1.SelectedItem is RoomOption cur1 ? cur1.RoomId : 0);

                int currentR2Id = preferredRoom2Id > 0
                    ? preferredRoom2Id
                    : (cmbRoom2.SelectedItem is RoomOption cur2 ? cur2.RoomId : 0);

                var validRoom1List = allAvailableRooms
                    .Where(r1 => allAvailableRooms.Any(r2 => CanPairFitOccupancy(r1, r2, totalAdults, totalChildren)))
                    .OrderBy(r => r.RoomId)
                    .ToList();

                cmbRoom1.DataSource = null;
                cmbRoom1.DataSource = validRoom1List;
                cmbRoom1.DisplayMember = "DisplayText";
                cmbRoom1.ValueMember = "RoomId";

                if (validRoom1List.Count > 0)
                {
                    if (validRoom1List.Any(r => r.RoomId == currentR1Id))
                        cmbRoom1.SelectedValue = currentR1Id;
                    else
                        cmbRoom1.SelectedIndex = 0;
                }

                BindRoom2ForSelectedRoom1(currentR2Id);
            }
            finally
            {
                isBindingDropdowns = false;
            }

            UpdateCombinedTotal();
        }

        private void BindRoom2ForSelectedRoom1(int preferredRoom2Id = 0)
        {
            int totalAdults = (int)nudDialogAdults.Value;
            int totalChildren = (int)nudDialogChildren.Value;

            if (cmbRoom1.SelectedItem is RoomOption selected1)
            {
                var validRoom2List = allAvailableRooms
                    .Where(r2 => CanPairFitOccupancy(selected1, r2, totalAdults, totalChildren))
                    .OrderBy(r => r.RoomId)
                    .ToList();

                cmbRoom2.DataSource = null;
                cmbRoom2.DataSource = validRoom2List;
                cmbRoom2.DisplayMember = "DisplayText";
                cmbRoom2.ValueMember = "RoomId";

                if (validRoom2List.Count > 0)
                {
                    if (validRoom2List.Any(r => r.RoomId == preferredRoom2Id))
                        cmbRoom2.SelectedValue = preferredRoom2Id;
                    else
                        cmbRoom2.SelectedIndex = 0;
                }
            }
            else
            {
                cmbRoom2.DataSource = null;
            }
        }

        private void cmbRoom1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isBindingDropdowns) return;

            int prevR2 = cmbRoom2.SelectedItem is RoomOption cur2 ? cur2.RoomId : 0;
            isBindingDropdowns = true;
            try
            {
                BindRoom2ForSelectedRoom1(prevR2);
            }
            finally
            {
                isBindingDropdowns = false;
            }

            UpdateCombinedTotal();
        }

        private void RecalculateDialogTotal(object sender, EventArgs e)
        {
            if (isBindingDropdowns) return;
            UpdateCombinedTotal();
        }

        private void UpdateCombinedTotal()
        {
            if (cmbRoom1.SelectedItem is RoomOption r1 && cmbRoom2.SelectedItem is RoomOption r2)
            {
                int totalAdults = (int)nudDialogAdults.Value;
                int nights = (int)nudDialogNights.Value;

                int room1Adults = (totalAdults + 1) / 2;
                int room2Adults = totalAdults - room1Adults;

                decimal total = ((room1Adults * r1.RatePerAdult) + (room2Adults * r2.RatePerAdult)) * nights;
                lblDialogTotal.Text = $"₱{total:N2}";
                btnSave.Enabled = true;
            }
            else
            {
                lblDialogTotal.Text = "₱0.00";
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(cmbRoom1.SelectedItem is RoomOption r1) || !(cmbRoom2.SelectedItem is RoomOption r2))
            {
                MessageBox.Show("No valid 2-room combination can accommodate this number of adults and children.",
                                "Capacity Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalAdults = (int)nudDialogAdults.Value;
            int totalChildren = (int)nudDialogChildren.Value;

            if (totalAdults < 2)
            {
                MessageBox.Show("Booking 2 rooms requires at least 2 adults (minimum 1 adult per room).",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CanPairFitOccupancy(r1, r2, totalAdults, totalChildren))
            {
                MessageBox.Show("Selected rooms cannot accommodate the entered number of adults and children.",
                                "Capacity Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nights = (int)nudDialogNights.Value;
            int room1Adults = (totalAdults + 1) / 2;
            int room2Adults = totalAdults - room1Adults;

            SelectedRoom1Id = r1.RoomId;
            SelectedRoom1Text = r1.DisplayText;
            Room1Rate = r1.RatePerAdult;

            SelectedRoom2Id = r2.RoomId;
            SelectedRoom2Text = r2.DisplayText;
            Room2Rate = r2.RatePerAdult;

            FinalAdults = totalAdults;
            FinalChildren = totalChildren;
            FinalNights = nights;
            CombinedTotal = ((room1Adults * r1.RatePerAdult) + (room2Adults * r2.RatePerAdult)) * nights;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (hasPreviousSelection)
            {
                DialogResult choice = MessageBox.Show(
                    "Keep your previous 2-room selection?\n\n" +
                    "• Yes = Save the last reservation choice\n" +
                    "• No = Don't save last reservation (reset to startup)",
                    "Back Options",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (choice == DialogResult.Yes)
                {
                    DialogResult = DialogResult.Ignore;
                    Close();
                    return;
                }
            }

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}