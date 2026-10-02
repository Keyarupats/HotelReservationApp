using System;
using HotelReservation.BusinessLogic.Repository;
using HotelReservation.Model;

namespace HotelReservation.BusinessLogic.Controller
{
    public class UserController
    {
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        public UserModel Authenticate(string username, string password)
        {
            // Simple validation before hitting the database
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            return _userRepository.AuthenticateUser(username.Trim(), password.Trim());
        }
    }
}