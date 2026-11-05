using HotelReservation.BusinessLogic.Repository;
using Model;

namespace HotelReservation.BusinessLogic.Controller
{
    public class UserController
    {
        private UserRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository();
        }

        public UserModel Authenticate(string username, string password, string selectedRole)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(selectedRole))
            {
                return null;
            }

            string cleanUsername = username.Trim();
            string cleanPassword = password.Trim();
            string cleanRole = selectedRole.Trim();

            UserModel user = userRepository.AuthenticateUser(cleanUsername, cleanPassword, cleanRole);

            if (user != null)
            {
                UserSession.CurrentUsername = user.Username;
                UserSession.CurrentRole = user.Role;
            }

            return user;
        }

        public void Logout()
        {
            UserSession.Clear();
        }
    }
}