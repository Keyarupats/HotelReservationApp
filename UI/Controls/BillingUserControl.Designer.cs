using System.Windows.Forms;
using System.Drawing;


namespace UI.Controls
{
    partial class BillingUserControl
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
            pnlStay = new Panel();
            lblOverstayHint = new Label();
            nudOverstayHours = new NumericUpDown();
            lblOverstay = new Label();
            pnlDivider1 = new Panel();
            txtTimePast = new TextBox();
            lblTimePast = new Label();
            txtNow = new TextBox();
            lblNow = new Label();
            txtExpectedCheckOut = new TextBox();
            lblExpectedCheckOut = new Label();
            txtCheckIn = new TextBox();
            lblCheckIn = new Label();
            txtChildren = new TextBox();
            lblChildren = new Label();
            txtAdults = new TextBox();
            lblAdults = new Label();
            txtRoom = new TextBox();
            lblRoom = new Label();
            txtGuestName = new TextBox();
            lblGuestName = new Label();
            cmbActiveStay = new ComboBox();
            lblSelectStay = new Label();
            lblStayTitle = new Label();
            pnlCharges = new Panel();
            lblErrorMessage = new Label();
            btnProceedToPayment = new Button();
            pnlSummary = new Panel();
            lblGrandTotalValue = new Label();
            lblGrandTotalText = new Label();
            pnlDivider2 = new Panel();
            lblFoodValue = new Label();
            lblFoodDesc = new Label();
            lblOverstayValue = new Label();
            lblOverstayDesc = new Label();
            lblRoomChargeValue = new Label();
            lblRoomChargeDesc = new Label();
            btnRemoveFood = new Button();
            dgvFoodOrders = new DataGridView();
            btnAddFood = new Button();
            nudFoodQty = new NumericUpDown();
            lblQty = new Label();
            cmbFoodItem = new ComboBox();
            lblAddFood = new Label();
            lblChargesTitle = new Label();
            pnlStay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudOverstayHours).BeginInit();
            pnlCharges.SuspendLayout();
            pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFoodOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFoodQty).BeginInit();
            SuspendLayout();
            // 
            // pnlStay
            // 
            pnlStay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlStay.BackColor = Color.White;
            pnlStay.BorderStyle = BorderStyle.FixedSingle;
            pnlStay.Controls.Add(lblOverstayHint);
            pnlStay.Controls.Add(nudOverstayHours);
            pnlStay.Controls.Add(lblOverstay);
            pnlStay.Controls.Add(pnlDivider1);
            pnlStay.Controls.Add(txtTimePast);
            pnlStay.Controls.Add(lblTimePast);
            pnlStay.Controls.Add(txtNow);
            pnlStay.Controls.Add(lblNow);
            pnlStay.Controls.Add(txtExpectedCheckOut);
            pnlStay.Controls.Add(lblExpectedCheckOut);
            pnlStay.Controls.Add(txtCheckIn);
            pnlStay.Controls.Add(lblCheckIn);
            pnlStay.Controls.Add(txtChildren);
            pnlStay.Controls.Add(lblChildren);
            pnlStay.Controls.Add(txtAdults);
            pnlStay.Controls.Add(lblAdults);
            pnlStay.Controls.Add(txtRoom);
            pnlStay.Controls.Add(lblRoom);
            pnlStay.Controls.Add(txtGuestName);
            pnlStay.Controls.Add(lblGuestName);
            pnlStay.Controls.Add(cmbActiveStay);
            pnlStay.Controls.Add(lblSelectStay);
            pnlStay.Controls.Add(lblStayTitle);
            pnlStay.Location = new Point(24, 24);
            pnlStay.Name = "pnlStay";
            pnlStay.Size = new Size(860, 833);
            pnlStay.TabIndex = 0;
            // 
            // lblOverstayHint
            // 
            lblOverstayHint.AutoSize = true;
            lblOverstayHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblOverstayHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblOverstayHint.Location = new Point(240, 596);
            lblOverstayHint.Name = "lblOverstayHint";
            lblOverstayHint.Size = new Size(315, 23);
            lblOverstayHint.TabIndex = 22;
            lblOverstayHint.Text = "Delays under 30 minutes may be ignored.";
            lblOverstayHint.UseMnemonic = false;
            // 
            // nudOverstayHours
            // 
            nudOverstayHours.Font = new Font("Segoe UI", 11F);
            nudOverstayHours.Location = new Point(20, 590);
            nudOverstayHours.Maximum = new decimal(new int[] { 48, 0, 0, 0 });
            nudOverstayHours.Name = "nudOverstayHours";
            nudOverstayHours.Size = new Size(200, 32);
            nudOverstayHours.TabIndex = 21;
            nudOverstayHours.ValueChanged += nudOverstayHours_ValueChanged;
            // 
            // lblOverstay
            // 
            lblOverstay.AutoSize = true;
            lblOverstay.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblOverstay.ForeColor = Color.FromArgb(44, 62, 80);
            lblOverstay.Location = new Point(20, 560);
            lblOverstay.Name = "lblOverstay";
            lblOverstay.Size = new Size(371, 23);
            lblOverstay.TabIndex = 20;
            lblOverstay.Text = "Billable Overstay Hours (entered by front desk)";
            lblOverstay.UseMnemonic = false;
            // 
            // pnlDivider1
            // 
            pnlDivider1.BackColor = Color.FromArgb(222, 226, 230);
            pnlDivider1.Location = new Point(20, 540);
            pnlDivider1.Name = "pnlDivider1";
            pnlDivider1.Size = new Size(820, 1);
            pnlDivider1.TabIndex = 19;
            // 
            // txtTimePast
            // 
            txtTimePast.BackColor = Color.FromArgb(236, 239, 241);
            txtTimePast.Font = new Font("Segoe UI", 11F);
            txtTimePast.Location = new Point(440, 462);
            txtTimePast.Name = "txtTimePast";
            txtTimePast.ReadOnly = true;
            txtTimePast.Size = new Size(400, 32);
            txtTimePast.TabIndex = 18;
            // 
            // lblTimePast
            // 
            lblTimePast.AutoSize = true;
            lblTimePast.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTimePast.ForeColor = Color.FromArgb(44, 62, 80);
            lblTimePast.Location = new Point(440, 436);
            lblTimePast.Name = "lblTimePast";
            lblTimePast.Size = new Size(171, 23);
            lblTimePast.TabIndex = 17;
            lblTimePast.Text = "Time Past Check-Out";
            lblTimePast.UseMnemonic = false;
            // 
            // txtNow
            // 
            txtNow.BackColor = Color.FromArgb(236, 239, 241);
            txtNow.Font = new Font("Segoe UI", 11F);
            txtNow.Location = new Point(20, 462);
            txtNow.Name = "txtNow";
            txtNow.ReadOnly = true;
            txtNow.Size = new Size(400, 32);
            txtNow.TabIndex = 16;
            // 
            // lblNow
            // 
            lblNow.AutoSize = true;
            lblNow.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblNow.ForeColor = Color.FromArgb(44, 62, 80);
            lblNow.Location = new Point(20, 436);
            lblNow.Name = "lblNow";
            lblNow.Size = new Size(238, 23);
            lblNow.TabIndex = 15;
            lblNow.Text = "Current Date & Time (system)";
            lblNow.UseMnemonic = false;
            // 
            // txtExpectedCheckOut
            // 
            txtExpectedCheckOut.BackColor = Color.FromArgb(236, 239, 241);
            txtExpectedCheckOut.Font = new Font("Segoe UI", 11F);
            txtExpectedCheckOut.Location = new Point(440, 370);
            txtExpectedCheckOut.Name = "txtExpectedCheckOut";
            txtExpectedCheckOut.ReadOnly = true;
            txtExpectedCheckOut.Size = new Size(400, 32);
            txtExpectedCheckOut.TabIndex = 14;
            // 
            // lblExpectedCheckOut
            // 
            lblExpectedCheckOut.AutoSize = true;
            lblExpectedCheckOut.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblExpectedCheckOut.ForeColor = Color.FromArgb(44, 62, 80);
            lblExpectedCheckOut.Location = new Point(440, 344);
            lblExpectedCheckOut.Name = "lblExpectedCheckOut";
            lblExpectedCheckOut.Size = new Size(167, 23);
            lblExpectedCheckOut.TabIndex = 13;
            lblExpectedCheckOut.Text = "Expected Check-Out";
            lblExpectedCheckOut.UseMnemonic = false;
            // 
            // txtCheckIn
            // 
            txtCheckIn.BackColor = Color.FromArgb(236, 239, 241);
            txtCheckIn.Font = new Font("Segoe UI", 11F);
            txtCheckIn.Location = new Point(20, 370);
            txtCheckIn.Name = "txtCheckIn";
            txtCheckIn.ReadOnly = true;
            txtCheckIn.Size = new Size(400, 32);
            txtCheckIn.TabIndex = 12;
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblCheckIn.ForeColor = Color.FromArgb(44, 62, 80);
            lblCheckIn.Location = new Point(20, 344);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(141, 23);
            lblCheckIn.TabIndex = 11;
            lblCheckIn.Text = "Check-In (actual)";
            lblCheckIn.UseMnemonic = false;
            // 
            // txtChildren
            // 
            txtChildren.BackColor = Color.FromArgb(236, 239, 241);
            txtChildren.Font = new Font("Segoe UI", 11F);
            txtChildren.Location = new Point(440, 278);
            txtChildren.Name = "txtChildren";
            txtChildren.ReadOnly = true;
            txtChildren.Size = new Size(400, 32);
            txtChildren.TabIndex = 10;
            // 
            // lblChildren
            // 
            lblChildren.AutoSize = true;
            lblChildren.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblChildren.ForeColor = Color.FromArgb(44, 62, 80);
            lblChildren.Location = new Point(440, 252);
            lblChildren.Name = "lblChildren";
            lblChildren.Size = new Size(312, 23);
            lblChildren.TabIndex = 9;
            lblChildren.Text = "Number of Children (10 y.o. and below)";
            lblChildren.UseMnemonic = false;
            // 
            // txtAdults
            // 
            txtAdults.BackColor = Color.FromArgb(236, 239, 241);
            txtAdults.Font = new Font("Segoe UI", 11F);
            txtAdults.Location = new Point(20, 278);
            txtAdults.Name = "txtAdults";
            txtAdults.ReadOnly = true;
            txtAdults.Size = new Size(400, 32);
            txtAdults.TabIndex = 8;
            // 
            // lblAdults
            // 
            lblAdults.AutoSize = true;
            lblAdults.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAdults.ForeColor = Color.FromArgb(44, 62, 80);
            lblAdults.Location = new Point(20, 252);
            lblAdults.Name = "lblAdults";
            lblAdults.Size = new Size(147, 23);
            lblAdults.TabIndex = 7;
            lblAdults.Text = "Number of Adults";
            lblAdults.UseMnemonic = false;
            // 
            // txtRoom
            // 
            txtRoom.BackColor = Color.FromArgb(236, 239, 241);
            txtRoom.Font = new Font("Segoe UI", 11F);
            txtRoom.Location = new Point(440, 186);
            txtRoom.Name = "txtRoom";
            txtRoom.ReadOnly = true;
            txtRoom.Size = new Size(400, 32);
            txtRoom.TabIndex = 6;
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblRoom.ForeColor = Color.FromArgb(44, 62, 80);
            lblRoom.Location = new Point(440, 160);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(56, 23);
            lblRoom.TabIndex = 5;
            lblRoom.Text = "Room";
            lblRoom.UseMnemonic = false;
            // 
            // txtGuestName
            // 
            txtGuestName.BackColor = Color.FromArgb(236, 239, 241);
            txtGuestName.Font = new Font("Segoe UI", 11F);
            txtGuestName.Location = new Point(20, 186);
            txtGuestName.Name = "txtGuestName";
            txtGuestName.ReadOnly = true;
            txtGuestName.Size = new Size(400, 32);
            txtGuestName.TabIndex = 4;
            // 
            // lblGuestName
            // 
            lblGuestName.AutoSize = true;
            lblGuestName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblGuestName.ForeColor = Color.FromArgb(44, 62, 80);
            lblGuestName.Location = new Point(20, 160);
            lblGuestName.Name = "lblGuestName";
            lblGuestName.Size = new Size(105, 23);
            lblGuestName.TabIndex = 3;
            lblGuestName.Text = "Guest Name";
            lblGuestName.UseMnemonic = false;
            // 
            // cmbActiveStay
            // 
            cmbActiveStay.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActiveStay.Font = new Font("Segoe UI", 11F);
            cmbActiveStay.FormattingEnabled = true;
            cmbActiveStay.Location = new Point(20, 98);
            cmbActiveStay.Name = "cmbActiveStay";
            cmbActiveStay.Size = new Size(820, 33);
            cmbActiveStay.TabIndex = 2;
            cmbActiveStay.SelectedIndexChanged += cmbActiveStay_SelectedIndexChanged;
            // 
            // lblSelectStay
            // 
            lblSelectStay.AutoSize = true;
            lblSelectStay.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSelectStay.ForeColor = Color.FromArgb(44, 62, 80);
            lblSelectStay.Location = new Point(20, 70);
            lblSelectStay.Name = "lblSelectStay";
            lblSelectStay.Size = new Size(145, 23);
            lblSelectStay.TabIndex = 1;
            lblSelectStay.Text = "Select Active Stay";
            lblSelectStay.UseMnemonic = false;
            // 
            // lblStayTitle
            // 
            lblStayTitle.AutoSize = true;
            lblStayTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblStayTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblStayTitle.Location = new Point(20, 16);
            lblStayTitle.Name = "lblStayTitle";
            lblStayTitle.Size = new Size(141, 35);
            lblStayTitle.TabIndex = 0;
            lblStayTitle.Text = "Active Stay";
            lblStayTitle.UseMnemonic = false;
            // 
            // pnlCharges
            // 
            pnlCharges.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCharges.BackColor = Color.White;
            pnlCharges.BorderStyle = BorderStyle.FixedSingle;
            pnlCharges.Controls.Add(lblErrorMessage);
            pnlCharges.Controls.Add(btnProceedToPayment);
            pnlCharges.Controls.Add(pnlSummary);
            pnlCharges.Controls.Add(btnRemoveFood);
            pnlCharges.Controls.Add(dgvFoodOrders);
            pnlCharges.Controls.Add(btnAddFood);
            pnlCharges.Controls.Add(nudFoodQty);
            pnlCharges.Controls.Add(lblQty);
            pnlCharges.Controls.Add(cmbFoodItem);
            pnlCharges.Controls.Add(lblAddFood);
            pnlCharges.Controls.Add(lblChargesTitle);
            pnlCharges.Location = new Point(908, 24);
            pnlCharges.Name = "pnlCharges";
            pnlCharges.Size = new Size(988, 833);
            pnlCharges.TabIndex = 1;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblErrorMessage.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Location = new Point(20, 756);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(500, 30);
            lblErrorMessage.TabIndex = 10;
            lblErrorMessage.TextAlign = ContentAlignment.MiddleLeft;
            lblErrorMessage.UseMnemonic = false;
            // 
            // btnProceedToPayment
            // 
            btnProceedToPayment.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnProceedToPayment.BackColor = Color.FromArgb(40, 167, 69);
            btnProceedToPayment.Cursor = Cursors.Hand;
            btnProceedToPayment.FlatAppearance.BorderSize = 0;
            btnProceedToPayment.FlatStyle = FlatStyle.Flat;
            btnProceedToPayment.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnProceedToPayment.ForeColor = Color.White;
            btnProceedToPayment.Location = new Point(548, 742);
            btnProceedToPayment.Name = "btnProceedToPayment";
            btnProceedToPayment.Size = new Size(420, 56);
            btnProceedToPayment.TabIndex = 9;
            btnProceedToPayment.Text = "Proceed to Payment";
            btnProceedToPayment.UseVisualStyleBackColor = false;
            btnProceedToPayment.Click += btnProceedToPayment_Click;
            // 
            // pnlSummary
            // 
            pnlSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSummary.BackColor = Color.FromArgb(248, 250, 252);
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Controls.Add(lblGrandTotalValue);
            pnlSummary.Controls.Add(lblGrandTotalText);
            pnlSummary.Controls.Add(pnlDivider2);
            pnlSummary.Controls.Add(lblFoodValue);
            pnlSummary.Controls.Add(lblFoodDesc);
            pnlSummary.Controls.Add(lblOverstayValue);
            pnlSummary.Controls.Add(lblOverstayDesc);
            pnlSummary.Controls.Add(lblRoomChargeValue);
            pnlSummary.Controls.Add(lblRoomChargeDesc);
            pnlSummary.Location = new Point(20, 440);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(948, 250);
            pnlSummary.TabIndex = 8;
            // 
            // lblGrandTotalValue
            // 
            lblGrandTotalValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGrandTotalValue.Font = new Font("Segoe UI Semibold", 26F, FontStyle.Bold);
            lblGrandTotalValue.ForeColor = Color.FromArgb(40, 167, 69);
            lblGrandTotalValue.Location = new Point(440, 164);
            lblGrandTotalValue.Name = "lblGrandTotalValue";
            lblGrandTotalValue.Size = new Size(490, 56);
            lblGrandTotalValue.TabIndex = 8;
            lblGrandTotalValue.Text = "₱0.00";
            lblGrandTotalValue.TextAlign = ContentAlignment.MiddleRight;
            lblGrandTotalValue.UseMnemonic = false;
            // 
            // lblGrandTotalText
            // 
            lblGrandTotalText.AutoSize = true;
            lblGrandTotalText.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            lblGrandTotalText.ForeColor = Color.FromArgb(44, 62, 80);
            lblGrandTotalText.Location = new Point(20, 176);
            lblGrandTotalText.Name = "lblGrandTotalText";
            lblGrandTotalText.Size = new Size(158, 37);
            lblGrandTotalText.TabIndex = 7;
            lblGrandTotalText.Text = "Grand Total";
            lblGrandTotalText.UseMnemonic = false;
            // 
            // pnlDivider2
            // 
            pnlDivider2.BackColor = Color.FromArgb(222, 226, 230);
            pnlDivider2.Location = new Point(20, 148);
            pnlDivider2.Name = "pnlDivider2";
            pnlDivider2.Size = new Size(908, 1);
            pnlDivider2.TabIndex = 6;
            // 
            // lblFoodValue
            // 
            lblFoodValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFoodValue.Font = new Font("Segoe UI", 11F);
            lblFoodValue.ForeColor = Color.FromArgb(44, 62, 80);
            lblFoodValue.Location = new Point(660, 100);
            lblFoodValue.Name = "lblFoodValue";
            lblFoodValue.Size = new Size(270, 30);
            lblFoodValue.TabIndex = 5;
            lblFoodValue.Text = "₱0.00";
            lblFoodValue.TextAlign = ContentAlignment.MiddleRight;
            lblFoodValue.UseMnemonic = false;
            // 
            // lblFoodDesc
            // 
            lblFoodDesc.Font = new Font("Segoe UI", 11F);
            lblFoodDesc.ForeColor = Color.FromArgb(44, 62, 80);
            lblFoodDesc.Location = new Point(20, 100);
            lblFoodDesc.Name = "lblFoodDesc";
            lblFoodDesc.Size = new Size(640, 30);
            lblFoodDesc.TabIndex = 4;
            lblFoodDesc.Text = "Food & Services";
            lblFoodDesc.TextAlign = ContentAlignment.MiddleLeft;
            lblFoodDesc.UseMnemonic = false;
            // 
            // lblOverstayValue
            // 
            lblOverstayValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblOverstayValue.Font = new Font("Segoe UI", 11F);
            lblOverstayValue.ForeColor = Color.FromArgb(44, 62, 80);
            lblOverstayValue.Location = new Point(660, 60);
            lblOverstayValue.Name = "lblOverstayValue";
            lblOverstayValue.Size = new Size(270, 30);
            lblOverstayValue.TabIndex = 3;
            lblOverstayValue.Text = "₱0.00";
            lblOverstayValue.TextAlign = ContentAlignment.MiddleRight;
            lblOverstayValue.UseMnemonic = false;
            // 
            // lblOverstayDesc
            // 
            lblOverstayDesc.Font = new Font("Segoe UI", 11F);
            lblOverstayDesc.ForeColor = Color.FromArgb(44, 62, 80);
            lblOverstayDesc.Location = new Point(20, 60);
            lblOverstayDesc.Name = "lblOverstayDesc";
            lblOverstayDesc.Size = new Size(640, 30);
            lblOverstayDesc.TabIndex = 2;
            lblOverstayDesc.Text = "Overstay";
            lblOverstayDesc.TextAlign = ContentAlignment.MiddleLeft;
            lblOverstayDesc.UseMnemonic = false;
            // 
            // lblRoomChargeValue
            // 
            lblRoomChargeValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRoomChargeValue.Font = new Font("Segoe UI", 11F);
            lblRoomChargeValue.ForeColor = Color.FromArgb(44, 62, 80);
            lblRoomChargeValue.Location = new Point(660, 20);
            lblRoomChargeValue.Name = "lblRoomChargeValue";
            lblRoomChargeValue.Size = new Size(270, 30);
            lblRoomChargeValue.TabIndex = 1;
            lblRoomChargeValue.Text = "₱0.00";
            lblRoomChargeValue.TextAlign = ContentAlignment.MiddleRight;
            lblRoomChargeValue.UseMnemonic = false;
            // 
            // lblRoomChargeDesc
            // 
            lblRoomChargeDesc.Font = new Font("Segoe UI", 11F);
            lblRoomChargeDesc.ForeColor = Color.FromArgb(44, 62, 80);
            lblRoomChargeDesc.Location = new Point(20, 20);
            lblRoomChargeDesc.Name = "lblRoomChargeDesc";
            lblRoomChargeDesc.Size = new Size(640, 30);
            lblRoomChargeDesc.TabIndex = 0;
            lblRoomChargeDesc.Text = "Room Charge";
            lblRoomChargeDesc.TextAlign = ContentAlignment.MiddleLeft;
            lblRoomChargeDesc.UseMnemonic = false;
            // 
            // btnRemoveFood
            // 
            btnRemoveFood.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoveFood.BackColor = Color.FromArgb(220, 53, 69);
            btnRemoveFood.Cursor = Cursors.Hand;
            btnRemoveFood.FlatAppearance.BorderSize = 0;
            btnRemoveFood.FlatStyle = FlatStyle.Flat;
            btnRemoveFood.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnRemoveFood.ForeColor = Color.White;
            btnRemoveFood.Location = new Point(848, 388);
            btnRemoveFood.Name = "btnRemoveFood";
            btnRemoveFood.Size = new Size(120, 34);
            btnRemoveFood.TabIndex = 7;
            btnRemoveFood.Text = "Remove";
            btnRemoveFood.UseVisualStyleBackColor = false;
            btnRemoveFood.Click += btnRemoveFood_Click;
            // 
            // dgvFoodOrders
            // 
            dgvFoodOrders.AllowUserToAddRows = false;
            dgvFoodOrders.AllowUserToDeleteRows = false;
            dgvFoodOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvFoodOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFoodOrders.BackgroundColor = Color.White;
            dgvFoodOrders.BorderStyle = BorderStyle.None;
            dgvFoodOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFoodOrders.Location = new Point(20, 150);
            dgvFoodOrders.MultiSelect = false;
            dgvFoodOrders.Name = "dgvFoodOrders";
            dgvFoodOrders.ReadOnly = true;
            dgvFoodOrders.RowHeadersVisible = false;
            dgvFoodOrders.RowHeadersWidth = 51;
            dgvFoodOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFoodOrders.Size = new Size(948, 230);
            dgvFoodOrders.TabIndex = 6;
            // 
            // btnAddFood
            // 
            btnAddFood.BackColor = Color.FromArgb(0, 120, 215);
            btnAddFood.Cursor = Cursors.Hand;
            btnAddFood.FlatAppearance.BorderSize = 0;
            btnAddFood.FlatStyle = FlatStyle.Flat;
            btnAddFood.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnAddFood.ForeColor = Color.White;
            btnAddFood.Location = new Point(680, 96);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(120, 36);
            btnAddFood.TabIndex = 5;
            btnAddFood.Text = "Add";
            btnAddFood.UseVisualStyleBackColor = false;
            btnAddFood.Click += btnAddFood_Click;
            // 
            // nudFoodQty
            // 
            nudFoodQty.Font = new Font("Segoe UI", 11F);
            nudFoodQty.Location = new Point(540, 98);
            nudFoodQty.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudFoodQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFoodQty.Name = "nudFoodQty";
            nudFoodQty.Size = new Size(120, 32);
            nudFoodQty.TabIndex = 4;
            nudFoodQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblQty.ForeColor = Color.FromArgb(44, 62, 80);
            lblQty.Location = new Point(540, 70);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(38, 23);
            lblQty.TabIndex = 3;
            lblQty.Text = "Qty";
            lblQty.UseMnemonic = false;
            // 
            // cmbFoodItem
            // 
            cmbFoodItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFoodItem.Font = new Font("Segoe UI", 11F);
            cmbFoodItem.FormattingEnabled = true;
            cmbFoodItem.Location = new Point(20, 98);
            cmbFoodItem.Name = "cmbFoodItem";
            cmbFoodItem.Size = new Size(500, 33);
            cmbFoodItem.TabIndex = 2;
            // 
            // lblAddFood
            // 
            lblAddFood.AutoSize = true;
            lblAddFood.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblAddFood.ForeColor = Color.FromArgb(44, 62, 80);
            lblAddFood.Location = new Point(20, 70);
            lblAddFood.Name = "lblAddFood";
            lblAddFood.Size = new Size(166, 23);
            lblAddFood.TabIndex = 1;
            lblAddFood.Text = "Add Food or Service";
            lblAddFood.UseMnemonic = false;
            // 
            // lblChargesTitle
            // 
            lblChargesTitle.AutoSize = true;
            lblChargesTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblChargesTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblChargesTitle.Location = new Point(20, 16);
            lblChargesTitle.Name = "lblChargesTitle";
            lblChargesTitle.Size = new Size(107, 35);
            lblChargesTitle.TabIndex = 0;
            lblChargesTitle.Text = "Charges";
            lblChargesTitle.UseMnemonic = false;
            // 
            // BillingUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(pnlCharges);
            Controls.Add(pnlStay);
            Name = "BillingUserControl";
            Size = new Size(1920, 881);
            Load += BillingUserControl_Load;
            pnlStay.ResumeLayout(false);
            pnlStay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudOverstayHours).EndInit();
            pnlCharges.ResumeLayout(false);
            pnlCharges.PerformLayout();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFoodOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFoodQty).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlStay;
        private System.Windows.Forms.Label lblStayTitle;
        private System.Windows.Forms.Label lblSelectStay;
        private System.Windows.Forms.ComboBox cmbActiveStay;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.TextBox txtGuestName;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label lblAdults;
        private System.Windows.Forms.TextBox txtAdults;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.TextBox txtChildren;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.TextBox txtCheckIn;
        private System.Windows.Forms.Label lblExpectedCheckOut;
        private System.Windows.Forms.TextBox txtExpectedCheckOut;
        private System.Windows.Forms.Label lblNow;
        private System.Windows.Forms.TextBox txtNow;
        private System.Windows.Forms.Label lblTimePast;
        private System.Windows.Forms.TextBox txtTimePast;
        private System.Windows.Forms.Panel pnlDivider1;
        private System.Windows.Forms.Label lblOverstay;
        private System.Windows.Forms.NumericUpDown nudOverstayHours;
        private System.Windows.Forms.Label lblOverstayHint;
        private System.Windows.Forms.Panel pnlCharges;
        private System.Windows.Forms.Label lblChargesTitle;
        private System.Windows.Forms.Label lblAddFood;
        private System.Windows.Forms.ComboBox cmbFoodItem;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.NumericUpDown nudFoodQty;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.DataGridView dgvFoodOrders;
        private System.Windows.Forms.Button btnRemoveFood;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblRoomChargeDesc;
        private System.Windows.Forms.Label lblRoomChargeValue;
        private System.Windows.Forms.Label lblOverstayDesc;
        private System.Windows.Forms.Label lblOverstayValue;
        private System.Windows.Forms.Label lblFoodDesc;
        private System.Windows.Forms.Label lblFoodValue;
        private System.Windows.Forms.Panel pnlDivider2;
        private System.Windows.Forms.Label lblGrandTotalText;
        private System.Windows.Forms.Label lblGrandTotalValue;
        private System.Windows.Forms.Button btnProceedToPayment;
        private System.Windows.Forms.Label lblErrorMessage;
    }
}