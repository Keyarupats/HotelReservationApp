namespace HotelReservation.Model
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public decimal RatePerNight { get; set; }
        public string Status { get; set; } = "Available";
    }
}