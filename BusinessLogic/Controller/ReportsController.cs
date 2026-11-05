using System;
using System.Collections.Generic;
using HotelReservation.BusinessLogic.Repository;
using Model;

namespace HotelReservation.BusinessLogic.Controller
{
    public class ReportsController
    {
        private ReservationRepository reservationRepository;

        public ReportsController()
        {
            reservationRepository = new ReservationRepository();
        }

        public List<ReservationModel> GetCompletedStays(DateTime startDate, DateTime endDate)
        {
            List<ReservationModel> allReservations = reservationRepository.GetReservations("Completed", null);
            List<ReservationModel> filteredList = new List<ReservationModel>();

            foreach (ReservationModel item in allReservations)
            {
                if (item.CheckInDateTime >= startDate && item.CheckInDateTime <= endDate)
                {
                    filteredList.Add(item);
                }
            }

            return filteredList;
        }

        public decimal CalculateTotalRevenue(DateTime startDate, DateTime endDate)
        {
            List<ReservationModel> completedStays = GetCompletedStays(startDate, endDate);
            decimal totalRevenue = 0.00m;

            foreach (ReservationModel item in completedStays)
            {
                totalRevenue = totalRevenue + item.TotalAmount;
            }

            return totalRevenue;
        }
    }
}
