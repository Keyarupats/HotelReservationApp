using System;
using Model;
using HotelReservationApp.BusinessLogic.Repository;

namespace HotelReservationApp.BusinessLogic.Controller
{
    public class UserController
    {
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        public bool AuthenticateUser(string username, string password, string role, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Input Validation
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                errorMessage = "Username, password, and role are required.";
                return false;
            }

            try
            {
                UserModel user = _userRepository.ValidateUserCredentials(username, password, role);

                if (user == null)
                {
                    errorMessage = "Invalid username, password, or role selection.";
                    return false;
                }

                if (!user.IsActive)
                {
                    errorMessage = "Your account is inactive. Please contact the administrator.";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred during authentication: " + ex.Message;
                return false;
            }
        }
    }
}