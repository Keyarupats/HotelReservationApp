namespace HotelReservation
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            lblErrorMessage = new Label();
            btnClear = new Button();
            cmbRole = new ComboBox();
            panel3 = new Panel();
            txtPassword = new TextBox();
            panel2 = new Panel();
            txtUsername = new TextBox();
            btnLogin = new Button();
            label2 = new Label();
            label1 = new Label();
            panel4 = new Panel();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            btnExit = new PictureBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnExit).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblErrorMessage);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(cmbRole);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(495, 71);
            panel1.Name = "panel1";
            panel1.Size = new Size(364, 466);
            panel1.TabIndex = 0;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            lblErrorMessage.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblErrorMessage.ForeColor = SystemColors.ActiveCaptionText;
            lblErrorMessage.Location = new Point(31, 111);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(238, 23);
            lblErrorMessage.TabIndex = 14;
            lblErrorMessage.Text = "Enter a valid data in this fields";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.White;
            btnClear.FlatAppearance.BorderColor = Color.FromArgb(128, 128, 255);
            btnClear.FlatAppearance.BorderSize = 2;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.ForeColor = Color.FromArgb(128, 128, 255);
            btnClear.Location = new Point(32, 375);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(126, 43);
            btnClear.TabIndex = 13;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(32, 309);
            cmbRole.Margin = new Padding(3, 4, 3, 4);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(303, 28);
            cmbRole.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(txtPassword);
            panel3.Location = new Point(26, 229);
            panel3.Name = "panel3";
            panel3.Size = new Size(310, 45);
            panel3.TabIndex = 11;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.ControlLight;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(6, 11);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(283, 27);
            txtPassword.TabIndex = 3;
            txtPassword.Text = "Password";
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(txtUsername);
            panel2.Location = new Point(25, 152);
            panel2.Name = "panel2";
            panel2.Size = new Size(310, 45);
            panel2.TabIndex = 10;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.ControlLight;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Location = new Point(6, 9);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(283, 27);
            txtUsername.TabIndex = 3;
            txtUsername.Text = "Username";
            txtUsername.Enter += txtUsername_Enter;
            txtUsername.Leave += txtUsername_Leave;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(128, 128, 255);
            btnLogin.ForeColor = SystemColors.ButtonHighlight;
            btnLogin.Location = new Point(186, 375);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(126, 43);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 60);
            label2.Name = "label2";
            label2.Size = new Size(138, 38);
            label2.TabIndex = 1;
            label2.Text = "Welcome";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.AppWorkspace;
            label1.Location = new Point(17, 35);
            label1.Name = "label1";
            label1.Size = new Size(196, 23);
            label1.TabIndex = 0;
            label1.Text = "please enter your details";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(128, 128, 255);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(-7, -3);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(445, 627);
            panel4.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Variable Display", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(107, 261);
            label7.Name = "label7";
            label7.Size = new Size(290, 63);
            label7.TabIndex = 2;
            label7.Text = "Reservation";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Variable Display", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(107, 319);
            label6.Name = "label6";
            label6.Size = new Size(118, 63);
            label6.TabIndex = 1;
            label6.Text = "App";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Variable Display", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(107, 196);
            label3.Name = "label3";
            label3.Size = new Size(149, 63);
            label3.TabIndex = 0;
            label3.Text = "Hotel";
            // 
            // btnExit
            // 
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.Location = new Point(873, 15);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(30, 30);
            btnExit.SizeMode = PictureBoxSizeMode.StretchImage;
            btnExit.TabIndex = 2;
            btnExit.TabStop = false;
            btnExit.Click += btnExit_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 616);
            Controls.Add(btnExit);
            Controls.Add(panel4);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginPageForm";
            Load += LoginPageForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btnExit).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private TextBox txtUsername;
        private Button btnLogin;
        private Panel panel2;
        private Panel panel3;
        private TextBox txtPassword;
        private Panel panel4;
        private ComboBox cmbRole;
        private Label label7;
        private Label label6;
        private Label label3;
        private Button btnClear;
        private Label lblErrorMessage;
        private PictureBox btnExit;
    }
}