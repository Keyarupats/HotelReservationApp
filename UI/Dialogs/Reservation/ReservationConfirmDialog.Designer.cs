namespace UI.Dialogs.Reservation
{
    partial class ReservationConfirmDialog
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlCard = new Panel();
            btnCancel = new Button();
            btnConfirmSave = new Button();
            lblTotalValue = new Label();
            lblTotalTitle = new Label();
            lblGuestsValue = new Label();
            lblGuestsTitle = new Label();
            lblRoomsValue = new Label();
            lblRoomsTitle = new Label();
            lblCheckOutValue = new Label();
            lblCheckOutTitle = new Label();
            lblCheckInValue = new Label();
            lblCheckInTitle = new Label();
            lblGuestValue = new Label();
            lblGuestTitle = new Label();
            lblSubtitle = new Label();
            lblHeader = new Label();
            pnlCard.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.BorderStyle = BorderStyle.FixedSingle;
            pnlCard.Controls.Add(btnCancel);
            pnlCard.Controls.Add(btnConfirmSave);
            pnlCard.Controls.Add(lblTotalValue);
            pnlCard.Controls.Add(lblTotalTitle);
            pnlCard.Controls.Add(lblGuestsValue);
            pnlCard.Controls.Add(lblGuestsTitle);
            pnlCard.Controls.Add(lblRoomsValue);
            pnlCard.Controls.Add(lblRoomsTitle);
            pnlCard.Controls.Add(lblCheckOutValue);
            pnlCard.Controls.Add(lblCheckOutTitle);
            pnlCard.Controls.Add(lblCheckInValue);
            pnlCard.Controls.Add(lblCheckInTitle);
            pnlCard.Controls.Add(lblGuestValue);
            pnlCard.Controls.Add(lblGuestTitle);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblHeader);
            pnlCard.Dock = DockStyle.Fill;
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(585, 480);
            pnlCard.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(226, 232, 240);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(51, 65, 85);
            btnCancel.Location = new Point(374, 399);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(167, 48);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnConfirmSave
            // 
            btnConfirmSave.BackColor = Color.FromArgb(2, 132, 199);
            btnConfirmSave.FlatStyle = FlatStyle.Flat;
            btnConfirmSave.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnConfirmSave.ForeColor = Color.White;
            btnConfirmSave.Location = new Point(25, 399);
            btnConfirmSave.Name = "btnConfirmSave";
            btnConfirmSave.Size = new Size(328, 48);
            btnConfirmSave.TabIndex = 14;
            btnConfirmSave.Text = "💾 Confirm && Save";
            btnConfirmSave.UseVisualStyleBackColor = false;
            btnConfirmSave.Click += btnConfirmSave_Click;
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.Green;
            lblTotalValue.Location = new Point(141, 352);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(80, 35);
            lblTotalValue.TabIndex = 13;
            lblTotalValue.Text = "₱0.00";
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTotalTitle.Location = new Point(24, 357);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(120, 25);
            lblTotalTitle.TabIndex = 12;
            lblTotalTitle.Text = "Total Quote:";
            // 
            // lblGuestsValue
            // 
            lblGuestsValue.AutoSize = true;
            lblGuestsValue.Font = new Font("Segoe UI", 10F);
            lblGuestsValue.Location = new Point(142, 329);
            lblGuestsValue.Name = "lblGuestsValue";
            lblGuestsValue.Size = new Size(231, 23);
            lblGuestsValue.TabIndex = 11;
            lblGuestsValue.Text = "2 Adults, 0 Children (1 Night)";
            // 
            // lblGuestsTitle
            // 
            lblGuestsTitle.AutoSize = true;
            lblGuestsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGuestsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblGuestsTitle.Location = new Point(25, 329);
            lblGuestsTitle.Name = "lblGuestsTitle";
            lblGuestsTitle.Size = new Size(101, 23);
            lblGuestsTitle.TabIndex = 10;
            lblGuestsTitle.Text = "Occupancy:";
            // 
            // lblRoomsValue
            // 
            lblRoomsValue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRoomsValue.Location = new Point(142, 185);
            lblRoomsValue.Name = "lblRoomsValue";
            lblRoomsValue.Size = new Size(272, 143);
            lblRoomsValue.TabIndex = 9;
            lblRoomsValue.Text = "Room 101";
            // 
            // lblRoomsTitle
            // 
            lblRoomsTitle.AutoSize = true;
            lblRoomsTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRoomsTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblRoomsTitle.Location = new Point(25, 185);
            lblRoomsTitle.Name = "lblRoomsTitle";
            lblRoomsTitle.Size = new Size(81, 23);
            lblRoomsTitle.TabIndex = 8;
            lblRoomsTitle.Text = "Room(s):";
            // 
            // lblCheckOutValue
            // 
            lblCheckOutValue.AutoSize = true;
            lblCheckOutValue.Font = new Font("Segoe UI", 10F);
            lblCheckOutValue.Location = new Point(142, 153);
            lblCheckOutValue.Name = "lblCheckOutValue";
            lblCheckOutValue.Size = new Size(184, 23);
            lblCheckOutValue.TabIndex = 7;
            lblCheckOutValue.Text = "Nov 14, 2026 12:00 PM";
            // 
            // lblCheckOutTitle
            // 
            lblCheckOutTitle.AutoSize = true;
            lblCheckOutTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCheckOutTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCheckOutTitle.Location = new Point(25, 153);
            lblCheckOutTitle.Name = "lblCheckOutTitle";
            lblCheckOutTitle.Size = new Size(99, 23);
            lblCheckOutTitle.TabIndex = 6;
            lblCheckOutTitle.Text = "Check-Out:";
            // 
            // lblCheckInValue
            // 
            lblCheckInValue.AutoSize = true;
            lblCheckInValue.Font = new Font("Segoe UI", 10F);
            lblCheckInValue.Location = new Point(142, 130);
            lblCheckInValue.Name = "lblCheckInValue";
            lblCheckInValue.Size = new Size(184, 23);
            lblCheckInValue.TabIndex = 5;
            lblCheckInValue.Text = "Nov 13, 2026 02:00 PM";
            // 
            // lblCheckInTitle
            // 
            lblCheckInTitle.AutoSize = true;
            lblCheckInTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCheckInTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblCheckInTitle.Location = new Point(25, 130);
            lblCheckInTitle.Name = "lblCheckInTitle";
            lblCheckInTitle.Size = new Size(84, 23);
            lblCheckInTitle.TabIndex = 4;
            lblCheckInTitle.Text = "Check-In:";
            // 
            // lblGuestValue
            // 
            lblGuestValue.AutoSize = true;
            lblGuestValue.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblGuestValue.ForeColor = Color.FromArgb(2, 132, 199);
            lblGuestValue.Location = new Point(142, 91);
            lblGuestValue.Name = "lblGuestValue";
            lblGuestValue.Size = new Size(116, 25);
            lblGuestValue.TabIndex = 3;
            lblGuestValue.Text = "Guest Name";
            // 
            // lblGuestTitle
            // 
            lblGuestTitle.AutoSize = true;
            lblGuestTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGuestTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblGuestTitle.Location = new Point(25, 92);
            lblGuestTitle.Name = "lblGuestTitle";
            lblGuestTitle.Size = new Size(60, 23);
            lblGuestTitle.TabIndex = 2;
            lblGuestTitle.Text = "Guest:";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.DimGray;
            lblSubtitle.Location = new Point(25, 52);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(362, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Please review the booking summary before saving.";
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.FromArgb(15, 23, 42);
            lblHeader.Location = new Point(24, 20);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(307, 32);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Confirm New Reservation";
            // 
            // ReservationConfirmDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 480);
            Controls.Add(pnlCard);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReservationConfirmDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirm Reservation";
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlCard;
        private Label lblHeader;
        private Label lblSubtitle;
        private Label lblGuestTitle;
        private Label lblGuestValue;
        private Label lblCheckInTitle;
        private Label lblCheckInValue;
        private Label lblCheckOutTitle;
        private Label lblCheckOutValue;
        private Label lblRoomsTitle;
        private Label lblRoomsValue;
        private Label lblGuestsTitle;
        private Label lblGuestsValue;
        private Label lblTotalTitle;
        private Label lblTotalValue;
        private Button btnConfirmSave;
        private Button btnCancel;
    }
}