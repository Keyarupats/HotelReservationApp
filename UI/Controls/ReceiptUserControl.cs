using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Repository;

namespace UI.Controls
{
    public partial class ReceiptUserControl : UserControl
    {
        private const int ReceiptWidth = 44;
        private const string HotelName = "GRAND HOTEL & SUITES INC.";
        private const string HotelAddress = "123 Hospitality Ave., Calamba, Laguna";

        private readonly BillingRepository billingRepo = new BillingRepository();
        private readonly PrintDocument printDocument = new PrintDocument();
        private List<ReceiptData> receipts = new List<ReceiptData>();
        private bool suppressEvents;

        private class ReceiptLine
        {
            public string Description;
            public int Quantity;
            public decimal Amount;
        }

        private class ReceiptData
        {
            public string ReceiptNo;
            public DateTime PaidAt;
            public string GuestName;
            public string Room;
            public DateTime CheckIn;
            public DateTime CheckOut;
            public List<ReceiptLine> Lines = new List<ReceiptLine>();
            public decimal SubTotal;
            public decimal VatAmount;
            public decimal Total;
            public string PaymentMethod;
            public decimal Tendered;
            public decimal Change;
            public string ReferenceNumber;
            public override string ToString() { return ReceiptNo + " - " + GuestName; }
        }

        public ReceiptUserControl()
        {
            InitializeComponent();
            StyleGrid(dgvPayments);
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void ReceiptUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            LoadReceipts();
        }

        public void LoadReceipts()
        {
            try
            {
                DataTable dt = billingRepo.GetCompletedTransactionsRaw();
                receipts = new List<ReceiptData>();

                foreach (DataRow row in dt.Rows)
                {
                    ReceiptData r = new ReceiptData();
                    r.ReceiptNo = "RES-" + Convert.ToInt32(row["ReservationId"]).ToString("D4");
                    r.PaidAt = row["ActualCheckOutDateTime"] != DBNull.Value ? Convert.ToDateTime(row["ActualCheckOutDateTime"]) : DateTime.Now;
                    r.GuestName = row["GuestName"].ToString();
                    r.Room = "Room " + row["RoomId"].ToString();
                    r.CheckIn = Convert.ToDateTime(row["CheckInDateTime"]);
                    r.CheckOut = r.PaidAt;

                    decimal roomCharge = Convert.ToDecimal(row["RoomCharge"]);
                    decimal overstayCharge = Convert.ToDecimal(row["OverstayCharge"]);
                    decimal foodCharge = Convert.ToDecimal(row["FoodCharge"]);

                    if (roomCharge > 0)
                        r.Lines.Add(new ReceiptLine { Description = "Room Accommodation", Quantity = 1, Amount = roomCharge });
                    if (overstayCharge > 0)
                        r.Lines.Add(new ReceiptLine { Description = "Overstay Fee", Quantity = 1, Amount = overstayCharge });
                    if (foodCharge > 0)
                        r.Lines.Add(new ReceiptLine { Description = "Food & Service Add-ons", Quantity = 1, Amount = foodCharge });

                    r.SubTotal = roomCharge + overstayCharge + foodCharge;
                    r.VatAmount = Math.Round(r.SubTotal * 0.12m, 2);
                    r.Total = r.SubTotal + r.VatAmount;

                    r.PaymentMethod = row["PaymentMethod"].ToString();
                    r.Tendered = row["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(row["AmountPaid"]) : r.Total;
                    r.Change = row["ChangeDue"] != DBNull.Value ? Convert.ToDecimal(row["ChangeDue"]) : 0m;
                    r.ReferenceNumber = row["PaymentReference"] != DBNull.Value ? row["PaymentReference"].ToString() : "";

                    receipts.Add(r);
                }

                DataTable table = new DataTable();
                table.Columns.Add("Receipt", typeof(string));
                table.Columns.Add("Guest", typeof(string));
                table.Columns.Add("Room", typeof(string));
                table.Columns.Add("Total", typeof(string));

                foreach (ReceiptData r in receipts)
                {
                    table.Rows.Add(r.ReceiptNo, r.GuestName, r.Room, "₱" + r.Total.ToString("N2"));
                }

                suppressEvents = true;
                dgvPayments.DataSource = table;
                cmbPayment.DataSource = null;
                cmbPayment.DataSource = receipts;
                suppressEvents = false;

                if (receipts.Count > 0)
                {
                    ShowReceipt(0);
                }
                else
                {
                    txtReceiptPreview.Text = "No completed check-out transactions found.";
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error loading history: " + ex.Message;
            }
        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressEvents || cmbPayment.SelectedIndex < 0) return;
            ShowReceipt(cmbPayment.SelectedIndex);
        }

        private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (suppressEvents || e.RowIndex < 0) return;
            ShowReceipt(e.RowIndex);
        }

