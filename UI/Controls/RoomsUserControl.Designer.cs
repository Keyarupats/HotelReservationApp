namespace UI
{
    partial class RoomsUserControl
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
            lblRoomTier = new Label();
            cmbRoomType = new ComboBox();
            lblViewDate = new Label();
            dtpViewDate = new DateTimePicker();
            lblAvailable = new Label();
            pnlColorAvailable = new Panel();
            pnlUnderlineAvailable = new Panel();
            lblReserved = new Label();
            pnlColorReserved = new Panel();
            pnlUnderlineReserved = new Panel();
            lblOccupied = new Label();
            pnlColorOccupied = new Panel();
            pnlUnderlineOccupied = new Panel();
            lblCleaning = new Label();
            pnlColorCleaning = new Panel();
            pnlUnderlineCleaning = new Panel();
            lblMaintenance = new Label();
            pnlColorMaintenance = new Panel();
            pnlUnderlineMaintenance = new Panel();
            btnEditRates = new Button();
            flpRooms = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblRoomTier
            // 
            lblRoomTier.AutoSize = true;
            lblRoomTier.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblRoomTier.Location = new Point(30, 23);
            lblRoomTier.Name = "lblRoomTier";
            lblRoomTier.Size = new Size(111, 28);
            lblRoomTier.TabIndex = 1;
            lblRoomTier.Text = "Room Tier:";
            // 
            // cmbRoomType
            // 
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.Font = new Font("Segoe UI", 11F);
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(147, 22);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(160, 33);
            cmbRoomType.TabIndex = 2;
            cmbRoomType.SelectedIndexChanged += cmbRoomType_SelectedIndexChanged;
            // 
            // lblViewDate
            // 
            lblViewDate.AutoSize = true;
            lblViewDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblViewDate.Location = new Point(326, 23);
            lblViewDate.Name = "lblViewDate";
            lblViewDate.Size = new Size(59, 28);
            lblViewDate.TabIndex = 3;
            lblViewDate.Text = "Date:";
            // 
            // dtpViewDate
            // 
            dtpViewDate.CustomFormat = "yyyy-MM-dd";
            dtpViewDate.Font = new Font("Segoe UI", 11F);
            dtpViewDate.Location = new Point(391, 20);
            dtpViewDate.Name = "dtpViewDate";
            dtpViewDate.Size = new Size(312, 32);
            dtpViewDate.TabIndex = 4;
            dtpViewDate.ValueChanged += dtpViewDate_ValueChanged;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.Cursor = Cursors.Hand;
            lblAvailable.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAvailable.Location = new Point(1045, 26);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(92, 25);
            lblAvailable.TabIndex = 6;
            lblAvailable.Text = "Available";
            lblAvailable.Click += lblAvailable_Click;
            // 
            // pnlColorAvailable
            // 
            pnlColorAvailable.BackColor = Color.Green;
            pnlColorAvailable.Location = new Point(1027, 28);
            pnlColorAvailable.Name = "pnlColorAvailable";
            pnlColorAvailable.Size = new Size(14, 15);
            pnlColorAvailable.TabIndex = 5;
            // 
            // pnlUnderlineAvailable
            // 
            pnlUnderlineAvailable.BackColor = Color.Green;
            pnlUnderlineAvailable.Location = new Point(1027, 50);
            pnlUnderlineAvailable.Name = "pnlUnderlineAvailable";
            pnlUnderlineAvailable.Size = new Size(95, 4);
            pnlUnderlineAvailable.TabIndex = 7;
            pnlUnderlineAvailable.Visible = false;
            // 
            // lblReserved
            // 
            lblReserved.AutoSize = true;
            lblReserved.Cursor = Cursors.Hand;
            lblReserved.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblReserved.Location = new Point(1175, 26);
            lblReserved.Name = "lblReserved";
            lblReserved.Size = new Size(93, 25);
            lblReserved.TabIndex = 9;
            lblReserved.Text = "Reserved";
            lblReserved.Click += lblReserved_Click;
            // 
            // pnlColorReserved
            // 
            pnlColorReserved.BackColor = Color.Blue;
            pnlColorReserved.Location = new Point(1157, 28);
            pnlColorReserved.Name = "pnlColorReserved";
            pnlColorReserved.Size = new Size(14, 15);
            pnlColorReserved.TabIndex = 8;
            // 
            // pnlUnderlineReserved
            // 
            pnlUnderlineReserved.BackColor = Color.Blue;
            pnlUnderlineReserved.Location = new Point(1157, 50);
            pnlUnderlineReserved.Name = "pnlUnderlineReserved";
            pnlUnderlineReserved.Size = new Size(95, 4);
            pnlUnderlineReserved.TabIndex = 10;
            pnlUnderlineReserved.Visible = false;
            // 
            // lblOccupied
            // 
            lblOccupied.AutoSize = true;
            lblOccupied.Cursor = Cursors.Hand;
            lblOccupied.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblOccupied.Location = new Point(1305, 26);
            lblOccupied.Name = "lblOccupied";
            lblOccupied.Size = new Size(95, 25);
            lblOccupied.TabIndex = 12;
            lblOccupied.Text = "Occupied";
            lblOccupied.Click += lblOccupied_Click;
            // 
            // pnlColorOccupied
            // 
            pnlColorOccupied.BackColor = Color.Red;
            pnlColorOccupied.Location = new Point(1287, 28);
            pnlColorOccupied.Name = "pnlColorOccupied";
            pnlColorOccupied.Size = new Size(14, 15);
            pnlColorOccupied.TabIndex = 11;
            // 
            // pnlUnderlineOccupied
            // 
            pnlUnderlineOccupied.BackColor = Color.Red;
            pnlUnderlineOccupied.Location = new Point(1287, 50);
            pnlUnderlineOccupied.Name = "pnlUnderlineOccupied";
            pnlUnderlineOccupied.Size = new Size(95, 4);
            pnlUnderlineOccupied.TabIndex = 13;
            pnlUnderlineOccupied.Visible = false;
            // 
            // lblCleaning
            // 
            lblCleaning.AutoSize = true;
            lblCleaning.Cursor = Cursors.Hand;
            lblCleaning.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCleaning.Location = new Point(1435, 26);
            lblCleaning.Name = "lblCleaning";
            lblCleaning.Size = new Size(90, 25);
            lblCleaning.TabIndex = 15;
            lblCleaning.Text = "Cleaning";
            lblCleaning.Click += lblCleaning_Click;
            // 
            // pnlColorCleaning
            // 
            pnlColorCleaning.BackColor = Color.Gold;
            pnlColorCleaning.Location = new Point(1417, 28);
            pnlColorCleaning.Name = "pnlColorCleaning";
            pnlColorCleaning.Size = new Size(14, 15);
            pnlColorCleaning.TabIndex = 14;
            // 
            // pnlUnderlineCleaning
            // 
            pnlUnderlineCleaning.BackColor = Color.Gold;
            pnlUnderlineCleaning.Location = new Point(1417, 50);
            pnlUnderlineCleaning.Name = "pnlUnderlineCleaning";
            pnlUnderlineCleaning.Size = new Size(90, 4);
            pnlUnderlineCleaning.TabIndex = 16;
            pnlUnderlineCleaning.Visible = false;
            // 
            // lblMaintenance
            // 
            lblMaintenance.AutoSize = true;
            lblMaintenance.Cursor = Cursors.Hand;
            lblMaintenance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMaintenance.Location = new Point(1560, 26);
            lblMaintenance.Name = "lblMaintenance";
            lblMaintenance.Size = new Size(127, 25);
            lblMaintenance.TabIndex = 18;
            lblMaintenance.Text = "Maintenance";
            lblMaintenance.Click += lblMaintenance_Click;
            // 
            // pnlColorMaintenance
            // 
            pnlColorMaintenance.BackColor = SystemColors.ControlDarkDark;
            pnlColorMaintenance.Location = new Point(1542, 28);
            pnlColorMaintenance.Name = "pnlColorMaintenance";
            pnlColorMaintenance.Size = new Size(14, 15);
            pnlColorMaintenance.TabIndex = 17;
            // 
            // pnlUnderlineMaintenance
            // 
            pnlUnderlineMaintenance.BackColor = SystemColors.ControlDarkDark;
            pnlUnderlineMaintenance.Location = new Point(1542, 50);
            pnlUnderlineMaintenance.Name = "pnlUnderlineMaintenance";
            pnlUnderlineMaintenance.Size = new Size(120, 4);
            pnlUnderlineMaintenance.TabIndex = 19;
            pnlUnderlineMaintenance.Visible = false;
            // 
            // btnEditRates
            // 
            btnEditRates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditRates.BackColor = Color.FromArgb(2, 132, 199);
            btnEditRates.FlatStyle = FlatStyle.Flat;
            btnEditRates.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditRates.ForeColor = Color.White;
            btnEditRates.Location = new Point(1730, 20);
            btnEditRates.Name = "btnEditRates";
            btnEditRates.Size = new Size(155, 36);
            btnEditRates.TabIndex = 20;
            btnEditRates.Text = "⚙ Adjust Rates";
            btnEditRates.UseVisualStyleBackColor = false;
            btnEditRates.Visible = false;
            btnEditRates.Click += btnEditRates_Click;
            // 
            // flpRooms
            // 
            flpRooms.AutoScroll = true;
            flpRooms.BackColor = Color.Silver;
            flpRooms.Dock = DockStyle.Bottom;
            flpRooms.Location = new Point(0, 64);
            flpRooms.Name = "flpRooms";
            flpRooms.Size = new Size(1920, 817);
            flpRooms.TabIndex = 21;
            // 
            // RoomsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(flpRooms);
            Controls.Add(btnEditRates);
            Controls.Add(pnlUnderlineMaintenance);
            Controls.Add(pnlUnderlineCleaning);
            Controls.Add(pnlUnderlineOccupied);
            Controls.Add(pnlUnderlineReserved);
            Controls.Add(pnlUnderlineAvailable);
            Controls.Add(pnlColorMaintenance);
            Controls.Add(lblMaintenance);
            Controls.Add(pnlColorCleaning);
            Controls.Add(lblCleaning);
            Controls.Add(pnlColorOccupied);
            Controls.Add(lblOccupied);
            Controls.Add(pnlColorReserved);
            Controls.Add(lblReserved);
            Controls.Add(pnlColorAvailable);
            Controls.Add(lblAvailable);
            Controls.Add(dtpViewDate);
            Controls.Add(lblViewDate);
            Controls.Add(cmbRoomType);
            Controls.Add(lblRoomTier);
            Name = "RoomsUserControl";
            Size = new Size(1920, 881);
            Load += RoomsUserControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblRoomTier;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Label lblViewDate;
        private System.Windows.Forms.DateTimePicker dtpViewDate;

        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.Panel pnlColorAvailable;
        private System.Windows.Forms.Panel pnlUnderlineAvailable;

        private System.Windows.Forms.Label lblReserved;
        private System.Windows.Forms.Panel pnlColorReserved;
        private System.Windows.Forms.Panel pnlUnderlineReserved;

        private System.Windows.Forms.Label lblOccupied;
        private System.Windows.Forms.Panel pnlColorOccupied;
        private System.Windows.Forms.Panel pnlUnderlineOccupied;

        private System.Windows.Forms.Label lblCleaning;
        private System.Windows.Forms.Panel pnlColorCleaning;
        private System.Windows.Forms.Panel pnlUnderlineCleaning;

        private System.Windows.Forms.Label lblMaintenance;
        private System.Windows.Forms.Panel pnlColorMaintenance;
        private System.Windows.Forms.Panel pnlUnderlineMaintenance;

        private System.Windows.Forms.Button btnEditRates;
        private System.Windows.Forms.FlowLayoutPanel flpRooms;
    }
}