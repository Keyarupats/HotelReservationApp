using BusinessLogic.Controller;
using HotelReservation;
using HotelReservation.BusinessLogic.Controller;
using HotelReservation.Model;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace HotelReswervation
{
    public partial class LoginForm : Form
    {
        private readonly UserController _userController;
        private ArrayList role;

        public LoginForm()
        {
            InitializeComponent();
            _userController = new UserController();
            role = new ArrayList
            {
                "Admin",
                "Front Desk Staff"
            };
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
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.Gray;
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

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
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

            UserModel user = _userController.Authenticate(username, password);

            if (user != null)
            {
                UserSession.CurrentUsername = user.Username;
                UserSession.CurrentRole = user.Role; 

                MessageBox.Show($"Welcome, {user.Username}!", "Login Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                RoomManagement room = new RoomManagement();
                room.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}