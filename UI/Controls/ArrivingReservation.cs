using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Controller;
using UI.Dialogs.Reservation;

namespace UI
{
    public partial class ArrivingReservation : UserControl
    {
        private ReservationController reservationController;
        private DataTable groupedArrivingTable;

        public ArrivingReservation()
        {
            InitializeComponent();
            reservationController = new ReservationController();
            dtpFilterDate.Enabled = rbSelectDate.Checked;

            dataGridViewArriving.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewArriving.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            LoadArrivingReservationsData();
        }

        private void LoadArrivingReservationsData()
        {
            try
            {
                DataTable rawTable = reservationController.GetArrivingReservations("");
                groupedArrivingTable = BuildGroupedArrivingTable(rawTable);
                ApplyLiveFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading arriving reservations: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable BuildGroupedArrivingTable(DataTable rawTable)
        {
            DataTable dt = new DataTable(); 
            dt.Columns.Add("Guest Name", typeof(string));
            dt.Columns.Add("Room", typeof(string));
            dt.Columns.Add("Booked Date", typeof(string));
            dt.Columns.Add("Check-In Date", typeof(string));
            dt.Columns.Add("Expected Check-Out", typeof(string));
            dt.Columns.Add("Total Amount", typeof(string));

            dt.Columns.Add("ReservationId", typeof(int));
            dt.Columns.Add("ReservationCode", typeof(string));
            dt.Columns.Add("ContactNo", typeof(string));
            dt.Columns.Add("AllReservationIds", typeof(string));
            dt.Columns.Add("AllRoomIds", typeof(string));
            dt.Columns.Add("CheckInDateOnly", typeof(string));
            dt.Columns.Add("CheckInRaw", typeof(DateTime));
            dt.Columns.Add("CheckOutRaw", typeof(DateTime));
            dt.Columns.Add("TotalAdults", typeof(int));
            dt.Columns.Add("TotalChildren", typeof(int));
            dt.Columns.Add("Nights", typeof(int));

            if (rawTable == null || rawTable.Rows.Count == 0)
                return dt;

            var groupedRows = rawTable.AsEnumerable()
                .GroupBy(r =>
                {
                    DateTime checkIn = Convert.ToDateTime(r["CheckInDateTime"]);
                    return new
                    {
                        GuestId = Convert.ToInt32(r["GuestId"]),
                        CheckInMinute = new DateTime(checkIn.Year, checkIn.Month, checkIn.Day, checkIn.Hour, checkIn.Minute, 0)
                    };
                })
                .OrderBy(g => g.Key.CheckInMinute);

            foreach (var group in groupedRows)
            {
                var first = group.First();
                int primaryId = group.Min(r => Convert.ToInt32(r["ReservationId"]));
                string allIds = string.Join(",", group.Select(r => r["ReservationId"].ToString()));
                string allRoomIds = string.Join(",", group.Select(r => r["RoomId"].ToString()));

                string code = first["ReservationCode"]?.ToString() ?? $"RES-{primaryId}";
                string guestName = first["GuestName"].ToString();
                string contactNo = first["ContactNo"].ToString();

                string roomsDisplay = group.Count() > 1
                    ? $"{string.Join(", ", group.Select(r => $"Room {r["RoomId"]} ({r["RoomType"]})"))} [{group.Count()} Rooms]"
                    : $"Room {first["RoomId"]} ({first["RoomType"]})";

                int totalAdults = group.Sum(r => Convert.ToInt32(r["Adults"]));
                int totalChildren = group.Sum(r => Convert.ToInt32(r["Children"]));

                string bookedDateDisplay = first["CreatedAt"] != DBNull.Value
                    ? Convert.ToDateTime(first["CreatedAt"]).ToString("MMM dd, yyyy  hh:mm tt")
                    : "N/A";

                DateTime checkIn = Convert.ToDateTime(first["CheckInDateTime"]);
                DateTime checkOut = Convert.ToDateTime(first["ExpectedCheckOutDateTime"]);
                int nights = Math.Max(1, (int)Math.Round((checkOut - checkIn).TotalHours / 24.0));
                decimal totalAmount = group.Sum(r => Convert.ToDecimal(r["TotalAmount"]));

                dt.Rows.Add(
                    guestName,
                    roomsDisplay,
                    bookedDateDisplay,
                    checkIn.ToString("MMM dd, yyyy  hh:mm tt"),
                    checkOut.ToString("MMM dd, yyyy  hh:mm tt"),
                    $"₱{totalAmount:N2}",
                    primaryId,
                    code,
                    contactNo,
                    allIds,
                    allRoomIds,
                    checkIn.ToString("yyyy-MM-dd"),
                    checkIn,
                    checkOut,
                    totalAdults,
                    totalChildren,
                    nights);
            }

            return dt;
        }

        private void ApplyLiveFilters()
        {
            if (groupedArrivingTable == null) return;

            List<string> filterParts = new List<string>();

            if (rbToday.Checked)
            {
                string todayStr = DateTime.Today.ToString("yyyy-MM-dd");
                filterParts.Add($"CheckInDateOnly = '{todayStr}'");
            }
            else if (rbSelectDate.Checked)
            {
                string selectedDateStr = dtpFilterDate.Value.Date.ToString("yyyy-MM-dd");
                filterParts.Add($"CheckInDateOnly = '{selectedDateStr}'");
            } 
            string keyword = txtSearchReservation.Text.Trim().Replace("'", "''");
            if (!string.IsNullOrEmpty(keyword))
            {
                filterParts.Add($"([Guest Name] LIKE '%{keyword}%' OR ContactNo LIKE '%{keyword}%' OR ReservationCode LIKE '%{keyword}%' OR Convert(ReservationId, 'System.String') LIKE '%{keyword}%')");
            }

            DataView dv = groupedArrivingTable.DefaultView;
            dv.RowFilter = string.Join(" AND ", filterParts);
            dataGridViewArriving.DataSource = dv;

            ConfigureGridColumns();
        }

        private void ConfigureGridColumns()
        {
            string[] hiddenCols =
            {
                "ReservationId",
                "ReservationCode",
                "ContactNo",
                "AllReservationIds",
                "AllRoomIds",
                "CheckInDateOnly",
                "CheckInRaw",
                "CheckOutRaw",
                "TotalAdults",
                "TotalChildren",
                "Nights"
            };

            foreach (string col in hiddenCols)
            {
                if (dataGridViewArriving.Columns[col] != null)
                {
                    dataGridViewArriving.Columns[col].Visible = false;
                }
            } 
            if (dataGridViewArriving.Columns["Guest Name"] != null)
                dataGridViewArriving.Columns["Guest Name"].FillWeight = 110;
            if (dataGridViewArriving.Columns["Room"] != null)
                dataGridViewArriving.Columns["Room"].FillWeight = 175;
            if (dataGridViewArriving.Columns["Booked Date"] != null)
                dataGridViewArriving.Columns["Booked Date"].FillWeight = 130;
            if (dataGridViewArriving.Columns["Check-In Date"] != null)
                dataGridViewArriving.Columns["Check-In Date"].FillWeight = 130;
            if (dataGridViewArriving.Columns["Expected Check-Out"] != null)
                dataGridViewArriving.Columns["Expected Check-Out"].FillWeight = 130;
            if (dataGridViewArriving.Columns["Total Amount"] != null)
                dataGridViewArriving.Columns["Total Amount"].FillWeight = 85;
        }

        private void DateFilter_Changed(object sender, EventArgs e)
        {
            dtpFilterDate.Enabled = rbSelectDate.Checked;
            ApplyLiveFilters();
        }

        private void dtpFilterDate_ValueChanged(object sender, EventArgs e)
        {
            if (rbSelectDate.Checked)
            {
                ApplyLiveFilters();
            }
        }

        private void txtSearchReservation_TextChanged(object sender, EventArgs e)
        {
            ApplyLiveFilters();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyLiveFilters();

            if (dataGridViewArriving.Rows.Count == 0 && !string.IsNullOrWhiteSpace(txtSearchReservation.Text))
            {
                MessageBox.Show("No confirmed arriving reservations found matching your search and date filter.",
                                "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCheckInSelected_Click(object sender, EventArgs e)
        {
            if (dataGridViewArriving.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an arriving reservation from the list to check in.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var row = dataGridViewArriving.SelectedRows[0];
                string guestDisplay = $"{row.Cells["Guest Name"].Value} ({row.Cells["ContactNo"].Value})";
                string roomsDisplay = row.Cells["Room"].Value.ToString();
                DateTime checkInRaw = Convert.ToDateTime(row.Cells["CheckInRaw"].Value);
                DateTime checkOutRaw = Convert.ToDateTime(row.Cells["CheckOutRaw"].Value);
                int adults = Convert.ToInt32(row.Cells["TotalAdults"].Value);
                int children = Convert.ToInt32(row.Cells["TotalChildren"].Value);
                int nights = Convert.ToInt32(row.Cells["Nights"].Value);
                string formattedTotal = row.Cells["Total Amount"].Value.ToString();

                int[] reservationIds = row.Cells["AllReservationIds"].Value.ToString()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                int[] roomIds = row.Cells["AllRoomIds"].Value.ToString()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                using (ReservationConfirmDialog checkInDialog = new ReservationConfirmDialog(
                    guestDisplay,
                    checkInRaw,
                    checkOutRaw,
                    roomsDisplay,
                    adults,
                    children,
                    nights,
                    formattedTotal,
                    "Confirm Guest Check-In",
                    "Verify arrival details and mark room(s) as Occupied:",
                    "🛎️ Complete Check-In"))
                {
                    if (checkInDialog.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }
                }

                if (reservationController.CheckInBooking(reservationIds, roomIds))
                {
                    LoadArrivingReservationsData();
                }
                else
                {
                    MessageBox.Show("Failed to complete check-in in the database. Please try again.",
                                    "Check-In Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Check-in error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}