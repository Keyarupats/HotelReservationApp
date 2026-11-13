using System;
using System.Linq;
using HotelReservation.BusinessLogic.Repository;
using Model;

namespace HotelReservation.BusinessLogic.Controller
{
    public class ReportController
    {
        private readonly ReportRepository reportRepository;

        public ReportController()
        {
            reportRepository = new ReportRepository();
        }

        public ReportSummaryModel GetReportSummary(DateTime startDate, DateTime endDate)
        {
            if (startDate.Date > endDate.Date)
            {
                throw new ArgumentException("Start Date must be on or before End Date.");
            }

            var breakdown = reportRepository.GetRevenueAndStaysByRoomType(startDate.Date, endDate.Date);
            decimal occupancy = reportRepository.GetOccupancyRate(startDate.Date, endDate.Date);

            return new ReportSummaryModel
            {
                BreakdownByRoomType = breakdown,
                CompletedStays = breakdown.Sum(r => r.StaysCompleted),
                TotalRevenue = breakdown.Sum(r => r.TotalGeneratedRevenue),
                OccupancyRate = occupancy
            };
        }
    }
}