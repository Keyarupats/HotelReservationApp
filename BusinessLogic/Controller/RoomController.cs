using BusinessLogic.Repository;
using HotelReservation.Model;

namespace BusinessLogic.Controller
{
    public class RoomController
    {
        private readonly RoomRepository _roomRepository;

        public RoomController(string connectionString)
        {
            _roomRepository = new RoomRepository(connectionString);
        }

        public List<RoomModel> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public int CreateRoom(RoomModel room)
        {
            if (string.IsNullOrWhiteSpace(room.Status))
            {
                room.Status = "Available";
            }

            return _roomRepository.AddRoom(room);
        }
    }
}
