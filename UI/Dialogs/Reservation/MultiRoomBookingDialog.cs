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
        public class RoomOption
        {
            public int RoomId { get; set; }
            public decimal RatePerAdult { get; set; }
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
                DisplayText = $"Room {r.RoomId} - {r.TypeName} (₱{r.RatePerAdult:N2}/adult)"
            }).ToList();

            nudDialogAdults.Value = Math.Min(16, Math.Max(1, initialAdults));
            nudDialogChildren.Value = Math.Min(8, Math.Max(0, initialChildren));
            nudDialogNights.Value = Math.Min(30, Math.Max(1, initialNights));

            BindRoom1();

            if (prevRoom1Id > 0)
            {
                cmbRoom1.SelectedValue = prevRoom1Id;
            }
            if (prevRoom2Id > 0)
            {
                cmbRoom2.SelectedValue = prevRoom2Id;
            }
        }



        private void BindRoom1()
        {
            cmbRoom1.DataSource = null;
            cmbRoom1.DataSource = allAvailableRooms.ToList();
            cmbRoom1.DisplayMember = "DisplayText";
            cmbRoom1.ValueMember = "RoomId";
        }

        private void cmbRoom1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoom1.SelectedItem is RoomOption selected1)
            {
                var remainingRooms = allAvailableRooms
                    .Where(r => r.RoomId != selected1.RoomId)
                    .ToList();

                cmbRoom2.DataSource = null;
                cmbRoom2.DataSource = remainingRooms;
                cmbRoom2.DisplayMember = "DisplayText";
                cmbRoom2.ValueMember = "RoomId";
            }

            RecalculateDialogTotal(null, EventArgs.Empty);
        }

        private void RecalculateDialogTotal(object sender, EventArgs e)
        {
            if (cmbRoom1.SelectedItem is RoomOption r1 && cmbRoom2.SelectedItem is RoomOption r2)
            {
                int totalAdults = (int)nudDialogAdults.Value;
                int nights = (int)nudDialogNights.Value;

                int room1Adults = (totalAdults + 1) / 2;
                int room2Adults = totalAdults - room1Adults;

                decimal total = ((room1Adults * r1.RatePerAdult) + (room2Adults * r2.RatePerAdult)) * nights;
                lblDialogTotal.Text = $"₱{total:N2}";
            }
            else
            {
                lblDialogTotal.Text = "₱0.00";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(cmbRoom1.SelectedItem is RoomOption r1) || !(cmbRoom2.SelectedItem is RoomOption r2))
            {
                MessageBox.Show("Please select two different rooms.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int totalAdults = (int)nudDialogAdults.Value;
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
            FinalChildren = (int)nudDialogChildren.Value;
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