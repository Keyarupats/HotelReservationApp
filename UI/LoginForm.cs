using System.Collections;

namespace HotelReswervation
{
    public partial class LoginForm : Form
    {

        ArrayList role;
        public LoginForm()
        {
            InitializeComponent();
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
    }
}
