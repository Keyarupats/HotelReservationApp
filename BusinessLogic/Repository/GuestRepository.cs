using HotelReservation.Model;
using System.Data;
using System.Data.SqlClient;

namespace HotelReservation.BusinessLogic.Repository
{
    public class GuestRepository
    {
        private readonly string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=HotelReservationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        public GuestRepository(string connectionString = null)
        {
            if (!string.IsNullOrWhiteSpace(connectionString) && !connectionString.Contains("Multiple Active Result Sets"))
            {
                _connectionString = connectionString;
            }
        }

        public int AddGuest(GuestModel guest)
        {
            int newId = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.spAddGuest", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ContactNo", guest.ContactNo);
                cmd.Parameters.AddWithValue("@FirstName", guest.FirstName);
                cmd.Parameters.AddWithValue("@LastName", guest.LastName);
                cmd.Parameters.AddWithValue("@MI", guest.MI);
                cmd.Parameters.AddWithValue("@Age", guest.Age);
                cmd.Parameters.AddWithValue("@Address", guest.Address);
                cmd.Parameters.AddWithValue("@Email", guest.Email);
                cmd.Parameters.AddWithValue("@IDType", guest.IDType);
                cmd.Parameters.AddWithValue("@IDNum", guest.IDNum);

                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    newId = Convert.ToInt32(result);
                }
            }

            return newId;
        }

        public List<GuestModel> GetGuests(bool includeInactive = false)
        {
            List<GuestModel> guests = new List<GuestModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.spGetGuests", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IncludeInactive", includeInactive);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        guests.Add(new GuestModel
                        {
                            GuestId = Convert.ToInt32(reader["GuestId"]),
                            ContactNo = reader["ContactNo"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            MI = reader["MI"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                            Address = reader["Address"].ToString(),
                            Email = reader["Email"].ToString(),
                            IDType = reader["IDType"].ToString(),
                            IDNum = reader["IDNum"].ToString(),
                            IsActive = Convert.ToBoolean(reader["IsActive"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                        });
                    }
                }
            }

            return guests;
        }


        public bool UpdateGuest(GuestModel guest)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE dbo.tblGuests 
                             SET FirstName = @FirstName,
                                 LastName = @LastName,
                                 MI = @MI,
                                 Age = @Age,
                                 Address = @Address,
                                 Email = @Email,
                                 IDType = @IDType,
                                 IDNum = @IDNum
                             WHERE ContactNo = @ContactNo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", guest.FirstName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@LastName", guest.LastName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@MI", guest.MI ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Age", guest.Age);
                        cmd.Parameters.AddWithValue("@Address", guest.Address ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", guest.Email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDType", guest.IDType ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@IDNum", guest.IDNum ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@ContactNo", guest.ContactNo);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating guest record: " + ex.Message);
            }
        }










        public bool CheckGuestExists(string contactNo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(1) FROM dbo.tblGuests WHERE ContactNo = @ContactNo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ContactNo", contactNo);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking guest existence: " + ex.Message);
            }
        }



        public List<GuestModel> GetActiveGuests()
        {
            List<GuestModel> guestList = new List<GuestModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM dbo.tblGuests WHERE IsActive = 1 ORDER BY GuestId DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                guestList.Add(MapReaderToGuest(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading active guest list: " + ex.Message);
            }

            return guestList;
        }

        public List<GuestModel> GetAllGuestsForAdmin()
        {
            List<GuestModel> guestList = new List<GuestModel>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM dbo.tblGuests ORDER BY GuestId DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                guestList.Add(MapReaderToGuest(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading all guest records: " + ex.Message);
            }

            return guestList;
        }

        public bool SoftDeleteGuest(string contactNo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = "UPDATE dbo.tblGuests SET IsActive = 0 WHERE ContactNo = @ContactNo";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ContactNo", contactNo);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deactivating guest: " + ex.Message);
            }
        }

        private GuestModel MapReaderToGuest(SqlDataReader reader)
        {
            return new GuestModel
            {
                GuestId = Convert.ToInt32(reader["GuestId"]),
                ContactNo = reader["ContactNo"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                MI = reader["MI"].ToString(),
                Age = Convert.ToInt32(reader["Age"]),
                Address = reader["Address"].ToString(),
                Email = reader["Email"].ToString(),
                IDType = reader["IDType"].ToString(),
                IDNum = reader["IDNum"].ToString(),
                IsActive = Convert.ToBoolean(reader["IsActive"])
            };
        }
    }
}