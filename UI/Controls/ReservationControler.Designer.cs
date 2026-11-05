namespace UI.Controls
{
    partial class ReservationControl
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
            btnSaveReservation = new Button();
            lblTotalAmount = new Label();
            lblTotalAmountHeader = new Label();
            cmbAvailableRooms = new ComboBox();
            lblRoom = new Label();
            lblCheckOut = new Label();
            lblCheckOutHeader = new Label();
            dtpCheckIn = new DateTimePicker();
            lblCheckIn = new Label();
            nudNights = new NumericUpDown();
            lblNights = new Label();
            nudChildren = new NumericUpDown();
            lblChildren = new Label();
            nudAdults = new NumericUpDown();
            lblAdults = new Label();
            txtGuestSearch = new TextBox();
            lblGuestSearch = new Label();
            lblTitleLeft = new Label();
            pnlRight = new Panel();
            btnCancel = new Button();
            btnConfirm = new Button();
            dgvReservations = new DataGridView();
            lblTitleRight = new Label();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNights).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudChildren).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAdults).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;
            pnlLeft.Controls.Add(btnSaveReservation);
            pnlLeft.Controls.Add(lblTotalAmount);
            pnlLeft.Controls.Add(lblTotalAmountHeader);
            pnlLeft.Controls.Add(cmbAvailableRooms);
            pnlLeft.Controls.Add(lblRoom);
            pnlLeft.Controls.Add(lblCheckOut);
            pnlLeft.Controls.Add(lblCheckOutHeader);
            pnlLeft.Controls.Add(dtpCheckIn);
            pnlLeft.Controls.Add(lblCheckIn);
            pnlLeft.Controls.Add(nudNights);
            pnlLeft.Controls.Add(lblNights);
            pnlLeft.Controls.Add(nudChildren);
            pnlLeft.Controls.Add(lblChildren);
            pnlLeft.Controls.Add(nudAdults);
            pnlLeft.Controls.Add(lblAdults);
            pnlLeft.Controls.Add(txtGuestSearch);
            pnlLeft.Controls.Add(lblGuestSearch);
            pnlLeft.Controls.Add(lblTitleLeft);
            pnlLeft.Location = new Point(40, 48);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(541, 756);
            pnlLeft.TabIndex = 0;
            // 
            // btnSaveReservation
            // 
            btnSaveReservation.BackColor = Color.FromArgb(2, 132, 199);
            btnSaveReservation.FlatStyle = FlatStyle.Flat;
            btnSaveReservation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSaveReservation.ForeColor = Color.White;
            btnSaveReservation.Location = new Point(29, 630);
            btnSaveReservation.Name = "btnSaveReservation";
            btnSaveReservation.Size = new Size(460, 60);
            btnSaveReservation.TabIndex = 17;
            btnSaveReservation.Text = "💾 Save Pending Reservation";
            btnSaveReservation.UseVisualStyleBackColor = false;
            btnSaveReservation.Click += btnSaveReservation_Click;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.Green;
            lblTotalAmount.Location = new Point(27, 530);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(89, 37);
            lblTotalAmount.TabIndex = 16;
            lblTotalAmount.Text = "₱0.00";
            // 
            // lblTotalAmountHeader
            // 
            lblTotalAmountHeader.AutoSize = true;
            lblTotalAmountHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalAmountHeader.Location = new Point(29, 500);
            lblTotalAmountHeader.Name = "lblTotalAmountHeader";
            lblTotalAmountHeader.Size = new Size(146, 28);
            lblTotalAmountHeader.TabIndex = 15;
            lblTotalAmountHeader.Text = "Total Amount:";
            // 
            // cmbAvailableRooms
            // 
            cmbAvailableRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAvailableRooms.Font = new Font("Segoe UI", 11F);
            cmbAvailableRooms.FormattingEnabled = true;
            cmbAvailableRooms.Location = new Point(29, 430);
            cmbAvailableRooms.Name = "cmbAvailableRooms";
            cmbAvailableRooms.Size = new Size(460, 33);
            cmbAvailableRooms.TabIndex = 14;
            cmbAvailableRooms.SelectedIndexChanged += cmbAvailableRooms_SelectedIndexChanged;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRoom.Location = new Point(29, 400);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(143, 23);
            lblRoom.TabIndex = 13;
            lblRoom.Text = "Available Rooms";
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblCheckOut.ForeColor = Color.DimGray;
            lblCheckOut.Location = new Point(29, 350);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(155, 25);
            lblCheckOut.TabIndex = 12;
            lblCheckOut.Text = "[Auto-Computed]";
            // 
            // lblCheckOutHeader
            // 
            lblCheckOutHeader.AutoSize = true;
            lblCheckOutHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCheckOutHeader.Location = new Point(29, 320);
            lblCheckOutHeader.Name = "lblCheckOutHeader";
            lblCheckOutHeader.Size = new Size(254, 23);
            lblCheckOutHeader.TabIndex = 11;
            lblCheckOutHeader.Text = "Check-Out Date/Time (22 Hrs)";
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.CustomFormat = "MMM dd, yyyy  hh:mm tt";
            dtpCheckIn.Font = new Font("Segoe UI", 11F);
            dtpCheckIn.Format = DateTimePickerFormat.Custom;
            dtpCheckIn.Location = new Point(29, 270);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(300, 32);
            dtpCheckIn.TabIndex = 10;
            dtpCheckIn.ValueChanged += dtpCheckIn_ValueChanged;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCheckIn.Location = new Point(29, 240);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(170, 23);
            lblCheckIn.TabIndex = 9;
            lblCheckIn.Text = "Check-In Date/Time";
            // 
            // nudNights
            // 
            nudNights.Font = new Font("Segoe UI", 11F);
            nudNights.Location = new Point(331, 190);
            nudNights.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            nudNights.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNights.Name = "nudNights";
            nudNights.Size = new Size(110, 32);
            nudNights.TabIndex = 8;
            nudNights.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudNights.ValueChanged += nudNights_ValueChanged;
            // 
            // lblNights
            // 
            lblNights.AutoSize = true;
            lblNights.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNights.Location = new Point(331, 160);
            lblNights.Name = "lblNights";
            lblNights.Size = new Size(63, 23);
            lblNights.TabIndex = 7;
            lblNights.Text = "Nights";
            // 
            // nudChildren
            // 
            nudChildren.Font = new Font("Segoe UI", 11F);
            nudChildren.Location = new Point(180, 190);
            nudChildren.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudChildren.Name = "nudChildren";
            nudChildren.Size = new Size(130, 32);
            nudChildren.TabIndex = 6;
            nudChildren.ValueChanged += Criteria_ValueChanged;
            // 
            // lblChildren
            // 
            lblChildren.AutoSize = true;
            lblChildren.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChildren.Location = new Point(180, 160);
            lblChildren.Name = "lblChildren";
            lblChildren.Size = new Size(78, 23);
            lblChildren.TabIndex = 5;
            lblChildren.Text = "Children";
            // 
            // nudAdults
            // 
            nudAdults.Font = new Font("Segoe UI", 11F);
            nudAdults.Location = new Point(29, 190);
            nudAdults.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudAdults.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAdults.Name = "nudAdults";
            nudAdults.Size = new Size(130, 32);
            nudAdults.TabIndex = 4;
            nudAdults.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudAdults.ValueChanged += Criteria_ValueChanged;
            // 
            // lblAdults
            // 
            lblAdults.AutoSize = true;
            lblAdults.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdults.Location = new Point(29, 160);
            lblAdults.Name = "lblAdults";
            lblAdults.Size = new Size(62, 23);
            lblAdults.TabIndex = 3;
            lblAdults.Text = "Adults";
            // 
            // txtGuestSearch
            // 
            txtGuestSearch.Font = new Font("Segoe UI", 11F);
            txtGuestSearch.Location = new Point(29, 110);
            txtGuestSearch.Name = "txtGuestSearch";
            txtGuestSearch.Size = new Size(460, 32);
            txtGuestSearch.TabIndex = 2;
            txtGuestSearch.TextChanged += txtGuestSearch_TextChanged;
            // 
            // lblGuestSearch
            // 
            lblGuestSearch.AutoSize = true;
            lblGuestSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGuestSearch.Location = new Point(29, 80);
            lblGuestSearch.Name = "lblGuestSearch";
            lblGuestSearch.Size = new Size(235, 23);
            lblGuestSearch.TabIndex = 1;
            lblGuestSearch.Text = "Search Guest (Code/Mobile)";
            // 
            // lblTitleLeft
            // 
            lblTitleLeft.AutoSize = true;
            lblTitleLeft.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitleLeft.Location = new Point(29, 20);
            lblTitleLeft.Name = "lblTitleLeft";
            lblTitleLeft.Size = new Size(287, 37);
            lblTitleLeft.TabIndex = 0;
            lblTitleLeft.Text = "Advance Reservation";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.BorderStyle = BorderStyle.FixedSingle;
            pnlRight.Controls.Add(btnCancel);
            pnlRight.Controls.Add(btnConfirm);
            pnlRight.Controls.Add(dgvReservations);
            pnlRight.Controls.Add(lblTitleRight);
            pnlRight.Location = new Point(620, 48);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(1260, 756);
            pnlRight.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(239, 68, 68);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(240, 672);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(200, 50);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "✖️ Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.FromArgb(34, 197, 94);
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.Location = new Point(23, 672);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(200, 50);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "✔️ Confirm";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // dgvReservations
            // 
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.AllowUserToDeleteRows = false;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.BackgroundColor = Color.FromArgb(248, 250, 252);
            dgvReservations.ColumnHeadersHeight = 40;
            dgvReservations.Location = new Point(23, 77);
            dgvReservations.MultiSelect = false;
            dgvReservations.Name = "dgvReservations";
            dgvReservations.ReadOnly = true;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.RowHeadersWidth = 51;
            dgvReservations.RowTemplate.Height = 35;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.Size = new Size(1211, 576);
            dgvReservations.TabIndex = 1;
            // 
            // lblTitleRight
            // 
            lblTitleRight.AutoSize = true;
            lblTitleRight.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitleRight.Location = new Point(18, 20);
            lblTitleRight.Name = "lblTitleRight";
            lblTitleRight.Size = new Size(317, 37);
            lblTitleRight.TabIndex = 0;
            lblTitleRight.Text = "Reservation Dashboard";
            // 
            // ReservationControll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "ReservationControll";
            Size = new Size(1920, 881);
            Load += ReservationControl_Load;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNights).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudChildren).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAdults).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTitleLeft;
        private System.Windows.Forms.Label lblGuestSearch;
        private System.Windows.Forms.TextBox txtGuestSearch;
        private System.Windows.Forms.Label lblAdults;
        private System.Windows.Forms.NumericUpDown nudAdults;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.NumericUpDown nudChildren;
        private System.Windows.Forms.Label lblNights;
        private System.Windows.Forms.NumericUpDown nudNights;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label lblCheckOutHeader;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbAvailableRooms;
        private System.Windows.Forms.Label lblTotalAmountHeader;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnSaveReservation;
        private System.Windows.Forms.Label lblTitleRight;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
    }
}