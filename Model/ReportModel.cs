using System.Collections.Generic;

namespace Model
{
    public class RoomTypeReportRow
    {
        public string RoomType { get; set; }
        public int StaysCompleted { get; set; }
        public decimal TotalGeneratedRevenue { get; set; }
    }

    public class ReportSummaryModel
    {
        public decimal TotalRevenue { get; set; }
        public int CompletedStays { get; set; }
        public decimal OccupancyRate { get; set; }
        public List<RoomTypeReportRow> BreakdownByRoomType { get; set; } = new List<RoomTypeReportRow>();
    }
}