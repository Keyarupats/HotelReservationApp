using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace HotelReservation.BusinessLogic.Repository
{
    public class ReservationRepository
    {
        private string connectionString;

        public ReservationRepository()
        {
            connectionString = DatabaseConfig.ConnectionString;
        }

        public int CreateReservation(ReservationModel res)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spCreateReservation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GuestId", res.GuestId);
                    cmd.Parameters.AddWithValue("@RoomId", res.RoomId);
                    cmd.Parameters.AddWithValue("@Adults", res.Adults);
                    cmd.Parameters.AddWithValue("@Children", res.Children);
                    cmd.Parameters.AddWithValue("@CheckInDateTime", res.CheckInDateTime);
                    cmd.Parameters.AddWithValue("@ExpectedCheckOutDateTime", res.ExpectedCheckOutDateTime);
                    cmd.Parameters.AddWithValue("@RatePerAdult", res.RatePerAdult);
                    cmd.Parameters.AddWithValue("@TotalAmount", res.TotalAmount);

                    if (string.IsNullOrEmpty(res.Status))
                    {
                        cmd.Parameters.AddWithValue("@Status", "Pending");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Status", res.Status);
                    }

                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    return 0;
                }
            }
        }

        public List<ReservationModel> GetReservations(string statusFilter, DateTime? filterDate)
        {
            List<ReservationModel> list = new List<ReservationModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetReservations", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (string.IsNullOrEmpty(statusFilter))
                    {
                        cmd.Parameters.AddWithValue("@StatusFilter", "ALL");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@StatusFilter", statusFilter);
                    }

                    if (filterDate.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@FilterDate", filterDate.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@FilterDate", DBNull.Value);
                    }

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReservationModel res = new ReservationModel();
                            res.ReservationId = Convert.ToInt32(reader["ReservationId"]);
                            res.ReservationCode = reader["ReservationCode"].ToString();
                            res.GuestId = Convert.ToInt32(reader["GuestId"]);
                            res.GuestName = reader["GuestName"].ToString();
                            res.ContactNo = reader["ContactNo"].ToString();
                            res.RoomId = Convert.ToInt32(reader["RoomId"]);
                            res.TypeName = reader["TypeName"].ToString();
                            res.Adults = Convert.ToInt32(reader["Adults"]);
                            res.Children = Convert.ToInt32(reader["Children"]);
                            res.CheckInDateTime = Convert.ToDateTime(reader["CheckInDateTime"]);
                            res.ExpectedCheckOutDateTime = Convert.ToDateTime(reader["ExpectedCheckOutDateTime"]);

                            if (reader["ActualCheckInDateTime"] != DBNull.Value)
                            {
                                res.ActualCheckInDateTime = Convert.ToDateTime(reader["ActualCheckInDateTime"]);
                            }

                            if (reader["ActualCheckOutDateTime"] != DBNull.Value)
                            {
                                res.ActualCheckOutDateTime = Convert.ToDateTime(reader["ActualCheckOutDateTime"]);
                            }

                            res.RatePerAdult = Convert.ToDecimal(reader["RatePerAdult"]);
                            res.TotalAmount = Convert.ToDecimal(reader["TotalAmount"]);

                            if (reader["PaymentMethod"] != DBNull.Value)
                            {
                                res.PaymentMethod = reader["PaymentMethod"].ToString();
                            }

                            if (reader["PaymentReference"] != DBNull.Value)
                            {
                                res.PaymentReference = reader["PaymentReference"].ToString();
                            }

                            res.AmountPaid = Convert.ToDecimal(reader["AmountPaid"]);
                            res.ChangeDue = Convert.ToDecimal(reader["ChangeDue"]);
                            res.Status = reader["Status"].ToString();

                            list.Add(res);
                        }
                    }
                }
            }
            return list;
        }

        public bool UpdateReservationStatus(int reservationId, string newStatus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE tblReservations SET Status = @NewStatus WHERE ReservationId = @ReservationId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@ReservationId", SqlDbType.Int).Value = reservationId;
                    cmd.Parameters.Add("@NewStatus", SqlDbType.NVarChar, 20).Value = newStatus;

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public bool CheckInReservation(int reservationId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE tblReservations 
                    SET Status = 'Occupied',
                        ActualCheckInDateTime = GETDATE()
                    WHERE ReservationId = @ReservationId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@ReservationId", SqlDbType.Int).Value = reservationId;

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public DataTable GetArrivingReservations(string keyword)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        r.ReservationId,
                        r.ReservationCode,
                        r.GuestId,
                        g.FirstName + ' ' + g.LastName AS GuestName,
                        g.ContactNo,
                        r.RoomId,
                        rt.TypeName AS RoomType,
                        r.Adults,
                        r.Children,
                        r.TotalAmount,
                        r.CreatedAt,
                        r.CheckInDateTime,
                        r.ExpectedCheckOutDateTime,
                        r.Status
                    FROM tblReservations r
                    INNER JOIN tblGuests g ON r.GuestId = g.GuestId
                    INNER JOIN tblRooms rm ON r.RoomId = rm.RoomId
                    INNER JOIN tblRoomTypes rt ON rm.RoomTypeId = rt.RoomTypeId
                    WHERE r.Status = 'Confirmed'
                      AND (@Keyword = '' 
                           OR g.ContactNo LIKE '%' + @Keyword + '%' 
                           OR g.FirstName LIKE '%' + @Keyword + '%' 
                           OR g.LastName LIKE '%' + @Keyword + '%'
                           OR (g.FirstName + ' ' + g.LastName) LIKE '%' + @Keyword + '%'
                           OR r.ReservationCode LIKE '%' + @Keyword + '%'
                           OR CAST(r.ReservationId AS VARCHAR) LIKE '%' + @Keyword + '%')
                    ORDER BY r.CheckInDateTime ASC, r.ReservationId ASC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Keyword", string.IsNullOrEmpty(keyword) ? "" : keyword);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
    }
}