namespace UI
{
    partial class ArrivingReservation
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitle = new Label();
            txtSearchReservation = new TextBox();
            btnSearch = new Button();
            rbToday = new RadioButton();
            rbAll = new RadioButton();
            rbSelectDate = new RadioButton();
            dtpFilterDate = new DateTimePicker();
            dataGridViewArriving = new DataGridView();
            btnCheckInSelected = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArriving).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(36, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(259, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Arriving Reservations";
            // 
            // txtSearchReservation
            // 
            txtSearchReservation.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchReservation.Location = new Point(36, 86);
            txtSearchReservation.Margin = new Padding(3, 4, 3, 4);
            txtSearchReservation.Name = "txtSearchReservation";
            txtSearchReservation.PlaceholderText = "Search guest name, mobile, or code...";
            txtSearchReservation.Size = new Size(340, 32);
            txtSearchReservation.TabIndex = 1;
            txtSearchReservation.TextChanged += txtSearchReservation_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 120, 215);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(388, 84);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 38);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // rbToday
            // 
            rbToday.AutoSize = true;
            rbToday.Checked = true;
            rbToday.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            rbToday.Location = new Point(540, 89);
            rbToday.Name = "rbToday";
            rbToday.Size = new Size(152, 29);
            rbToday.TabIndex = 3;
            rbToday.TabStop = true;
            rbToday.Text = "Today's Arrival";
            rbToday.UseVisualStyleBackColor = true;
            rbToday.CheckedChanged += DateFilter_Changed;
            // 
            // rbAll
            // 
            rbAll.AutoSize = true;
            rbAll.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            rbAll.Location = new Point(725, 89);
            rbAll.Name = "rbAll";
            rbAll.Size = new Size(222, 29);
            rbAll.TabIndex = 4;
            rbAll.Text = "All Confirmed Booking";
            rbAll.UseVisualStyleBackColor = true;
            rbAll.CheckedChanged += DateFilter_Changed;
            // 
            // rbSelectDate
            // 
            rbSelectDate.AutoSize = true;
            rbSelectDate.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            rbSelectDate.Location = new Point(972, 89);
            rbSelectDate.Name = "rbSelectDate";
            rbSelectDate.Size = new Size(146, 29);
            rbSelectDate.TabIndex = 5;
            rbSelectDate.Text = "Select a Date!";
            rbSelectDate.UseVisualStyleBackColor = true;
            rbSelectDate.CheckedChanged += DateFilter_Changed;
            // 
            // dtpFilterDate
            // 
            dtpFilterDate.CustomFormat = "MMM dd, yyyy";
            dtpFilterDate.Enabled = false;
            dtpFilterDate.Font = new Font("Segoe UI", 11F);
            dtpFilterDate.Format = DateTimePickerFormat.Custom;
            dtpFilterDate.Location = new Point(1130, 86);
            dtpFilterDate.Name = "dtpFilterDate";
            dtpFilterDate.Size = new Size(195, 32);
            dtpFilterDate.TabIndex = 6;
            dtpFilterDate.ValueChanged += dtpFilterDate_ValueChanged;
            // 
            // dataGridViewArriving
            // 
            dataGridViewArriving.AllowUserToAddRows = false;
            dataGridViewArriving.AllowUserToDeleteRows = false;
            dataGridViewArriving.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewArriving.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArriving.BackgroundColor = Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(226, 232, 240);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewArriving.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewArriving.ColumnHeadersHeight = 46;
            dataGridViewArriving.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(2, 132, 199);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewArriving.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewArriving.EnableHeadersVisualStyles = false;
            dataGridViewArriving.Location = new Point(36, 152);
            dataGridViewArriving.Margin = new Padding(3, 4, 3, 4);
            dataGridViewArriving.MultiSelect = false;
            dataGridViewArriving.Name = "dataGridViewArriving";
            dataGridViewArriving.ReadOnly = true;
            dataGridViewArriving.RowHeadersVisible = false;
            dataGridViewArriving.RowHeadersWidth = 51;
            dataGridViewArriving.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewArriving.Size = new Size(1840, 536);
            dataGridViewArriving.TabIndex = 7;
            // 
            // btnCheckInSelected
            // 
            btnCheckInSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCheckInSelected.BackColor = Color.FromArgb(40, 167, 69);
            btnCheckInSelected.FlatAppearance.BorderSize = 0;
            btnCheckInSelected.FlatStyle = FlatStyle.Flat;
            btnCheckInSelected.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnCheckInSelected.ForeColor = Color.White;
            btnCheckInSelected.Location = new Point(1521, 711);
            btnCheckInSelected.Margin = new Padding(3, 4, 3, 4);
            btnCheckInSelected.Name = "btnCheckInSelected";
            btnCheckInSelected.Size = new Size(355, 52);
            btnCheckInSelected.TabIndex = 8;
            btnCheckInSelected.Text = "🛎️ Check-In Selected Row";
            btnCheckInSelected.UseVisualStyleBackColor = false;
            btnCheckInSelected.Click += btnCheckInSelected_Click;
            // 
            // ArrivingReservation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(btnCheckInSelected);
            Controls.Add(dataGridViewArriving);
            Controls.Add(dtpFilterDate);
            Controls.Add(rbSelectDate);
            Controls.Add(rbAll);
            Controls.Add(rbToday);
            Controls.Add(btnSearch);
            Controls.Add(txtSearchReservation);
            Controls.Add(lblTitle);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ArrivingReservation";
            Size = new Size(1920, 806);
            ((System.ComponentModel.ISupportInitialize)dataGridViewArriving).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearchReservation;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbToday;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbSelectDate;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.DataGridView dataGridViewArriving;
        private System.Windows.Forms.Button btnCheckInSelected;
    }
}