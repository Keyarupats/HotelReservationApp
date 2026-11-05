using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace UI
{
    public partial class PaymentUserControl : UserControl
    {
        // TODO: set to false once the BillingController (SettlePayment / complete check-out) is connected
        private static readonly bool DemoMode = true;

        // The main form subscribes to these to call the controller and to move between screens
        public event EventHandler<PaymentRequestEventArgs> SettleRequested;
        public event EventHandler BackToBillRequested;

        private int reservationId;
        private decimal totalDue;

        public PaymentUserControl()
        {
            InitializeComponent();
        }

        private void PaymentUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            ApplyMethodState();

            if (DemoMode && reservationId == 0)
            {
                SetStay(7, "Carlo Mendoza", "1001 - Economy", "Oct 29, 2026  02:10 PM", "Oct 30, 2026  02:40 PM", "2 adults, 1 child", 3820m);
            }
        }

        // Call this from the main form after the Billing screen raises ProceedToPaymentRequested
        public void SetStay(int reservationId, string guestName, string room, string checkIn, string checkOut, string guests, decimal totalDue)
        {
            this.reservationId = reservationId;
            this.totalDue = totalDue;

            txtGuestName.Text = guestName;
            txtRoom.Text = room;
            txtCheckIn.Text = checkIn;
            txtCheckOut.Text = checkOut;
            txtGuests.Text = guests;
            lblTotalDueValue.Text = Peso(totalDue);

            rdoCash.Checked = true;
            txtCashTendered.Clear();
            txtReferenceNumber.Clear();
            txtChangeDue.Clear();
            lblErrorMessage.Text = "";
        }

        private void PaymentMethod_CheckedChanged(object sender, EventArgs e)
        {
            ApplyMethodState();
        }

        private void ApplyMethodState()
        {
            bool isCash = rdoCash.Checked;

            txtCashTendered.Enabled = isCash;
            txtChangeDue.Enabled = isCash;
            txtReferenceNumber.Enabled = !isCash;

            if (isCash)
            {
                txtReferenceNumber.Clear();
                lblReference.ForeColor = Color.Gray;
                lblCashTendered.ForeColor = Color.FromArgb(44, 62, 80);
            }
            else
            {
                txtCashTendered.Clear();
                txtChangeDue.Clear();
                lblReference.ForeColor = Color.FromArgb(44, 62, 80);
                lblCashTendered.ForeColor = Color.Gray;
            }

            lblErrorMessage.Text = "";
        }

        private void txtCashTendered_TextChanged(object sender, EventArgs e)
        {
            decimal tendered;
            if (TryParseMoney(txtCashTendered.Text, out tendered))
            {
                decimal change = tendered - totalDue;
                if (change >= 0)
                {
                    txtChangeDue.Text = Peso(change);
                    txtChangeDue.ForeColor = Color.Green;
                }
                else
                {
                    txtChangeDue.Text = "Not enough";
                    txtChangeDue.ForeColor = Color.Red;
                }
            }
            else
            {
                txtChangeDue.Clear();
            }
        }

        private void btnSettlePayment_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            PaymentRequestEventArgs args = new PaymentRequestEventArgs();
            args.ReservationId = reservationId;
            args.AmountDue = totalDue;

            if (rdoCash.Checked)
            {
                decimal tendered;
                if (TryParseMoney(txtCashTendered.Text, out tendered) == false)
                {
                    lblErrorMessage.Text = "Enter the cash tendered amount.";
                    txtCashTendered.Focus();
                    return;
                }

                if (tendered < totalDue)
                {
                    lblErrorMessage.Text = "Cash tendered is less than the total amount due.";
                    txtCashTendered.Focus();
                    return;
                }

                args.PaymentMethod = "Cash";
                args.CashTendered = tendered;
            }
            else
            {
                string reference = txtReferenceNumber.Text.Trim();
                if (reference.Length < 6)
                {
                    lblErrorMessage.Text = "Enter the card or QR reference number (at least 6 characters).";
                    txtReferenceNumber.Focus();
                    return;
                }

                args.PaymentMethod = "Card / QR";
                args.ReferenceNumber = reference;
                args.CashTendered = totalDue;
            }

            if (SettleRequested == null)
            {
                MessageBox.Show("Nothing was saved. The payment is not connected yet.\nSubscribe to SettleRequested in the main form and call the controller.",
                                "Not connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SettleRequested(this, args);
        }

        private void btnBackToBill_Click(object sender, EventArgs e)
        {
            if (BackToBillRequested != null)
            {
                BackToBillRequested(this, EventArgs.Empty);
            }
        }

        private static bool TryParseMoney(string text, out decimal value)
        {
            string cleaned = text.Replace("₱", "").Replace(",", "").Trim();
            return decimal.TryParse(cleaned, NumberStyles.Number, CultureInfo.InvariantCulture, out value) && value >= 0;
        }

        private static string Peso(decimal value)
        {
            return "₱" + value.ToString("N2");
        }
    }

    public class PaymentRequestEventArgs : EventArgs
    {
        public int ReservationId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal AmountDue { get; set; }
        public decimal CashTendered { get; set; }
        public string ReferenceNumber { get; set; }
    }
}