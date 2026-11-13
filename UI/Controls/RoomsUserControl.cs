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

            cmbRoomType.Items.Clear();
            cmbRoomType.Items.Add("ALL");
            cmbRoomType.Items.Add("Economy");
            cmbRoomType.Items.Add("Deluxe");
            cmbRoomType.Items.Add("Suite");
            cmbRoomType.SelectedIndex = 0;

            dtpViewDate.Value = DateTime.Today;

            ResetStatusIndicators();

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
            pnlUnderlineAvailable.Visible = false;
            pnlUnderlineReserved.Visible = false;
            pnlUnderlineOccupied.Visible = false;
            pnlUnderlineCleaning.Visible = false;
            pnlUnderlineMaintenance.Visible = false;

            lblAvailable.Top = 30;
            lblReserved.Top = 30;
            lblOccupied.Top = 30;
            lblCleaning.Top = 30;
            lblMaintenance.Top = 30;

            SetLabelClickable(lblAvailable, true);
            SetLabelClickable(lblReserved, true);
            SetLabelClickable(lblOccupied, true);
            SetLabelClickable(lblCleaning, true);
            SetLabelClickable(lblMaintenance, true);

            btnEditRates.Visible = false;
        }

        private void SetLabelClickable(Label lbl, bool clickable)
        {
            lbl.Enabled = clickable;
            lbl.Cursor = clickable ? Cursors.Hand : Cursors.Default;
        }

        private void lblAvailable_Click(object sender, EventArgs e)
        {
            ResetStatusIndicators();

            lblAvailable.Top = 25;
            pnlUnderlineAvailable.Visible = true;
            SetLabelClickable(lblAvailable, false); 
            activeStatusFilter = "Available";

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
            SetLabelClickable(lblReserved, false); 
            activeStatusFilter = "Reserved";

            LoadRooms();
        }

        private void lblOccupied_Click(object sender, EventArgs e)
        {
            ResetStatusIndicators();

            lblOccupied.Top = 25;
            pnlUnderlineOccupied.Visible = true;
            SetLabelClickable(lblOccupied, false); 
            activeStatusFilter = "Occupied";

            LoadRooms();
        }

        private void lblCleaning_Click(object sender, EventArgs e)
        {
            ResetStatusIndicators();

            lblCleaning.Top = 25;
            pnlUnderlineCleaning.Visible = true;
            SetLabelClickable(lblCleaning, false); 
            activeStatusFilter = "Cleaning";

            LoadRooms();
        }

        private void lblMaintenance_Click(object sender, EventArgs e)
        {
            ResetStatusIndicators();

            lblMaintenance.Top = 25;
            pnlUnderlineMaintenance.Visible = true;
            SetLabelClickable(lblMaintenance, false); 
            activeStatusFilter = "Maintenance";

            LoadRooms();
        }


        public void LoadRooms()
        {
            if (flpRooms == null || roomController == null)
            {
                return;
            }

            flpRooms.Controls.Clear();
            selectedCardControl = null;

            string tierFilter = "ALL";
            if (cmbRoomType.SelectedItem != null)
            {
                tierFilter = cmbRoomType.SelectedItem.ToString().Trim();
            }
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

                if (tierFilter == "ALL" || string.Equals(room.TypeName.Trim(), tierFilter, StringComparison.OrdinalIgnoreCase))
                {
                    matchesTier = true;
                }
                if (activeStatusFilter == "All" || string.Equals(room.Status.Trim(), activeStatusFilter, StringComparison.OrdinalIgnoreCase))
                {
                    matchesStatus = true;
                }

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
            List<RoomModel> rooms = roomController.GetRooms(null);
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
            if (UserSession.CurrentRole != "Admin")
            {
                MessageBox.Show("Only Administrators can update room rates.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form dialog = new Form())
            {
                dialog.Text = "Admin - Update Room Tier Rate";
                dialog.Size = new Size(420, 260);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.BackColor = Color.White;

                Label lblTier = new Label
                {
                    Text = "Select Tier:",
                    Location = new Point(30, 25),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                ComboBox cmbTierSelect = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Location = new Point(30, 50),
                    Size = new Size(340, 28),
                    Font = new Font("Segoe UI", 10F)
                };
                cmbTierSelect.Items.AddRange(new object[] { "Economy", "Deluxe", "Suite" });

                Label lblRate = new Label
                {
                    Text = "Rate per Adult (₱):",
                    Location = new Point(30, 95),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                };

                TextBox txtRate = new TextBox
                {
                    Location = new Point(30, 120),
                    Size = new Size(340, 28),
                    Font = new Font("Segoe UI", 11F)
                };

                cmbTierSelect.SelectedIndexChanged += (s, ev) =>
                {
                    string selectedTier = cmbTierSelect.SelectedItem.ToString();
                    decimal currentRate = roomController.GetTierRate(selectedTier);
                    txtRate.Text = currentRate.ToString("0.00");
                };
                cmbTierSelect.SelectedIndex = 0;

                Button btnSave = new Button
                {
                    Text = "Update Rate",
                    Location = new Point(230, 165),
                    Size = new Size(140, 36),
                    BackColor = Color.FromArgb(2, 132, 199),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnSave.FlatAppearance.BorderSize = 0;

                btnSave.Click += (s, ev) =>
                {
                    if (!decimal.TryParse(txtRate.Text.Trim(), out decimal newRate) || newRate <= 0)
                    {
                        MessageBox.Show("Please enter a valid rate greater than 0.", "Invalid Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtRate.Focus();
                        return;
                    }

                    string tier = cmbTierSelect.SelectedItem.ToString();

                    // Check live availability at the exact moment the button is clicked
                    List<RoomModel> currentRooms = roomController.GetRooms(tier);
                    bool hasAvailableRoom = currentRooms.Exists(r =>
                        string.Equals(r.TypeName.Trim(), tier, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(r.Status.Trim(), "Available", StringComparison.OrdinalIgnoreCase));

                    if (!hasAvailableRoom)
                    {
                        MessageBox.Show($"Cannot update {tier} rate: there are currently no Available rooms in this tier.",
                                        "No Available Rooms", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (roomController.UpdateTierRate(tier, newRate))
                    {
                        MessageBox.Show($"Rate for {tier} tier successfully updated to ₱{newRate:N2}!",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dialog.DialogResult = DialogResult.OK;
                        dialog.Close();
                        LoadRooms();
                    }
                    else
                    {
                        MessageBox.Show($"Rate update failed: no Available {tier} rooms were found at the time of update.",
                                        "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                dialog.AcceptButton = btnSave;
                dialog.Controls.AddRange(new Control[] { lblTier, cmbTierSelect, lblRate, txtRate, btnSave });
                dialog.ShowDialog(this);
            }
        }
    }
}