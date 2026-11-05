using System.Collections.Generic;
using HotelReservation.BusinessLogic.Repository;
using Model;

namespace HotelReservation.BusinessLogic.Controller
{
    public class GuestController
    {
        private GuestRepository guestRepository;

        public GuestController()
        {
            guestRepository = new GuestRepository();
        }

        public int RegisterGuest(GuestModel guest)
        {
            if (guest == null)
            {
                return 0;
            }

            if (string.IsNullOrWhiteSpace(guest.FirstName) || string.IsNullOrWhiteSpace(guest.LastName) || string.IsNullOrWhiteSpace(guest.Address))
            {
                return 0;
            }

            if (string.IsNullOrWhiteSpace(guest.ContactNo) || guest.ContactNo.Trim().Length != 11)
            {
                return 0;
            }

            if (guest.Age < 18)
            {
                return 0;
            }

            return guestRepository.AddGuest(guest);
        }

        public bool UpdateGuest(GuestModel guest)
        {
            if (guest == null || guest.GuestId <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(guest.FirstName) || string.IsNullOrWhiteSpace(guest.LastName) || string.IsNullOrWhiteSpace(guest.Address))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(guest.ContactNo) || guest.ContactNo.Trim().Length != 11)
            {
                return false;
            }

            if (guest.Age < 18)
            {
                return false;
            }

            return guestRepository.UpdateGuest(guest);
        }

        public bool SoftDeleteGuest(string contactNo)
        {
            if (string.IsNullOrWhiteSpace(contactNo))
            {
                return false;
            }

            return guestRepository.SoftDeleteGuest(contactNo.Trim());
        }

        public List<GuestModel> GetGuests(bool includeInactive)
        {
            return guestRepository.GetGuests(includeInactive);
        }

        public List<GuestModel> SearchGuests(string searchText, bool includeInactive)
        {
            if (searchText == null)
            {
                searchText = "";
            }

            return guestRepository.SearchGuests(searchText.Trim(), includeInactive);
        }

        public bool IsMobileNumberRegistered(string contactNo, int currentGuestId)
        {
            if (string.IsNullOrWhiteSpace(contactNo))
            {
                return false;
            }

            return guestRepository.CheckMobileExists(contactNo.Trim(), currentGuestId);
        }
    }
}