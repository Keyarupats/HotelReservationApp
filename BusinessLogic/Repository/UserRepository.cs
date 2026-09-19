using System;
using System.Data;
using System.Data.SqlClient;
using Model;
namespace HotelReservationApp.BusinessLogic.Repository
{
    public class UserRepository
    {
        // Adjust connection string to match your local database settings
        private readonly string _connectionString = @"Data Source=Keyaru\SQLEXPRESS;
                                                    Integrated Security=True;
                                                    Persist Security Info=False;
                                                    Pooling=False;
                                                    Multiple Active Result Sets=False;
                                                    Encrypt=True;
                                                    Trust Server Certificate=True;
                                                    Command Timeout=0";

        public UserModel ValidateUserCredentials(string username, string password, string role)
        {
            UserModel user = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.spValidateUserCredentials", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserId = reader["UserId"].ToString(),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                Role = reader["Role"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }

            return user;
        }
    }
}