using System;
using System.Collections.Generic;

namespace Model
{
    public class MenuItemModel
    {
        public int MenuItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Category { get; set; }
        public decimal UnitPrice { get; set; }

        public override string ToString() => $"{ItemName}  -  ₱{UnitPrice:N2}";
    }

    public class FoodOrderItemModel
    {
        public int MenuItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount => Quantity * UnitPrice;
    }

    public class ActiveStayBillingModel
    {
        public int PrimaryReservationId { get; set; }
        public List<int> ReservationIds { get; set; } = new List<int>();
        public string GuestName { get; set; }
        public string ContactNo { get; set; }
        public string RoomDisplay { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime ExpectedCheckOut { get; set; }
        public decimal RoomChargeTotal { get; set; }
        public decimal CombinedOverstayHourlyRate { get; set; }
        public string RateBreakdownLabel { get; set; }
        public string OverstayBreakdownLabel { get; set; }

        public override string ToString() => $"Room {RoomDisplay} - {GuestName}";
    }

    public class CheckoutSettlementModel
    {
        public int PrimaryReservationId { get; set; }
        public List<int> ReservationIds { get; set; } = new List<int>();
        public string GuestName { get; set; }
        public string RoomDisplay { get; set; }
        public string CheckInText { get; set; }
        public string CheckOutText { get; set; }
        public string GuestsText { get; set; }

        public decimal RoomCharge { get; set; }
        public decimal OverstayCharge { get; set; }
        public decimal FoodCharge { get; set; }
        public decimal SubTotalBeforeTax => RoomCharge + OverstayCharge + FoodCharge;
        public decimal VatAmount => Math.Round(SubTotalBeforeTax * 0.12m, 2);
        public decimal GrandTotal => SubTotalBeforeTax + VatAmount;

        public List<FoodOrderItemModel> FoodOrders { get; set; } = new List<FoodOrderItemModel>();
        public string PaymentMethod { get; set; }
        public decimal CashTendered { get; set; }
        public decimal ChangeDue { get; set; }
        public string ReferenceNumber { get; set; }
    }
}