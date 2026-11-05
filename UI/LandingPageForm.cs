using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UI.Controls;

namespace UI
{
    public partial class LandingPageForm : Form
    {
        public LandingPageForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void lblRoom_Click(object sender, EventArgs e)
        {
            LoadUserContorl(new RoomsUserControl());
        }

        private void LandingPageForm_Load(object sender, EventArgs e)
        {
            LoadUserContorl(new RoomsUserControl());

        }

        private void LoadUserContorl(UserControl uc)
        {
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void lblGuests_Click(object sender, EventArgs e)
        {
            LoadUserContorl(new GuestDirectoryControl());
        }

        private void lblReservation_Click(object sender, EventArgs e)
        {
            LoadUserContorl(new ReservationControl());
        }

        private void lblCheckIn_Click(object sender, EventArgs e)
        {
            LoadUserContorl(new CheckInContainer());
        }

        private void lblBilling_Click(object sender, EventArgs e)
        {
            BillingUserControl billingControl = new BillingUserControl();

            billingControl.ProceedToPaymentRequested += (sender, e) =>
            {
                ShowPaymentScreen(e.ReservationId, e.GrandTotal);
            };

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(billingControl);
            billingControl.Dock = DockStyle.Fill;
        }

        public void ShowPaymentScreen(int reservationId, decimal grandTotal)
        {
            PaymentUserControl paymentControl = new PaymentUserControl();

            paymentControl.SetStay(
                reservationId,
                "Guest Name",  
                "Room Info",   
                DateTime.Now.ToString("MMM dd, yyyy hh:mm tt"),
                DateTime.Now.AddHours(22).ToString("MMM dd, yyyy hh:mm tt"),
                "1 Guest",
                grandTotal
            );

            paymentControl.BackToBillRequested += (s, args) =>
            {
                pnlContent.Controls.Clear();
                BillingUserControl billing = new BillingUserControl();
                pnlContent.Controls.Add(billing);
                billing.Dock = DockStyle.Fill;
            };

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(paymentControl);
            paymentControl.Dock = DockStyle.Fill;
        }
    }
}
