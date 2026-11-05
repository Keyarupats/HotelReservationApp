using Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HotelReservation.BusinessLogic.Repository
{
    public class UserRepository
    {
        private string connectionString;

        public UserRepository()
        {
            connectionString = DatabaseConfig.ConnectionString;
        }

        public UserModel AuthenticateUser(string username, string password, string role)
        {
            UserModel user = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spValidateUserCredentials", conn))
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
                            user = new UserModel();
                            user.Id = Convert.ToInt32(reader["UserId"]);
                            user.UserId = reader["UserCode"].ToString();
                            user.Username = reader["Username"].ToString();
                            user.Role = reader["Role"].ToString();
                            user.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        }
                    }
                }
            }
            return user;
        }
    }
}