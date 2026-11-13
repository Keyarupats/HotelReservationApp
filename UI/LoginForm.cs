using HotelReservation.BusinessLogic.Controller;
using Model;
using System.Collections;
using UI;
using UI.Dialogs.LogIn;

namespace HotelReservation
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
            string role = cmbRole.SelectedItem != null ? cmbRole.SelectedItem.ToString() : "";
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                lblErrorMessage.Text = "Please fill fields and select a Role.";
                lblErrorMessage.Visible = true;
                return;
            }
            UserController userController = new UserController();
            UserModel user = userController.Authenticate(username, password, role);
            if (user != null)
            {
                lblErrorMessage.Visible = false;
                LandingPageForm landingPage = new LandingPageForm();
                landingPage.Show();
                this.Hide();
            }
            else
            {
                lblErrorMessage.Text = "Invalid field or role mismatch.";
                lblErrorMessage.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            using (ExitConfirmDialog confirmDialog = new ExitConfirmDialog())
            {
                DialogResult result = confirmDialog.ShowDialog(this);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}