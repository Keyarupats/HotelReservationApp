using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UI.Controls
{
    partial class ReceiptUserControl
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
            pnlList = new Panel();
            lblPrintHint = new Label();
            btnPrint = new Button();
            lblErrorMessage = new Label();
            dgvPayments = new DataGridView();
            cmbPayment = new ComboBox();
            lblSelectPayment = new Label();
            lblListTitle = new Label();
            pnlPreview = new Panel();
            pnlPaper = new Panel();
            txtReceiptPreview = new RichTextBox();
            lblPreviewHint = new Label();
            lblPreviewTitle = new Label();
            pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).BeginInit();
            pnlPreview.SuspendLayout();
            pnlPaper.SuspendLayout();
            SuspendLayout();
            // 
            // pnlList
            // 
            pnlList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlList.BackColor = Color.White;
            pnlList.BorderStyle = BorderStyle.FixedSingle;
            pnlList.Controls.Add(lblPrintHint);
            pnlList.Controls.Add(btnPrint);
            pnlList.Controls.Add(lblErrorMessage);
            pnlList.Controls.Add(dgvPayments);
            pnlList.Controls.Add(cmbPayment);
            pnlList.Controls.Add(lblSelectPayment);
            pnlList.Controls.Add(lblListTitle);
            pnlList.Location = new Point(24, 24);
            pnlList.Name = "pnlList";
            pnlList.Size = new Size(700, 833);
            pnlList.TabIndex = 0;
            // 
            // lblPrintHint
            // 
            lblPrintHint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPrintHint.AutoSize = true;
            lblPrintHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblPrintHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPrintHint.Location = new Point(20, 804);
            lblPrintHint.Name = "lblPrintHint";
            lblPrintHint.Size = new Size(320, 23);
            lblPrintHint.TabIndex = 6;
            lblPrintHint.Text = "Opens the standard Windows print dialog.";
            lblPrintHint.UseMnemonic = false;
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPrint.BackColor = Color.FromArgb(0, 120, 215);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(20, 740);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(660, 56);
            btnPrint.TabIndex = 5;
            btnPrint.Text = "Print Receipt";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblErrorMessage.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Location = new Point(20, 664);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(660, 30);
            lblErrorMessage.TabIndex = 4;
            lblErrorMessage.TextAlign = ContentAlignment.MiddleLeft;
            lblErrorMessage.UseMnemonic = false;
            // 
            // dgvPayments
            // 
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.BorderStyle = BorderStyle.None;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Location = new Point(20, 150);
            dgvPayments.MultiSelect = false;
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.RowHeadersWidth = 51;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.Size = new Size(660, 500);
            dgvPayments.TabIndex = 3;
            dgvPayments.CellClick += dgvPayments_CellClick;
            // 
            // cmbPayment
            // 
            cmbPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPayment.Font = new Font("Segoe UI", 11F);
            cmbPayment.FormattingEnabled = true;
            cmbPayment.Location = new Point(20, 98);
            cmbPayment.Name = "cmbPayment";
            cmbPayment.Size = new Size(660, 33);
            cmbPayment.TabIndex = 2;
            cmbPayment.SelectedIndexChanged += cmbPayment_SelectedIndexChanged;
            // 
            // lblSelectPayment
            // 
            lblSelectPayment.AutoSize = true;
            lblSelectPayment.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSelectPayment.ForeColor = Color.FromArgb(44, 62, 80);
            lblSelectPayment.Location = new Point(20, 70);
            lblSelectPayment.Name = "lblSelectPayment";
            lblSelectPayment.Size = new Size(128, 23);
            lblSelectPayment.TabIndex = 1;
            lblSelectPayment.Text = "Select Payment";
            lblSelectPayment.UseMnemonic = false;
            // 
            // lblListTitle
            // 
            lblListTitle.AutoSize = true;
            lblListTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblListTitle.Location = new Point(20, 16);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(257, 35);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "Completed Payments";
            lblListTitle.UseMnemonic = false;
            // 
            // pnlPreview
            // 
            pnlPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPreview.BackColor = Color.White;
            pnlPreview.BorderStyle = BorderStyle.FixedSingle;
            pnlPreview.Controls.Add(pnlPaper);
            pnlPreview.Controls.Add(lblPreviewHint);
            pnlPreview.Controls.Add(lblPreviewTitle);
            pnlPreview.Location = new Point(748, 24);
            pnlPreview.Name = "pnlPreview";
            pnlPreview.Size = new Size(1148, 833);
            pnlPreview.TabIndex = 1;
            // 
            // pnlPaper
            // 
            pnlPaper.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            pnlPaper.BackColor = Color.FromArgb(255, 255, 253);
            pnlPaper.BorderStyle = BorderStyle.FixedSingle;
            pnlPaper.Controls.Add(txtReceiptPreview);
            pnlPaper.Location = new Point(264, 50);
            pnlPaper.Name = "pnlPaper";
            pnlPaper.Size = new Size(620, 777);
            pnlPaper.TabIndex = 2;
            // 
            // txtReceiptPreview
            // 
            txtReceiptPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtReceiptPreview.BackColor = Color.FromArgb(255, 255, 253);
            txtReceiptPreview.BorderStyle = BorderStyle.None;
            txtReceiptPreview.Font = new Font("Consolas", 11F);
            txtReceiptPreview.ForeColor = Color.FromArgb(44, 62, 80);
            txtReceiptPreview.Location = new Point(14, 14);
            txtReceiptPreview.Name = "txtReceiptPreview";
            txtReceiptPreview.ReadOnly = true;
            txtReceiptPreview.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtReceiptPreview.Size = new Size(590, 747);
            txtReceiptPreview.TabIndex = 0;
            txtReceiptPreview.TabStop = false;
            txtReceiptPreview.Text = "";
            txtReceiptPreview.WordWrap = false;
            // 
            // lblPreviewHint
            // 
            lblPreviewHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPreviewHint.AutoSize = true;
            lblPreviewHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblPreviewHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPreviewHint.Location = new Point(880, 24);
            lblPreviewHint.Name = "lblPreviewHint";
            lblPreviewHint.Size = new Size(215, 23);
            lblPreviewHint.TabIndex = 1;
            lblPreviewHint.Text = "Monospaced text (Consolas)";
            lblPreviewHint.UseMnemonic = false;
            // 
            // lblPreviewTitle
            // 
            lblPreviewTitle.AutoSize = true;
            lblPreviewTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblPreviewTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblPreviewTitle.Location = new Point(20, 16);
            lblPreviewTitle.Name = "lblPreviewTitle";
            lblPreviewTitle.Size = new Size(195, 35);
            lblPreviewTitle.TabIndex = 0;
            lblPreviewTitle.Text = "Receipt Preview";
            lblPreviewTitle.UseMnemonic = false;
            // 
            // ReceiptUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(pnlPreview);
            Controls.Add(pnlList);
            Name = "ReceiptUserControl";
            Size = new Size(1920, 881);
            Load += ReceiptUserControl_Load;
            pnlList.ResumeLayout(false);
            pnlList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPayments).EndInit();
            pnlPreview.ResumeLayout(false);
            pnlPreview.PerformLayout();
            pnlPaper.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblSelectPayment;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblPrintHint;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.Label lblPreviewTitle;
        private System.Windows.Forms.Label lblPreviewHint;
        private System.Windows.Forms.Panel pnlPaper;
        private System.Windows.Forms.RichTextBox txtReceiptPreview;
    }
}