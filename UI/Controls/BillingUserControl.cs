using System.Data;

namespace UI.Controls
{
  public partial class BillingUserControl : UserControl
    {
        private static readonly bool DemoMode = true;

        public event EventHandler<BillSummaryEventArgs> ProceedToPaymentRequested;

        private DataTable foodTable;
        private DemoStay currentStay;
        private decimal grandTotal;

        private class DemoStay
        {
            public int ReservationId;
            public string Display;
            public string GuestName;
            public string Room;
            public int Adults;
            public int Children;
            public DateTime CheckIn;
            public DateTime ExpectedCheckOut;
            public decimal RatePerAdult;
            public decimal OverstayRatePerHour;
            public override string ToString() { return Display; }
        }

        private class FoodItem
        {
            public string Name;
            public decimal Price;
            public override string ToString() { return Name + "  -  ₱" + Price.ToString("N2"); }
        }

        public BillingUserControl()
        {
            InitializeComponent();
            BuildFoodTable();
            StyleGrid(dgvFoodOrders);
        }

        private void BillingUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            if (DemoMode)
            {
                LoadFoodMenu();
                LoadActiveStays();
            }
        }

        // ---------------------------------------------------------------- data loading
        private void LoadActiveStays()
        {
            // TODO: replace with the controller call that returns reservations with Status = 'Occupied'
            List<DemoStay> stays = new List<DemoStay>();

            DateTime now = DateTime.Now;
            DemoStay a = new DemoStay();
            a.ReservationId = 7;
            a.Display = "Room 1001 - Carlo Mendoza";
            a.GuestName = "Carlo Mendoza";
            a.Room = "1001 - Economy";
            a.Adults = 2;
            a.Children = 1;
            a.CheckIn = now.AddHours(-24.5);
            a.ExpectedCheckOut = a.CheckIn.AddHours(22);
            a.RatePerAdult = 1200m;
            a.OverstayRatePerHour = 200m;
            stays.Add(a);

            DemoStay b = new DemoStay();
            b.ReservationId = 8;
            b.Display = "Room 1010 - Jose Ramos";
            b.GuestName = "Jose Ramos";
            b.Room = "1010 - Economy";
            b.Adults = 10;
            b.Children = 3;
            b.CheckIn = now.AddHours(-10);
            b.ExpectedCheckOut = b.CheckIn.AddHours(22);
            b.RatePerAdult = 1200m;
            b.OverstayRatePerHour = 200m;
            stays.Add(b);

            cmbActiveStay.DataSource = null;
            cmbActiveStay.DataSource = stays;
            cmbActiveStay.SelectedIndex = stays.Count > 0 ? 0 : -1;
        }

        private void LoadFoodMenu()
        {
            // TODO: replace with the fixed food menu (name and price) from the database
            List<FoodItem> menu = new List<FoodItem>();
            menu.Add(new FoodItem { Name = "Breakfast Set", Price = 250m });
            menu.Add(new FoodItem { Name = "Chicken Meal", Price = 280m });
            menu.Add(new FoodItem { Name = "Burger & Fries", Price = 220m });
            menu.Add(new FoodItem { Name = "Pancit Canton", Price = 180m });
            menu.Add(new FoodItem { Name = "Coffee", Price = 70m });
            menu.Add(new FoodItem { Name = "Soft Drink", Price = 60m });
            menu.Add(new FoodItem { Name = "Bottled Water", Price = 40m });

            cmbFoodItem.DataSource = menu;
            cmbFoodItem.SelectedIndex = menu.Count > 0 ? 0 : -1;
        }

        // ---------------------------------------------------------------- events
        private void cmbActiveStay_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentStay = cmbActiveStay.SelectedItem as DemoStay;
            lblErrorMessage.Text = "";
            foodTable.Rows.Clear();

            if (currentStay == null)
            {
                txtGuestName.Clear();
                txtRoom.Clear();
                txtAdults.Clear();
                txtChildren.Clear();
                txtCheckIn.Clear();
                txtExpectedCheckOut.Clear();
                txtNow.Clear();
                txtTimePast.Clear();
                nudOverstayHours.Value = 0;
                RecalculateTotals();
                return;
            }

            txtGuestName.Text = currentStay.GuestName;
            txtRoom.Text = currentStay.Room;
            txtAdults.Text = currentStay.Adults.ToString();
            txtChildren.Text = currentStay.Children.ToString();
            txtCheckIn.Text = currentStay.CheckIn.ToString("MMM dd, yyyy  hh:mm tt");
            txtExpectedCheckOut.Text = currentStay.ExpectedCheckOut.ToString("MMM dd, yyyy  hh:mm tt");

            DateTime now = DateTime.Now;
            txtNow.Text = now.ToString("MMM dd, yyyy  hh:mm tt");

