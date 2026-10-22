using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class LandingPageForm : Form
    {
        public LandingPageForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblRoom_Click(object sender, EventArgs e)
        {

        }

        private void LandingPageForm_Load(object sender, EventArgs e)
        {
            LoadUserContorl(new RoomsUserControl());

        }

        private void LoadUserContorl(UserControl uc) 
        { 
            pnlContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
