using System;
using System.Windows.Forms;

namespace UI.Dialogs.Reservation
{
    public partial class ReservationConfirmDialog : Form
    {
        public ReservationConfirmDialog(
            string guestDisplay,
            DateTime checkIn,
            DateTime checkOut,
            string roomSummary,
            int adults,
            int children,
            int nights,
            string formattedTotal,
            string headerText = "Confirm New Reservation",
            string subtitleText = "Please review the booking summary before saving:",
            string confirmButtonText = "💾 Confirm && Save")
        {
            InitializeComponent();

            lblHeader.Text = headerText;
            lblSubtitle.Text = subtitleText;
            btnConfirmSave.Text = confirmButtonText;

            lblGuestValue.Text = guestDisplay;
            lblCheckInValue.Text = checkIn.ToString("MMM dd, yyyy  hh:mm tt");
            lblCheckOutValue.Text = checkOut.ToString("MMM dd, yyyy  hh:mm tt");
            lblRoomsValue.Text = roomSummary.Replace("\n", Environment.NewLine);
            lblGuestsValue.Text = $"{adults} Adult(s), {children} Child(ren) • {nights} Night(s)";
            lblTotalValue.Text = formattedTotal;
        }

        private void btnConfirmSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}