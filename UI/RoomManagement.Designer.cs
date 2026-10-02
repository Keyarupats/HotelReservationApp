namespace HotelReservation
{
    partial class RoomManagement
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
            panel1 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            panel2 = new Panel();
            label8 = new Label();
            txtStatus = new TextBox();
            btnSave = new Button();
            label7 = new Label();
            txtBaseRate = new TextBox();
            label4 = new Label();
            txtCategory = new TextBox();
            label3 = new Label();
            txtRoomNumber = new TextBox();
            panel6 = new Panel();
            dgvRoomDirectory = new DataGridView();
            label6 = new Label();
            cmbRoomType = new ComboBox();
            panel7 = new Panel();
            label5 = new Label();
            panel3 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomDirectory).BeginInit();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(187, 34);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label1.Location = new Point(4, 8);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 0;
            label1.Text = "Total Rooms:";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(192, 192, 255);
            panel5.Controls.Add(panel2);
            panel5.Location = new Point(12, 63);
            panel5.Name = "panel5";
            panel5.Size = new Size(447, 522);
            panel5.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtStatus);
            panel2.Controls.Add(btnSave);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(txtBaseRate);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtCategory);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtRoomNumber);
            panel2.Location = new Point(3, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(441, 482);
            panel2.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label8.ForeColor = SystemColors.ActiveCaptionText;
            label8.Location = new Point(32, 314);
            label8.Name = "label8";
            label8.Size = new Size(132, 20);
            label8.TabIndex = 14;
            label8.Text = "Current Status:";
            // 
            // txtStatus
            // 
            txtStatus.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtStatus.Location = new Point(35, 334);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(350, 26);
            txtStatus.TabIndex = 13;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(128, 255, 128);
            btnSave.Enabled = false;
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            btnSave.FlatAppearance.BorderSize = 2;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(78, 399);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(280, 43);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save / Update Rate";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(34, 227);
            label7.Name = "label7";
            label7.Size = new Size(156, 20);
            label7.TabIndex = 11;
            label7.Text = "Base Rate / Night:";
            // 
            // txtBaseRate
            // 
            txtBaseRate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtBaseRate.Location = new Point(37, 247);
            txtBaseRate.Name = "txtBaseRate";
            txtBaseRate.ReadOnly = true;
            txtBaseRate.Size = new Size(350, 26);
            txtBaseRate.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(35, 143);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 9;
            label4.Text = "Category:";
            // 
            // txtCategory
            // 
            txtCategory.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtCategory.Location = new Point(37, 166);
            txtCategory.Name = "txtCategory";
            txtCategory.ReadOnly = true;
            txtCategory.Size = new Size(350, 26);
            txtCategory.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(35, 56);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 7;
            label3.Text = "Room Number:";
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            txtRoomNumber.Location = new Point(37, 78);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.ReadOnly = true;
            txtRoomNumber.Size = new Size(350, 26);
            txtRoomNumber.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(192, 192, 255);
            panel6.Controls.Add(dgvRoomDirectory);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(cmbRoomType);
            panel6.Controls.Add(panel7);
            panel6.Location = new Point(478, 63);
            panel6.Name = "panel6";
            panel6.Size = new Size(640, 522);
            panel6.TabIndex = 5;
            // 
            // dgvRoomDirectory
            // 
            dgvRoomDirectory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomDirectory.Location = new Point(3, 82);
            dgvRoomDirectory.Name = "dgvRoomDirectory";
            dgvRoomDirectory.ReadOnly = true;
            dgvRoomDirectory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRoomDirectory.Size = new Size(634, 437);
            dgvRoomDirectory.TabIndex = 7;
            dgvRoomDirectory.CellClick += dgvRoomDirectory_CellClick;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(8, 47);
            label6.Name = "label6";
            label6.Size = new Size(96, 20);
            label6.TabIndex = 6;
            label6.Text = "Room Tier:";
            // 
            // cmbRoomType
            // 
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(105, 44);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(208, 28);
            cmbRoomType.TabIndex = 5;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(128, 128, 255);
            panel7.Controls.Add(label5);
            panel7.Location = new Point(1, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(639, 34);
            panel7.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(3, 8);
            label5.Name = "label5";
            label5.Size = new Size(169, 20);
            label5.TabIndex = 2;
            label5.Text = "Room Invenrory List";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(128, 128, 255);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(12, 63);
            panel3.Name = "panel3";
            panel3.Size = new Size(447, 34);
            panel3.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(3, 8);
            label2.Name = "label2";
            label2.Size = new Size(133, 20);
            label2.TabIndex = 2;
            label2.Text = "Room Category";
            // 
            // RoomManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1130, 597);
            Controls.Add(panel3);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "RoomManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Room Management";
            Load += RoomManagement_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoomDirectory).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel5;
        private Panel panel6;
        private ComboBox cmbRoomType;
        private Panel panel7;
        private Label label5;
        private Label label6;
        private DataGridView dgvRoomDirectory;
        private Panel panel2;
        private Panel panel3;
        private Label label2;
        private Label label3;
        private TextBox txtRoomNumber;
        private Label label7;
        private TextBox txtBaseRate;
        private Label label4;
        private TextBox txtCategory;
        private Button btnSave;
        private Label label8;
        private TextBox txtStatus;
    }
}