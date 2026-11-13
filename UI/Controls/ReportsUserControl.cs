using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Controller;
using Model;

namespace UI.Controls
{
    public partial class ReportsUserControl : UserControl
    {
        private readonly ReportController reportController;

        public ReportsUserControl()
        {
            InitializeComponent();
            reportController = new ReportController();
            StyleGrid(dgvRevenueByType);
        }

        private void ReportsUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            if (UserSession.CurrentRole != "Admin")
            {
                SetFilterControlsEnabled(false);
                lblErrorMessage.Text = "Reports are available to the Admin only.";
                return;
            }

            DateTime today = DateTime.Today;
            dtpStartDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpEndDate.Value = today;

            LoadReport();
        }

        private void SetFilterControlsEnabled(bool enabled)
        {
            btnFilter.Enabled = enabled;
            dtpStartDate.Enabled = enabled;
            dtpEndDate.Enabled = enabled;
            btnPresetToday.Enabled = enabled;
            btnPresetMonth.Enabled = enabled;
            btnPresetYear.Enabled = enabled;
            btnExportCsv.Enabled = enabled;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnPresetToday_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtpStartDate.Value = today;
            dtpEndDate.Value = today;
            LoadReport();
        }

        private void btnPresetMonth_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtpStartDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpEndDate.Value = today;
            LoadReport();
        }

        private void btnPresetYear_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            dtpStartDate.Value = new DateTime(today.Year, 1, 1);
            dtpEndDate.Value = today;
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

            try
            {
                ReportSummaryModel summary = reportController.GetReportSummary(start, end);

                DataTable table = new DataTable();
                table.Columns.Add("Room Type", typeof(string));
                table.Columns.Add("Stays Completed", typeof(int));
                table.Columns.Add("Total Generated Revenue", typeof(decimal));

                foreach (var item in summary.BreakdownByRoomType)
                {
                    table.Rows.Add(item.RoomType, item.StaysCompleted, item.TotalGeneratedRevenue);
                }

                table.Rows.Add("TOTAL", summary.CompletedStays, summary.TotalRevenue);

                dgvRevenueByType.DataSource = table;

                lblRevenueValue.Text = "₱" + summary.TotalRevenue.ToString("N2");
                lblStaysValue.Text = summary.CompletedStays.ToString();
                lblOccupancyValue.Text = summary.OccupancyRate.ToString("0.##") + "%";

                lblFootnote.Text = $"Showing {start:MMM dd, yyyy} to {end:MMM dd, yyyy}";
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Failed to load report: " + ex.Message;
            }
        }

        private void dgvRevenueByType_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvRevenueByType.Columns.Contains("Total Generated Revenue"))
            {
                dgvRevenueByType.Columns["Total Generated Revenue"].DefaultCellStyle.Format = "₱#,##0.00";
                dgvRevenueByType.Columns["Total Generated Revenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            foreach (DataGridViewColumn col in dgvRevenueByType.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewRow row in dgvRevenueByType.Rows)
            {
                if (row.Cells["Room Type"].Value?.ToString() == "TOTAL")
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
                    row.DefaultCellStyle.BackColor = Color.FromArgb(234, 247, 240);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(212, 239, 223);
                    row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 130, 76);
                }
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (dgvRevenueByType.Rows.Count == 0)
            {
                lblErrorMessage.Text = "No report data available to export.";
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.FileName = $"HotelReport_{dtpStartDate.Value:yyyyMMdd}_to_{dtpEndDate.Value:yyyyMMdd}.csv";

                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine($"Hotel Revenue & Occupancy Report ({dtpStartDate.Value:MMM dd, yyyy} - {dtpEndDate.Value:MMM dd, yyyy})");
                    sb.AppendLine($"Total Revenue,{lblRevenueValue.Text.Replace(",", "")}");
                    sb.AppendLine($"Completed Stays,{lblStaysValue.Text}");
                    sb.AppendLine($"Occupancy Rate,{lblOccupancyValue.Text}");
                    sb.AppendLine();

                    string[] headers = new string[dgvRevenueByType.Columns.Count];
                    for (int i = 0; i < dgvRevenueByType.Columns.Count; i++)
                    {
                        headers[i] = EscapeCsv(dgvRevenueByType.Columns[i].HeaderText);
                    }
                    sb.AppendLine(string.Join(",", headers));

                    foreach (DataGridViewRow row in dgvRevenueByType.Rows)
                    {
                        string[] cells = new string[dgvRevenueByType.Columns.Count];
                        for (int i = 0; i < dgvRevenueByType.Columns.Count; i++)
                        {
                            cells[i] = EscapeCsv(row.Cells[i].Value?.ToString() ?? "");
                        }
                        sb.AppendLine(string.Join(",", cells));
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Report exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    lblErrorMessage.Text = "Export failed: " + ex.Message;
                }
            }
        }

        private static string EscapeCsv(string value)
        {
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
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