using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace UI.Controls
{
    partial class ReportsUserControl
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
            pnlFilter = new Panel();
            lblStartDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpEndDate = new DateTimePicker();
            btnFilter = new Button();
            lblErrorMessage = new Label();
            pnlCardRevenue = new Panel();
            pnlAccentRevenue = new Panel();
            lblRevenueTitle = new Label();
            lblRevenueValue = new Label();
            pnlCardStays = new Panel();
            pnlAccentStays = new Panel();
            lblStaysTitle = new Label();
            lblStaysValue = new Label();
            pnlCardOccupancy = new Panel();
            pnlAccentOccupancy = new Panel();
            lblOccupancyTitle = new Label();
            lblOccupancyValue = new Label();
            pnlBreakdown = new Panel();
            lblBreakdownTitle = new Label();
            dgvRevenueByType = new DataGridView();
            lblFootnote = new Label();
            ((System.ComponentModel.ISupportInitialize)(dgvRevenueByType)).BeginInit();
            pnlFilter.SuspendLayout();
            pnlCardRevenue.SuspendLayout();
            pnlAccentRevenue.SuspendLayout();
            pnlCardStays.SuspendLayout();
            pnlAccentStays.SuspendLayout();
            pnlCardOccupancy.SuspendLayout();
            pnlAccentOccupancy.SuspendLayout();
            pnlBreakdown.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(lblErrorMessage);
            pnlFilter.Controls.Add(btnFilter);
            pnlFilter.Controls.Add(dtpEndDate);
            pnlFilter.Controls.Add(lblEndDate);
            pnlFilter.Controls.Add(dtpStartDate);
            pnlFilter.Controls.Add(lblStartDate);
            pnlFilter.Location = new Point(24, 24);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1872, 84);
            pnlFilter.BackColor = Color.White;
            pnlFilter.BorderStyle = BorderStyle.FixedSingle;
            pnlFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilter.TabIndex = 0;
            // 
            // lblStartDate
            // 
            lblStartDate.Location = new Point(24, 28);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Text = "Start Date";
            lblStartDate.ForeColor = Color.FromArgb(44, 62, 80);
            lblStartDate.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblStartDate.AutoSize = true;
            lblStartDate.UseMnemonic = false;
            lblStartDate.TabIndex = 0;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(130, 22);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 32);
            dtpStartDate.Font = new Font("Segoe UI", 11F);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "MMM dd, yyyy";
            dtpStartDate.TabIndex = 1;
            // 
            // lblEndDate
            // 
            lblEndDate.Location = new Point(370, 28);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Text = "End Date";
            lblEndDate.ForeColor = Color.FromArgb(44, 62, 80);
            lblEndDate.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblEndDate.AutoSize = true;
            lblEndDate.UseMnemonic = false;
            lblEndDate.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(460, 22);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 32);
            dtpEndDate.Font = new Font("Segoe UI", 11F);
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "MMM dd, yyyy";
            dtpEndDate.TabIndex = 3;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(700, 20);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(170, 38);
            btnFilter.Text = "Filter Report";
            btnFilter.BackColor = Color.FromArgb(0, 120, 215);
            btnFilter.ForeColor = Color.White;
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Cursor = Cursors.Hand;
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.TabIndex = 4;
            btnFilter.Click += btnFilter_Click;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.Location = new Point(900, 28);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(700, 28);
            lblErrorMessage.Text = "";
            lblErrorMessage.ForeColor = Color.Red;
            lblErrorMessage.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblErrorMessage.AutoSize = false;
            lblErrorMessage.UseMnemonic = false;
            lblErrorMessage.TextAlign = ContentAlignment.MiddleLeft;
            lblErrorMessage.TabIndex = 5;
            // 
            // pnlCardRevenue
            // 
            pnlCardRevenue.Controls.Add(lblRevenueValue);
            pnlCardRevenue.Controls.Add(lblRevenueTitle);
            pnlCardRevenue.Controls.Add(pnlAccentRevenue);
            pnlCardRevenue.Location = new Point(24, 132);
            pnlCardRevenue.Name = "pnlCardRevenue";
            pnlCardRevenue.Size = new Size(608, 150);
            pnlCardRevenue.BackColor = Color.White;
            pnlCardRevenue.BorderStyle = BorderStyle.FixedSingle;
            pnlCardRevenue.TabIndex = 1;
            // 
            // pnlAccentRevenue
            // 
            pnlAccentRevenue.Location = new Point(0, 0);
            pnlAccentRevenue.Name = "pnlAccentRevenue";
            pnlAccentRevenue.Size = new Size(10, 148);
            pnlAccentRevenue.BackColor = Color.FromArgb(40, 167, 69);
            pnlAccentRevenue.TabIndex = 0;
            // 
            // lblRevenueTitle
            // 
            lblRevenueTitle.Location = new Point(36, 24);
            lblRevenueTitle.Name = "lblRevenueTitle";
            lblRevenueTitle.Text = "Total Revenue";
            lblRevenueTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblRevenueTitle.Font = new Font("Segoe UI", 14F);
            lblRevenueTitle.AutoSize = true;
            lblRevenueTitle.UseMnemonic = false;
            lblRevenueTitle.TabIndex = 1;
            // 
            // lblRevenueValue
            // 
            lblRevenueValue.Location = new Point(36, 64);
            lblRevenueValue.Name = "lblRevenueValue";
            lblRevenueValue.Text = "0";
            lblRevenueValue.ForeColor = Color.FromArgb(40, 167, 69);
            lblRevenueValue.Font = new Font("Segoe UI Semibold", 32F, FontStyle.Bold);
            lblRevenueValue.AutoSize = true;
            lblRevenueValue.UseMnemonic = false;
            lblRevenueValue.TabIndex = 2;
            // 
            // pnlCardStays
            // 
            pnlCardStays.Controls.Add(lblStaysValue);
            pnlCardStays.Controls.Add(lblStaysTitle);
            pnlCardStays.Controls.Add(pnlAccentStays);
            pnlCardStays.Location = new Point(656, 132);
            pnlCardStays.Name = "pnlCardStays";
            pnlCardStays.Size = new Size(608, 150);
            pnlCardStays.BackColor = Color.White;
            pnlCardStays.BorderStyle = BorderStyle.FixedSingle;
            pnlCardStays.TabIndex = 2;
            // 
            // pnlAccentStays
            // 
            pnlAccentStays.Location = new Point(0, 0);
            pnlAccentStays.Name = "pnlAccentStays";
            pnlAccentStays.Size = new Size(10, 148);
            pnlAccentStays.BackColor = Color.FromArgb(0, 120, 215);
            pnlAccentStays.TabIndex = 0;
            // 
            // lblStaysTitle
            // 
            lblStaysTitle.Location = new Point(36, 24);
            lblStaysTitle.Name = "lblStaysTitle";
            lblStaysTitle.Text = "Completed Stays";
            lblStaysTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblStaysTitle.Font = new Font("Segoe UI", 14F);
            lblStaysTitle.AutoSize = true;
            lblStaysTitle.UseMnemonic = false;
            lblStaysTitle.TabIndex = 1;
            // 
            // lblStaysValue
            // 
            lblStaysValue.Location = new Point(36, 64);
            lblStaysValue.Name = "lblStaysValue";
            lblStaysValue.Text = "0";
            lblStaysValue.ForeColor = Color.FromArgb(0, 120, 215);
            lblStaysValue.Font = new Font("Segoe UI Semibold", 32F, FontStyle.Bold);
            lblStaysValue.AutoSize = true;
            lblStaysValue.UseMnemonic = false;
            lblStaysValue.TabIndex = 2;
            // 
            // pnlCardOccupancy
            // 
            pnlCardOccupancy.Controls.Add(lblOccupancyValue);
            pnlCardOccupancy.Controls.Add(lblOccupancyTitle);
            pnlCardOccupancy.Controls.Add(pnlAccentOccupancy);
            pnlCardOccupancy.Location = new Point(1288, 132);
            pnlCardOccupancy.Name = "pnlCardOccupancy";
            pnlCardOccupancy.Size = new Size(608, 150);
            pnlCardOccupancy.BackColor = Color.White;
            pnlCardOccupancy.BorderStyle = BorderStyle.FixedSingle;
            pnlCardOccupancy.TabIndex = 3;
            // 
            // pnlAccentOccupancy
            // 
            pnlAccentOccupancy.Location = new Point(0, 0);
            pnlAccentOccupancy.Name = "pnlAccentOccupancy";
            pnlAccentOccupancy.Size = new Size(10, 148);
            pnlAccentOccupancy.BackColor = Color.FromArgb(142, 68, 173);
            pnlAccentOccupancy.TabIndex = 0;
            // 
            // lblOccupancyTitle
            // 
            lblOccupancyTitle.Location = new Point(36, 24);
            lblOccupancyTitle.Name = "lblOccupancyTitle";
            lblOccupancyTitle.Text = "Occupancy Rate";
            lblOccupancyTitle.ForeColor = Color.FromArgb(108, 117, 125);
            lblOccupancyTitle.Font = new Font("Segoe UI", 14F);
            lblOccupancyTitle.AutoSize = true;
            lblOccupancyTitle.UseMnemonic = false;
            lblOccupancyTitle.TabIndex = 1;
            // 
            // lblOccupancyValue
            // 
            lblOccupancyValue.Location = new Point(36, 64);
            lblOccupancyValue.Name = "lblOccupancyValue";
            lblOccupancyValue.Text = "0";
            lblOccupancyValue.ForeColor = Color.FromArgb(142, 68, 173);
            lblOccupancyValue.Font = new Font("Segoe UI Semibold", 32F, FontStyle.Bold);
            lblOccupancyValue.AutoSize = true;
            lblOccupancyValue.UseMnemonic = false;
            lblOccupancyValue.TabIndex = 2;
            // 
            // pnlBreakdown
            // 
            pnlBreakdown.Controls.Add(lblFootnote);
            pnlBreakdown.Controls.Add(dgvRevenueByType);
            pnlBreakdown.Controls.Add(lblBreakdownTitle);
            pnlBreakdown.Location = new Point(24, 306);
            pnlBreakdown.Name = "pnlBreakdown";
            pnlBreakdown.Size = new Size(1872, 551);
            pnlBreakdown.BackColor = Color.White;
            pnlBreakdown.BorderStyle = BorderStyle.FixedSingle;
            pnlBreakdown.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlBreakdown.TabIndex = 4;
            // 
            // lblBreakdownTitle
            // 
            lblBreakdownTitle.Location = new Point(20, 16);
            lblBreakdownTitle.Name = "lblBreakdownTitle";
            lblBreakdownTitle.Text = "Revenue & Stays by Room Type";
            lblBreakdownTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblBreakdownTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblBreakdownTitle.AutoSize = true;
            lblBreakdownTitle.UseMnemonic = false;
            lblBreakdownTitle.TabIndex = 0;
            // 
            // dgvRevenueByType
            // 
            dgvRevenueByType.Location = new Point(20, 70);
            dgvRevenueByType.Name = "dgvRevenueByType";
            dgvRevenueByType.Size = new Size(1832, 380);
            dgvRevenueByType.AllowUserToAddRows = false;
            dgvRevenueByType.AllowUserToDeleteRows = false;
            dgvRevenueByType.ReadOnly = true;
            dgvRevenueByType.RowHeadersVisible = false;
            dgvRevenueByType.BackgroundColor = Color.White;
            dgvRevenueByType.BorderStyle = BorderStyle.None;
            dgvRevenueByType.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenueByType.MultiSelect = false;
            dgvRevenueByType.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRevenueByType.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenueByType.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRevenueByType.TabIndex = 1;
            // 
            // lblFootnote
            // 
            lblFootnote.Location = new Point(20, 490);
            lblFootnote.Name = "lblFootnote";
            lblFootnote.Size = new Size(1800, 28);
            lblFootnote.Text = "";
            lblFootnote.ForeColor = Color.FromArgb(108, 117, 125);
            lblFootnote.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblFootnote.AutoSize = false;
            lblFootnote.UseMnemonic = false;
            lblFootnote.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblFootnote.TabIndex = 2;
            // 
            // ReportsUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(pnlBreakdown);
            Controls.Add(pnlCardOccupancy);
            Controls.Add(pnlCardStays);
            Controls.Add(pnlCardRevenue);
            Controls.Add(pnlFilter);
            Name = "ReportsUserControl";
            Size = new Size(1920, 881);
            Load += ReportsUserControl_Load;
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlCardRevenue.ResumeLayout(false);
            pnlCardRevenue.PerformLayout();
            pnlAccentRevenue.ResumeLayout(false);
            pnlAccentRevenue.PerformLayout();
            pnlCardStays.ResumeLayout(false);
            pnlCardStays.PerformLayout();
            pnlAccentStays.ResumeLayout(false);
            pnlAccentStays.PerformLayout();
            pnlCardOccupancy.ResumeLayout(false);
            pnlCardOccupancy.PerformLayout();
            pnlAccentOccupancy.ResumeLayout(false);
            pnlAccentOccupancy.PerformLayout();
            pnlBreakdown.ResumeLayout(false);
            pnlBreakdown.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvRevenueByType)).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Panel pnlCardRevenue;
        private System.Windows.Forms.Panel pnlAccentRevenue;
        private System.Windows.Forms.Label lblRevenueTitle;
        private System.Windows.Forms.Label lblRevenueValue;
        private System.Windows.Forms.Panel pnlCardStays;
        private System.Windows.Forms.Panel pnlAccentStays;
        private System.Windows.Forms.Label lblStaysTitle;
        private System.Windows.Forms.Label lblStaysValue;
        private System.Windows.Forms.Panel pnlCardOccupancy;
        private System.Windows.Forms.Panel pnlAccentOccupancy;
        private System.Windows.Forms.Label lblOccupancyTitle;
        private System.Windows.Forms.Label lblOccupancyValue;
        private System.Windows.Forms.Panel pnlBreakdown;
        private System.Windows.Forms.Label lblBreakdownTitle;
        private System.Windows.Forms.DataGridView dgvRevenueByType;
        private System.Windows.Forms.Label lblFootnote;
    }
}