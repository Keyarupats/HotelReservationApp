using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Controller;
using Model;

namespace UI
{
    public partial class PaymentUserControl : UserControl
    {
        private readonly BillingController billingController = new BillingController();

        public event EventHandler BackToBillRequested;
        public event EventHandler CheckoutCompleted;

        private CheckoutSettlementModel currentSettlement;

        public PaymentUserControl()
        {
            InitializeComponent();
        }

        private void PaymentUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            ApplyMethodState();
        }

        public void LoadSettlement(CheckoutSettlementModel settlement)
        {
            currentSettlement = settlement;

            txtGuestName.Text = settlement.GuestName;
            txtRoom.Text = settlement.RoomDisplay;
            txtCheckIn.Text = settlement.CheckInText;
            txtCheckOut.Text = settlement.CheckOutText;
            txtGuests.Text = settlement.GuestsText;
            lblTotalDueValue.Text = Peso(settlement.GrandTotal);

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
            if (currentSettlement == null) return;

            if (TryParseMoney(txtCashTendered.Text, out decimal tendered))
            {
                decimal change = tendered - currentSettlement.GrandTotal;
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

            if (currentSettlement == null)
            {
                lblErrorMessage.Text = "No stay summary loaded.";
                return;
            }

            if (rdoCash.Checked)
            {
                if (!TryParseMoney(txtCashTendered.Text, out decimal tendered))
                {
                    lblErrorMessage.Text = "Enter the cash tendered amount.";
                    txtCashTendered.Focus();
                    return;
                }

                if (tendered < currentSettlement.GrandTotal)
                {
                    lblErrorMessage.Text = "Cash tendered is less than the total amount due.";
                    txtCashTendered.Focus();
                    return;
                }
                currentSettlement.PaymentMethod = "Cash";
                currentSettlement.CashTendered = tendered;
                currentSettlement.ChangeDue = tendered - currentSettlement.GrandTotal;
                currentSettlement.ReferenceNumber = null;
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
                currentSettlement.PaymentMethod = "Card/e-Wallet (QR)";
                currentSettlement.ReferenceNumber = reference;
                currentSettlement.CashTendered = currentSettlement.GrandTotal;
                currentSettlement.ChangeDue = 0m;
            }

            try
            {
                bool success = billingController.CompleteCheckout(currentSettlement);
                if (success)
                {
                    MessageBox.Show(
                        $"Check-out settled for {currentSettlement.GuestName}!\n" +
                        $"Total Paid: {Peso(currentSettlement.GrandTotal)}\n" +
                        $"Change Due: {Peso(currentSettlement.ChangeDue)}\n" +
                        $"Room(s) {currentSettlement.RoomDisplay} marked as Cleaning.",
                        "Check-Out Complete",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CheckoutCompleted?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    lblErrorMessage.Text = "Failed to settle check-out in the database.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error settling payment: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackToBill_Click(object sender, EventArgs e)
        {
            BackToBillRequested?.Invoke(this, EventArgs.Empty);
        }

        private static bool TryParseMoney(string text, out decimal value)
        {
            string cleaned = text.Replace("₱", "").Replace(",", "").Trim();
            return decimal.TryParse(cleaned, NumberStyles.Number, CultureInfo.InvariantCulture, out value) && value >= 0;
        }

        private static string Peso(decimal value) => "₱" + value.ToString("N2");

        private void txtReferenceNumber_TextChanged(object sender, EventArgs e)
        {
            if (rdoCash.Checked) return;

            string reference = txtReferenceNumber.Text.Trim();
            bool isValidLength = reference.Length == 16;

            if (isValidLength)
            {
                txtReferenceNumber.ForeColor = Color.Blue;
                btnSettlePayment.Enabled = true;
                btnSettlePayment.BackColor = Color.FromArgb(40, 167, 69); 
                lblErrorMessage.Text = "";
            }
            else
            {
                txtReferenceNumber.ForeColor = Color.Red;
                btnSettlePayment.Enabled = false;
                btnSettlePayment.BackColor = Color.Gray; 
                lblErrorMessage.Text = "Reference number must be exactly 16 characters.";
            }
        }
    }
}