namespace Model
{
    public class RoomTypeModel
    {
        public int RoomTypeId { get; set; }
        public string TypeName { get; set; }
        public decimal RatePerAdult { get; set; }
        public decimal OverstayRatePerHour { get; set; }
        public int StayHours { get; set; }

        public RoomTypeModel()
        {
            TypeName = string.Empty;
            StayHours = 22;
        }
    }
}