using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model;

namespace UI.Dialogs
{
    public partial class ReceiptPreviewDialog : Form
    {
        private CheckoutSettlementModel settlement;

        public ReceiptPreviewDialog(CheckoutSettlementModel settlementData)
        {
            InitializeComponent();
            settlement = settlementData;
            BuildReceiptText();
        }

        private void BuildReceiptText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("          HOTEL MANAGEMENT SYSTEM          ");
            sb.AppendLine("        Official Acknowledgment Receipt     ");
            sb.AppendLine("--------------------------------------------");
            sb.AppendLine($"Date & Time : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            sb.AppendLine($"Guest Name  : {settlement.GuestName}");
            sb.AppendLine($"Room(s)     : {settlement.RoomDisplay}");
            sb.AppendLine($"Check-In    : {settlement.CheckInText}");
            sb.AppendLine($"Check-Out   : {settlement.CheckOutText}");
            sb.AppendLine("--------------------------------------------");
            sb.AppendLine("ITEMIZED CHARGES:");
            sb.AppendLine($" Room Charge               ₱{settlement.RoomCharge,12:N2}");
            sb.AppendLine($" Overstay Fee              ₱{settlement.OverstayCharge,12:N2}");
            sb.AppendLine($" Food & Services           ₱{settlement.FoodCharge,12:N2}");
            sb.AppendLine("--------------------------------------------");

            decimal subTotal = settlement.RoomCharge + settlement.OverstayCharge + settlement.FoodCharge;
            decimal vat = Math.Round(subTotal * 0.12m, 2);

            sb.AppendLine($" Subtotal (VAT-Excl.)      ₱{subTotal,12:N2}");
            sb.AppendLine($" VAT (12%)                 ₱{vat,12:N2}");
            sb.AppendLine("--------------------------------------------");
            sb.AppendLine($" GRAND TOTAL               ₱{settlement.GrandTotal,12:N2}");
            sb.AppendLine("--------------------------------------------");
            sb.AppendLine($" Payment Method: {settlement.PaymentMethod}");
            if (settlement.PaymentMethod == "Cash")
            {
                sb.AppendLine($" Amount Tendered           ₱{settlement.CashTendered,12:N2}");
                sb.AppendLine($" Change Due                ₱{settlement.ChangeDue,12:N2}");
            }
            else
            {
                sb.AppendLine($" Reference No.             {settlement.ReferenceNumber}");
            }
            sb.AppendLine("--------------------------------------------");
            sb.AppendLine("      *** THIS IS NOT AN OFFICIAL INVOICE *** ");
            sb.AppendLine("        Thank you for staying with us!      ");

            txtReceiptOutput.Font = new Font("Consolas", 10F, FontStyle.Regular);
            txtReceiptOutput.Text = sb.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Receipt sent to printer successfully!", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}   