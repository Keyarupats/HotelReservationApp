namespace HotelReswervation
{
    partial class GuestLookup
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
            panel3 = new Panel();
            label2 = new Label();
            panel6 = new Panel();
            dgvGuests = new DataGridView();
            panel7 = new Panel();
            lblGuestsCount = new Label();
            label5 = new Label();
            label6 = new Label();
            panel5 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            label13 = new Label();
            txtAddress = new TextBox();
            txtAge = new TextBox();
            label12 = new Label();
            label11 = new Label();
            txtFirstName = new TextBox();
            label10 = new Label();
            btnSearch = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            label9 = new Label();
            txtIDNum = new TextBox();
            label8 = new Label();
            cmbIDType = new ComboBox();
            btnSave = new Button();
            label7 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtLastName = new TextBox();
            label3 = new Label();
            txtSearch = new TextBox();
            txtMI = new TextBox();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuests).BeginInit();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(128, 128, 255);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(12, 63);
            panel3.Name = "panel3";
            panel3.Size = new Size(333, 34);
            panel3.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(3, 8);
            label2.Name = "label2";
            label2.Size = new Size(187, 20);
            label2.TabIndex = 2;
            label2.Text = "Guests Profile Lookup";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(192, 192, 255);
            panel6.Controls.Add(dgvGuests);
            panel6.Controls.Add(panel7);
            panel6.Location = new Point(360, 63);
            panel6.Name = "panel6";
            panel6.Size = new Size(758, 522);
            panel6.TabIndex = 7;
            // 
            // dgvGuests
            // 
            dgvGuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGuests.Location = new Point(3, 40);
            dgvGuests.Name = "dgvGuests";
            dgvGuests.ReadOnly = true;
            dgvGuests.RowHeadersWidth = 47;
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.Size = new Size(752, 479);
            dgvGuests.TabIndex = 7;
            dgvGuests.CellClick += dgvGuests_CellClick;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(128, 128, 255);
            panel7.Controls.Add(lblGuestsCount);
            panel7.Controls.Add(label5);
            panel7.Controls.Add(label6);
            panel7.Location = new Point(1, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(757, 34);
            panel7.TabIndex = 4;
            // 
            // lblGuestsCount
            // 
            lblGuestsCount.AutoSize = true;
            lblGuestsCount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lblGuestsCount.ForeColor = SystemColors.ButtonHighlight;
            lblGuestsCount.Location = new Point(725, 8);
            lblGuestsCount.Name = "lblGuestsCount";
            lblGuestsCount.Size = new Size(29, 20);
            lblGuestsCount.TabIndex = 8;
            lblGuestsCount.Text = "52";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(3, 8);
            label5.Name = "label5";
            label5.Size = new Size(208, 20);
            label5.TabIndex = 2;
            label5.Text = "Lists of Guests Directory";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(561, 8);
            label6.Name = "label6";
            label6.Size = new Size(176, 20);
            label6.TabIndex = 6;
            label6.Text = "Total Active Guests: ";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(192, 192, 255);
            panel5.Controls.Add(panel2);
            panel5.Location = new Point(12, 63);
            panel5.Name = "panel5";
            panel5.Size = new Size(333, 522);
            panel5.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(txtAddress);
            panel2.Controls.Add(txtAge);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(txtFirstName);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(btnSearch);
            panel2.Controls.Add(btnClear);
            panel2.Controls.Add(btnDelete);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(txtIDNum);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(cmbIDType);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtEmail);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtLastName);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtSearch);
            panel2.Location = new Point(3, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(327, 482);
            panel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(262, 159);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 28;
            label1.Text = "Age:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label13.ForeColor = SystemColors.ActiveCaptionText;
            label13.Location = new Point(14, 157);
            label13.Name = "label13";
            label13.Size = new Size(62, 15);
            label13.TabIndex = 26;
            label13.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtAddress.Location = new Point(14, 176);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(242, 26);
            txtAddress.TabIndex = 25;
            // 
            // txtAge
            // 
            txtAge.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtAge.Location = new Point(260, 177);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(50, 26);
            txtAge.TabIndex = 27;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label12.ForeColor = SystemColors.ActiveCaptionText;
            label12.Location = new Point(263, 105);
            label12.Name = "label12";
            label12.Size = new Size(27, 15);
            label12.TabIndex = 24;
            label12.Text = "MI:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label11.ForeColor = SystemColors.ActiveCaptionText;
            label11.Location = new Point(13, 103);
            label11.Name = "label11";
            label11.Size = new Size(81, 15);
            label11.TabIndex = 22;
            label11.Text = "First Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtFirstName.Location = new Point(13, 122);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(242, 26);
            txtFirstName.TabIndex = 21;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(192, 0, 0);
            label10.Location = new Point(97, 54);
            label10.Name = "label10";
            label10.Size = new Size(176, 15);
            label10.TabIndex = 20;
            label10.Text = "(Lastname, Firstname MI.)";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(128, 255, 255);
            btnSearch.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 192);
            btnSearch.FlatAppearance.BorderSize = 2;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = SystemColors.ActiveCaptionText;
            btnSearch.Location = new Point(219, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(92, 30);
            btnSearch.TabIndex = 19;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Silver;
            btnClear.FlatAppearance.BorderColor = Color.Gray;
            btnClear.FlatAppearance.BorderSize = 2;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = SystemColors.ButtonFace;
            btnClear.Location = new Point(165, 429);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(146, 43);
            btnClear.TabIndex = 18;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 128, 128);
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(192, 0, 0);
            btnDelete.FlatAppearance.BorderSize = 2;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = SystemColors.ButtonFace;
            btnDelete.Location = new Point(13, 429);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(146, 43);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label9.ForeColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(16, 322);
            label9.Name = "label9";
            label9.Size = new Size(80, 15);
            label9.TabIndex = 16;
            label9.Text = "ID Number:";
            // 
            // txtIDNum
            // 
            txtIDNum.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtIDNum.Location = new Point(13, 342);
            txtIDNum.Name = "txtIDNum";
            txtIDNum.Size = new Size(298, 26);
            txtIDNum.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(19, 263);
            label8.Name = "label8";
            label8.Size = new Size(59, 15);
            label8.TabIndex = 14;
            label8.Text = "ID Type:";
            // 
            // cmbIDType
            // 
            cmbIDType.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cmbIDType.FormattingEnabled = true;
            cmbIDType.Items.AddRange(new object[] { "Driver Licence", "Pasport", "National ID", "SSS ID", "GSIS ID" });
            cmbIDType.Location = new Point(13, 281);
            cmbIDType.Name = "cmbIDType";
            cmbIDType.Size = new Size(298, 28);
            cmbIDType.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(128, 255, 128);
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            btnSave.FlatAppearance.BorderSize = 2;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(13, 380);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(298, 43);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save / Update Profile";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(15, 205);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 11;
            label7.Text = "Email Address:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtEmail.Location = new Point(13, 225);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(298, 26);
            txtEmail.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(14, 54);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 9;
            label4.Text = "Last Name:";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtLastName.Location = new Point(13, 73);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(298, 26);
            txtLastName.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(11, 2);
            label3.Name = "label3";
            label3.Size = new Size(110, 15);
            label3.TabIndex = 7;
            label3.Text = "Mobile Number:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(13, 21);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 29);
            txtSearch.TabIndex = 0;
            txtSearch.Leave += txtSearch_Leave;
            // 
            // txtMI
            // 
            txtMI.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtMI.Location = new Point(276, 222);
            txtMI.Name = "txtMI";
            txtMI.Size = new Size(50, 26);
            txtMI.TabIndex = 23;
            // 
            // GuestLookup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 597);
            Controls.Add(panel3);
            Controls.Add(txtMI);
            Controls.Add(panel6);
            Controls.Add(panel5);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "GuestLookup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frontdesk View";
            Load += GuestLookup_Load_1;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGuests).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel3;
        private Label label2;
        private Panel panel6;
        private DataGridView dgvGuests;
        private Panel panel7;
        private Label lblGuestsCount;
        private Label label5;
        private Label label6;
        private Panel panel5;
        private Panel panel2;
        private Button btnSave;
        private Label label7;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtLastName;
        private Label label3;
        private TextBox txtSearch;
        private Button btnClear;
        private Button btnDelete;
        private Label label9;
        private TextBox txtIDNum;
        private Label label8;
        private ComboBox cmbIDType;
        private Button btnSearch;
        private Label label10;
        private Label label12;
        private Label label11;
        private TextBox txtFirstName;
        private TextBox txtMI;
        private Label label1;
        private Label label13;
        private TextBox txtAddress;
        private TextBox txtAge;
    }
}