namespace UI
{
    partial class LandingPageForm
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
            btnLogout = new Button();
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            lblReceipt = new Label();
            lblBilling = new Label();
            lblReservation = new Label();
            lblCheckIn = new Label();
            lblAvailability = new Label();
            lblGuests = new Label();
            lblRoom = new Label();
            pnlContent = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.CornflowerBlue;
            btnLogout.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = SystemColors.ButtonHighlight;
            btnLogout.Location = new Point(1680, 32);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(137, 45);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkBlue;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnLogout);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1920, 112);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkBlue;
            label1.Font = new Font("Segoe UI", 22.2545452F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(71, 31);
            label1.Name = "label1";
            label1.Size = new Size(723, 46);
            label1.TabIndex = 0;
            label1.Text = "HOTEL RESERVATION AND BILLING SYSTEM";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblReceipt);
            panel2.Controls.Add(lblBilling);
            panel2.Controls.Add(lblReservation);
            panel2.Controls.Add(lblCheckIn);
            panel2.Controls.Add(lblAvailability);
            panel2.Controls.Add(lblGuests);
            panel2.Controls.Add(lblRoom);
            panel2.Location = new Point(0, 111);
            panel2.Name = "panel2";
            panel2.Size = new Size(1920, 90);
            panel2.TabIndex = 2;
            // 
            // lblReceipt
            // 
            lblReceipt.AutoSize = true;
            lblReceipt.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReceipt.Location = new Point(889, 30);
            lblReceipt.Name = "lblReceipt";
            lblReceipt.Size = new Size(83, 30);
            lblReceipt.TabIndex = 7;
            lblReceipt.Text = "Receipt";
            // 
            // lblBilling
            // 
            lblBilling.AutoSize = true;
            lblBilling.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBilling.Location = new Point(768, 30);
            lblBilling.Name = "lblBilling";
            lblBilling.Size = new Size(71, 30);
            lblBilling.TabIndex = 6;
            lblBilling.Text = "Billing";
            // 
            // lblReservation
            // 
            lblReservation.AutoSize = true;
            lblReservation.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReservation.Location = new Point(447, 30);
            lblReservation.Name = "lblReservation";
            lblReservation.Size = new Size(125, 30);
            lblReservation.TabIndex = 5;
            lblReservation.Text = "Reservation";
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCheckIn.Location = new Point(621, 30);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(95, 30);
            lblCheckIn.TabIndex = 4;
            lblCheckIn.Text = "Check-In";
            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvailability.Location = new Point(289, 29);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new Size(117, 30);
            lblAvailability.TabIndex = 3;
            lblAvailability.Text = "Availability";
            lblAvailability.Click += label4_Click;
            // 
            // lblGuests
            // 
            lblGuests.AutoSize = true;
            lblGuests.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGuests.Location = new Point(165, 30);
            lblGuests.Name = "lblGuests";
            lblGuests.Size = new Size(77, 30);
            lblGuests.TabIndex = 3;
            lblGuests.Text = "Guests";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoom.Location = new Point(48, 29);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(79, 30);
            lblRoom.TabIndex = 0;
            lblRoom.Text = "Rooms";
            lblRoom.Click += lblRoom_Click;
            // 
            // pnlContent
            // 
            pnlContent.Location = new Point(3, 198);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1920, 885);
            pnlContent.TabIndex = 3;
            // 
            // LandingPageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            Controls.Add(pnlContent);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LandingPageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LandingPageForm";
            Load += LandingPageForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogout;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label lblReceipt;
        private Label lblBilling;
        private Label lblReservation;
        private Label lblCheckIn;
        private Label lblAvailability;
        private Label lblGuests;
        private Label lblRoom;
        private Panel pnlContent;
    }
}