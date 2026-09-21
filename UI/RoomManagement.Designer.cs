namespace HotelReswervation
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
            panel6 = new Panel();
            dgvRoomDirectory = new DataGridView();
            label6 = new Label();
            cmbRoomType = new ComboBox();
            panel7 = new Panel();
            label5 = new Label();
            panel3 = new Panel();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            label7 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
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
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBox1);
            panel2.Location = new Point(3, 37);
            panel2.Name = "panel2";
            panel2.Size = new Size(441, 482);
            panel2.TabIndex = 5;
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
            cmbRoomType.Items.AddRange(new object[] { "ALL TIER", "STANDARD", "DELUXE", "SUITE" });
            cmbRoomType.Location = new Point(105, 44);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(208, 28);
            cmbRoomType.TabIndex = 5;
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
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            textBox1.Location = new Point(37, 78);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(350, 26);
            textBox1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(35, 56);
            label3.Name = "label3";
            label3.Size = new Size(156, 20);
            label3.TabIndex = 7;
            label3.Text = "Base Rate / Night:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(35, 143);
            label4.Name = "label4";
            label4.Size = new Size(257, 20);
            label4.TabIndex = 9;
            label4.Text = "Rooms in Tier (Total Rooms: 5)";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            textBox2.Location = new Point(37, 166);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(350, 26);
            textBox2.TabIndex = 8;
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
            // textBox3
            // 
            textBox3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            textBox3.Location = new Point(37, 247);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(350, 26);
            textBox3.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 255, 128);
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(72, 342);
            button1.Name = "button1";
            button1.Size = new Size(280, 43);
            button1.TabIndex = 12;
            button1.Text = "Save / Update Rate";
            button1.UseVisualStyleBackColor = false;
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
        private TextBox textBox1;
        private Label label7;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Button button1;
    }
}