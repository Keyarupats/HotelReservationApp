using HotelReservation.BusinessLogic.Repository;
using HotelReservation.Model;

namespace HotelReservation.BusinessLogic.Controller
{
    public class UserController
    {
        private readonly UserRepository _userRepository;

        public UserController(string connectionString = null)
        {
            _userRepository = new UserRepository(connectionString);
        }

        public UserModel Login(string username, string password, string role)
        {
            // Business Rule: Reject blank or empty field inputs immediately
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role))
            {
                return null;
            }

            return _userRepository.ValidateUserCredentials(username, password, role);
        }
    }
}