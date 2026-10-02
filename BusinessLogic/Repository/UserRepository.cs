using System;
using System.Data;
using System.Data.SqlClient;
using HotelReservation.Model;

namespace HotelReservation.BusinessLogic.Repository
{
    public class UserRepository
    {
        private readonly string _connectionString = @"Data Source=Keyaru\SQLEXPRESS;Initial Catalog=HotelReservationDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connect Timeout=30;";

        public UserRepository(string connectionString = null)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                _connectionString = connectionString;
            }
        }

        public UserModel ValidateUserCredentials(string username, string password, string role)
        {
            UserModel user = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
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
                        };
                    }
                }
            }

            return user;
        }
    }
}