        private void ShowReceipt(int index)
        {
            if (index < 0 || index >= receipts.Count) return;

            suppressEvents = true;
            cmbPayment.SelectedIndex = index;
            if (dgvPayments.Rows.Count > index)
            {
                dgvPayments.ClearSelection();
                dgvPayments.Rows[index].Selected = true;
            }
            suppressEvents = false;

            lblErrorMessage.Text = "";

            txtReceiptPreview.Clear();
            BuildRichReceipt(receipts[index]);
        }

        private void BuildRichReceipt(ReceiptData r)
        {
            txtReceiptPreview.Font = new Font("Consolas", 10.5F, FontStyle.Regular);
            string equals = new string('=', ReceiptWidth);
            string dashes = new string('-', ReceiptWidth);

            AppendCentered("\n" + equals + "\n");
            AppendCentered(HotelName + "\n");
            AppendCentered(HotelAddress + "\n");
            AppendCentered(equals + "\n\n");

            // Meta Info
            AppendLeft("VAT REG TIN  : 211-298-185-0000\n");
            AppendLeft("Terminal S/N : HOTEL-POS22-0925221805\n");
            AppendLeft("Terminal SPM : SP062021-048-0092\n");
            AppendLeft("AR No.       : " + r.ReceiptNo.Replace("RES-", "AR-2026-") + "\n");
            AppendLeft("Date & Time  : " + r.PaidAt.ToString("yyyy-MM-dd HH:mm:ss") + "\n\n");

            AppendCentered(dashes + "\n");
            AppendCentered("*** ACKNOWLEDGMENT RECEIPT ***\n");
            AppendCentered(dashes + "\n\n");

            // Guest & Stay Info
            AppendLeft("Guest Name   : " + r.GuestName + "\n");
            AppendLeft("Room Assigned: " + r.Room + "\n");
            AppendLeft("Check-In     : " + r.CheckIn.ToString("yyyy-MM-dd HH:mm") + "\n");
            AppendLeft("Check-Out    : " + r.CheckOut.ToString("yyyy-MM-dd HH:mm") + "\n\n");

            AppendCentered(dashes + "\n");
            AppendLeft("DESCRIPTION".PadRight(26) + "QTY".PadLeft(5) + "AMOUNT".PadLeft(13) + "\n");
            AppendCentered(dashes + "\n");

            foreach (ReceiptLine line in r.Lines)
            {
                string desc = line.Description.Length > 26 ? line.Description.Substring(0, 26) : line.Description;
                AppendLeft(desc.PadRight(26) + line.Quantity.ToString().PadLeft(5) + line.Amount.ToString("N2").PadLeft(13) + "\n");
            }

            AppendCentered("\n" + dashes + "\n");
            AppendLeft(TwoColumn("SUBTOTAL (VAT-Excl.)", "PHP " + r.SubTotal.ToString("N2")) + "\n");
            AppendLeft(TwoColumn("VATable Sales", "PHP " + r.SubTotal.ToString("N2")) + "\n");
            AppendLeft(TwoColumn("VAT Amount (12%)", "PHP " + r.VatAmount.ToString("N2")) + "\n");
            AppendLeft(TwoColumn("VAT-Exempt / Zero", "PHP 0.00") + "\n");
            AppendCentered(dashes + "\n\n");

            AppendLeft(TwoColumn("GRAND TOTAL", "PHP " + r.Total.ToString("N2")) + "\n\n");
            AppendLeft(TwoColumn("PAYMENT METHOD", r.PaymentMethod) + "\n");

            if (r.PaymentMethod == "Cash")
            {
                AppendLeft(TwoColumn("CASH TENDERED", "PHP " + r.Tendered.ToString("N2")) + "\n");
                AppendLeft(TwoColumn("CHANGE DUE", "PHP " + r.Change.ToString("N2")) + "\n");
            }
            else
            {
                AppendLeft(TwoColumn("REFERENCE NO", r.ReferenceNumber ?? "") + "\n");
            }

            AppendCentered("\n" + dashes + "\n\n");
            AppendCentered("*** THIS DOCUMENT IS NOT VALID FOR CLAIM OF INPUT TAX ***\n\n");
            AppendCentered("[ PAID IN FULL ]\n");
            AppendCentered("Thank you for staying with us!\n\n");
            AppendCentered(equals + "\n\n");
        }

        private void AppendCentered(string text)
        {
            int start = txtReceiptPreview.TextLength;
            txtReceiptPreview.AppendText(text);
            txtReceiptPreview.Select(start, text.Length);
            txtReceiptPreview.SelectionIndent = 0;
            txtReceiptPreview.SelectionAlignment = HorizontalAlignment.Center;
            txtReceiptPreview.DeselectAll();
        }

