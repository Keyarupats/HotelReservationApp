using HotelReservation.BusinessLogic.Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class GuestDirectoryControl : UserControl
    {
        private GuestController guestController;
        private int selectedGuestId = 0;

        public GuestDirectoryControl()
        {
            InitializeComponent();
            guestController = new GuestController();
        }

        private void GuestDirectoryControl_Load(object sender, EventArgs e)
        {
            if (UserSession.CurrentRole == "Admin")
            {
                chkShowDeleted.Visible = true;
            }
            else
            {
                chkShowDeleted.Visible = false;
            }

            LoadGuests();
        }

        private void LoadGuests()
        {
            bool includeInactive = chkShowDeleted.Checked;
            List<GuestModel> guests = guestController.GetGuests(includeInactive);

            dgvGuests.DataSource = null;
            dgvGuests.DataSource = guests;

            if (dgvGuests.Columns["GuestId"] != null) dgvGuests.Columns["GuestId"].Visible = false;
            if (dgvGuests.Columns["FirstName"] != null) dgvGuests.Columns["FirstName"].Visible = false;
            if (dgvGuests.Columns["LastName"] != null) dgvGuests.Columns["LastName"].Visible = false;
            if (dgvGuests.Columns["MI"] != null) dgvGuests.Columns["MI"].Visible = false;
            if (dgvGuests.Columns["Age"] != null) dgvGuests.Columns["Age"].Visible = false;
            if (dgvGuests.Columns["Address"] != null) dgvGuests.Columns["Address"].Visible = false;
            if (dgvGuests.Columns["IDType"] != null) dgvGuests.Columns["IDType"].Visible = false;
            if (dgvGuests.Columns["IDNum"] != null) dgvGuests.Columns["IDNum"].Visible = false;
            if (dgvGuests.Columns["IsActive"] != null) dgvGuests.Columns["IsActive"].Visible = false;

            if (dgvGuests.Columns["GuestCode"] != null)
            {
                dgvGuests.Columns["GuestCode"].Visible = true;
                dgvGuests.Columns["GuestCode"].HeaderText = "Guest Code";
                dgvGuests.Columns["GuestCode"].DisplayIndex = 0;
            }

            if (dgvGuests.Columns["ContactNo"] != null)
            {
                dgvGuests.Columns["ContactNo"].Visible = true;
                dgvGuests.Columns["ContactNo"].HeaderText = "Contact Num";
                dgvGuests.Columns["ContactNo"].DisplayIndex = 1;
            }

            if (dgvGuests.Columns["FullName"] != null)
            {
                dgvGuests.Columns["FullName"].Visible = true;
                dgvGuests.Columns["FullName"].HeaderText = "Full Name";
                dgvGuests.Columns["FullName"].DisplayIndex = 2;
            }

            if (dgvGuests.Columns["Email"] != null)
            {
                dgvGuests.Columns["Email"].Visible = true;
                dgvGuests.Columns["Email"].HeaderText = "Email";
                dgvGuests.Columns["Email"].DisplayIndex = 3;
            }

            if (dgvGuests.Columns["CreatedAt"] != null)
            {
                dgvGuests.Columns["CreatedAt"].Visible = true;
                dgvGuests.Columns["CreatedAt"].HeaderText = "Created At";
                dgvGuests.Columns["CreatedAt"].DefaultCellStyle.Format = "yyyy-MM-dd";
                dgvGuests.Columns["CreatedAt"].DisplayIndex = 4;
            }

            lblTotalCount.Text = "Total Guests: " + guests.Count.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs() == false)
            {
                return;
            }

            GuestModel newGuest = new GuestModel();
            newGuest.ContactNo = txtMobileNumber.Text.Trim();
            newGuest.FirstName = txtFirstName.Text.Trim();
            newGuest.LastName = txtLastName.Text.Trim();
            newGuest.MI = txtMI.Text.Trim();
            newGuest.Age = Convert.ToInt32(txtAge.Text.Trim());
            newGuest.Email = txtEmail.Text.Trim();
            newGuest.Address = txtAddress.Text.Trim();
            newGuest.IDType = cmbIDType.SelectedItem.ToString();
            newGuest.IDNum = txtIDNumber.Text.Trim();
            newGuest.IsActive = true;

            int newId = guestController.RegisterGuest(newGuest);

            if (newId > 0)
            {
                MessageBox.Show("Guest registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadGuests();
            }
            else
            {
                MessageBox.Show("Failed to save guest. The mobile number might already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedGuestId == 0)
            {
                MessageBox.Show("Please select a guest from the directory table first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ValidateInputs() == false)
            {
                return;
            }

            GuestModel guest = new GuestModel();
            guest.GuestId = selectedGuestId;
            guest.ContactNo = txtMobileNumber.Text.Trim();
            guest.FirstName = txtFirstName.Text.Trim();
            guest.LastName = txtLastName.Text.Trim();
            guest.MI = txtMI.Text.Trim();
            guest.Age = Convert.ToInt32(txtAge.Text.Trim());
            guest.Email = txtEmail.Text.Trim();
            guest.Address = txtAddress.Text.Trim();
            guest.IDType = cmbIDType.SelectedItem.ToString();
            guest.IDNum = txtIDNumber.Text.Trim();

            bool success = guestController.UpdateGuest(guest);

            if (success)
            {
                MessageBox.Show("Guest profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadGuests();
            }
            else
            {
                MessageBox.Show("Failed to update guest.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedGuestId == 0)
            {
                MessageBox.Show("Please select a guest from the directory table first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to archive (soft delete) this guest?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                bool success = guestController.SoftDeleteGuest(txtMobileNumber.Text.Trim());

                if (success)
                {
                    MessageBox.Show("Guest archived successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadGuests();
                }
                else
                {
                    MessageBox.Show("Failed to delete guest.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a mobile number, name, or guest code to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool isFound = false;
            for (int i = 0; i < dgvGuests.Rows.Count; i++)
            {
                DataGridViewRow row = dgvGuests.Rows[i];
                string contactNo = row.Cells["ContactNo"].Value != null ? row.Cells["ContactNo"].Value.ToString() : "";
                string firstName = row.Cells["FirstName"].Value != null ? row.Cells["FirstName"].Value.ToString() : "";
                string lastName = row.Cells["LastName"].Value != null ? row.Cells["LastName"].Value.ToString() : "";
                string email = row.Cells["Email"].Value != null ? row.Cells["Email"].Value.ToString() : "";
                string guestCode = "G-" + Convert.ToInt32(row.Cells["GuestId"].Value).ToString("D4");
                if (contactNo.Contains(keyword) ||
                    firstName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    lastName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    guestCode.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    email.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    dgvGuests.ClearSelection();
                    row.Selected = true;
                    // Scroll the DataGridView so the found row is visible
                    dgvGuests.FirstDisplayedScrollingRowIndex = i;
                    // 4. Automatically populate all the textboxes on the left
                    selectedGuestId = Convert.ToInt32(row.Cells["GuestId"].Value);
                    txtGuestCode.Text = guestCode;
                    txtMobileNumber.Text = contactNo;
                    txtFirstName.Text = firstName;
                    txtLastName.Text = lastName;
                    txtMI.Text = row.Cells["MI"].Value != null ? row.Cells["MI"].Value.ToString() : "";
                    txtAge.Text = row.Cells["Age"].Value.ToString();
                    txtEmail.Text = email;
                    txtAddress.Text = row.Cells["Address"].Value.ToString();
                    cmbIDType.SelectedItem = row.Cells["IDType"].Value.ToString();
                    txtIDNumber.Text = row.Cells["IDNum"].Value.ToString();
                    isFound = true;
                    MessageBox.Show("Guest found! (ID: " + guestCode + ")", "Search Match", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break; // Stop at the first match
                }
            }
            // 5. If no guest matched the search
            if (isFound == false)
            {
                MessageBox.Show("No guest found matching: " + keyword, "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkShowDeleted_CheckedChanged(object sender, EventArgs e)
        {
            LoadGuests();
        }

        private void dgvGuests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGuests.Rows[e.RowIndex];

                selectedGuestId = Convert.ToInt32(row.Cells["GuestId"].Value);
                txtGuestCode.Text = "G-" + selectedGuestId.ToString("D4");
                txtMobileNumber.Text = row.Cells["ContactNo"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtMI.Text = row.Cells["MI"].Value != null ? row.Cells["MI"].Value.ToString() : "";
                txtAge.Text = row.Cells["Age"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                cmbIDType.SelectedItem = row.Cells["IDType"].Value.ToString();
                txtIDNumber.Text = row.Cells["IDNum"].Value.ToString();
            }
        }

        private void ClearForm()
        {
            selectedGuestId = 0;
            txtGuestCode.Clear();
            txtMobileNumber.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMI.Clear();
            txtAge.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmbIDType.SelectedIndex = -1;
            txtIDNumber.Clear();
            txtMobileNumber.Focus();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtMobileNumber.Text))
            {
                MessageBox.Show("Mobile number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNumber.Focus();
                return false;
            }

            if (txtMobileNumber.Text.Trim().Length != 11)
            {
                MessageBox.Show("Mobile number must be exactly 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            int age = 0;
            if (int.TryParse(txtAge.Text.Trim(), out age) == false || age < 18)
            {
                MessageBox.Show("Guest age must be a valid number of 18 or older.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAge.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            if (cmbIDType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an ID type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbIDType.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIDNumber.Text))
            {
                MessageBox.Show("ID number is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDNumber.Focus();
                return false;
            }

            return true;
        }

        private void txtMobileNumber_Leave(object sender, EventArgs e)
        {
            string mobile = txtMobileNumber.Text.Trim();
            if (string.IsNullOrEmpty(mobile))
            {
                return;
            }
            if (mobile.Length != 11)
            {
                MessageBox.Show("Mobile number must be exactly 11 digits (e.g., 09170000049).",
                                "Invalid Format",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtMobileNumber.Focus();
                return;
            }
            bool exists = guestController.IsMobileNumberRegistered(mobile, selectedGuestId);
            if (exists)
            {
                MessageBox.Show("Notice: This mobile number (" + mobile + ") is already registered to an existing guest!\n\nPlease use a different number.",
                                "Duplicate Mobile Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtMobileNumber.SelectAll();
                txtMobileNumber.Focus();
            }
        }
    }
}