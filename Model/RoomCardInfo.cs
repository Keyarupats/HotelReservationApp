using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class RoomCardInfo
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomTier { get; set; }
        public decimal RoomRate { get; set; }
        public string Status { get; set; } 
        public string BedConfiguration { get; set; }
        public int TotalCapacity { get; set; }
        public int Above10Capacity { get; set; }
        public int Below10Capacity { get; set; }
        public string ImagePath { get; set; }

        public string CurrentGuestName { get; set; }
        public DateTime? ExpectedCheckOut { get; set; }

        public bool IsOverstay =>
            Status != null &&
            Status.Equals("Occupied", StringComparison.OrdinalIgnoreCase) &&
            ExpectedCheckOut.HasValue &&
            DateTime.Now > ExpectedCheckOut.Value;
    }
}
