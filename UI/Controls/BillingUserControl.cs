using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HotelReservation.BusinessLogic.Controller;
using Model;

namespace UI.Controls
{
    public partial class BillingUserControl : UserControl
    {
        private readonly BillingController billingController = new BillingController();

        private DataTable foodTable;
        private ActiveStayBillingModel currentStay;
        private decimal roomCharge;
        private decimal overstayCharge;
        private decimal foodCharge;
        private decimal grandTotal;

        public BillingUserControl()
        {
            InitializeComponent();
            BuildFoodTable();
            StyleGrid(dgvFoodOrders);
        }

        private void BillingUserControl_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            RefreshBillingData();
        }

        public void RefreshBillingData()
        {
            LoadFoodMenu();
            LoadActiveStays();
        }

        private void LoadActiveStays()
        {
            try
            {
                List<ActiveStayBillingModel> stays = billingController.GetActiveOccupiedStays();
                cmbActiveStay.DataSource = null;
                cmbActiveStay.DataSource = stays;
                cmbActiveStay.SelectedIndex = stays.Count > 0 ? 0 : -1;

                if (stays.Count == 0)
                {
                    ClearStayFields();
                }
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error loading occupied stays: " + ex.Message;
            }
        }

        private void LoadFoodMenu()
        {
            try
            {
                List<MenuItemModel> menu = billingController.GetAvailableMenuItems();
                cmbFoodItem.DataSource = null;
                cmbFoodItem.DataSource = menu;
                cmbFoodItem.SelectedIndex = menu.Count > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = "Error loading menu items: " + ex.Message;
            }
        }

        private void ClearStayFields()
        {
            currentStay = null;
            txtGuestName.Clear();
            txtRoom.Clear();
            txtAdults.Clear();
            txtChildren.Clear();
            txtCheckIn.Clear();
            txtExpectedCheckOut.Clear();
            txtNow.Clear();
            txtTimePast.Clear();
            nudOverstayHours.Value = 0;
            foodTable.Rows.Clear();
            RecalculateTotals();
        }

        private void cmbActiveStay_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentStay = cmbActiveStay.SelectedItem as ActiveStayBillingModel;
            lblErrorMessage.Text = "";
            foodTable.Rows.Clear();

            if (currentStay == null)
            {
                ClearStayFields();
                return;
            }

            txtGuestName.Text = currentStay.GuestName;
            txtRoom.Text = currentStay.RoomDisplay;
            txtAdults.Text = currentStay.Adults.ToString();
            txtChildren.Text = currentStay.Children.ToString();
            txtCheckIn.Text = currentStay.CheckIn.ToString("MMM dd, yyyy  hh:mm tt");
            txtExpectedCheckOut.Text = currentStay.ExpectedCheckOut.ToString("MMM dd, yyyy  hh:mm tt");

            DateTime now = DateTime.Now;
            txtNow.Text = now.ToString("MMM dd, yyyy  hh:mm tt");

            TimeSpan late = now - currentStay.ExpectedCheckOut;
            if (late.TotalMinutes > 0)
            {
                txtTimePast.Text = $"{(int)late.TotalHours} h {late.Minutes} min";
                txtTimePast.ForeColor = Color.DarkOrange;

                int suggestedHours = (int)late.TotalHours + (late.Minutes >= 30 ? 1 : 0);
                nudOverstayHours.Value = Math.Min((decimal)suggestedHours, nudOverstayHours.Maximum);
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
            MenuItemModel item = cmbFoodItem.SelectedItem as MenuItemModel;

            if (currentStay == null)
            {
                lblErrorMessage.Text = "Select an active stay first.";
                return;
            }
            if (item == null)
            {
                lblErrorMessage.Text = "Select a food or service item to add.";
                return;
            }

            int qty = (int)nudFoodQty.Value;

            foreach (DataRow row in foodTable.Rows)
            {
                if (Convert.ToInt32(row["MenuItemId"]) == item.MenuItemId)
                {
                    int newQty = Convert.ToInt32(row["Qty"]) + qty;
                    row["Qty"] = newQty;
                    row["Amount"] = newQty * item.UnitPrice;
                    RecalculateTotals();
                    return;
                }
            }

            foodTable.Rows.Add(item.MenuItemId, item.ItemName, qty, item.UnitPrice, qty * item.UnitPrice);
            RecalculateTotals();
        }

