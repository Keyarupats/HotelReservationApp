namespace Model
{
    public class RoomModel
    {
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public string TypeName { get; set; }
        public decimal RatePerAdult { get; set; }
        public int BedCount { get; set; }
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public string Status { get; set; }

        public RoomModel()
        {
            TypeName = string.Empty;
            Status = "Available";
        }
    }
}