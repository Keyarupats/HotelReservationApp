using System.Data;
using System.Data.SqlClient;
using HotelReservation.Model;

namespace BusinessLogic.Repository
{
    public class RoomRepository
    {
        private readonly string _connectionString = @"Data Source=Keyaru\SQLEXPRESS;Initial Catalog=HotelReservationDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connect Timeout=30;";

        public RoomRepository(string connectionString = null)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                _connectionString = connectionString;
            }
        }

        public List<RoomModel> GetAllRooms()
        {
            var rooms = new List<RoomModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("spGetAllRooms", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rooms.Add(new RoomModel
                        {
                            RoomId = Convert.ToInt32(reader["RoomId"]),
                            RoomNumber = reader["RoomNumber"].ToString() ?? string.Empty,
                            RoomType = reader["RoomType"].ToString() ?? string.Empty,
                            RatePerNight = Convert.ToDecimal(reader["RatePerNight"]),
                            Status = reader["Status"].ToString() ?? "Available"
                        });
                    }
                }
            }

            return rooms;
        }

        public int AddRoom(RoomModel room)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            using (SqlCommand command = new SqlCommand("spAddRoom", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@RoomNumber", room.RoomNumber);
                command.Parameters.AddWithValue("@RoomType", room.RoomType);
                command.Parameters.AddWithValue("@RatePerNight", room.RatePerNight);
                command.Parameters.AddWithValue("@Status", room.Status ?? "Available");

                connection.Open();
                // Returns the auto-generated RoomId
                var result = command.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }
    }
}