        private void btnRemoveFood_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";

            if (dgvFoodOrders.CurrentRow == null)
            {
                lblErrorMessage.Text = "Select an item row to remove.";
                return;
            }

            if (dgvFoodOrders.CurrentRow.DataBoundItem is DataRowView view)
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

            var orders = new List<FoodOrderItemModel>();
            foreach (DataRow row in foodTable.Rows)
            {
                orders.Add(new FoodOrderItemModel
                {
                    MenuItemId = Convert.ToInt32(row["MenuItemId"]),
                    ItemName = row["Item"].ToString(),
                    Quantity = Convert.ToInt32(row["Qty"]),
                    UnitPrice = Convert.ToDecimal(row["Price"])
                });
            }

            var settlement = new CheckoutSettlementModel
            {
                PrimaryReservationId = currentStay.PrimaryReservationId,
                ReservationIds = new List<int>(currentStay.ReservationIds),
                GuestName = currentStay.GuestName,
                RoomDisplay = currentStay.RoomDisplay,
                CheckInText = txtCheckIn.Text,
                CheckOutText = txtNow.Text,
                GuestsText = $"{currentStay.Adults} adult(s), {currentStay.Children} child(ren)",
                RoomCharge = roomCharge,
                OverstayCharge = overstayCharge,
                FoodCharge = foodCharge,
                FoodOrders = orders
            };
            Control container = this.Parent;
            if (container != null)
            {
                PaymentUserControl paymentUc = new PaymentUserControl();
                paymentUc.Dock = DockStyle.Fill;
                paymentUc.LoadSettlement(settlement);

                paymentUc.BackToBillRequested += (s, args) =>
                {
                    container.Controls.Remove(paymentUc);
                    paymentUc.Dispose();
                    this.Visible = true;
                    this.BringToFront();
                };

                paymentUc.CheckoutCompleted += (s, args) =>
                {
                    container.Controls.Remove(paymentUc);
                    paymentUc.Dispose();
                    this.Visible = true;
                    this.BringToFront();
                    RefreshBillingData();
                };

                this.Visible = false;
                container.Controls.Add(paymentUc);
                paymentUc.BringToFront();
            }
        }

        private void RecalculateTotals()
        {
            roomCharge = 0m;
            overstayCharge = 0m;
            foodCharge = 0m;

            if (currentStay != null)
            {
                roomCharge = currentStay.RoomChargeTotal;
                int hours = (int)nudOverstayHours.Value;
                overstayCharge = billingController.CalculateOverstayCharge(currentStay, hours);

                lblRoomChargeDesc.Text = $"Room Charge  ({currentStay.RateBreakdownLabel})";
                lblOverstayDesc.Text = $"Overstay  ({hours} h × {currentStay.OverstayBreakdownLabel})";
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

            decimal subTotal = roomCharge + overstayCharge + foodCharge;
            decimal vat = Math.Round(subTotal * 0.12m, 2);
            grandTotal = subTotal + vat;

            lblRoomChargeValue.Text = Peso(roomCharge);
            lblOverstayValue.Text = Peso(overstayCharge);
            lblFoodValue.Text = Peso(foodCharge);
            lblSubtotalValue.Text = Peso(subTotal); 
            lblVatValue.Text = Peso(vat);           
            lblGrandTotalValue.Text = Peso(grandTotal); 
        }

        private void BuildFoodTable()
        {
            foodTable = new DataTable();
            foodTable.Columns.Add("MenuItemId", typeof(int));
            foodTable.Columns.Add("Item", typeof(string));
            foodTable.Columns.Add("Qty", typeof(int));
            foodTable.Columns.Add("Price", typeof(decimal));
            foodTable.Columns.Add("Amount", typeof(decimal));

            dgvFoodOrders.DataSource = foodTable;
            dgvFoodOrders.Columns["MenuItemId"].Visible = false;
            dgvFoodOrders.Columns["Price"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvFoodOrders.Columns["Amount"].DefaultCellStyle.Format = "₱#,##0.00";
            dgvFoodOrders.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvFoodOrders.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private static string Peso(decimal value) => "₱" + value.ToString("N2");

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
}