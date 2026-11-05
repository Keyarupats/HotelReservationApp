using HotelReservation.BusinessLogic.Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class WalkInCheckIn : UserControl
    {
        public WalkInCheckIn()
        {
            InitializeComponent();
            LoadAvailableRoomsComboBox();
        }

        private void LoadAvailableRoomsComboBox()
        {
            RoomController roomController = new RoomController();

            DateTime checkInTime = DateTime.Now;
            int adults = (int)numAdults.Value;
            int children = (int)numChildren.Value;

            var availableRooms = roomController.GetAvailableRooms(checkInTime, adults, children);

            cmbAvailableRooms.DataSource = availableRooms;
            cmbAvailableRooms.DisplayMember = "TypeName"; 
            cmbAvailableRooms.ValueMember = "RoomId";       
        }

        private void btnFindGuest_Click(object sender, EventArgs e)
        {
            string searchInput = txtSearchGuest.Text.Trim();
            if (string.IsNullOrEmpty(searchInput))
            {
                MessageBox.Show("Please enter a name, mobile number, email, or ID to search.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool guestFound = false;

            if (guestFound)
            {
                lblGuestStatusNotice.Visible = false;
            }
            else
            {
                lblGuestStatusNotice.Text = "No guest found. Fill in the details below and click Register Guest.";
                lblGuestStatusNotice.ForeColor = Color.DarkOrange;
            }
        }

        private void btnRegisterGuest_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string mobile = txtMobileNumber.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(mobile))
            {
                MessageBox.Show("Please fill in the required guest fields (First Name, Last Name, Mobile Number).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Guest registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCompleteCheckIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Walk-in check-in completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAllFields();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void ClearAllFields()
        {
            txtSearchGuest.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtMiddleInitial.Clear();
            txtMobileNumber.Clear();
            txtAge.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtIdNumber.Clear();
            lblGuestStatusNotice.Text = "";
        }
    }
}