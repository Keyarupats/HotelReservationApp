namespace UI
{
    partial class RoomsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblRoomType = new Label();
            cmbRoomType = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            flpRooms = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblRoomType
            // 
            lblRoomType.AutoSize = true;
            lblRoomType.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomType.Location = new Point(46, 25);
            lblRoomType.Name = "lblRoomType";
            lblRoomType.Size = new Size(127, 30);
            lblRoomType.TabIndex = 1;
            lblRoomType.Text = "Room Type:";
            // 
            // cmbRoomType
            // 
            cmbRoomType.Font = new Font("Segoe UI", 13.7454548F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Items.AddRange(new object[] { "All", "Available", "Reserved", "Occupied", "Cleaning ", "Maintenance" });
            cmbRoomType.Location = new Point(198, 22);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(261, 38);
            cmbRoomType.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.7454548F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(1704, 30);
            label1.Name = "label1";
            label1.Size = new Size(134, 30);
            label1.TabIndex = 3;
            label1.Text = "Maintenance";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.7454548F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1514, 30);
            label2.Name = "label2";
            label2.Size = new Size(94, 30);
            label2.TabIndex = 4;
            label2.Text = "Cleaning";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.7454548F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(1314, 30);
            label3.Name = "label3";
            label3.Size = new Size(101, 30);
            label3.TabIndex = 5;
            label3.Text = "Occupied";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.7454548F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(1129, 30);
            label4.Name = "label4";
            label4.Size = new Size(96, 30);
            label4.TabIndex = 6;
            label4.Text = "Reserved";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.7454548F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(947, 30);
            label5.Name = "label5";
            label5.Size = new Size(97, 30);
            label5.TabIndex = 7;
            label5.Text = "Available";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Green;
            panel1.Location = new Point(923, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(20, 20);
            panel1.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Blue;
            panel2.Location = new Point(1103, 36);
            panel2.Name = "panel2";
            panel2.Size = new Size(20, 20);
            panel2.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Red;
            panel3.Location = new Point(1288, 36);
            panel3.Name = "panel3";
            panel3.Size = new Size(20, 20);
            panel3.TabIndex = 10;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gold;
            panel4.Location = new Point(1488, 36);
            panel4.Name = "panel4";
            panel4.Size = new Size(20, 20);
            panel4.TabIndex = 11;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlDarkDark;
            panel5.Location = new Point(1678, 36);
            panel5.Name = "panel5";
            panel5.Size = new Size(20, 20);
            panel5.TabIndex = 12;
            // 
            // flpRooms
            // 
            flpRooms.AutoScroll = true;
            flpRooms.Dock = DockStyle.Bottom;
            flpRooms.Location = new Point(0, 93);
            flpRooms.Name = "flpRooms";
            flpRooms.Size = new Size(1920, 792);
            flpRooms.TabIndex = 13;
            // 
            // RoomsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            Controls.Add(flpRooms);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbRoomType);
            Controls.Add(lblRoomType);
            Name = "RoomsUserControl";
            Size = new Size(1920, 885);
            Load += RoomsUserControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoomType;
        private ComboBox cmbRoomType;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private FlowLayoutPanel flpRooms;
    }
}
