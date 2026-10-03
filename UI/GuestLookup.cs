using HotelReservation.BusinessLogic.Controller;
using HotelReservation.Model;

namespace HotelReswervation
{
    public partial class GuestLookup : Form
    {
        private readonly GuestController _guestController;
        private List<GuestModel> _allGuestsMasterList;

        public GuestModel SelectedGuest { get; private set; }

        public GuestLookup()
        {
            InitializeComponent();
            _guestController = new GuestController();
            _allGuestsMasterList = new List<GuestModel>();
        }

        private void GuestLookup_Load(object sender, EventArgs e)
        {
            txtSearch.MaxLength = 11;

            LoadGuestData();
        }

        private void LoadGuestData()
        {
            try
            {
                bool isAdmin = UserSession.CurrentRole.Equals("Admin", StringComparison.OrdinalIgnoreCase);

                
                if (isAdmin)
                {
                    _allGuestsMasterList = _guestController.GetAllGuestsForAdmin();
                }
                else
                {
                    _allGuestsMasterList = _guestController.GetActiveGuests();
                }

                BindAndFormatGrid(_allGuestsMasterList);

                UpdateGuestCountLabel(isAdmin);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading guest records: {ex.Message}", "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void UpdateGuestCountLabel(bool isAdmin)
        {
            int count = _allGuestsMasterList.Count;

            if (isAdmin)
            {
                lblGuestsCount.Text = count.ToString();
            }
            else
            {
                lblGuestsCount.Text = count.ToString();
            }
        }



        private void BindAndFormatGrid(List<GuestModel> guestList)
        {
            dgvGuests.DataSource = null;
            dgvGuests.DataSource = guestList;

            if (dgvGuests.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in dgvGuests.Columns)
            {
                col.Visible = false;
            }

            if (dgvGuests.Columns["ContactNo"] != null)
            {
                dgvGuests.Columns["ContactNo"].Visible = true;
                dgvGuests.Columns["ContactNo"].HeaderText = "Mobile Number";
                dgvGuests.Columns["ContactNo"].DisplayIndex = 0;
            }

            if (dgvGuests.Columns["FullName"] != null)
            {
                dgvGuests.Columns["FullName"].Visible = true;
                dgvGuests.Columns["FullName"].HeaderText = "Full Name";
                dgvGuests.Columns["FullName"].DisplayIndex = 1;
            }

            if (dgvGuests.Columns["Age"] != null)
            {
                dgvGuests.Columns["Age"].Visible = true;
                dgvGuests.Columns["Age"].HeaderText = "Age";
                dgvGuests.Columns["Age"].DisplayIndex = 2;
            }

            if (dgvGuests.Columns["Email"] != null)
            {
                dgvGuests.Columns["Email"].Visible = true;
                dgvGuests.Columns["Email"].HeaderText = "Email Address";
                dgvGuests.Columns["Email"].DisplayIndex = 3;
            }

            if (dgvGuests.Columns["IDType"] != null)
            {
                dgvGuests.Columns["IDType"].Visible = true;
                dgvGuests.Columns["IDType"].HeaderText = "ID Type";
                dgvGuests.Columns["IDType"].DisplayIndex = 4;
            }

            dgvGuests.AutoGenerateColumns = false;
            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGuests.ReadOnly = true;
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.AllowUserToAddRows = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchNumber = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchNumber))
            {
                MessageBox.Show("Please enter a mobile number to search.", "Input Required",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GuestModel foundGuest = _allGuestsMasterList.FirstOrDefault(g => g.ContactNo == searchNumber);

            if (foundGuest != null)
            {
                txtSearch.Text = foundGuest.ContactNo;
                txtFirstName.Text = foundGuest.FirstName;
                txtLastName.Text = foundGuest.LastName;
                txtMI.Text = foundGuest.MI;
                txtAge.Text = foundGuest.Age.ToString();
                txtAddress.Text = foundGuest.Address;
                txtEmail.Text = foundGuest.Email;
                txtIDNum.Text = foundGuest.IDNum;
                cmbIDType.SelectedItem = foundGuest.IDType;

                foreach (DataGridViewRow row in dgvGuests.Rows)
                {
                    GuestModel rowGuest = row.DataBoundItem as GuestModel;
                    if (rowGuest != null && rowGuest.ContactNo == foundGuest.ContactNo)
                    {
                        row.Selected = true;

                        if (dgvGuests.Columns["ContactNo"] != null)
                        {
                            dgvGuests.CurrentCell = row.Cells["ContactNo"];
                        }
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("No guest found with that mobile number.", "Search Result",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvGuests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGuests.Rows[e.RowIndex];

                txtSearch.Text = row.Cells["ContactNo"].Value?.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value?.ToString();
                txtLastName.Text = row.Cells["LastName"].Value?.ToString();
                txtMI.Text = row.Cells["MI"].Value?.ToString();
                txtAge.Text = row.Cells["Age"].Value?.ToString();
                txtAddress.Text = row.Cells["Address"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                cmbIDType.Text = row.Cells["IDType"].Value?.ToString();
                txtIDNum.Text = row.Cells["IDNum"].Value?.ToString();
            }
        }





        private void btnSave_Click(object sender, EventArgs e)
        {
            string contactNo = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(contactNo))
            {
                MessageBox.Show("Please enter or select a Contact Number.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtAge.Text.Trim(), out int age))
            {
                MessageBox.Show("Please enter a valid age.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GuestModel guest = new GuestModel
            {
                ContactNo = contactNo,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                MI = txtMI.Text.Trim(),
                Age = age,
                Address = txtAddress.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                IDType = cmbIDType.Text.Trim(),
                IDNum = txtIDNum.Text.Trim()
            };

            try
            {
                bool success = _guestController.SaveGuest(guest);

                if (success)
                {
                    MessageBox.Show("Guest record saved successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnClear_Click(sender, e); 
                    LoadGuestData();           
                }
                else
                {
                    MessageBox.Show("Unable to save guest record.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving guest: " + ex.Message, "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAddress.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtSearch.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtMI.Text = string.Empty;
            txtIDNum.Text = string.Empty;

            if (cmbIDType != null)
            {
                cmbIDType.SelectedIndex = -1;
            }

            BindAndFormatGrid(_allGuestsMasterList);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text) && txtSearch.Text.Length != 11)
            {
                MessageBox.Show("Mobile number must be exactly 11 digits.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string contactNo = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(contactNo))
            {
                MessageBox.Show("Please select or search for a guest first.", "Selection Required",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to remove this guest record?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool isDeleted = _guestController.SoftDeleteGuest(contactNo);

                    if (isDeleted)
                    {
                        MessageBox.Show("Guest record removed successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnClear_Click(sender, e);

                        LoadGuestData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to remove guest record.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting guest: " + ex.Message, "Database Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
            

        private void GuestLookup_Load_1(object sender, EventArgs e)
        {
            LoadGuestData();
        }
    }
}