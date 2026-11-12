using System;
using System.Drawing;
using System.Windows.Forms;

namespace UI.Dialogs.Reservation
{
    partial class MultiRoomBookingDialog
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
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblAdults = new Label();
            nudDialogAdults = new NumericUpDown();
            lblChildren = new Label();
            nudDialogChildren = new NumericUpDown();
            lblNights = new Label();
            nudDialogNights = new NumericUpDown();
            lblRoom1 = new Label();
            cmbRoom1 = new ComboBox();
            lblRoom2 = new Label();
            cmbRoom2 = new ComboBox();
            lblTotalHeader = new Label();
            lblDialogTotal = new Label();
            btnSave = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)nudDialogAdults).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDialogChildren).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDialogNights).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(302, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Multi-Room Reservation";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(24, 58);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(481, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Group exceeds single-room limit (12). Select 2 rooms (Max: 16A, 8C).";
            // 
            // lblAdults
            // 
            lblAdults.AutoSize = true;
            lblAdults.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdults.Location = new Point(24, 100);
            lblAdults.Name = "lblAdults";
            lblAdults.Size = new Size(143, 23);
            lblAdults.TabIndex = 2;
            lblAdults.Text = "Total Adults (16)";
            // 
            // nudDialogAdults
            // 
            nudDialogAdults.Font = new Font("Segoe UI", 11F);
            nudDialogAdults.Location = new Point(24, 128);
            nudDialogAdults.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            nudDialogAdults.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDialogAdults.Name = "nudDialogAdults";
            nudDialogAdults.Size = new Size(140, 32);
            nudDialogAdults.TabIndex = 3;
            nudDialogAdults.Value = new decimal(new int[] { 8, 0, 0, 0 });
            nudDialogAdults.ValueChanged += RecalculateDialogTotal;
            // 
            // lblChildren
            // 
            lblChildren.AutoSize = true;
            lblChildren.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblChildren.Location = new Point(190, 100);
            lblChildren.Name = "lblChildren";
            lblChildren.Size = new Size(149, 23);
            lblChildren.TabIndex = 4;
            lblChildren.Text = "Total Children (8)";
            // 
            // nudDialogChildren
            // 
            nudDialogChildren.Font = new Font("Segoe UI", 11F);
            nudDialogChildren.Location = new Point(190, 128);
            nudDialogChildren.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            nudDialogChildren.Name = "nudDialogChildren";
            nudDialogChildren.Size = new Size(140, 32);
            nudDialogChildren.TabIndex = 5;
            nudDialogChildren.ValueChanged += RecalculateDialogTotal;
            // 
            // lblNights
            // 
            lblNights.AutoSize = true;
            lblNights.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNights.Location = new Point(356, 100);
            lblNights.Name = "lblNights";
            lblNights.Size = new Size(63, 23);
            lblNights.TabIndex = 6;
            lblNights.Text = "Nights";
            // 
            // nudDialogNights
            // 
            nudDialogNights.Font = new Font("Segoe UI", 11F);
            nudDialogNights.Location = new Point(356, 128);
            nudDialogNights.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            nudDialogNights.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudDialogNights.Name = "nudDialogNights";
            nudDialogNights.Size = new Size(130, 32);
            nudDialogNights.TabIndex = 7;
            nudDialogNights.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudDialogNights.ValueChanged += RecalculateDialogTotal;
            // 
            // lblRoom1
            // 
            lblRoom1.AutoSize = true;
            lblRoom1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRoom1.Location = new Point(24, 180);
            lblRoom1.Name = "lblRoom1";
            lblRoom1.Size = new Size(168, 23);
            lblRoom1.TabIndex = 8;
            lblRoom1.Text = "First Choice Room *";
            // 
            // cmbRoom1
            // 
            cmbRoom1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom1.Font = new Font("Segoe UI", 11F);
            cmbRoom1.FormattingEnabled = true;
            cmbRoom1.Location = new Point(24, 208);
            cmbRoom1.Name = "cmbRoom1";
            cmbRoom1.Size = new Size(462, 33);
            cmbRoom1.TabIndex = 9;
            cmbRoom1.SelectedIndexChanged += cmbRoom1_SelectedIndexChanged;
            // 
            // lblRoom2
            // 
            lblRoom2.AutoSize = true;
            lblRoom2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRoom2.Location = new Point(24, 260);
            lblRoom2.Name = "lblRoom2";
            lblRoom2.Size = new Size(191, 23);
            lblRoom2.TabIndex = 10;
            lblRoom2.Text = "Second Choice Room *";
            // 
            // cmbRoom2
            // 
            cmbRoom2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoom2.Font = new Font("Segoe UI", 11F);
            cmbRoom2.FormattingEnabled = true;
            cmbRoom2.Location = new Point(24, 288);
            cmbRoom2.Name = "cmbRoom2";
            cmbRoom2.Size = new Size(462, 33);
            cmbRoom2.TabIndex = 11;
            cmbRoom2.SelectedIndexChanged += RecalculateDialogTotal;
            // 
            // lblTotalHeader
            // 
            lblTotalHeader.AutoSize = true;
            lblTotalHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalHeader.Location = new Point(24, 345);
            lblTotalHeader.Name = "lblTotalHeader";
            lblTotalHeader.Size = new Size(235, 25);
            lblTotalHeader.TabIndex = 12;
            lblTotalHeader.Text = "Combined Total Amount:";
            // 
            // lblDialogTotal
            // 
            lblDialogTotal.AutoSize = true;
            lblDialogTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDialogTotal.ForeColor = Color.Green;
            lblDialogTotal.Location = new Point(24, 375);
            lblDialogTotal.Name = "lblDialogTotal";
            lblDialogTotal.Size = new Size(89, 37);
            lblDialogTotal.TabIndex = 13;
            lblDialogTotal.Text = "₱0.00";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(34, 197, 94);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(241, 435);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(245, 50);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save 2-Room Selection";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(100, 116, 139);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(24, 435);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(180, 50);
            btnBack.TabIndex = 15;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // MultiRoomBookingDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(512, 510);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(lblDialogTotal);
            Controls.Add(lblTotalHeader);
            Controls.Add(cmbRoom2);
            Controls.Add(lblRoom2);
            Controls.Add(cmbRoom1);
            Controls.Add(lblRoom1);
            Controls.Add(nudDialogNights);
            Controls.Add(lblNights);
            Controls.Add(nudDialogChildren);
            Controls.Add(lblChildren);
            Controls.Add(nudDialogAdults);
            Controls.Add(lblAdults);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MultiRoomBookingDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "2-Room Booking Setup";
            ((System.ComponentModel.ISupportInitialize)nudDialogAdults).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDialogChildren).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDialogNights).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblAdults;
        private NumericUpDown nudDialogAdults;
        private Label lblChildren;
        private NumericUpDown nudDialogChildren;
        private Label lblNights;
        private NumericUpDown nudDialogNights;
        private Label lblRoom1;
        private ComboBox cmbRoom1;
        private Label lblRoom2;
        private ComboBox cmbRoom2;
        private Label lblTotalHeader;
        private Label lblDialogTotal;
        private Button btnSave;
        private Button btnBack;
    }
}