namespace UI
{
    partial class RoomCardControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomCardControl));
            panel1 = new Panel();
            lblTotalCapacity = new Label();
            lblBelow10 = new Label();
            lblAbove10 = new Label();
            lblBeds = new Label();
            lblStatus = new Label();
            lblRoomRate = new Label();
            lblRoomTier = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblTier = new Label();
            lblRoomNumber = new Label();
            lblRoom = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(lblTotalCapacity);
            panel1.Controls.Add(lblBelow10);
            panel1.Controls.Add(lblAbove10);
            panel1.Controls.Add(lblBeds);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(lblRoomRate);
            panel1.Controls.Add(lblRoomTier);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblTier);
            panel1.Controls.Add(lblRoomNumber);
            panel1.Controls.Add(lblRoom);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(419, 674);
            panel1.TabIndex = 0;
            // 
            // lblTotalCapacity
            // 
            lblTotalCapacity.Anchor = AnchorStyles.Right;
            lblTotalCapacity.AutoSize = true;
            lblTotalCapacity.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTotalCapacity.ForeColor = Color.DimGray;
            lblTotalCapacity.Location = new Point(371, 531);
            lblTotalCapacity.Name = "lblTotalCapacity";
            lblTotalCapacity.Size = new Size(25, 31);
            lblTotalCapacity.TabIndex = 17;
            lblTotalCapacity.Text = "3";
            // 
            // lblBelow10
            // 
            lblBelow10.Anchor = AnchorStyles.Right;
            lblBelow10.AutoSize = true;
            lblBelow10.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblBelow10.ForeColor = Color.DimGray;
            lblBelow10.Location = new Point(371, 622);
            lblBelow10.Name = "lblBelow10";
            lblBelow10.Size = new Size(23, 31);
            lblBelow10.TabIndex = 16;
            lblBelow10.Text = "1";
            // 
            // lblAbove10
            // 
            lblAbove10.Anchor = AnchorStyles.Right;
            lblAbove10.AutoSize = true;
            lblAbove10.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblAbove10.ForeColor = Color.DimGray;
            lblAbove10.Location = new Point(371, 580);
            lblAbove10.Name = "lblAbove10";
            lblAbove10.Size = new Size(26, 31);
            lblAbove10.TabIndex = 15;
            lblAbove10.Text = "2";
            // 
            // lblBeds
            // 
            lblBeds.Anchor = AnchorStyles.Right;
            lblBeds.AutoSize = true;
            lblBeds.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblBeds.ForeColor = Color.DimGray;
            lblBeds.Location = new Point(371, 475);
            lblBeds.Name = "lblBeds";
            lblBeds.Size = new Size(23, 31);
            lblBeds.TabIndex = 14;
            lblBeds.Text = "1";
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(288, 422);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(113, 31);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "Available";
            // 
            // lblRoomRate
            // 
            lblRoomRate.Anchor = AnchorStyles.Right;
            lblRoomRate.AutoSize = true;
            lblRoomRate.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRoomRate.ForeColor = Color.DimGray;
            lblRoomRate.Location = new Point(318, 381);
            lblRoomRate.Name = "lblRoomRate";
            lblRoomRate.Size = new Size(81, 31);
            lblRoomRate.TabIndex = 12;
            lblRoomRate.Text = "₱1,200";
            // 
            // lblRoomTier
            // 
            lblRoomTier.Anchor = AnchorStyles.Right;
            lblRoomTier.AutoSize = true;
            lblRoomTier.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblRoomTier.ForeColor = Color.DimGray;
            lblRoomTier.Location = new Point(294, 338);
            lblRoomTier.Name = "lblRoomTier";
            lblRoomTier.Size = new Size(107, 31);
            lblRoomTier.TabIndex = 11;
            lblRoomTier.Text = "Economy";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(22, 622);
            label6.Name = "label6";
            label6.Size = new Size(199, 31);
            label6.TabIndex = 10;
            label6.Text = "10 y.o. and below:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(22, 580);
            label5.Name = "label5";
            label5.Size = new Size(158, 31);
            label5.TabIndex = 9;
            label5.Text = "Above 10 y.o.:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 531);
            label4.Name = "label4";
            label4.Size = new Size(195, 31);
            label4.TabIndex = 8;
            label4.Text = "Persons Capacity:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(22, 475);
            label3.Name = "label3";
            label3.Size = new Size(180, 31);
            label3.TabIndex = 7;
            label3.Text = "Number of Bed:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 381);
            label2.Name = "label2";
            label2.Size = new Size(66, 31);
            label2.TabIndex = 6;
            label2.Text = "Rate:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 422);
            label1.Name = "label1";
            label1.Size = new Size(83, 31);
            label1.TabIndex = 5;
            label1.Text = "Status:";
            // 
            // lblTier
            // 
            lblTier.AutoSize = true;
            lblTier.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTier.Location = new Point(22, 338);
            lblTier.Name = "lblTier";
            lblTier.Size = new Size(61, 31);
            lblTier.TabIndex = 4;
            lblTier.Text = "Tier:";
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomNumber.Location = new Point(89, 18);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(23, 31);
            lblRoomNumber.TabIndex = 3;
            lblRoomNumber.Text = "1";
            // 
            // lblRoom
            // 
            lblRoom.AutoSize = true;
            lblRoom.Font = new Font("Segoe UI Semibold", 13.7454548F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoom.Location = new Point(22, 18);
            lblRoom.Name = "lblRoom";
            lblRoom.Size = new Size(75, 31);
            lblRoom.TabIndex = 2;
            lblRoom.Text = "Room";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 65);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(371, 250);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // RoomCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 0);
            Controls.Add(panel1);
            Margin = new Padding(25, 15, 25, 15);
            Name = "RoomCardControl";
            Size = new Size(419, 691);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label lblRoom;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblTier;
        private Label lblRoomNumber;
        private Label lblTotalCapacity;
        private Label lblBelow10;
        private Label lblAbove10;
        private Label lblBeds;
        private Label lblStatus;
        private Label lblRoomRate;
        private Label lblRoomTier;
    }
}
