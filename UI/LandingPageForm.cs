using HotelReservation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UI.Controls;

namespace UI
{
    public partial class LandingPageForm : Form
    {
        private Label activeNavLabel = null;
        private readonly Dictionary<Label, int> restingTopPositions = new Dictionary<Label, int>();

        // Neutral monochrome shadow palette
        private readonly Color activeShadowBackColor = Color.FromArgb(232, 236, 241);
        private readonly Color activeTextColor = Color.FromArgb(30, 34, 38);
        private readonly Color inactiveTextColor = Color.FromArgb(95, 103, 112);

        public LandingPageForm()
        {
            InitializeComponent();
        }

        private void LandingPageForm_Load(object sender, EventArgs e)
        {
            RegisterNavLabels();
            SetActiveNav(lblHome);
            LoadUserContorl(new ReportsUserControl());
        }

        private void RegisterNavLabels()
        {
            Label[] navLabels =
            {
                lblHome,
                lblRoom,
                lblGuests,
                lblReservation,
                lblCheckIn,
                lblBilling,
                lblReceipt
            };

            foreach (Label lbl in navLabels)
            {
                if (lbl == null) continue;

                restingTopPositions[lbl] = lbl.Top;
                lbl.Cursor = Cursors.Hand;
                lbl.ForeColor = inactiveTextColor;
                lbl.BackColor = Color.Transparent;
            }
        }

        private void SetActiveNav(Label targetLabel)
        {
            if (targetLabel == null || activeNavLabel == targetLabel)
            {
                return;
            }

            // Reset all navigation labels to resting shadowless state
            foreach (var entry in restingTopPositions)
            {
                Label lbl = entry.Key;
                lbl.Top = entry.Value;
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = inactiveTextColor;
                lbl.Font = new Font(lbl.Font.FontFamily, lbl.Font.Size, FontStyle.Regular);
                lbl.Cursor = Cursors.Hand;
            }

            // Lift active label and apply subtle neutral shadow fill
            if (restingTopPositions.TryGetValue(targetLabel, out int baseTop))
            {
                targetLabel.Top = baseTop - 4;
            }

            targetLabel.BackColor = activeShadowBackColor;
            targetLabel.ForeColor = activeTextColor;
            targetLabel.Font = new Font(targetLabel.Font.FontFamily, targetLabel.Font.Size, FontStyle.Bold);
            targetLabel.Cursor = Cursors.Default;

            activeNavLabel = targetLabel;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void LoadUserContorl(UserControl uc)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            if (activeNavLabel == lblHome) return;
            SetActiveNav(lblHome);
            LoadUserContorl(new ReportsUserControl());
        }

        private void lblRoom_Click(object sender, EventArgs e)
        {
            if (activeNavLabel == lblRoom) return;
            SetActiveNav(lblRoom);
            LoadUserContorl(new RoomsUserControl());
        }

        private void lblGuests_Click(object sender, EventArgs e)
        {
            if (activeNavLabel == lblGuests) return;
            SetActiveNav(lblGuests);
            LoadUserContorl(new GuestDirectoryControl());
        }

        private void lblReservation_Click(object sender, EventArgs e)
        {
            if (activeNavLabel == lblReservation) return;
            SetActiveNav(lblReservation);
            LoadUserContorl(new ReservationControl());
        }

        private void lblCheckIn_Click(object sender, EventArgs e)
        {
            if (activeNavLabel == lblCheckIn) return;
            SetActiveNav(lblCheckIn);
            LoadUserContorl(new CheckInContainer());
        }

        private void lblBilling_Click(object sender, EventArgs e)
        {
            if (activeNavLabel == lblBilling) return;
            SetActiveNav(lblBilling);
            LoadUserContorl(new BillingUserControl());
        }

        private void lblReceipt_Click(object sender, EventArgs e)
        {
            if (activeNavLabel == lblReceipt) return;
            SetActiveNav(lblReceipt);
            LoadUserContorl(new ReceiptUserControl());
        }
    }
}