using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace UI
{
    partial class GuestDirectoryControl
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            lblTitleLeft = new Label();
            lblGuestCode = new Label();
            txtGuestCode = new TextBox();
            lblMobile = new Label();
            txtMobileNumber = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblMI = new Label();
            txtMI = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblIDType = new Label();
            cmbIDType = new ComboBox();
            lblIDNum = new Label();
            txtIDNumber = new TextBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            pnlRight = new Panel();
            lblTitleRight = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvGuests = new DataGridView();
            chkShowDeleted = new CheckBox();
            lblTotalCount = new Label();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            ((ISupportInitialize)dgvGuests).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(lblTitleLeft);
            pnlLeft.Controls.Add(lblGuestCode);
            pnlLeft.Controls.Add(txtGuestCode);
            pnlLeft.Controls.Add(lblMobile);
            pnlLeft.Controls.Add(txtMobileNumber);
            pnlLeft.Controls.Add(lblFirstName);
            pnlLeft.Controls.Add(txtFirstName);
            pnlLeft.Controls.Add(lblLastName);
            pnlLeft.Controls.Add(txtLastName);
            pnlLeft.Controls.Add(lblMI);
            pnlLeft.Controls.Add(txtMI);
            pnlLeft.Controls.Add(lblAge);
            pnlLeft.Controls.Add(txtAge);
            pnlLeft.Controls.Add(lblEmail);
            pnlLeft.Controls.Add(txtEmail);
            pnlLeft.Controls.Add(lblAddress);
            pnlLeft.Controls.Add(txtAddress);
            pnlLeft.Controls.Add(lblIDType);
            pnlLeft.Controls.Add(cmbIDType);
            pnlLeft.Controls.Add(lblIDNum);
            pnlLeft.Controls.Add(txtIDNumber);
            pnlLeft.Controls.Add(btnSave);
            pnlLeft.Controls.Add(btnUpdate);
            pnlLeft.Controls.Add(btnDelete);
            pnlLeft.Controls.Add(btnClear);
            pnlLeft.Location = new Point(40, 48);
            pnlLeft.Margin = new Padding(3, 4, 3, 4);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(541, 756);
            pnlLeft.TabIndex = 0;
            // 
            // lblTitleLeft
            // 
            lblTitleLeft.AutoSize = true;
            lblTitleLeft.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitleLeft.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitleLeft.Location = new Point(29, 8);
            lblTitleLeft.Name = "lblTitleLeft";
            lblTitleLeft.Size = new Size(279, 37);
            lblTitleLeft.TabIndex = 0;
            lblTitleLeft.Text = "Guest Profile Details";
            // 
            // lblGuestCode
            // 
            lblGuestCode.AutoSize = true;
            lblGuestCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGuestCode.ForeColor = Color.FromArgb(51, 65, 85);
            lblGuestCode.Location = new Point(29, 68);
            lblGuestCode.Name = "lblGuestCode";
            lblGuestCode.Size = new Size(101, 23);
            lblGuestCode.TabIndex = 1;
            lblGuestCode.Text = "Guest Code";
            // 
            // txtGuestCode
            // 
            txtGuestCode.BackColor = Color.Silver;
            txtGuestCode.BorderStyle = BorderStyle.FixedSingle;
            txtGuestCode.Font = new Font("Segoe UI", 11F);
            txtGuestCode.Location = new Point(29, 101);
            txtGuestCode.Margin = new Padding(3, 4, 3, 4);
            txtGuestCode.Name = "txtGuestCode";
            txtGuestCode.ReadOnly = true;
            txtGuestCode.Size = new Size(219, 32);
            txtGuestCode.TabIndex = 2;
            // 
            // lblMobile
            // 
            lblMobile.AutoSize = true;
            lblMobile.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMobile.ForeColor = Color.FromArgb(51, 65, 85);
            lblMobile.Location = new Point(254, 68);
            lblMobile.Name = "lblMobile";
            lblMobile.Size = new Size(254, 23);
            lblMobile.TabIndex = 3;
            lblMobile.Text = "Mobile Number (Primary ID) *";
            // 
            // txtMobileNumber
            // 
            txtMobileNumber.BackColor = Color.Silver;
            txtMobileNumber.BorderStyle = BorderStyle.FixedSingle;
            txtMobileNumber.Font = new Font("Segoe UI", 11F);
            txtMobileNumber.Location = new Point(254, 101);
            txtMobileNumber.Margin = new Padding(3, 4, 3, 4);
            txtMobileNumber.MaxLength = 11;
            txtMobileNumber.Name = "txtMobileNumber";
            txtMobileNumber.Size = new Size(226, 32);
            txtMobileNumber.TabIndex = 4;
            txtMobileNumber.Leave += txtMobileNumber_Leave;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(51, 65, 85);
            lblFirstName.Location = new Point(29, 168);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(110, 23);
            lblFirstName.TabIndex = 5;
            lblFirstName.Text = "First Name *";
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.Silver;
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Segoe UI", 11F);
            txtFirstName.Location = new Point(29, 201);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(161, 32);
            txtFirstName.TabIndex = 6;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(51, 65, 85);
            lblLastName.Location = new Point(196, 168);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(107, 23);
            lblLastName.TabIndex = 7;
            lblLastName.Text = "Last Name *";
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.Silver;
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Segoe UI", 11F);
            txtLastName.Location = new Point(196, 201);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(170, 32);
            txtLastName.TabIndex = 8;
            // 
            // lblMI
            // 
            lblMI.AutoSize = true;
            lblMI.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMI.ForeColor = Color.FromArgb(51, 65, 85);
            lblMI.Location = new Point(383, 168);
            lblMI.Name = "lblMI";
            lblMI.Size = new Size(41, 23);
            lblMI.TabIndex = 9;
            lblMI.Text = "M.I.";
            // 
            // txtMI
            // 
            txtMI.BackColor = Color.Silver;
            txtMI.BorderStyle = BorderStyle.FixedSingle;
            txtMI.Font = new Font("Segoe UI", 11F);
            txtMI.Location = new Point(383, 201);
            txtMI.Margin = new Padding(3, 4, 3, 4);
            txtMI.MaxLength = 5;
            txtMI.Name = "txtMI";
            txtMI.Size = new Size(97, 32);
            txtMI.TabIndex = 10;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAge.ForeColor = Color.FromArgb(51, 65, 85);
            lblAge.Location = new Point(29, 268);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(55, 23);
            lblAge.TabIndex = 11;
            lblAge.Text = "Age *";
            // 
            // txtAge
            // 
            txtAge.BackColor = Color.Silver;
            txtAge.BorderStyle = BorderStyle.FixedSingle;
            txtAge.Font = new Font("Segoe UI", 11F);
            txtAge.Location = new Point(29, 301);
            txtAge.Margin = new Padding(3, 4, 3, 4);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(114, 32);
            txtAge.TabIndex = 12;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(51, 65, 85);
            lblEmail.Location = new Point(166, 268);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(136, 23);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email Address *";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.Silver;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(166, 301);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(314, 32);
            txtEmail.TabIndex = 14;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAddress.ForeColor = Color.FromArgb(51, 65, 85);
            lblAddress.Location = new Point(29, 368);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(263, 23);
            lblAddress.TabIndex = 15;
            lblAddress.Text = "Complete Residential Address *";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.Silver;
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 11F);
            txtAddress.Location = new Point(29, 401);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(451, 79);
            txtAddress.TabIndex = 16;
            // 
            // lblIDType
            // 
            lblIDType.AutoSize = true;
            lblIDType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIDType.ForeColor = Color.FromArgb(51, 65, 85);
            lblIDType.Location = new Point(29, 515);
            lblIDType.Name = "lblIDType";
            lblIDType.Size = new Size(84, 23);
            lblIDType.TabIndex = 17;
            lblIDType.Text = "ID Type *";
            // 
            // cmbIDType
            // 
            cmbIDType.BackColor = Color.Silver;
            cmbIDType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIDType.Font = new Font("Segoe UI", 11F);
            cmbIDType.FormattingEnabled = true;
            cmbIDType.Items.AddRange(new object[] { "Driver's License", "Passport", "National ID", "SSS ID", "GSIS ID" });
            cmbIDType.Location = new Point(29, 548);
            cmbIDType.Margin = new Padding(3, 4, 3, 4);
            cmbIDType.Name = "cmbIDType";
            cmbIDType.Size = new Size(219, 33);
            cmbIDType.TabIndex = 18;
            // 
            // lblIDNum
            // 
            lblIDNum.AutoSize = true;
            lblIDNum.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIDNum.ForeColor = Color.FromArgb(51, 65, 85);
            lblIDNum.Location = new Point(254, 516);
            lblIDNum.Name = "lblIDNum";
            lblIDNum.Size = new Size(185, 23);
            lblIDNum.TabIndex = 19;
            lblIDNum.Text = "ID Number / Ref No *";
            // 
            // txtIDNumber
            // 
            txtIDNumber.BackColor = Color.Silver;
            txtIDNumber.BorderStyle = BorderStyle.FixedSingle;
            txtIDNumber.Font = new Font("Segoe UI", 11F);
            txtIDNumber.Location = new Point(254, 549);
            txtIDNumber.Margin = new Padding(3, 4, 3, 4);
            txtIDNumber.Name = "txtIDNumber";
            txtIDNumber.Size = new Size(226, 32);
            txtIDNumber.TabIndex = 20;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(34, 197, 94);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(50, 599);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(189, 60);
            btnSave.TabIndex = 21;
            btnSave.Text = "➕ Save New Guest";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(2, 132, 199);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(254, 599);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(189, 60);
            btnUpdate.TabIndex = 22;
            btnUpdate.Text = "💾 Update Profile";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(239, 68, 68);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(50, 679);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(189, 60);
            btnDelete.TabIndex = 23;
            btnDelete.Text = "🗑 Archive (Soft Delete)";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(100, 116, 139);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(254, 679);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(189, 60);
            btnClear.TabIndex = 24;
            btnClear.Text = "↺ Clear Form";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.BorderStyle = BorderStyle.FixedSingle;
            pnlRight.Controls.Add(lblTitleRight);
            pnlRight.Controls.Add(txtSearch);
            pnlRight.Controls.Add(btnSearch);
            pnlRight.Controls.Add(dgvGuests);
            pnlRight.Controls.Add(chkShowDeleted);
            pnlRight.Controls.Add(lblTotalCount);
            pnlRight.Location = new Point(620, 48);
            pnlRight.Margin = new Padding(3, 4, 3, 4);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(1260, 756);
            pnlRight.TabIndex = 1;
            // 
            // lblTitleRight
            // 
            lblTitleRight.AutoSize = true;
            lblTitleRight.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitleRight.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitleRight.Location = new Point(18, 14);
            lblTitleRight.Name = "lblTitleRight";
            lblTitleRight.Size = new Size(219, 37);
            lblTitleRight.TabIndex = 0;
            lblTitleRight.Text = "Guest Directory";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(634, 19);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by name, mobile, email, or guest code...";
            txtSearch.Size = new Size(457, 32);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(2, 132, 199);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1108, 15);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(126, 44);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvGuests
            // 
            dgvGuests.AllowUserToAddRows = false;
            dgvGuests.AllowUserToDeleteRows = false;
            dgvGuests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGuests.BackgroundColor = Color.FromArgb(248, 250, 252);
            dgvGuests.ColumnHeadersHeight = 40;
            dgvGuests.Location = new Point(23, 77);
            dgvGuests.Margin = new Padding(3, 4, 3, 4);
            dgvGuests.MultiSelect = false;
            dgvGuests.Name = "dgvGuests";
            dgvGuests.ReadOnly = true;
            dgvGuests.RowHeadersVisible = false;
            dgvGuests.RowHeadersWidth = 51;
            dgvGuests.RowTemplate.Height = 35;
            dgvGuests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGuests.Size = new Size(1211, 626);
            dgvGuests.TabIndex = 3;
            dgvGuests.CellClick += dgvGuests_CellClick;
            // 
            // chkShowDeleted
            // 
            chkShowDeleted.AutoSize = true;
            chkShowDeleted.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkShowDeleted.ForeColor = Color.FromArgb(51, 65, 85);
            chkShowDeleted.Location = new Point(848, 711);
            chkShowDeleted.Margin = new Padding(3, 4, 3, 4);
            chkShowDeleted.Name = "chkShowDeleted";
            chkShowDeleted.Size = new Size(393, 27);
            chkShowDeleted.TabIndex = 4;
            chkShowDeleted.Text = "Include Inactive / Soft-Deleted (Admin View)";
            chkShowDeleted.UseVisualStyleBackColor = true;
            chkShowDeleted.CheckedChanged += chkShowDeleted_CheckedChanged;
            // 
            // lblTotalCount
            // 
            lblTotalCount.AutoSize = true;
            lblTotalCount.Font = new Font("Segoe UI", 10F);
            lblTotalCount.ForeColor = Color.FromArgb(100, 116, 139);
            lblTotalCount.Location = new Point(36, 716);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(120, 23);
            lblTotalCount.TabIndex = 5;
            lblTotalCount.Text = "Total Guests: 0";
            // 
            // GuestDirectoryControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(pnlLeft);
            Controls.Add(pnlRight);
            Margin = new Padding(3, 4, 3, 4);
            Name = "GuestDirectoryControl";
            Size = new Size(1920, 881);
            Load += GuestDirectoryControl_Load;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((ISupportInitialize)dgvGuests).EndInit();
            ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblTitleLeft;
        private System.Windows.Forms.Label lblGuestCode;
        private System.Windows.Forms.TextBox txtGuestCode;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblMI;
        private System.Windows.Forms.TextBox txtMI;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblIDType;
        private System.Windows.Forms.ComboBox cmbIDType;
        private System.Windows.Forms.Label lblIDNum;
        private System.Windows.Forms.TextBox txtIDNumber;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTitleRight;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvGuests;
        private System.Windows.Forms.CheckBox chkShowDeleted;
        private System.Windows.Forms.Label lblTotalCount;
    }
}