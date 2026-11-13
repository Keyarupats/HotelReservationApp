using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace HotelReservation.BusinessLogic.Repository
{
    public class RoomRepository
    {
        private string connectionString;

        public RoomRepository()
        {
            connectionString = DatabaseConfig.ConnectionString;
        }

        public List<RoomModel> GetAllRooms(string typeFilter)
        {
            List<RoomModel> list = new List<RoomModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllRooms", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TypeNameFilter", string.IsNullOrEmpty(typeFilter) ? "ALL" : typeFilter);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RoomModel room = new RoomModel();
                            room.RoomId = Convert.ToInt32(reader["RoomId"]);
                            room.RoomTypeId = Convert.ToInt32(reader["RoomTypeId"]);
                            room.TypeName = reader["TypeName"].ToString();
                            room.RatePerAdult = Convert.ToDecimal(reader["RatePerAdult"]);
                            room.BedCount = Convert.ToInt32(reader["BedCount"]);
                            room.MaxAdults = Convert.ToInt32(reader["MaxAdults"]);
                            room.MaxChildren = Convert.ToInt32(reader["MaxChildren"]);
                            room.Status = reader["Status"].ToString();
                            list.Add(room);
                        }
                    }
                }
            }
            return list;
        }

        public bool UpdateRoomStatus(int roomId, string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateRoomStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RoomId", roomId);
                    cmd.Parameters.AddWithValue("@Status", status);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        public List<RoomModel> GetAvailableRooms(DateTime checkIn, DateTime checkOut, int adults, int children)
        {
            List<RoomModel> list = new List<RoomModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAvailableRooms", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                    cmd.Parameters.AddWithValue("@CheckOut", checkOut);
                    cmd.Parameters.AddWithValue("@Adults", adults);
                    cmd.Parameters.AddWithValue("@Children", children);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RoomModel room = new RoomModel();
                            room.RoomId = Convert.ToInt32(reader["RoomId"]);
                            room.TypeName = reader["TypeName"].ToString();
                            room.RatePerAdult = Convert.ToDecimal(reader["RatePerAdult"]);
                            room.BedCount = Convert.ToInt32(reader["BedCount"]);
                            room.MaxAdults = Convert.ToInt32(reader["MaxAdults"]);
                            room.MaxChildren = Convert.ToInt32(reader["MaxChildren"]);
                            room.Status = reader["Status"].ToString();
                            list.Add(room);
                        }
                    }
                }
            }
            return list;
        }

        public decimal GetTierRate(string typeName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT RatePerAdult FROM tblRoomTypes WHERE TypeName = @TypeName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TypeName", typeName);

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToDecimal(result);
                    }
                    return 0.00m;
                }
            }
        }

        public bool UpdateTierRate(string typeName, decimal newRate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE rt
            SET rt.RatePerAdult = @NewRate
            FROM tblRoomTypes rt
            WHERE rt.TypeName = @TypeName
              AND EXISTS (
                  SELECT 1 
                  FROM tblRooms r 
                  WHERE r.RoomTypeId = rt.RoomTypeId 
                    AND r.Status = 'Available'
              );";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@TypeName", SqlDbType.NVarChar, 30).Value = typeName.Trim();
                    SqlParameter rateParam = cmd.Parameters.Add("@NewRate", SqlDbType.Decimal);
                    rateParam.Precision = 10;
                    rateParam.Scale = 2;
                    rateParam.Value = newRate;

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}