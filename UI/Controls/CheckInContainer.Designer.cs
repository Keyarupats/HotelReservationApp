namespace UI
{
    partial class CheckInContainer
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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSubNav = new Panel();
            btnWalkInGuest = new Button();
            btnArrivingReservation = new Button();
            panelContainerContent = new Panel();
            panelSubNav.SuspendLayout();
            SuspendLayout();
            // 
            // panelSubNav
            // 
            panelSubNav.BackColor = Color.Silver;
            panelSubNav.Controls.Add(btnWalkInGuest);
            panelSubNav.Controls.Add(btnArrivingReservation);
            panelSubNav.Dock = DockStyle.Top;
            panelSubNav.Location = new Point(0, 0);
            panelSubNav.Margin = new Padding(3, 4, 3, 4);
            panelSubNav.Name = "panelSubNav";
            panelSubNav.Size = new Size(1920, 75);
            panelSubNav.TabIndex = 0;
            // 
            // btnWalkInGuest
            // 
            btnWalkInGuest.FlatAppearance.BorderSize = 0;
            btnWalkInGuest.FlatStyle = FlatStyle.Flat;
            btnWalkInGuest.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWalkInGuest.Location = new Point(207, 12);
            btnWalkInGuest.Margin = new Padding(3, 4, 3, 4);
            btnWalkInGuest.Name = "btnWalkInGuest";
            btnWalkInGuest.Size = new Size(150, 50);
            btnWalkInGuest.TabIndex = 1;
            btnWalkInGuest.Text = "Walk-In Guest";
            btnWalkInGuest.UseVisualStyleBackColor = true;
            btnWalkInGuest.Click += btnWalkInGuest_Click;
            // 
            // btnArrivingReservation
            // 
            btnArrivingReservation.FlatAppearance.BorderSize = 0;
            btnArrivingReservation.FlatStyle = FlatStyle.Flat;
            btnArrivingReservation.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnArrivingReservation.Location = new Point(20, 12);
            btnArrivingReservation.Margin = new Padding(3, 4, 3, 4);
            btnArrivingReservation.Name = "btnArrivingReservation";
            btnArrivingReservation.Size = new Size(181, 50);
            btnArrivingReservation.TabIndex = 0;
            btnArrivingReservation.Text = "Arriving Reservation";
            btnArrivingReservation.UseVisualStyleBackColor = true;
            btnArrivingReservation.Click += btnArrivingReservation_Click;
            // 
            // panelContainerContent
            // 
            panelContainerContent.BackColor = Color.Silver;
            panelContainerContent.BorderStyle = BorderStyle.FixedSingle;
            panelContainerContent.Dock = DockStyle.Fill;
            panelContainerContent.Location = new Point(0, 75);
            panelContainerContent.Margin = new Padding(3, 4, 3, 4);
            panelContainerContent.Name = "panelContainerContent";
            panelContainerContent.Size = new Size(1920, 806);
            panelContainerContent.TabIndex = 1;
            // 
            // CheckInContainer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelContainerContent);
            Controls.Add(panelSubNav);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CheckInContainer";
            Size = new Size(1920, 881);
            panelSubNav.ResumeLayout(false);
            ResumeLayout(false);

        }


        private System.Windows.Forms.Panel panelSubNav;
        private System.Windows.Forms.Button btnWalkInGuest;
        private System.Windows.Forms.Button btnArrivingReservation;
        private System.Windows.Forms.Panel panelContainerContent;
    }
}