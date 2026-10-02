using BusinessLogic.Controller;
using HotelReservation;
using HotelReservation.BusinessLogic.Controller;
using HotelReservation.Model;
using System.Collections;

namespace HotelReswervation
{
    public partial class LoginForm : Form
    {
        private readonly UserController _userController;
        ArrayList role;
        public LoginForm()
        {
            InitializeComponent();
            _userController = new UserController();
            role = new ArrayList();
            role.Add("Admin");
            role.Add("Front Desk Staff");
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void LoginPageForm_Load(object sender, EventArgs e)
        {
            cmbRole.DataSource = role;
            cmbRole.SelectedIndex = -1;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string selectedRole = cmbRole.SelectedItem?.ToString();

            // 1. Validation for empty inputs[cite: 1]
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(selectedRole))
            {
                MessageBox.Show("Please enter your Username, Password, and select a Role.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validate against database via Controller[cite: 1]
            UserModel loggedInUser = _userController.Login(username, password, selectedRole);

            if (loggedInUser != null)
            {
                MessageBox.Show($"Welcome back, {loggedInUser.Username}!", "Login Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3. Open main dashboard and apply role-based restrictions[cite: 1]
                RoomManagement dashboard = new RoomManagement();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username, password, or role selection. Please try again.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
