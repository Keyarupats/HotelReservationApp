using System;
using System.Data.SqlClient;
using HotelReservation.Model;

namespace HotelReservation.BusinessLogic.Repository
{
    public class UserRepository
    {
        // Use your actual SQL Server connection string
        private readonly string _connectionString = @"Data Source=Keyaru\SQLEXPRESS;Initial Catalog=HotelReservationDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        public UserModel AuthenticateUser(string username, string password)
        {
            UserModel user = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    // Query to check matching Username and Password
                    string query = @"SELECT UserId, Username, Role 
                                     FROM dbo.tblUsers 
                                     WHERE Username = @Username AND Password = @Password AND IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new UserModel
                                {
                                    UserId = reader["UserId"].ToString(),
                                    Username = reader["Username"].ToString(),
                                    Role = reader["Role"].ToString() // "Admin" or "Staff"
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database error during authentication: " + ex.Message);
            }

            return user; // Returns null if username/password don't match
        }
    }
}