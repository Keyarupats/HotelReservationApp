using System;

namespace Model
{
    public class BillingModel
    {
        public int BillingId { get; set; }
        public int ReservationId { get; set; }
        public string ReservationCode { get; set; }
        public decimal BaseRoomRate { get; set; }
        public decimal ExtraGuestFee { get; set; }
        public decimal OverstayFee { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal BalanceDue { get; set; }
        public string PaymentStatus { get; set; } // Paid, Partial, Unpaid
        public DateTime ProcessedAt { get; set; }

        public BillingModel()
        {
            ReservationCode = string.Empty;
            PaymentStatus = "Unpaid";
            ProcessedAt = DateTime.Now;
        }
    }
}