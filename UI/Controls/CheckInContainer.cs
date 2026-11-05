using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class CheckInContainer : UserControl
    {
        public CheckInContainer()
        {
            InitializeComponent();

            // Load Walk-In Guest view by default when the container opens
            LoadWalkInView();
            SetActiveTabButton(btnWalkInGuest);
        }

        private void btnWalkInGuest_Click(object sender, EventArgs e)
        {
            LoadWalkInView();
            SetActiveTabButton(btnWalkInGuest);
        }

        private void btnArrivingReservation_Click(object sender, EventArgs e)
        {
            LoadArrivingView();
            SetActiveTabButton(btnArrivingReservation);
        }

        private void LoadWalkInView()
        {
            panelContainerContent.Controls.Clear();
            WalkInCheckIn walkInControl = new WalkInCheckIn
            {
                Dock = DockStyle.Fill
            };
            panelContainerContent.Controls.Add(walkInControl);
        }

        private void LoadArrivingView()
        {
            panelContainerContent.Controls.Clear();
            ArrivingReservation arrivingControl = new ArrivingReservation
            {
                Dock = DockStyle.Fill
            };
            panelContainerContent.Controls.Add(arrivingControl);
        }

        // Optional: Simple visual helper to indicate which sub-tab is active
        private void SetActiveTabButton(Button activeButton)
        {
            // Reset styles for both buttons
            btnWalkInGuest.BackColor = Color.FromArgb(240, 240, 240);
            btnWalkInGuest.ForeColor = Color.Black;
            btnArrivingReservation.BackColor = Color.FromArgb(240, 240, 240);
            btnArrivingReservation.ForeColor = Color.Black;

            // Highlight active button
            activeButton.BackColor = Color.FromArgb(0, 120, 215); // Windows Blue accent
            activeButton.ForeColor = Color.White;
        }
    }
}