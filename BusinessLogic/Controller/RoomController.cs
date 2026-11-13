using HotelReservation.BusinessLogic.Repository;
using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace HotelReservation.BusinessLogic.Controller
{
    public class RoomController
    {
        private RoomRepository roomRepository;

        public RoomController()
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

        public List<RoomModel> GetRoomsByDate(DateTime targetDate)
        {
            List<RoomModel> rooms = new List<RoomModel>();

            using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("spGetRoomsByDate", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TargetDate", SqlDbType.Date).Value = targetDate.Date;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new RoomModel
                        {
                            RoomId = Convert.ToInt32(reader["RoomId"]),
                            RoomTypeId = Convert.ToInt32(reader["RoomTypeId"]),
                            TypeName = reader["TypeName"].ToString(),
                            BedCount = Convert.ToInt32(reader["BedCount"]),
                            MaxAdults = Convert.ToInt32(reader["MaxAdults"]),
                            MaxChildren = Convert.ToInt32(reader["MaxChildren"]),
                            RatePerAdult = Convert.ToDecimal(reader["RatePerAdult"]),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }

            return rooms;
        }

    }
}