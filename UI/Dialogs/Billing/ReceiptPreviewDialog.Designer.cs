namespace UI.Dialogs
{
    partial class ReceiptPreviewDialog
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
            txtReceiptOutput = new RichTextBox();
            btnPrint = new Button();
            btnClose = new Button();
            panelTop = new Panel();
            lblTitle = new Label();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // txtReceiptOutput
            // 
            txtReceiptOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtReceiptOutput.BackColor = Color.White;
            txtReceiptOutput.BorderStyle = BorderStyle.None;
            txtReceiptOutput.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtReceiptOutput.Location = new Point(20, 70);
            txtReceiptOutput.Name = "txtReceiptOutput";
            txtReceiptOutput.ReadOnly = true;
            txtReceiptOutput.Size = new Size(430, 480);
            txtReceiptOutput.TabIndex = 0;
            txtReceiptOutput.Text = "";
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPrint.BackColor = Color.FromArgb(40, 167, 69);
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(319, 570);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(139, 38);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "Print Receipt";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(108, 117, 125);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(186, 570);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(115, 38);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(44, 62, 80);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(470, 50);
            panelTop.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(16, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(224, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Official Receipt Preview";
            // 
            // ReceiptPreviewDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(470, 620);
            Controls.Add(panelTop);
            Controls.Add(btnClose);
            Controls.Add(btnPrint);
            Controls.Add(txtReceiptOutput);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ReceiptPreviewDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Receipt Preview";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtReceiptOutput;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
    }
}