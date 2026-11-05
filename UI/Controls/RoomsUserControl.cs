using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Controller;
using Model;

namespace UI
{
    public partial class RoomsUserControl : UserControl
    {
        private RoomController roomController;
        private RoomCardControl selectedCardControl = null;
        private string activeStatusFilter = "All";

        public RoomsUserControl()
        {
            InitializeComponent();
            roomController = new RoomController();

            // 1. Populate the Tier ComboBox (Default: ALL)
            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add("ALL");
            cmbRoomType.Items.Add("Economy");
            cmbRoomType.Items.Add("Deluxe");
            cmbRoomType.Items.Add("Suite");
            cmbRoomType.SelectedIndex = 0;

            // 2. Set default date to today
            dtpViewDate.Value = DateTime.Today;

            // 3. Reset labels and underlines to default
            ResetStatusIndicators();

            // 4. Initial load of rooms
            LoadRooms();
        }

        private void RoomsUserControl_Load(object sender, EventArgs e)
        {
            RefreshRoomView();
            if (flpRooms != null && flpRooms.Controls.Count == 0)
            {
                LoadRooms();
            }
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void dtpViewDate_ValueChanged(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void ResetStatusIndicators()
        {
            // Hide all underline panels
            pnlUnderlineAvailable.Visible = false;
            pnlUnderlineReserved.Visible = false;
            pnlUnderlineOccupied.Visible = false;
            pnlUnderlineCleaning.Visible = false;
            pnlUnderlineMaintenance.Visible = false;

            // Reset label vertical positions (default Top = 30)
            lblAvailable.Top = 30;
            lblReserved.Top = 30;
            lblOccupied.Top = 30;
            lblCleaning.Top = 30;
            lblMaintenance.Top = 30;

            // Hide the edit rates button by default
            btnEditRates.Visible = false;
        }

        // --- Status Label Click Events ---

        private void lblAvailable_Click(object sender, EventArgs e)
        {
            ResetStatusIndicators();

            // Shift up 5px and show underline
            lblAvailable.Top = 25;
            pnlUnderlineAvailable.Visible = true;
            activeStatusFilter = "Available";

            // If logged in as Admin, show the Edit Rates button!
            if (UserSession.CurrentRole == "Admin")
            {
                btnEditRates.Visible = true;
            }

            LoadRooms();
        }

        private void lblReserved_Click(object sender, EventArgs e)
        {
            ResetStatusIndicators();

            lblReserved.Top = 25;
            pnlUnderlineReserved.Visible = true;
            activeStatusFilter = "Reserved";

            LoadRooms();
        }

        private void lblOccupied_Click(object sender, EventArgs e)
        {
            ResetStatusIndicators();

            lblOccupied.Top = 25;
            pnlUnderlineOccupied.Visible = true;
            activeStatusFilter = "Occupied";

            LoadRooms();
        }

        private void lblCleaning_Click(object sender, EventArgs e)
        {
            ResetStatusIndicators();

            lblCleaning.Top = 25;
            pnlUnderlineCleaning.Visible = true;
            activeStatusFilter = "Cleaning";

            LoadRooms();
        }

        private void lblMaintenance_Click(object sender, EventArgs e)
        {
            ResetStatusIndicators();

            lblMaintenance.Top = 25;
            pnlUnderlineMaintenance.Visible = true;
            activeStatusFilter = "Maintenance";

            LoadRooms();
        }

        // --- Main Room Card Loading Logic ---

        public void LoadRooms()
        {
            if (flpRooms == null || roomController == null)
            {
                return;
            }

            flpRooms.Controls.Clear();
            selectedCardControl = null;

            // Tier Filter (ALL, Economy, Deluxe, Suite)
            string tierFilter = "ALL";
            if (cmbRoomType.SelectedItem != null)
            {
                tierFilter = cmbRoomType.SelectedItem.ToString().Trim();
            }

            // Fetch rooms from SQL Server
            List<RoomModel> allRooms = roomController.GetRooms("All");

            if (allRooms == null || allRooms.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "No rooms found in database. Check if tblRooms has data!";
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Segoe UI", 14F);
                flpRooms.Controls.Add(lblEmpty);
                return;
            }

            flpRooms.SuspendLayout();

            for (int i = 0; i < allRooms.Count; i++)
            {
                RoomModel room = allRooms[i];
                bool matchesTier = false;
                bool matchesStatus = false;

                // 1. Check Tier Match
                if (tierFilter == "ALL" || string.Equals(room.TypeName.Trim(), tierFilter, StringComparison.OrdinalIgnoreCase))
                {
                    matchesTier = true;
                }

                // 2. Check Status Match (from clicked status label)
                if (activeStatusFilter == "All" || string.Equals(room.Status.Trim(), activeStatusFilter, StringComparison.OrdinalIgnoreCase))
                {
                    matchesStatus = true;
                }

                // If both match, display the card
                if (matchesTier && matchesStatus)
                {
                    RoomCardControl card = new RoomCardControl();
                    card.SetRoomData(room);
                    card.RoomCardClicked += new EventHandler(OnRoomCard_Clicked);
                    flpRooms.Controls.Add(card);
                }
            }

            flpRooms.ResumeLayout();
        }

        public void RefreshRoomView()
        {
            // Re-fetch all rooms from the controller and re-bind/re-draw your room cards
            List<RoomModel> rooms = roomController.GetRooms(null);
            // Draw or bind your RoomCardControls here...
        }

        private void OnRoomCard_Clicked(object sender, EventArgs e)
        {
            if (selectedCardControl != null)
            {
                selectedCardControl.HighlightSelected(false);
            }

            selectedCardControl = (RoomCardControl)sender;
            selectedCardControl.HighlightSelected(true);

            RoomModel room = selectedCardControl.CurrentRoom;
            ShowRoomActionDialog(room);
        }

        private void ShowRoomActionDialog(RoomModel room)
        {
            string message = "Selected: Room " + room.RoomId.ToString() + " (" + room.TypeName + ")\n" +
                             "Current Status: " + room.Status + "\n" +
                             "Rate: ₱" + room.RatePerAdult.ToString("N2") + " / adult\n\n";

            if (room.Status == "Cleaning")
            {
                DialogResult result = MessageBox.Show(message + "Do you want to mark this room as AVAILABLE?",
                                                      "Housekeeping Action",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    roomController.ChangeRoomStatus(room.RoomId, "Available");
                    MessageBox.Show("Room " + room.RoomId.ToString() + " is now Clean and Available!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRooms();
                }
            }
            else if (room.Status == "Maintenance")
            {
                DialogResult result = MessageBox.Show(message + "Restore Room " + room.RoomId.ToString() + " to AVAILABLE?",
                                                      "Maintenance Complete",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    roomController.ChangeRoomStatus(room.RoomId, "Available");
                    LoadRooms();
                }
            }
            else if (room.Status == "Available")
            {
                DialogResult result = MessageBox.Show(message + "Do you need to set Room " + room.RoomId.ToString() + " to MAINTENANCE for repairs?",
                                                      "Set Maintenance",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    roomController.ChangeRoomStatus(room.RoomId, "Maintenance");
                    LoadRooms();
                }
            }
        }

        private void btnEditRates_Click(object sender, EventArgs e)
        {
            Form dialog = new Form();
            dialog.Text = "Admin - Update Room Tier Rate";
            dialog.Size = new Size(420, 260);
            dialog.StartPosition = FormStartPosition.CenterParent;
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.MaximizeBox = false;
            dialog.MinimizeBox = false;
            dialog.BackColor = Color.White;
            Label lblTier = new Label();
            lblTier.Text = "Select Tier:";
            lblTier.Location = new Point(30, 25);
            lblTier.AutoSize = true;
            lblTier.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ComboBox cmbTierSelect = new ComboBox();
            cmbTierSelect.Items.AddRange(new object[] { "Economy", "Deluxe", "Suite" });
            cmbTierSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTierSelect.Location = new Point(30, 50);
            cmbTierSelect.Size = new Size(340, 28);
            cmbTierSelect.Font = new Font("Segoe UI", 10F);
            Label lblRate = new Label();
            lblRate.Text = "Rate per Adult (₱):";
            lblRate.Location = new Point(30, 95);
            lblRate.AutoSize = true;
            lblRate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            TextBox txtRate = new TextBox();
            txtRate.Location = new Point(30, 120);
            txtRate.Size = new Size(340, 28);
            txtRate.Font = new Font("Segoe UI", 11F);
            // Event: When selection in ComboBox changes, automatically load the rate from SQL!
            cmbTierSelect.SelectedIndexChanged += new EventHandler(delegate (object s, EventArgs ev)
            {
                string selectedTier = cmbTierSelect.SelectedItem.ToString();
                decimal currentRate = roomController.GetTierRate(selectedTier);
                txtRate.Text = currentRate.ToString("0.00");
            });
            // Default select Economy on load
            cmbTierSelect.SelectedIndex = 0;
            Button btnSave = new Button();
            btnSave.Text = "Update Rate";
            btnSave.Location = new Point(230, 165);
            btnSave.Size = new Size(140, 36);
            btnSave.BackColor = Color.FromArgb(2, 132, 199);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            // Event: Save new rate to SQL
            btnSave.Click += new EventHandler(delegate (object s, EventArgs ev)
            {
                decimal newRate = 0;
                if (decimal.TryParse(txtRate.Text.Trim(), out newRate) && newRate > 0)
                {
                    string tier = cmbTierSelect.SelectedItem.ToString();
                    // Real SQL UPDATE
                    bool success = roomController.UpdateTierRate(tier, newRate);
                    if (success)
                    {
                        MessageBox.Show("Rate for " + tier + " tier successfully updated to ₱" + newRate.ToString("N2") + "!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        dialog.Close();
                        LoadRooms(); // Refresh the room cards with the new rate!
                    }
                    else
                    {
                        MessageBox.Show("Failed to update rate in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid rate greater than 0.", "Invalid Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRate.Focus();
                }
            });
            dialog.Controls.Add(lblTier);
            dialog.Controls.Add(cmbTierSelect);
            dialog.Controls.Add(lblRate);
            dialog.Controls.Add(txtRate);
            dialog.Controls.Add(btnSave);
            dialog.ShowDialog();
        }
    }
}