using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class ReceiptUserControl : UserControl
    {
        // TODO: set to false and delete the demo data once the controller returns completed payments
        private static readonly bool DemoMode = true;

        private const int ReceiptWidth = 44;
        private const string HotelName = "GRAND HOTEL & SUITES INC.";
        private const string HotelAddress = "123 Hospitality Ave., Calamba, Laguna";

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
            if (DesignMode)
            {
                return;
            }

            LoadReceipts();
        }

        // ---------------------------------------------------------------- data
        private void LoadReceipts()
        {
            // TODO: replace with the controller call that returns completed payments (Status = 'Completed')
            receipts = DemoMode ? BuildDemoReceipts() : new List<ReceiptData>();

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
        }

        private List<ReceiptData> BuildDemoReceipts()
        {
            List<ReceiptData> list = new List<ReceiptData>();
            DateTime now = DateTime.Now;

            ReceiptData a = new ReceiptData();
            a.ReceiptNo = "RES-0007";
            a.PaidAt = now;
            a.GuestName = "Carlo Mendoza";
            a.Room = "1001 (Economy)";
            a.CheckIn = now.AddHours(-24.5);
            a.CheckOut = now;
            a.Lines.Add(new ReceiptLine { Description = "Room (2 adults @ 1,200)", Quantity = 2, Amount = 2400m });
            a.Lines.Add(new ReceiptLine { Description = "Overstay (2 h x 2 adults @ 200)", Quantity = 2, Amount = 800m });
            a.Lines.Add(new ReceiptLine { Description = "Breakfast Set", Quantity = 2, Amount = 500m });
            a.Lines.Add(new ReceiptLine { Description = "Bottled Water", Quantity = 3, Amount = 120m });
            a.Total = 3820m;
            a.PaymentMethod = "Cash";
            a.Tendered = 4000m;
            a.Change = 180m;
            list.Add(a);

            ReceiptData b = new ReceiptData();
            b.ReceiptNo = "RES-0006";
            b.PaidAt = now.AddDays(-1);
            b.GuestName = "Mark Tan";
            b.Room = "3004 (Suite)";
            b.CheckIn = now.AddDays(-1).AddHours(-22);
            b.CheckOut = now.AddDays(-1);
            b.Lines.Add(new ReceiptLine { Description = "Room (5 adults @ 2,000)", Quantity = 5, Amount = 10000m });
            b.Total = 10000m;
            b.PaymentMethod = "Card / QR";
            b.Tendered = 10000m;
            b.Change = 0m;
            b.ReferenceNumber = "QR-884213";
            list.Add(b);

            ReceiptData c = new ReceiptData();
            c.ReceiptNo = "RES-0005";
            c.PaidAt = now.AddDays(-2);
            c.GuestName = "Liza Cruz";
            c.Room = "2008 (Deluxe)";
            c.CheckIn = now.AddDays(-2).AddHours(-22);
            c.CheckOut = now.AddDays(-2);
            c.Lines.Add(new ReceiptLine { Description = "Room (6 adults @ 1,600)", Quantity = 6, Amount = 9600m });
            c.Total = 9600m;
            c.PaymentMethod = "Cash";
            c.Tendered = 10000m;
            c.Change = 400m;
            list.Add(c);

            return list;
        }

        // ---------------------------------------------------------------- events
        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (suppressEvents || cmbPayment.SelectedIndex < 0)
            {
                return;
            }

            ShowReceipt(cmbPayment.SelectedIndex);
        }

        private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (suppressEvents || e.RowIndex < 0)
            {
                return;
            }

            ShowReceipt(e.RowIndex);
        }

        private void ShowReceipt(int index)
        {
            if (index < 0 || index >= receipts.Count)
            {
                return;
            }

            suppressEvents = true;
            cmbPayment.SelectedIndex = index;
            if (dgvPayments.Rows.Count > index)
            {
                dgvPayments.ClearSelection();
                dgvPayments.Rows[index].Selected = true;
            }
            suppressEvents = false;

            lblErrorMessage.Text = "";
            txtReceiptPreview.Text = BuildReceiptText(receipts[index]);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            if (string.IsNullOrWhiteSpace(txtReceiptPreview.Text))
            {
                lblErrorMessage.Text = "Select a completed payment first.";
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

        // ---------------------------------------------------------------- receipt text
        private string BuildReceiptText(ReceiptData r)
        {
            StringBuilder sb = new StringBuilder();
            string equals = new string('=', ReceiptWidth);
            string dashes = new string('-', ReceiptWidth);

            sb.AppendLine(equals);
            sb.AppendLine(Center(HotelName));
            sb.AppendLine(Center(HotelAddress));
            sb.AppendLine(equals);
            sb.AppendLine("OFFICIAL RECEIPT");
            sb.AppendLine("Receipt No : " + r.ReceiptNo);
            sb.AppendLine("Date/Time  : " + r.PaidAt.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine("Guest      : " + r.GuestName);
            sb.AppendLine("Room       : " + r.Room);
            sb.AppendLine("Check-In   : " + r.CheckIn.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine("Check-Out  : " + r.CheckOut.ToString("yyyy-MM-dd HH:mm"));
            sb.AppendLine(dashes);
            sb.AppendLine("DESCRIPTION".PadRight(26) + "QTY".PadLeft(5) + "AMOUNT".PadLeft(13));

            foreach (ReceiptLine line in r.Lines)
            {
                string desc = line.Description.Length > 26 ? line.Description.Substring(0, 26) : line.Description;
                sb.AppendLine(desc.PadRight(26) + line.Quantity.ToString().PadLeft(5) + line.Amount.ToString("N2").PadLeft(13));
            }

            sb.AppendLine(dashes);
            sb.AppendLine(TwoColumn("TOTAL AMOUNT DUE", "PHP " + r.Total.ToString("N2")));
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
            sb.AppendLine(Center("[ PAID IN FULL ]"));
            sb.AppendLine(Center("Thank you for staying with us!"));
            sb.AppendLine(equals);

            return sb.ToString();
        }

        private static string Center(string text)
        {
            if (text.Length >= ReceiptWidth)
            {
                return text;
            }

            int left = (ReceiptWidth - text.Length) / 2;
            return new string(' ', left) + text;
        }

        private static string TwoColumn(string left, string right)
        {
            int space = ReceiptWidth - left.Length - right.Length;
            if (space < 1)
            {
                space = 1;
            }

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