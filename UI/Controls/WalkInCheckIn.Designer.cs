namespace UI
{
    partial class WalkInCheckIn
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

        private void InitializeComponent()
        {
            panelGuestInfo = new Panel();
            lblGuestInfoTitle = new Label();
            lblSearchLabel = new Label();
            txtSearchGuest = new TextBox();
            btnFindGuest = new Button();
            lblGuestStatusNotice = new Label();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblMI = new Label();
            txtMiddleInitial = new TextBox();
            lblMobile = new Label();
            txtMobileNumber = new TextBox();
            lblAge = new Label();
            txtAge = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblIdType = new Label();
            cmbIdType = new ComboBox();
            lblIdNumber = new Label();
            txtIdNumber = new TextBox();
            btnRegisterGuest = new Button();
            btnClearGuest = new Button();
            panelStayDetails = new Panel();
            lblStayDetailsTitle = new Label();
            lblActiveGuestName = new Label();
            lblAdults = new Label();
            numAdults = new NumericUpDown();
            lblChildren = new Label();
            numChildren = new NumericUpDown();
            lblNights = new Label();
            numNights = new NumericUpDown();
            lblRoomSelect = new Label();
            cmbAvailableRooms = new ComboBox();
            lblFirstRoomChoice = new Label();
            lblSecondRoomChoice = new Label();
            btnEditMultiRoom = new Button();
            lblRateAdult = new Label();
            txtRateAdult = new TextBox();
            lblTotalAmount = new Label();
            txtTotalAmount = new TextBox();
            lblCheckInTime = new Label();
            txtCheckInTime = new TextBox();
            lblCheckOutTime = new Label();
            txtCheckOutTime = new TextBox();
            lblRoomStatusTransition = new Label();
            badgeAvailable = new Button();
            lblArrow = new Label();
            badgeOccupied = new Button();
            btnCompleteCheckIn = new Button();
            btnClearStay = new Button();
            lblErrorMsg = new Label();
            panelGuestInfo.SuspendLayout();
            panelStayDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAdults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numChildren).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNights).BeginInit();
            SuspendLayout();
            // 
            // panelGuestInfo
            // 
            panelGuestInfo.BackColor = Color.White;
            panelGuestInfo.BorderStyle = BorderStyle.FixedSingle;
            panelGuestInfo.Controls.Add(lblGuestInfoTitle);
            panelGuestInfo.Controls.Add(lblSearchLabel);
            panelGuestInfo.Controls.Add(txtSearchGuest);
            panelGuestInfo.Controls.Add(btnFindGuest);
            panelGuestInfo.Controls.Add(lblGuestStatusNotice);
            panelGuestInfo.Controls.Add(lblFirstName);
            panelGuestInfo.Controls.Add(txtFirstName);
            panelGuestInfo.Controls.Add(lblLastName);
            panelGuestInfo.Controls.Add(txtLastName);
            panelGuestInfo.Controls.Add(lblMI);
            panelGuestInfo.Controls.Add(txtMiddleInitial);
            panelGuestInfo.Controls.Add(lblMobile);
            panelGuestInfo.Controls.Add(txtMobileNumber);
            panelGuestInfo.Controls.Add(lblAge);
            panelGuestInfo.Controls.Add(txtAge);
            panelGuestInfo.Controls.Add(lblEmail);
            panelGuestInfo.Controls.Add(txtEmail);
            panelGuestInfo.Controls.Add(lblAddress);
            panelGuestInfo.Controls.Add(txtAddress);
            panelGuestInfo.Controls.Add(lblIdType);
            panelGuestInfo.Controls.Add(cmbIdType);
            panelGuestInfo.Controls.Add(lblIdNumber);
            panelGuestInfo.Controls.Add(txtIdNumber);
            panelGuestInfo.Controls.Add(btnRegisterGuest);
            panelGuestInfo.Controls.Add(btnClearGuest);
            panelGuestInfo.Location = new Point(27, 15);
            panelGuestInfo.Margin = new Padding(3, 4, 3, 4);
            panelGuestInfo.Name = "panelGuestInfo";
            panelGuestInfo.Size = new Size(803, 761);
            panelGuestInfo.TabIndex = 0;
            // 
            // lblGuestInfoTitle
            // 
            lblGuestInfoTitle.AutoSize = true;
            lblGuestInfoTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblGuestInfoTitle.Location = new Point(147, 50);
            lblGuestInfoTitle.Name = "lblGuestInfoTitle";
            lblGuestInfoTitle.Size = new Size(213, 32);
            lblGuestInfoTitle.TabIndex = 0;
            lblGuestInfoTitle.Text = "Guest Information";
            // 
            // lblSearchLabel
            // 
            lblSearchLabel.AutoSize = true;
            lblSearchLabel.Font = new Font("Segoe UI", 9.5F);
            lblSearchLabel.Location = new Point(147, 102);
            lblSearchLabel.Name = "lblSearchLabel";
            lblSearchLabel.Size = new Size(355, 21);
            lblSearchLabel.TabIndex = 1;
            lblSearchLabel.Text = "Search Guest (name, mobile, email, or guest code)";
            // 
            // txtSearchGuest
            // 
            txtSearchGuest.BackColor = Color.White;
            txtSearchGuest.Font = new Font("Segoe UI", 10F);
            txtSearchGuest.Location = new Point(147, 132);
            txtSearchGuest.Margin = new Padding(3, 4, 3, 4);
            txtSearchGuest.Name = "txtSearchGuest";
            txtSearchGuest.PlaceholderText = "e.g. 09171234567, Juan, or G-0001";
            txtSearchGuest.Size = new Size(330, 30);
            txtSearchGuest.TabIndex = 2;
            txtSearchGuest.KeyDown += txtSearchGuest_KeyDown;
            // 
            // btnFindGuest
            // 
            btnFindGuest.BackColor = Color.FromArgb(0, 120, 215);
            btnFindGuest.FlatStyle = FlatStyle.Flat;
            btnFindGuest.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnFindGuest.ForeColor = Color.White;
            btnFindGuest.Location = new Point(492, 129);
            btnFindGuest.Margin = new Padding(3, 4, 3, 4);
            btnFindGuest.Name = "btnFindGuest";
            btnFindGuest.Size = new Size(120, 38);
            btnFindGuest.TabIndex = 3;
            btnFindGuest.Text = "Find Guest";
            btnFindGuest.UseVisualStyleBackColor = false;
            btnFindGuest.Click += btnFindGuest_Click;
            // 
            // lblGuestStatusNotice
            // 
            lblGuestStatusNotice.BorderStyle = BorderStyle.FixedSingle;
            lblGuestStatusNotice.Font = new Font("Segoe UI", 9F);
            lblGuestStatusNotice.ForeColor = Color.DimGray;
            lblGuestStatusNotice.Location = new Point(147, 185);
            lblGuestStatusNotice.Name = "lblGuestStatusNotice";
            lblGuestStatusNotice.Size = new Size(465, 43);
            lblGuestStatusNotice.TabIndex = 4;
            lblGuestStatusNotice.Text = " Search an existing guest above, or fill in details to register a new guest.";
            lblGuestStatusNotice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(147, 250);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(90, 20);
            lblFirstName.TabIndex = 5;
            lblFirstName.Text = "First Name *";
            // 
            // txtFirstName
            // 
            txtFirstName.BackColor = Color.White;
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(147, 278);
            txtFirstName.Margin = new Padding(3, 4, 3, 4);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(195, 30);
            txtFirstName.TabIndex = 6;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(357, 250);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(89, 20);
            lblLastName.TabIndex = 7;
            lblLastName.Text = "Last Name *";
            // 
            // txtLastName
            // 
            txtLastName.BackColor = Color.White;
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(357, 278);
            txtLastName.Margin = new Padding(3, 4, 3, 4);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(165, 30);
            txtLastName.TabIndex = 8;
            // 
            // lblMI
            // 
            lblMI.AutoSize = true;
            lblMI.Location = new Point(537, 250);
            lblMI.Name = "lblMI";
            lblMI.Size = new Size(26, 20);
            lblMI.TabIndex = 9;
            lblMI.Text = "MI";
            // 
            // txtMiddleInitial
            // 
            txtMiddleInitial.BackColor = Color.White;
            txtMiddleInitial.Font = new Font("Segoe UI", 10F);
            txtMiddleInitial.Location = new Point(537, 278);
            txtMiddleInitial.Margin = new Padding(3, 4, 3, 4);
            txtMiddleInitial.MaxLength = 5;
            txtMiddleInitial.Name = "txtMiddleInitial";
            txtMiddleInitial.Size = new Size(75, 30);
            txtMiddleInitial.TabIndex = 10;
            // 
            // lblMobile
            // 
            lblMobile.AutoSize = true;
            lblMobile.Location = new Point(147, 335);
            lblMobile.Name = "lblMobile";
            lblMobile.Size = new Size(124, 20);
            lblMobile.TabIndex = 11;
            lblMobile.Text = "Mobile Number *";
            // 
            // txtMobileNumber
            // 
            txtMobileNumber.BackColor = Color.White;
            txtMobileNumber.Font = new Font("Segoe UI", 10F);
            txtMobileNumber.Location = new Point(147, 363);
            txtMobileNumber.Margin = new Padding(3, 4, 3, 4);
            txtMobileNumber.MaxLength = 11;
            txtMobileNumber.Name = "txtMobileNumber";
            txtMobileNumber.Size = new Size(150, 30);
            txtMobileNumber.TabIndex = 12;
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(312, 335);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(46, 20);
            lblAge.TabIndex = 13;
            lblAge.Text = "Age *";
            // 
            // txtAge
            // 
            txtAge.BackColor = Color.White;
            txtAge.Font = new Font("Segoe UI", 10F);
            txtAge.Location = new Point(312, 363);
            txtAge.Margin = new Padding(3, 4, 3, 4);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(75, 30);
            txtAge.TabIndex = 14;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(402, 335);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 15;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(402, 363);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(210, 30);
            txtEmail.TabIndex = 16;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(147, 420);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(72, 20);
            lblAddress.TabIndex = 17;
            lblAddress.Text = "Address *";
            // 
            // txtAddress
            // 
            txtAddress.BackColor = Color.White;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(147, 448);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(465, 30);
            txtAddress.TabIndex = 18;
            // 
            // lblIdType
            // 
            lblIdType.AutoSize = true;
            lblIdType.Location = new Point(147, 505);
            lblIdType.Name = "lblIdType";
            lblIdType.Size = new Size(69, 20);
            lblIdType.TabIndex = 19;
            lblIdType.Text = "ID Type *";
            // 
            // cmbIdType
            // 
            cmbIdType.BackColor = Color.White;
            cmbIdType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIdType.Font = new Font("Segoe UI", 10F);
            cmbIdType.FormattingEnabled = true;
            cmbIdType.Items.AddRange(new object[] { "Driver's License", "Passport", "National ID", "SSS ID", "GSIS ID" });
            cmbIdType.Location = new Point(147, 533);
            cmbIdType.Margin = new Padding(3, 4, 3, 4);
            cmbIdType.Name = "cmbIdType";
            cmbIdType.Size = new Size(195, 31);
            cmbIdType.TabIndex = 20;
            // 
            // lblIdNumber
            // 
            lblIdNumber.AutoSize = true;
            lblIdNumber.Location = new Point(357, 505);
            lblIdNumber.Name = "lblIdNumber";
            lblIdNumber.Size = new Size(92, 20);
            lblIdNumber.TabIndex = 21;
            lblIdNumber.Text = "ID Number *";
            // 
            // txtIdNumber
            // 
            txtIdNumber.BackColor = Color.White;
            txtIdNumber.Font = new Font("Segoe UI", 10F);
            txtIdNumber.Location = new Point(357, 533);
            txtIdNumber.Margin = new Padding(3, 4, 3, 4);
            txtIdNumber.Name = "txtIdNumber";
            txtIdNumber.Size = new Size(255, 30);
            txtIdNumber.TabIndex = 22;
            // 
            // btnRegisterGuest
            // 
            btnRegisterGuest.BackColor = Color.FromArgb(0, 120, 215);
            btnRegisterGuest.FlatStyle = FlatStyle.Flat;
            btnRegisterGuest.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnRegisterGuest.ForeColor = Color.White;
            btnRegisterGuest.Location = new Point(147, 610);
            btnRegisterGuest.Margin = new Padding(3, 4, 3, 4);
            btnRegisterGuest.Name = "btnRegisterGuest";
            btnRegisterGuest.Size = new Size(165, 50);
            btnRegisterGuest.TabIndex = 23;
            btnRegisterGuest.Text = "Register Guest";
            btnRegisterGuest.UseVisualStyleBackColor = false;
            btnRegisterGuest.Click += btnRegisterGuest_Click;
            // 
            // btnClearGuest
            // 
            btnClearGuest.BackColor = Color.Gray;
            btnClearGuest.FlatStyle = FlatStyle.Flat;
            btnClearGuest.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnClearGuest.ForeColor = Color.White;
            btnClearGuest.Location = new Point(327, 610);
            btnClearGuest.Margin = new Padding(3, 4, 3, 4);
            btnClearGuest.Name = "btnClearGuest";
            btnClearGuest.Size = new Size(110, 50);
            btnClearGuest.TabIndex = 24;
            btnClearGuest.Text = "Clear";
            btnClearGuest.UseVisualStyleBackColor = false;
            btnClearGuest.Click += btnClear_Click;
            // 
            // panelStayDetails
            // 
            panelStayDetails.BackColor = Color.White;
            panelStayDetails.BorderStyle = BorderStyle.FixedSingle;
            panelStayDetails.Controls.Add(lblStayDetailsTitle);
            panelStayDetails.Controls.Add(lblActiveGuestName);
            panelStayDetails.Controls.Add(lblAdults);
            panelStayDetails.Controls.Add(numAdults);
            panelStayDetails.Controls.Add(lblChildren);
            panelStayDetails.Controls.Add(numChildren);
            panelStayDetails.Controls.Add(lblNights);
            panelStayDetails.Controls.Add(numNights);
            panelStayDetails.Controls.Add(lblRoomSelect);
            panelStayDetails.Controls.Add(cmbAvailableRooms);
            panelStayDetails.Controls.Add(lblFirstRoomChoice);
            panelStayDetails.Controls.Add(lblSecondRoomChoice);
            panelStayDetails.Controls.Add(btnEditMultiRoom);
            panelStayDetails.Controls.Add(lblRateAdult);
            panelStayDetails.Controls.Add(txtRateAdult);
            panelStayDetails.Controls.Add(lblTotalAmount);
            panelStayDetails.Controls.Add(txtTotalAmount);
            panelStayDetails.Controls.Add(lblCheckInTime);
            panelStayDetails.Controls.Add(txtCheckInTime);
            panelStayDetails.Controls.Add(lblCheckOutTime);
            panelStayDetails.Controls.Add(txtCheckOutTime);
            panelStayDetails.Controls.Add(lblRoomStatusTransition);
            panelStayDetails.Controls.Add(badgeAvailable);
            panelStayDetails.Controls.Add(lblArrow);
            panelStayDetails.Controls.Add(badgeOccupied);
            panelStayDetails.Controls.Add(btnCompleteCheckIn);
            panelStayDetails.Controls.Add(btnClearStay);
            panelStayDetails.Controls.Add(lblErrorMsg);
            panelStayDetails.Location = new Point(921, 15);
            panelStayDetails.Margin = new Padding(3, 4, 3, 4);
            panelStayDetails.Name = "panelStayDetails";
            panelStayDetails.Size = new Size(959, 761);
            panelStayDetails.TabIndex = 1;
            // 
            // lblStayDetailsTitle
            // 
            lblStayDetailsTitle.AutoSize = true;
            lblStayDetailsTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblStayDetailsTitle.Location = new Point(197, 50);
            lblStayDetailsTitle.Name = "lblStayDetailsTitle";
            lblStayDetailsTitle.Size = new Size(141, 32);
            lblStayDetailsTitle.TabIndex = 0;
            lblStayDetailsTitle.Text = "Stay Details";
            // 
            // lblActiveGuestName
            // 
            lblActiveGuestName.AutoSize = true;
            lblActiveGuestName.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblActiveGuestName.ForeColor = Color.DimGray;
            lblActiveGuestName.Location = new Point(490, 56);
            lblActiveGuestName.Name = "lblActiveGuestName";
            lblActiveGuestName.Size = new Size(208, 25);
            lblActiveGuestName.TabIndex = 1;
            lblActiveGuestName.Text = "Guest: (None Selected)";
            // 
            // lblAdults
            // 
            lblAdults.AutoSize = true;
            lblAdults.Location = new Point(197, 115);
            lblAdults.Name = "lblAdults";
            lblAdults.Size = new Size(127, 20);
            lblAdults.TabIndex = 2;
            lblAdults.Text = "Number of Adults";
            // 
            // numAdults
            // 
            numAdults.Font = new Font("Segoe UI", 10F);
            numAdults.Location = new Point(197, 145);
            numAdults.Margin = new Padding(3, 4, 3, 4);
            numAdults.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numAdults.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numAdults.Name = "numAdults";
            numAdults.Size = new Size(165, 30);
            numAdults.TabIndex = 3;
            numAdults.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numAdults.ValueChanged += numAdults_ValueChanged;
            // 
            // lblChildren
            // 
            lblChildren.AutoSize = true;
            lblChildren.Location = new Point(382, 115);
            lblChildren.Name = "lblChildren";
            lblChildren.Size = new Size(169, 20);
            lblChildren.TabIndex = 4;
            lblChildren.Text = "Children (10 y.o. & below)";
            // 
            // numChildren
            // 
            numChildren.Font = new Font("Segoe UI", 10F);
            numChildren.Location = new Point(382, 145);
            numChildren.Margin = new Padding(3, 4, 3, 4);
            numChildren.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            numChildren.Name = "numChildren";
            numChildren.Size = new Size(195, 30);
            numChildren.TabIndex = 5;
            numChildren.ValueChanged += numChildren_ValueChanged;
            // 
            // lblNights
            // 
            lblNights.AutoSize = true;
            lblNights.Location = new Point(597, 115);
            lblNights.Name = "lblNights";
            lblNights.Size = new Size(128, 20);
            lblNights.TabIndex = 6;
            lblNights.Text = "Number of Nights";
            // 
            // numNights
            // 
            numNights.Font = new Font("Segoe UI", 10F);
            numNights.Location = new Point(597, 145);
            numNights.Margin = new Padding(3, 4, 3, 4);
            numNights.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            numNights.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numNights.Name = "numNights";
            numNights.Size = new Size(170, 30);
            numNights.TabIndex = 7;
            numNights.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numNights.ValueChanged += numNights_ValueChanged;
            // 
            // lblRoomSelect
            // 
            lblRoomSelect.AutoSize = true;
            lblRoomSelect.Location = new Point(197, 205);
            lblRoomSelect.Name = "lblRoomSelect";
            lblRoomSelect.Size = new Size(416, 20);
            lblRoomSelect.TabIndex = 8;
            lblRoomSelect.Text = "Select Available Room (free for next 22 hours & fits headcount)";
            // 
            // cmbAvailableRooms
            // 
            cmbAvailableRooms.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAvailableRooms.Font = new Font("Segoe UI", 10F);
            cmbAvailableRooms.Location = new Point(197, 229);
            cmbAvailableRooms.Margin = new Padding(3, 4, 3, 4);
            cmbAvailableRooms.Name = "cmbAvailableRooms";
            cmbAvailableRooms.Size = new Size(570, 31);
            cmbAvailableRooms.TabIndex = 9;
            cmbAvailableRooms.SelectedIndexChanged += cmbAvailableRooms_SelectedIndexChanged;
            // 
            // lblFirstRoomChoice
            // 
            lblFirstRoomChoice.AutoSize = true;
            lblFirstRoomChoice.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblFirstRoomChoice.ForeColor = Color.FromArgb(2, 132, 199);
            lblFirstRoomChoice.Location = new Point(197, 276);
            lblFirstRoomChoice.Name = "lblFirstRoomChoice";
            lblFirstRoomChoice.Size = new Size(148, 25);
            lblFirstRoomChoice.TabIndex = 25;
            lblFirstRoomChoice.Text = "1st Room: None";
            lblFirstRoomChoice.Visible = false;
            // 
            // lblSecondRoomChoice
            // 
            lblSecondRoomChoice.AutoSize = true;
            lblSecondRoomChoice.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblSecondRoomChoice.ForeColor = Color.FromArgb(2, 132, 199);
            lblSecondRoomChoice.Location = new Point(197, 306);
            lblSecondRoomChoice.Name = "lblSecondRoomChoice";
            lblSecondRoomChoice.Size = new Size(155, 25);
            lblSecondRoomChoice.TabIndex = 26;
            lblSecondRoomChoice.Text = "2nd Room: None";
            lblSecondRoomChoice.Visible = false;
            // 
            // btnEditMultiRoom
            // 
            btnEditMultiRoom.BackColor = Color.FromArgb(245, 158, 11);
            btnEditMultiRoom.FlatStyle = FlatStyle.Flat;
            btnEditMultiRoom.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEditMultiRoom.ForeColor = Color.White;
            btnEditMultiRoom.Location = new Point(198, 228);
            btnEditMultiRoom.Name = "btnEditMultiRoom";
            btnEditMultiRoom.Size = new Size(154, 42);
            btnEditMultiRoom.TabIndex = 27;
            btnEditMultiRoom.Text = "✎ Edit Rooms";
            btnEditMultiRoom.UseVisualStyleBackColor = false;
            btnEditMultiRoom.Visible = false;
            btnEditMultiRoom.Click += btnEditMultiRoom_Click;
            // 
            // lblRateAdult
            // 
            lblRateAdult.AutoSize = true;
            lblRateAdult.Location = new Point(197, 365);
            lblRateAdult.Name = "lblRateAdult";
            lblRateAdult.Size = new Size(201, 20);
            lblRateAdult.TabIndex = 10;
            lblRateAdult.Text = "Rate per Adult (22-hour stay)";
            // 
            // txtRateAdult
            // 
            txtRateAdult.BackColor = Color.Silver;
            txtRateAdult.Font = new Font("Segoe UI", 10F);
            txtRateAdult.Location = new Point(197, 395);
            txtRateAdult.Margin = new Padding(3, 4, 3, 4);
            txtRateAdult.Name = "txtRateAdult";
            txtRateAdult.ReadOnly = true;
            txtRateAdult.Size = new Size(265, 30);
            txtRateAdult.TabIndex = 11;
            txtRateAdult.Text = "₱0.00";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(482, 365);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(99, 20);
            lblTotalAmount.TabIndex = 12;
            lblTotalAmount.Text = "Total Amount";
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.BackColor = Color.Silver;
            txtTotalAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtTotalAmount.ForeColor = Color.ForestGreen;
            txtTotalAmount.Location = new Point(482, 395);
            txtTotalAmount.Margin = new Padding(3, 4, 3, 4);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(285, 30);
            txtTotalAmount.TabIndex = 13;
            txtTotalAmount.Text = "₱0.00";
            // 
            // lblCheckInTime
            // 
            lblCheckInTime.AutoSize = true;
            lblCheckInTime.Location = new Point(197, 457);
            lblCheckInTime.Name = "lblCheckInTime";
            lblCheckInTime.Size = new Size(202, 20);
            lblCheckInTime.TabIndex = 14;
            lblCheckInTime.Text = "Check-In Date & Time (system)";
            // 
            // txtCheckInTime
            // 
            txtCheckInTime.BackColor = Color.Silver;
            txtCheckInTime.Font = new Font("Segoe UI", 10F);
            txtCheckInTime.Location = new Point(197, 487);
            txtCheckInTime.Margin = new Padding(3, 4, 3, 4);
            txtCheckInTime.Name = "txtCheckInTime";
            txtCheckInTime.ReadOnly = true;
            txtCheckInTime.Size = new Size(265, 30);
            txtCheckInTime.TabIndex = 15;
            // 
            // lblCheckOutTime
            // 
            lblCheckOutTime.AutoSize = true;
            lblCheckOutTime.Location = new Point(482, 457);
            lblCheckOutTime.Name = "lblCheckOutTime";
            lblCheckOutTime.Size = new Size(246, 20);
            lblCheckOutTime.TabIndex = 16;
            lblCheckOutTime.Text = "Expected Check-Out (+22 hrs/night)";
            // 
            // txtCheckOutTime
            // 
            txtCheckOutTime.BackColor = Color.Silver;
            txtCheckOutTime.Font = new Font("Segoe UI", 10F);
            txtCheckOutTime.Location = new Point(482, 487);
            txtCheckOutTime.Margin = new Padding(3, 4, 3, 4);
            txtCheckOutTime.Name = "txtCheckOutTime";
            txtCheckOutTime.ReadOnly = true;
            txtCheckOutTime.Size = new Size(285, 30);
            txtCheckOutTime.TabIndex = 17;
            // 
            // lblRoomStatusTransition
            // 
            lblRoomStatusTransition.AutoSize = true;
            lblRoomStatusTransition.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomStatusTransition.ForeColor = Color.Olive;
            lblRoomStatusTransition.Location = new Point(197, 562);
            lblRoomStatusTransition.Name = "lblRoomStatusTransition";
            lblRoomStatusTransition.Size = new Size(201, 20);
            lblRoomStatusTransition.TabIndex = 18;
            lblRoomStatusTransition.Text = "Room status after check-in:";
            // 
            // badgeAvailable
            // 
            badgeAvailable.BackColor = Color.ForestGreen;
            badgeAvailable.FlatStyle = FlatStyle.Flat;
            badgeAvailable.ForeColor = Color.White;
            badgeAvailable.Location = new Point(542, 553);
            badgeAvailable.Margin = new Padding(3, 4, 3, 4);
            badgeAvailable.Name = "badgeAvailable";
            badgeAvailable.Size = new Size(90, 38);
            badgeAvailable.TabIndex = 19;
            badgeAvailable.Text = "Available";
            badgeAvailable.UseVisualStyleBackColor = false;
            // 
            // lblArrow
            // 
            lblArrow.AutoSize = true;
            lblArrow.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblArrow.Location = new Point(642, 557);
            lblArrow.Name = "lblArrow";
            lblArrow.Size = new Size(33, 28);
            lblArrow.TabIndex = 20;
            lblArrow.Text = "➔";
            // 
            // badgeOccupied
            // 
            badgeOccupied.BackColor = Color.Firebrick;
            badgeOccupied.FlatStyle = FlatStyle.Flat;
            badgeOccupied.ForeColor = Color.White;
            badgeOccupied.Location = new Point(677, 553);
            badgeOccupied.Margin = new Padding(3, 4, 3, 4);
            badgeOccupied.Name = "badgeOccupied";
            badgeOccupied.Size = new Size(90, 38);
            badgeOccupied.TabIndex = 21;
            badgeOccupied.Text = "Occupied";
            badgeOccupied.UseVisualStyleBackColor = false;
            // 
            // btnCompleteCheckIn
            // 
            btnCompleteCheckIn.BackColor = Color.FromArgb(40, 167, 69);
            btnCompleteCheckIn.FlatStyle = FlatStyle.Flat;
            btnCompleteCheckIn.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnCompleteCheckIn.ForeColor = Color.White;
            btnCompleteCheckIn.Location = new Point(197, 648);
            btnCompleteCheckIn.Margin = new Padding(3, 4, 3, 4);
            btnCompleteCheckIn.Name = "btnCompleteCheckIn";
            btnCompleteCheckIn.Size = new Size(220, 56);
            btnCompleteCheckIn.TabIndex = 22;
            btnCompleteCheckIn.Text = "🛎️ Complete Check-In";
            btnCompleteCheckIn.UseVisualStyleBackColor = false;
            btnCompleteCheckIn.Click += btnCompleteCheckIn_Click;
            // 
            // btnClearStay
            // 
            btnClearStay.BackColor = Color.Gray;
            btnClearStay.FlatStyle = FlatStyle.Flat;
            btnClearStay.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnClearStay.ForeColor = Color.White;
            btnClearStay.Location = new Point(432, 648);
            btnClearStay.Margin = new Padding(3, 4, 3, 4);
            btnClearStay.Name = "btnClearStay";
            btnClearStay.Size = new Size(120, 56);
            btnClearStay.TabIndex = 23;
            btnClearStay.Text = "Clear";
            btnClearStay.UseVisualStyleBackColor = false;
            btnClearStay.Click += btnClearStay_Click;
            // 
            // lblErrorMsg
            // 
            lblErrorMsg.AutoSize = true;
            lblErrorMsg.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblErrorMsg.ForeColor = Color.Firebrick;
            lblErrorMsg.Location = new Point(197, 648);
            lblErrorMsg.Name = "lblErrorMsg";
            lblErrorMsg.Size = new Size(0, 21);
            lblErrorMsg.TabIndex = 24;
            // 
            // WalkInCheckIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(panelGuestInfo);
            Controls.Add(panelStayDetails);
            Margin = new Padding(3, 4, 3, 4);
            Name = "WalkInCheckIn";
            Size = new Size(1920, 806);
            panelGuestInfo.ResumeLayout(false);
            panelGuestInfo.PerformLayout();
            panelStayDetails.ResumeLayout(false);
            panelStayDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAdults).EndInit();
            ((System.ComponentModel.ISupportInitialize)numChildren).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNights).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelGuestInfo;
        private System.Windows.Forms.Label lblGuestInfoTitle;
        private System.Windows.Forms.Label lblSearchLabel;
        private System.Windows.Forms.TextBox txtSearchGuest;
        private System.Windows.Forms.Button btnFindGuest;
        private System.Windows.Forms.Label lblGuestStatusNotice;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblMI;
        private System.Windows.Forms.TextBox txtMiddleInitial;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblIdType;
        private System.Windows.Forms.ComboBox cmbIdType;
        private System.Windows.Forms.Label lblIdNumber;
        private System.Windows.Forms.TextBox txtIdNumber;
        private System.Windows.Forms.Button btnRegisterGuest;
        private System.Windows.Forms.Button btnClearGuest;

        private System.Windows.Forms.Panel panelStayDetails;
        private System.Windows.Forms.Label lblStayDetailsTitle;
        private System.Windows.Forms.Label lblActiveGuestName;
        private System.Windows.Forms.Label lblAdults;
        private System.Windows.Forms.NumericUpDown numAdults;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.NumericUpDown numChildren;
        private System.Windows.Forms.Label lblNights;
        private System.Windows.Forms.NumericUpDown numNights;
        private System.Windows.Forms.Label lblRoomSelect;
        private System.Windows.Forms.ComboBox cmbAvailableRooms;
        private System.Windows.Forms.Label lblFirstRoomChoice;
        private System.Windows.Forms.Label lblSecondRoomChoice;
        private System.Windows.Forms.Button btnEditMultiRoom;
        private System.Windows.Forms.Label lblRateAdult;
        private System.Windows.Forms.TextBox txtRateAdult;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblCheckInTime;
        private System.Windows.Forms.TextBox txtCheckInTime;
        private System.Windows.Forms.Label lblCheckOutTime;
        private System.Windows.Forms.TextBox txtCheckOutTime;
        private System.Windows.Forms.Label lblRoomStatusTransition;
        private System.Windows.Forms.Button badgeAvailable;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.Button badgeOccupied;
        private System.Windows.Forms.Button btnCompleteCheckIn;
        private System.Windows.Forms.Button btnClearStay;
        private System.Windows.Forms.Label lblErrorMsg;
    }
}