        private void AppendLeft(string text)
        {
            int start = txtReceiptPreview.TextLength;
            txtReceiptPreview.AppendText(text);
            txtReceiptPreview.Select(start, text.Length);
            txtReceiptPreview.SelectionIndent = 85; // Aligns left text with the centered 44-char dividers
            txtReceiptPreview.SelectionAlignment = HorizontalAlignment.Left;
            txtReceiptPreview.DeselectAll();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            if (string.IsNullOrWhiteSpace(txtReceiptPreview.Text))
            {
                lblErrorMessage.Text = "Select a completed transaction first.";
                return;
            }

            using (PrintDialog dialog = new PrintDialog())
            {
                dialog.Document = printDocument;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Font printFont = new Font("Consolas", 10F))
            {
                e.Graphics.DrawString(txtReceiptPreview.Text, printFont, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top);
            }
            e.HasMorePages = false;
        }

        private string BuildReceiptText(ReceiptData r)
        {
            StringBuilder sb = new StringBuilder();
            string equals = new string('=', ReceiptWidth);
            string dashes = new string('-', ReceiptWidth);

            sb.AppendLine(equals);
            sb.AppendLine(Center(HotelName));
            sb.AppendLine(Center(HotelAddress));
            sb.AppendLine(equals);
            sb.AppendLine("VAT REG TIN: 211-298-185-0000");
            sb.AppendLine("Terminal S/N : HOTEL-POS22-0925221805");
            sb.AppendLine("Terminal SPM : SP062021-048-0092");
            sb.AppendLine("AR No.       : " + r.ReceiptNo.Replace("RES-", "AR-2026-"));
            sb.AppendLine("Date & Time  : " + r.PaidAt.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendLine(dashes);
            sb.AppendLine(Center("*** ACKNOWLEDGMENT RECEIPT ***"));
            sb.AppendLine(dashes);
            sb.AppendLine("Guest Name   : " + r.GuestName);
            sb.AppendLine("Room Assigned: " + r.Room);
            sb.AppendLine("Check-In     : " + r.CheckIn.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine("Check-Out    : " + r.CheckOut.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine(dashes);
            sb.AppendLine("DESCRIPTION".PadRight(26) + "QTY".PadLeft(5) + "AMOUNT".PadLeft(13));

            foreach (ReceiptLine line in r.Lines)
            {
                string desc = line.Description.Length > 26 ? line.Description.Substring(0, 26) : line.Description;
                sb.AppendLine(desc.PadRight(26) + line.Quantity.ToString().PadLeft(5) + line.Amount.ToString("N2").PadLeft(13));
            }

            sb.AppendLine(dashes);
            sb.AppendLine(TwoColumn("SUBTOTAL (VAT-Excl.)", "PHP " + r.SubTotal.ToString("N2")));
            sb.AppendLine(TwoColumn("VATable Sales", "PHP " + r.SubTotal.ToString("N2")));
            sb.AppendLine(TwoColumn("VAT Amount (12%)", "PHP " + r.VatAmount.ToString("N2")));
            sb.AppendLine(TwoColumn("VAT-Exempt / Zero", "PHP 0.00"));
            sb.AppendLine(dashes);
            sb.AppendLine(TwoColumn("GRAND TOTAL", "PHP " + r.Total.ToString("N2")));
            sb.AppendLine(TwoColumn("PAYMENT METHOD", r.PaymentMethod));

            if (r.PaymentMethod == "Cash")
            {
                sb.AppendLine(TwoColumn("CASH TENDERED", "PHP " + r.Tendered.ToString("N2")));
                sb.AppendLine(TwoColumn("CHANGE DUE", "PHP " + r.Change.ToString("N2")));
            }
            else
            {
                sb.AppendLine(TwoColumn("REFERENCE NO", r.ReferenceNumber ?? ""));
            }

            sb.AppendLine(dashes);
            sb.AppendLine(Center("*** THIS DOCUMENT IS NOT VALID FOR CLAIM OF INPUT TAX ***"));
            sb.AppendLine(Center("[ PAID IN FULL ]"));
            sb.AppendLine(Center("Thank you for staying with us!"));
            sb.AppendLine(equals);

            return sb.ToString();
        }

        private static string Center(string text)
        {
            if (text.Length >= ReceiptWidth) return text;
            int left = (ReceiptWidth - text.Length) / 2;
            return new string(' ', left) + text;
        }

        private static string TwoColumn(string left, string right)
        {
            int space = ReceiptWidth - left.Length - right.Length;
            if (space < 1) space = 1;
            return left + new string(' ', space) + right;
        }

        private static void StyleGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 36;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(44, 62, 80);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            grid.RowTemplate.Height = 34;
        }
    }
}