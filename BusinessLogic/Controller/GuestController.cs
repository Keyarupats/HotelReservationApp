using System;
using System.Collections.Generic;
using HotelReservation.BusinessLogic.Repository;
using HotelReservation.Model;

namespace HotelReservation.BusinessLogic.Controller
{
    public class GuestController
    {
        private readonly GuestRepository _guestRepository;

        public GuestController(string connectionString = null)
        {
            _guestRepository = new GuestRepository(connectionString);
        }

        public int RegisterGuest(GuestModel guest)
        {
            if (guest == null) throw new ArgumentNullException(nameof(guest));

            if (string.IsNullOrWhiteSpace(guest.ContactNo))
                throw new ArgumentException("Contact Number is required.", nameof(guest.ContactNo));

            if (string.IsNullOrWhiteSpace(guest.FirstName))
                throw new ArgumentException("First Name is required.", nameof(guest.FirstName));

            if (string.IsNullOrWhiteSpace(guest.LastName))
                throw new ArgumentException("Last Name is required.", nameof(guest.LastName));

            if (string.IsNullOrWhiteSpace(guest.MI))
                throw new ArgumentException("Middle Initial is required.", nameof(guest.MI));

            if (guest.Age < 18)
                throw new ArgumentException("Guest must be at least 18 years old.", nameof(guest.Age));

            if (string.IsNullOrWhiteSpace(guest.Address))
                throw new ArgumentException("Address is required.", nameof(guest.Address));

            if (string.IsNullOrWhiteSpace(guest.Email))
                throw new ArgumentException("Email is required.", nameof(guest.Email));

            if (string.IsNullOrWhiteSpace(guest.IDType))
                throw new ArgumentException("ID Type selection is required.", nameof(guest.IDType));

            if (string.IsNullOrWhiteSpace(guest.IDNum))
                throw new ArgumentException("ID Number is required.", nameof(guest.IDNum));

            // Clean inputs before sending down to Repository
            guest.ContactNo = guest.ContactNo.Trim();
            guest.FirstName = guest.FirstName.Trim();
            guest.LastName = guest.LastName.Trim();
            guest.MI = guest.MI.Trim();
            guest.Address = guest.Address.Trim();
            guest.Email = guest.Email.Trim();
            guest.IDType = guest.IDType.Trim();
            guest.IDNum = guest.IDNum.Trim();

            return _guestRepository.AddGuest(guest);
        }

        public List<GuestModel> GetActiveGuests()
        {
            return _guestRepository.GetActiveGuests();
        }

        public List<GuestModel> GetAllGuestsForAdmin()
        {
            return _guestRepository.GetAllGuestsForAdmin();
        }

        public bool SoftDeleteGuest(string contactNo)
        {
            if (string.IsNullOrWhiteSpace(contactNo))
            {
                throw new ArgumentException("Contact number is required.");
            }

            return _guestRepository.SoftDeleteGuest(contactNo.Trim());
        }
    }
}