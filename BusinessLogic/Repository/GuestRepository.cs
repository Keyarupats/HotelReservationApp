using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace HotelReservation.BusinessLogic.Repository
{
    public class GuestRepository
    {
        private string connectionString;

        public GuestRepository()
        {
            connectionString = DatabaseConfig.ConnectionString;
        }

        public int AddGuest(GuestModel guest)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spAddGuests", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactNo", guest.ContactNo);
                    cmd.Parameters.AddWithValue("@FirstName", guest.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", guest.LastName);

                    if (string.IsNullOrEmpty(guest.MI))
                    {
                        cmd.Parameters.AddWithValue("@MI", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MI", guest.MI);
                    }

                    cmd.Parameters.AddWithValue("@Age", guest.Age);
                    cmd.Parameters.AddWithValue("@Address", guest.Address);
                    cmd.Parameters.AddWithValue("@Email", guest.Email);
                    cmd.Parameters.AddWithValue("@IDType", guest.IDType);
                    cmd.Parameters.AddWithValue("@IDNum", guest.IDNum);

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

        public bool UpdateGuest(GuestModel guest)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spUpdateGuest", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@GuestId", guest.GuestId);
                    cmd.Parameters.AddWithValue("@ContactNo", guest.ContactNo);
                    cmd.Parameters.AddWithValue("@FirstName", guest.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", guest.LastName);

                    if (string.IsNullOrEmpty(guest.MI))
                    {
                        cmd.Parameters.AddWithValue("@MI", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MI", guest.MI);
                    }

                    cmd.Parameters.AddWithValue("@Age", guest.Age);
                    cmd.Parameters.AddWithValue("@Address", guest.Address);
                    cmd.Parameters.AddWithValue("@Email", guest.Email);
                    cmd.Parameters.AddWithValue("@IDType", guest.IDType);
                    cmd.Parameters.AddWithValue("@IDNum", guest.IDNum);

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

        public bool SoftDeleteGuest(string contactNo)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spDeleteGuest", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactNo", contactNo);

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

        public List<GuestModel> GetGuests(bool includeInactive)
        {
            List<GuestModel> list = new List<GuestModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetGuests", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IncludeInactive", includeInactive ? 1 : 0);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GuestModel guest = MapReaderToGuest(reader);
                            list.Add(guest);
                        }
                    }
                }
            }
            return list;
        }

        public List<GuestModel> SearchGuests(string searchText, bool includeInactive)
        {
            List<GuestModel> list = new List<GuestModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spSearchGuests", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchText", searchText);
                    cmd.Parameters.AddWithValue("@IncludeInactive", includeInactive ? 1 : 0);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GuestModel guest = MapReaderToGuest(reader);
                            list.Add(guest);
                        }
                    }
                }
            }
            return list;
        }

        public bool CheckMobileExists(string contactNo, int currentGuestId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM tblGuests WHERE ContactNo = @ContactNo AND GuestId <> @GuestId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ContactNo", contactNo.Trim());
                    cmd.Parameters.AddWithValue("@GuestId", currentGuestId);

                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }

        private GuestModel MapReaderToGuest(SqlDataReader reader)
        {
            GuestModel guest = new GuestModel();
            guest.GuestId = Convert.ToInt32(reader["GuestId"]);
            guest.GuestCode = reader["GuestCode"].ToString();
            guest.ContactNo = reader["ContactNo"].ToString();
            guest.FirstName = reader["FirstName"].ToString();
            guest.LastName = reader["LastName"].ToString();

            if (reader["MI"] != DBNull.Value)
            {
                guest.MI = reader["MI"].ToString();
            }
            else
            {
                guest.MI = "";
            }

            guest.Age = Convert.ToInt32(reader["Age"]);
            guest.Address = reader["Address"].ToString();
            guest.Email = reader["Email"].ToString();
            guest.IDType = reader["IDType"].ToString();
            guest.IDNum = reader["IDNum"].ToString();
            guest.IsActive = Convert.ToBoolean(reader["IsActive"]);
            guest.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);

            return guest;
        }
    }
}