            TimeSpan late = now - currentStay.ExpectedCheckOut;
            if (late.TotalMinutes > 0)
            {
                txtTimePast.Text = ((int)late.TotalHours).ToString() + " h " + late.Minutes.ToString() + " min";
                txtTimePast.ForeColor = Color.DarkOrange;
                // Suggested billable hours = whole hours late (the front desk can change it)
                decimal suggested = (decimal)Math.Floor(late.TotalHours);
                nudOverstayHours.Value = Math.Min(suggested, nudOverstayHours.Maximum);
            }
            else
            {
                txtTimePast.Text = "On time";
                txtTimePast.ForeColor = Color.Green;
                nudOverstayHours.Value = 0;
            }

            RecalculateTotals();
        }

        private void nudOverstayHours_ValueChanged(object sender, EventArgs e)
        {
            RecalculateTotals();
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            FoodItem item = cmbFoodItem.SelectedItem as FoodItem;

            if (currentStay == null)
            {
                lblErrorMessage.Text = "Select an active stay first.";
                return;
            }

            if (item == null)
            {
                lblErrorMessage.Text = "Select a food item to add.";
                return;
            }

            int qty = (int)nudFoodQty.Value;

            foreach (DataRow row in foodTable.Rows)
            {
                if (row["Item"].ToString() == item.Name)
                {
                    int newQty = Convert.ToInt32(row["Qty"]) + qty;
                    row["Qty"] = newQty;
                    row["Amount"] = newQty * item.Price;
                    RecalculateTotals();
                    return;
                }
            }

            foodTable.Rows.Add(item.Name, qty, item.Price, qty * item.Price);
            RecalculateTotals();
        }

        private void btnRemoveFood_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            if (dgvFoodOrders.CurrentRow == null)
            {
                lblErrorMessage.Text = "Select a food row to remove.";
                return;
            }

            DataRowView view = dgvFoodOrders.CurrentRow.DataBoundItem as DataRowView;
            if (view != null)
            {
                foodTable.Rows.Remove(view.Row);
                RecalculateTotals();
            }
        }

        private void btnProceedToPayment_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            if (currentStay == null)
            {
                lblErrorMessage.Text = "Please select an active stay first.";
                return;
            }

            if (ProceedToPaymentRequested == null)
            {
                // Simplified, non-technical message box text:
                MessageBox.Show("The payment window is not linked to the main dashboard yet.",
                                "Payment Form Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PaymentUserControl payment = new PaymentUserControl();
            payment.Show();

            BillSummaryEventArgs args = new BillSummaryEventArgs();
            args.ReservationId = currentStay.ReservationId;
            args.GrandTotal = grandTotal;
            ProceedToPaymentRequested(payment, args);
        }

        // ---------------------------------------------------------------- helpers
        private void RecalculateTotals()
        {
            decimal roomCharge = 0m;
            decimal overstayCharge = 0m;
            decimal foodCharge = 0m;

            if (currentStay != null)
            {
                // TODO: move these formulas into the BillingController so the form only displays results
                roomCharge = currentStay.Adults * currentStay.RatePerAdult;
                overstayCharge = (int)nudOverstayHours.Value * currentStay.Adults * currentStay.OverstayRatePerHour;

                lblRoomChargeDesc.Text = "Room Charge  (" + currentStay.Adults.ToString() + " adults x " + Peso(currentStay.RatePerAdult) + ")";
                lblOverstayDesc.Text = "Overstay  (" + ((int)nudOverstayHours.Value).ToString() + " h x " + currentStay.Adults.ToString() + " adults x " + Peso(currentStay.OverstayRatePerHour) + ")";
            }
            else
            {
                lblRoomChargeDesc.Text = "Room Charge";
                lblOverstayDesc.Text = "Overstay";
            }

            foreach (DataRow row in foodTable.Rows)
            {
                foodCharge += Convert.ToDecimal(row["Amount"]);
            }

            grandTotal = roomCharge + overstayCharge + foodCharge;

            lblRoomChargeValue.Text = Peso(roomCharge);
            lblOverstayValue.Text = Peso(overstayCharge);
            lblFoodValue.Text = Peso(foodCharge);
            lblGrandTotalValue.Text = Peso(grandTotal);
        }

        private void BuildFoodTable()
        {
            foodTable = new DataTable();
            foodTable.Columns.Add("Item", typeof(string));
            foodTable.Columns.Add("Qty", typeof(int));
            foodTable.Columns.Add("Price", typeof(decimal));
            foodTable.Columns.Add("Amount", typeof(decimal));
            dgvFoodOrders.DataSource = foodTable;
            dgvFoodOrders.Columns["Price"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvFoodOrders.Columns["Amount"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvFoodOrders.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFoodOrders.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private static string Peso(decimal value)
        {
            return "₱" + value.ToString("N2");
        }

        private static void StyleGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grid.ColumnHeadersHeight = 36;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(214, 234, 248);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(44, 62, 80);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            grid.RowTemplate.Height = 32;
        }
    }

    public class BillSummaryEventArgs : EventArgs
    {
        public int ReservationId { get; set; }
        public decimal GrandTotal { get; set; }
    }
}