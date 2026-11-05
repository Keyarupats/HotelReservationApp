using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Controller;
using Model;

namespace UI.Controls
{
    public partial class ReportsUserControl : UserControl
    {
        // TODO: set to false and delete the demo data once the report controller is connected
        private static readonly bool DemoMode = true;

        public ReportsUserControl()
        {
            InitializeComponent();
            StyleGrid(dgvRevenueByType);
        }

        private void ReportsUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            // Reports are for the Admin only
            if (UserSession.CurrentRole != "Admin")
            {
                btnFilter.Enabled = false;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                lblErrorMessage.Text = "Reports are available to the Admin only.";
                return;
            }

            DateTime today = DateTime.Today;
            dtpStartDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpEndDate.Value = today;

            LoadReport();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void LoadReport()
        {
            lblErrorMessage.Text = "";

            DateTime start = dtpStartDate.Value.Date;
            DateTime end = dtpEndDate.Value.Date;

            if (start > end)
            {
                lblErrorMessage.Text = "Start Date must be on or before End Date.";
                return;
            }

            // TODO: replace the demo numbers with the controller call for the selected range:
            //   total revenue, number of completed stays, occupancy, and revenue and stays per room type
            DataTable table = new DataTable();
            table.Columns.Add("Room Type", typeof(string));
            table.Columns.Add("Stays Completed", typeof(int));
            table.Columns.Add("Total Generated Revenue", typeof(decimal));

            table.Rows.Add("Economy", 14, 71800m);
            table.Rows.Add("Deluxe", 7, 56000m);
            table.Rows.Add("Suite", 3, 58600m);

            int totalStays = 0;
            decimal totalRevenue = 0m;
            foreach (DataRow row in table.Rows)
            {
                totalStays += Convert.ToInt32(row["Stays Completed"]);
                totalRevenue += Convert.ToDecimal(row["Total Generated Revenue"]);
            }

            table.Rows.Add("TOTAL", totalStays, totalRevenue);

            dgvRevenueByType.DataSource = table;
            dgvRevenueByType.Columns["Total Generated Revenue"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvRevenueByType.Columns["Total Generated Revenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewRow totalRow = dgvRevenueByType.Rows[dgvRevenueByType.Rows.Count - 1];
            totalRow.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            totalRow.DefaultCellStyle.BackColor = Color.FromArgb(234, 247, 240);

            lblRevenueValue.Text = "₱" + totalRevenue.ToString("N2");
            lblStaysValue.Text = totalStays.ToString();
            lblOccupancyValue.Text = "41%";

            lblFootnote.Text = "Showing " + start.ToString("MMM dd, yyyy") + " to " + end.ToString("MMM dd, yyyy") +
                               (DemoMode ? "  (demo numbers)" : "");
        }

        private static void StyleGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 42;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(44, 62, 80);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            grid.RowTemplate.Height = 44;
        }
    }
}