using System;

namespace Model
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }
        public string ReservationCode { get; set; }
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public string ContactNo { get; set; }
        public int RoomId { get; set; }
        public string TypeName { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public DateTime ExpectedCheckOutDateTime { get; set; }
        public DateTime? ActualCheckInDateTime { get; set; }
        public DateTime? ActualCheckOutDateTime { get; set; }
        public decimal RatePerAdult { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReference { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal ChangeDue { get; set; }
        public string Status { get; set; }

        public ReservationModel()
        {
            ReservationCode = string.Empty;
            GuestName = string.Empty;
            ContactNo = string.Empty;
            TypeName = string.Empty;
            PaymentMethod = string.Empty;
            PaymentReference = string.Empty;
            Status = "Pending";
            CheckInDateTime = DateTime.Now;
            ExpectedCheckOutDateTime = DateTime.Now.AddHours(22);
        }
    }
}