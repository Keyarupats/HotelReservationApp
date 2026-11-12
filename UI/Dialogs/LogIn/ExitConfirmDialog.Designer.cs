namespace UI.Dialogs.LogIn
{
    partial class ExitConfirmDialog
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
            lblMessage = new Label();
            btnNo = new Button();
            btnYes = new Button();
            panel2 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Top;
            lblMessage.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(0, 0);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(573, 106);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Do you really want to exit?";
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnNo
            // 
            btnNo.BackColor = Color.Silver;
            btnNo.FlatStyle = FlatStyle.Flat;
            btnNo.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnNo.Location = new Point(33, 121);
            btnNo.Margin = new Padding(4, 5, 4, 5);
            btnNo.Name = "btnNo";
            btnNo.Size = new Size(233, 76);
            btnNo.TabIndex = 1;
            btnNo.Text = "No, I do not want to exit";
            btnNo.UseVisualStyleBackColor = false;
            btnNo.Click += btnNo_Click;
            // 
            // btnYes
            // 
            btnYes.BackColor = Color.FromArgb(128, 128, 255);
            btnYes.FlatAppearance.BorderColor = Color.Gray;
            btnYes.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            btnYes.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 0, 192);
            btnYes.FlatStyle = FlatStyle.Flat;
            btnYes.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            btnYes.ForeColor = SystemColors.ButtonFace;
            btnYes.Location = new Point(304, 121);
            btnYes.Margin = new Padding(4, 5, 4, 5);
            btnYes.Name = "btnYes";
            btnYes.Size = new Size(233, 76);
            btnYes.TabIndex = 2;
            btnYes.Text = "I want to exit";
            btnYes.UseVisualStyleBackColor = false;
            btnYes.Click += btnYes_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(btnNo);
            panel2.Controls.Add(btnYes);
            panel2.Controls.Add(lblMessage);
            panel2.Location = new Point(3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(573, 225);
            panel2.TabIndex = 3;
            // 
            // ExitConfirmDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 192);
            ClientSize = new Size(579, 232);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExitConfirmDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Exit Confirmation";
            panel2.ResumeLayout(false);
            ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private Panel panel2;
    }
}