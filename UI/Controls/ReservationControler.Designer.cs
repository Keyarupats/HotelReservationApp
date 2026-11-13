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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            rdoPM = new RadioButton();
            rdoAM = new RadioButton();
            nudMinute = new NumericUpDown();
            lblTimeColon = new Label();
            nudHour = new NumericUpDown();
            lblCheckInTime = new Label();
            btnEditMultiRoom = new Button();
            btnSaveReservation = new Button();
            lblTotalAmount = new Label();
            lblTotalAmountHeader = new Label();
            lblSecondRoomChoice = new Label();
            lblFirstRoomChoice = new Label();
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
            ((System.ComponentModel.ISupportInitialize)nudMinute).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudHour).BeginInit();
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
            pnlLeft.Controls.Add(label3);
            pnlLeft.Controls.Add(label2);
            pnlLeft.Controls.Add(label1);
            pnlLeft.Controls.Add(rdoPM);
            pnlLeft.Controls.Add(rdoAM);
            pnlLeft.Controls.Add(nudMinute);
            pnlLeft.Controls.Add(lblTimeColon);
            pnlLeft.Controls.Add(nudHour);
            pnlLeft.Controls.Add(lblCheckInTime);
            pnlLeft.Controls.Add(btnEditMultiRoom);
            pnlLeft.Controls.Add(btnSaveReservation);
            pnlLeft.Controls.Add(lblTotalAmount);
            pnlLeft.Controls.Add(lblTotalAmountHeader);
            pnlLeft.Controls.Add(lblSecondRoomChoice);
            pnlLeft.Controls.Add(lblFirstRoomChoice);
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
            pnlLeft.Location = new Point(24, 25);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(557, 831);
            pnlLeft.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(300, 329);
            label3.Name = "label3";
            label3.Size = new Size(46, 17);
            label3.TabIndex = 29;
            label3.Text = "[MINS]";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(222, 329);
            label2.Name = "label2";
            label2.Size = new Size(52, 17);
            label2.TabIndex = 28;
            label2.Text = "[HOUR]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(29, 329);
            label1.Name = "label1";
            label1.Size = new Size(94, 17);
            label1.TabIndex = 27;
            label1.Text = "[MM-DD-YYYY]";
            // 
            // rdoPM
            // 
            rdoPM.AutoSize = true;
            rdoPM.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rdoPM.Location = new Point(432, 299);
            rdoPM.Name = "rdoPM";
            rdoPM.Size = new Size(57, 27);
            rdoPM.TabIndex = 26;
            rdoPM.Text = "PM";
            rdoPM.UseVisualStyleBackColor = true;
            rdoPM.CheckedChanged += CheckInDateTime_Changed;
            // 
            // rdoAM
            // 
            rdoAM.AutoSize = true;
            rdoAM.Checked = true;
            rdoAM.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rdoAM.Location = new Point(368, 299);
            rdoAM.Name = "rdoAM";
            rdoAM.Size = new Size(59, 27);
            rdoAM.TabIndex = 25;
            rdoAM.TabStop = true;
            rdoAM.Text = "AM";
            rdoAM.UseVisualStyleBackColor = true;
            rdoAM.CheckedChanged += CheckInDateTime_Changed;
            // 
            // nudMinute
            // 
            nudMinute.Font = new Font("Segoe UI", 11F);
            nudMinute.Location = new Point(300, 296);
            nudMinute.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            nudMinute.Name = "nudMinute";
            nudMinute.Size = new Size(60, 32);
            nudMinute.TabIndex = 24;
            nudMinute.ValueChanged += CheckInDateTime_Changed;
            // 
            // lblTimeColon
            // 
            lblTimeColon.AutoSize = true;
            lblTimeColon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTimeColon.Location = new Point(287, 297);
            lblTimeColon.Name = "lblTimeColon";
            lblTimeColon.Size = new Size(17, 28);
            lblTimeColon.TabIndex = 23;
            lblTimeColon.Text = ":";
            // 
            // nudHour
            // 
            nudHour.Font = new Font("Segoe UI", 11F);
            nudHour.Location = new Point(225, 296);
            nudHour.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            nudHour.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudHour.Name = "nudHour";
            nudHour.Size = new Size(60, 32);
            nudHour.TabIndex = 22;
            nudHour.Value = new decimal(new int[] { 2, 0, 0, 0 });
            nudHour.ValueChanged += CheckInDateTime_Changed;
            // 
            // lblCheckInTime
            // 
            lblCheckInTime.AutoSize = true;
            lblCheckInTime.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCheckInTime.Location = new Point(225, 270);
            lblCheckInTime.Name = "lblCheckInTime";
            lblCheckInTime.Size = new Size(137, 23);
            lblCheckInTime.TabIndex = 21;
            lblCheckInTime.Text = "Check-In Time *";
            // 
            // btnEditMultiRoom
            // 
            btnEditMultiRoom.BackColor = Color.FromArgb(245, 158, 11);
            btnEditMultiRoom.FlatStyle = FlatStyle.Flat;
            btnEditMultiRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditMultiRoom.ForeColor = Color.White;
            btnEditMultiRoom.Location = new Point(335, 451);
            btnEditMultiRoom.Name = "btnEditMultiRoom";
            btnEditMultiRoom.Size = new Size(154, 42);
            btnEditMultiRoom.TabIndex = 20;
            btnEditMultiRoom.Text = "✎ Edit Rooms";
            btnEditMultiRoom.UseVisualStyleBackColor = false;
            btnEditMultiRoom.Visible = false;
            btnEditMultiRoom.Click += btnEditMultiRoom_Click;
            // 
            // btnSaveReservation
            // 
            btnSaveReservation.BackColor = Color.FromArgb(2, 132, 199);
            btnSaveReservation.FlatStyle = FlatStyle.Flat;
            btnSaveReservation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSaveReservation.ForeColor = Color.White;
            btnSaveReservation.Location = new Point(36, 694);
            btnSaveReservation.Name = "btnSaveReservation";
            btnSaveReservation.Size = new Size(453, 60);
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
            lblTotalAmount.Location = new Point(44, 623);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(89, 37);
            lblTotalAmount.TabIndex = 16;
            lblTotalAmount.Text = "₱0.00";
            // 
            // lblTotalAmountHeader
            // 
            lblTotalAmountHeader.AutoSize = true;
            lblTotalAmountHeader.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalAmountHeader.Location = new Point(46, 593);
            lblTotalAmountHeader.Name = "lblTotalAmountHeader";
            lblTotalAmountHeader.Size = new Size(146, 28);
            lblTotalAmountHeader.TabIndex = 15;
            lblTotalAmountHeader.Text = "Total Amount:";
            // 
            // lblSecondRoomChoice
            // 
            lblSecondRoomChoice.AutoSize = true;
            lblSecondRoomChoice.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblSecondRoomChoice.ForeColor = Color.FromArgb(2, 132, 199);
            lblSecondRoomChoice.Location = new Point(36, 524);
            lblSecondRoomChoice.Name = "lblSecondRoomChoice";
            lblSecondRoomChoice.Size = new Size(155, 25);
            lblSecondRoomChoice.TabIndex = 19;
            lblSecondRoomChoice.Text = "2nd Room: None";
            lblSecondRoomChoice.Visible = false;
            // 
            // lblFirstRoomChoice
            // 
            lblFirstRoomChoice.AutoSize = true;
            lblFirstRoomChoice.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblFirstRoomChoice.ForeColor = Color.FromArgb(2, 132, 199);
            lblFirstRoomChoice.Location = new Point(36, 499);
            lblFirstRoomChoice.Name = "lblFirstRoomChoice";
            lblFirstRoomChoice.Size = new Size(148, 25);
            lblFirstRoomChoice.TabIndex = 18;
            lblFirstRoomChoice.Text = "1st Room: None";
            lblFirstRoomChoice.Visible = false;
            // 
            // cmbAvailableRooms
            // 
            cmbAvailableRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAvailableRooms.Font = new Font("Segoe UI", 11F);
            cmbAvailableRooms.FormattingEnabled = true;
            cmbAvailableRooms.Location = new Point(36, 491);
            cmbAvailableRooms.Name = "cmbAvailableRooms";
            cmbAvailableRooms.Size = new Size(453, 33);
            cmbAvailableRooms.TabIndex = 14;
            cmbAvailableRooms.SelectedIndexChanged += cmbAvailableRooms_SelectedIndexChanged;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRoom.Location = new Point(29, 461);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(156, 23);
            lblRoom.TabIndex = 13;
            lblRoom.Text = "Available Rooms *";
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblCheckOut.ForeColor = Color.DimGray;
            lblCheckOut.Location = new Point(29, 399);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(155, 25);
            lblCheckOut.TabIndex = 12;
            lblCheckOut.Text = "[Auto-Computed]";
            // 
            // lblCheckOutHeader
            // 
            lblCheckOutHeader.AutoSize = true;
            lblCheckOutHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCheckOutHeader.Location = new Point(29, 369);
            lblCheckOutHeader.Name = "lblCheckOutHeader";
            lblCheckOutHeader.Size = new Size(267, 23);
            lblCheckOutHeader.TabIndex = 11;
            lblCheckOutHeader.Text = "Check-Out Date/Time (22 Hrs) *";
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.CustomFormat = "MMM dd, yyyy";
            dtpCheckIn.Font = new Font("Segoe UI", 11F);
            dtpCheckIn.Format = DateTimePickerFormat.Custom;
            dtpCheckIn.Location = new Point(29, 296);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(185, 32);
            dtpCheckIn.TabIndex = 10;
            dtpCheckIn.ValueChanged += CheckInDateTime_Changed;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCheckIn.Location = new Point(29, 270);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(135, 23);
            lblCheckIn.TabIndex = 9;
            lblCheckIn.Text = "Check-In Date *";
            // 
            // nudNights
            // 
            nudNights.Enabled = false;
            nudNights.Font = new Font("Segoe UI", 11F);
            nudNights.Location = new Point(331, 208);
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
            lblNights.Location = new Point(331, 178);
            lblNights.Name = "lblNights";
            lblNights.Size = new Size(76, 23);
            lblNights.TabIndex = 7;
            lblNights.Text = "Nights *";
            // 
            // nudChildren
            // 
            nudChildren.Font = new Font("Segoe UI", 11F);
            nudChildren.Location = new Point(180, 208);
            nudChildren.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            nudChildren.Name = "nudChildren";
            nudChildren.Size = new Size(130, 32);
            nudChildren.TabIndex = 6;
            nudChildren.ValueChanged += nudChildren_ValueChanged;
            nudChildren.Leave += nudChildren_Leave;
            // 
            // lblChildren
            // 
            lblChildren.AutoSize = true;
            lblChildren.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChildren.Location = new Point(180, 178);
            lblChildren.Name = "lblChildren";
            lblChildren.Size = new Size(91, 23);
            lblChildren.TabIndex = 5;
            lblChildren.Text = "Children *";
            // 
            // nudAdults
            // 
            nudAdults.Enabled = false;
            nudAdults.Font = new Font("Segoe UI", 11F);
            nudAdults.Location = new Point(29, 208);
            nudAdults.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            nudAdults.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAdults.Name = "nudAdults";
            nudAdults.Size = new Size(130, 32);
            nudAdults.TabIndex = 4;
            nudAdults.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudAdults.ValueChanged += nudAdults_ValueChanged;
            // 
            // lblAdults
            // 
            lblAdults.AutoSize = true;
            lblAdults.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdults.Location = new Point(29, 178);
            lblAdults.Name = "lblAdults";
            lblAdults.Size = new Size(75, 23);
            lblAdults.TabIndex = 3;
            lblAdults.Text = "Adults *";
            // 
            // txtGuestSearch
            // 
            txtGuestSearch.Font = new Font("Segoe UI", 11F);
            txtGuestSearch.Location = new Point(29, 120);
            txtGuestSearch.Name = "txtGuestSearch";
            txtGuestSearch.Size = new Size(460, 32);
            txtGuestSearch.TabIndex = 2;
            txtGuestSearch.TextChanged += txtGuestSearch_TextChanged;
            // 
            // lblGuestSearch
            // 
            lblGuestSearch.AutoSize = true;
            lblGuestSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGuestSearch.Location = new Point(29, 90);
            lblGuestSearch.Name = "lblGuestSearch";
            lblGuestSearch.Size = new Size(248, 23);
            lblGuestSearch.TabIndex = 1;
            lblGuestSearch.Text = "Search Guest (Code/Mobile) *";
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
            pnlRight.Location = new Point(604, 25);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(1276, 831);
            pnlRight.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(239, 68, 68);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(240, 738);
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
            btnConfirm.Location = new Point(23, 738);
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
            dgvReservations.Size = new Size(1211, 641);
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
            // ReservationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "ReservationControl";
            Size = new Size(1920, 881);
            Load += ReservationControl_Load;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMinute).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudHour).EndInit();
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
        private System.Windows.Forms.Label lblCheckInTime;
        private System.Windows.Forms.NumericUpDown nudHour;
        private System.Windows.Forms.Label lblTimeColon;
        private System.Windows.Forms.NumericUpDown nudMinute;
        private System.Windows.Forms.RadioButton rdoAM;
        private System.Windows.Forms.RadioButton rdoPM;
        private System.Windows.Forms.Label lblCheckOutHeader;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.ComboBox cmbAvailableRooms;
        private System.Windows.Forms.Label lblFirstRoomChoice;
        private System.Windows.Forms.Label lblSecondRoomChoice;
        private System.Windows.Forms.Label lblTotalAmountHeader;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnSaveReservation;
        private System.Windows.Forms.Label lblTitleRight;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEditMultiRoom;
        private Label label1;
        private Label label3;
        private Label label2;
    }
}