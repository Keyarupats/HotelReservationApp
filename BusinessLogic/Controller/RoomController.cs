using System;
using System.Collections.Generic;
using HotelReservation.BusinessLogic.Repository;
using Model;

namespace HotelReservation.BusinessLogic.Controller
{
    public class RoomController
    {
        private RoomRepository roomRepository;

        public RoomController(string connectionString)
        {
            roomRepository = new RoomRepository();
        }

        public List<RoomModel> GetRooms(string categoryFilter)
        {
            return roomRepository.GetAllRooms(categoryFilter);
        }

        public bool ChangeRoomStatus(int roomId, string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
            {
                return false;
            }

            if (newStatus != "Available" && newStatus != "Reserved" && newStatus != "Occupied" && newStatus != "Cleaning" && newStatus != "Maintenance")
            {
                return false;
            }

            return roomRepository.UpdateRoomStatus(roomId, newStatus);
        }

        public List<RoomModel> GetAvailableRooms(DateTime checkIn, int adults, int children)
        {
            DateTime checkOut = checkIn.AddHours(22);
            return roomRepository.GetAvailableRooms(checkIn, checkOut, adults, children);
        }

        public decimal GetTierRate(string typeName)
        {
            return roomRepository.GetTierRate(typeName);
        }

        public bool UpdateTierRate(string typeName, decimal newRate)
        {
            if (newRate <= 0)
            {
                return false;
            }

            return roomRepository.UpdateTierRate(typeName, newRate);
        }


    }
}