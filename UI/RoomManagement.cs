using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Controller;
using Model;

namespace HotelReservation
{
    public partial class RoomManagement : Form
    {
        private readonly RoomController _roomController;
        private List<RoomModel> _allRoomsMasterList;
        public RoomManagement()
        {
            InitializeComponent();
            
        }


        public RoomManagement(string connectionString, List<RoomModel> preloadedRooms = null)
        {
            InitializeComponent();
            _roomController = new RoomController(connectionString);

        }



        private void ApplyRoomFilter()
        {
            if (_allRoomsMasterList == null || !_allRoomsMasterList.Any()) return;

            string selectedTier = cmbRoomType.SelectedItem?.ToString();

            List<RoomModel> filteredRooms;

            if (cmbRoomType.SelectedIndex == 0 || selectedTier == "ALL TIER")
            {
                filteredRooms = _allRoomsMasterList;
            }
            else
            {
            }
        }

        private void BindAndFormatGrid(List<RoomModel> roomList)
        {
            dgvRoomDirectory.DataSource = null;
            dgvRoomDirectory.DataSource = roomList;

            if (dgvRoomDirectory.Rows.Count > 0)
            {
                dgvRoomDirectory.Rows[0].Selected = true;

                dgvRoomDirectory_CellClick(dgvRoomDirectory, new DataGridViewCellEventArgs(0, 0));
            }

            if (dgvRoomDirectory.Columns.Count == 0) return;

            if (dgvRoomDirectory.Columns["RoomId"] != null)
                dgvRoomDirectory.Columns["RoomId"].Visible = true;

            if (dgvRoomDirectory.Columns["RoomNumber"] != null)
                dgvRoomDirectory.Columns["RoomNumber"].HeaderText = "Room Number";

            if (dgvRoomDirectory.Columns["RoomType"] != null)
                dgvRoomDirectory.Columns["RoomType"].HeaderText = "Category / Tier";

            if (dgvRoomDirectory.Columns["RatePerNight"] != null)
            {
                dgvRoomDirectory.Columns["RatePerNight"].HeaderText = "Rate / Night";
                dgvRoomDirectory.Columns["RatePerNight"].DefaultCellStyle.Format = "'₱'#,##0.00";
                dgvRoomDirectory.Columns["RatePerNight"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvRoomDirectory.Columns["Status"] != null)
                dgvRoomDirectory.Columns["Status"].HeaderText = "Status";

            dgvRoomDirectory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRoomDirectory.ReadOnly = true;
            dgvRoomDirectory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoomDirectory.AllowUserToAddRows = false;
        }

        private void RoomManagement_Load(object sender, EventArgs e)
        {

            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add("ALL TIER");
            cmbRoomType.Items.Add("Economy");
            cmbRoomType.Items.Add("Deluxe");
            cmbRoomType.Items.Add("Suite");

            cmbRoomType.SelectedIndex = 0;
        }

        


        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyRoomFilter();
        }

        private void dgvRoomDirectory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRoomDirectory.Rows[e.RowIndex];

                txtRoomNumber.Text = row.Cells["RoomNumber"].Value?.ToString() ?? string.Empty;

                txtCategory.Text = row.Cells["RoomType"].Value?.ToString() ?? string.Empty;

                if (row.Cells["RatePerNight"].Value != null)
                {
                    decimal rate = Convert.ToDecimal(row.Cells["RatePerNight"].Value);
                    txtBaseRate.Text = rate.ToString("0.00");
                }
                else
                {
                    txtBaseRate.Text = string.Empty;
                }

                txtStatus.Text = row.Cells["Status"].Value?.ToString() ?? string.Empty;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
