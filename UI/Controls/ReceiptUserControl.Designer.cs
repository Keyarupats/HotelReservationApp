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
            lblListTitle = new Label();
            lblSelectPayment = new Label();
            cmbPayment = new ComboBox();
            dgvPayments = new DataGridView();
            lblErrorMessage = new Label();
            btnPrint = new Button();
            lblPrintHint = new Label();
            pnlPreview = new Panel();
            lblPreviewTitle = new Label();
            lblPreviewHint = new Label();
            pnlPaper = new Panel();
            txtReceiptPreview = new TextBox();
            ((System.ComponentModel.ISupportInitialize)(dgvPayments)).BeginInit();
            pnlList.SuspendLayout();
            pnlPreview.SuspendLayout();
            pnlPaper.SuspendLayout();
            SuspendLayout();
            // 
            // pnlList
            // 
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
            pnlList.BackColor = Color.White;
            pnlList.BorderStyle = BorderStyle.FixedSingle;
            pnlList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            pnlList.TabIndex = 0;
            // 
            // lblListTitle
            // 
            lblListTitle.Location = new Point(20, 16);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Text = "Completed Payments";
            lblListTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblListTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblListTitle.AutoSize = true;
            lblListTitle.UseMnemonic = false;
            lblListTitle.TabIndex = 0;
            // 
            // lblSelectPayment
            // 
            lblSelectPayment.Location = new Point(20, 70);
            lblSelectPayment.Name = "lblSelectPayment";
            lblSelectPayment.Text = "Select Payment";
            lblSelectPayment.ForeColor = Color.FromArgb(44, 62, 80);
            lblSelectPayment.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblSelectPayment.AutoSize = true;
            lblSelectPayment.UseMnemonic = false;
            lblSelectPayment.TabIndex = 1;
            // 
            // cmbPayment
            // 
            cmbPayment.Location = new Point(20, 98);
            cmbPayment.Name = "cmbPayment";
            cmbPayment.Size = new Size(660, 33);
            cmbPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPayment.Font = new Font("Segoe UI", 11F);
            cmbPayment.FormattingEnabled = true;
            cmbPayment.TabIndex = 2;
            cmbPayment.SelectedIndexChanged += cmbPayment_SelectedIndexChanged;
            // 
            // dgvPayments
            // 
            dgvPayments.Location = new Point(20, 150);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.Size = new Size(660, 500);
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;
            dgvPayments.BackgroundColor = Color.White;
            dgvPayments.BorderStyle = BorderStyle.None;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.MultiSelect = false;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPayments.TabIndex = 3;
            dgvPayments.CellClick += dgvPayments_CellClick;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.Location = new Point(20, 664);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(660, 30);
            lblErrorMessage.Text = "";
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblErrorMessage.AutoSize = false;
            lblErrorMessage.UseMnemonic = false;
            lblErrorMessage.TextAlign = ContentAlignment.MiddleLeft;
            lblErrorMessage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblErrorMessage.TabIndex = 4;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(20, 740);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(660, 56);
            btnPrint.Text = "Print Receipt";
            btnPrint.BackColor = Color.FromArgb(0, 120, 215);
            btnPrint.ForeColor = Color.White;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.TabIndex = 5;
            btnPrint.Click += btnPrint_Click;
            // 
            // lblPrintHint
            // 
            lblPrintHint.Location = new Point(20, 804);
            lblPrintHint.Name = "lblPrintHint";
            lblPrintHint.Text = "Opens the standard Windows print dialog.";
            lblPrintHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPrintHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblPrintHint.AutoSize = true;
            lblPrintHint.UseMnemonic = false;
            lblPrintHint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblPrintHint.TabIndex = 6;
            // 
            // pnlPreview
            // 
            pnlPreview.Controls.Add(pnlPaper);
            pnlPreview.Controls.Add(lblPreviewHint);
            pnlPreview.Controls.Add(lblPreviewTitle);
            pnlPreview.Location = new Point(748, 24);
            pnlPreview.Name = "pnlPreview";
            pnlPreview.Size = new Size(1148, 833);
            pnlPreview.BackColor = Color.White;
            pnlPreview.BorderStyle = BorderStyle.FixedSingle;
            pnlPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPreview.TabIndex = 1;
            // 
            // lblPreviewTitle
            // 
            lblPreviewTitle.Location = new Point(20, 16);
            lblPreviewTitle.Name = "lblPreviewTitle";
            lblPreviewTitle.Text = "Receipt Preview";
            lblPreviewTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblPreviewTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblPreviewTitle.AutoSize = true;
            lblPreviewTitle.UseMnemonic = false;
            lblPreviewTitle.TabIndex = 0;
            // 
            // lblPreviewHint
            // 
            lblPreviewHint.Location = new Point(880, 24);
            lblPreviewHint.Name = "lblPreviewHint";
            lblPreviewHint.Text = "Monospaced text (Consolas)";
            lblPreviewHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblPreviewHint.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblPreviewHint.AutoSize = true;
            lblPreviewHint.UseMnemonic = false;
            lblPreviewHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPreviewHint.TabIndex = 1;
            // 
            // pnlPaper
            // 
            pnlPaper.Controls.Add(txtReceiptPreview);
            pnlPaper.Location = new Point(264, 70);
            pnlPaper.Name = "pnlPaper";
            pnlPaper.Size = new Size(620, 740);
            pnlPaper.BackColor = Color.FromArgb(255, 255, 253);
            pnlPaper.BorderStyle = BorderStyle.FixedSingle;
            pnlPaper.Anchor = AnchorStyles.Top;
            pnlPaper.TabIndex = 2;
            // 
            // txtReceiptPreview
            // 
            txtReceiptPreview.Location = new Point(14, 14);
            txtReceiptPreview.Name = "txtReceiptPreview";
            txtReceiptPreview.Size = new Size(590, 710);
            txtReceiptPreview.Multiline = true;
            txtReceiptPreview.ReadOnly = true;
            txtReceiptPreview.WordWrap = false;
            txtReceiptPreview.BorderStyle = BorderStyle.None;
            txtReceiptPreview.BackColor = Color.FromArgb(255, 255, 253);
            txtReceiptPreview.Font = new Font("Consolas", 11F);
            txtReceiptPreview.ForeColor = Color.FromArgb(44, 62, 80);
            txtReceiptPreview.TabStop = false;
            txtReceiptPreview.TabIndex = 0;
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
            pnlPreview.ResumeLayout(false);
            pnlPreview.PerformLayout();
            pnlPaper.ResumeLayout(false);
            pnlPaper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvPayments)).EndInit();
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
        private System.Windows.Forms.TextBox txtReceiptPreview;
    }
}