using System;
using System.Collections.Generic;
using System.Data;
using HotelReservation.BusinessLogic.Repository;
using Model;

namespace HotelReservation.BusinessLogic.Controller
{
    public class ReservationController
    {
        private ReservationRepository reservationRepository;
        private RoomRepository roomRepository;

        public ReservationController()
        {
            reservationRepository = new ReservationRepository();
            roomRepository = new RoomRepository();
        }

        public DateTime ComputeCheckOut(DateTime checkInDateTime)
        {
            return checkInDateTime.AddHours(22);
        }

        public decimal CalculateTotalQuote(decimal ratePerAdult, int adults)
        {
            if (adults < 1)
            {
                return 0.00m;
            }
            return ratePerAdult * adults;
        }

        public int CreateBooking(ReservationModel reservation)
        {
            if (reservation == null)
            {
                return 0;
            }

            if (reservation.GuestId <= 0 || reservation.RoomId <= 0 || reservation.Adults < 1)
            {
                return 0;
            }

            reservation.ExpectedCheckOutDateTime = ComputeCheckOut(reservation.CheckInDateTime);
            reservation.TotalAmount = CalculateTotalQuote(reservation.RatePerAdult, reservation.Adults);

            if (string.IsNullOrEmpty(reservation.Status))
            {
                if (reservation.AmountPaid > 0)
                {
                    reservation.Status = "Confirmed";
                }
                else
                {
                    reservation.Status = "Pending";
                }
            }

            return reservationRepository.CreateReservation(reservation);
        }

        public List<ReservationModel> GetReservations(string statusFilter, DateTime? filterDate)
        {
            return reservationRepository.GetReservations(statusFilter, filterDate);
        }

        // Added to support ArrivingReservation search and grid loading
        public DataTable GetArrivingReservations(string keyword)
        {
            return reservationRepository.GetArrivingReservations(keyword);
        }

        public bool ConfirmBooking(int reservationId)
        {
            return reservationRepository.UpdateReservationStatus(reservationId, "Confirmed");
        }

        public bool CancelBooking(int reservationId, int roomId)
        {
            bool success = reservationRepository.UpdateReservationStatus(reservationId, "Cancelled");
            if (success)
            {
                roomRepository.UpdateRoomStatus(roomId, "Available");
            }
            return success;
        }
    }
}