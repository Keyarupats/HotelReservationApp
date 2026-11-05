namespace UI
{
    partial class ArrivingReservation
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
            lblTitle = new Label();
            txtSearchReservation = new TextBox();
            btnSearch = new Button();
            dataGridViewArriving = new DataGridView();
            btnCheckInSelected = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewArriving).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(30, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(321, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Arriving Reservations (Today)";
            // 
            // txtSearchReservation
            // 
            txtSearchReservation.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchReservation.Location = new Point(36, 88);
            txtSearchReservation.Margin = new Padding(3, 4, 3, 4);
            txtSearchReservation.Name = "txtSearchReservation";
            txtSearchReservation.Size = new Size(300, 30);
            txtSearchReservation.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(0, 120, 215);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(350, 86);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 42);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridViewArriving
            // 
            dataGridViewArriving.AllowUserToAddRows = false;
            dataGridViewArriving.AllowUserToDeleteRows = false;
            dataGridViewArriving.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewArriving.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArriving.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewArriving.Location = new Point(36, 157);
            dataGridViewArriving.Margin = new Padding(3, 4, 3, 4);
            dataGridViewArriving.Name = "dataGridViewArriving";
            dataGridViewArriving.ReadOnly = true;
            dataGridViewArriving.RowHeadersWidth = 51;
            dataGridViewArriving.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewArriving.Size = new Size(1840, 531);
            dataGridViewArriving.TabIndex = 3;
            // 
            // btnCheckInSelected
            // 
            btnCheckInSelected.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCheckInSelected.BackColor = Color.FromArgb(40, 167, 69);
            btnCheckInSelected.FlatAppearance.BorderSize = 0;
            btnCheckInSelected.FlatStyle = FlatStyle.Flat;
            btnCheckInSelected.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            btnCheckInSelected.ForeColor = Color.White;
            btnCheckInSelected.Location = new Point(1676, 711);
            btnCheckInSelected.Margin = new Padding(3, 4, 3, 4);
            btnCheckInSelected.Name = "btnCheckInSelected";
            btnCheckInSelected.Size = new Size(200, 52);
            btnCheckInSelected.TabIndex = 4;
            btnCheckInSelected.Text = "Check-In Selected";
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
        private System.Windows.Forms.DataGridView dataGridViewArriving;
        private System.Windows.Forms.Button btnCheckInSelected;
    }
}