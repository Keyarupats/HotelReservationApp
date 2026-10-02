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

            if (searchNumber == "")
            {
                MessageBox.Show("Please enter a mobile number to search.", "Input Required",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GuestModel foundGuest = null;

            foreach (GuestModel guest in _allGuestsMasterList)
            {
                if (guest.ContactNo == searchNumber)
                {
                    foundGuest = guest;
                    break; 
                }
            }

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
                        dgvGuests.CurrentCell = row.Cells[0];
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
                GuestModel selectedGuest = dgvGuests.Rows[e.RowIndex].DataBoundItem as GuestModel;

                if (selectedGuest != null)
                {
                    SelectedGuest = selectedGuest;

                    txtSearch.Text = selectedGuest.ContactNo;
                    txtFirstName.Text = selectedGuest.FirstName;
                    txtLastName.Text = selectedGuest.LastName;
                    txtMI.Text = selectedGuest.MI;
                    txtAge.Text = selectedGuest.Age.ToString();
                    txtAddress.Text = selectedGuest.Address;
                    txtEmail.Text = selectedGuest.Email;
                    txtIDNum.Text = selectedGuest.IDNum;

                    if (!string.IsNullOrEmpty(selectedGuest.IDType) && cmbIDType.Items.Contains(selectedGuest.IDType))
                    {
                        cmbIDType.SelectedItem = selectedGuest.IDType;
                    }
                    else
                    {
                        cmbIDType.SelectedIndex = -1;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbIDType.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtIDNum.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int.TryParse(txtAge.Text.Trim(), out int age);

                var newGuest = new GuestModel
                {
                    ContactNo = txtSearch.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    MI = txtMI.Text.Trim(),
                    Age = age,
                    Address = txtAddress.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    IDType = cmbIDType.SelectedItem?.ToString() ?? string.Empty,
                    IDNum = txtIDNum.Text.Trim()
                };

                int newGuestId = _guestController.RegisterGuest(newGuest);

                MessageBox.Show("Guest registered successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClear_Click(sender, e);

                LoadGuestData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validation / Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
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