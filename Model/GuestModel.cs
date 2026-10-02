using System;

namespace HotelReservation.Model
{
    public class GuestModel
    {
        public int GuestId { get; set; }
        public string ContactNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string IDType { get; set; }
        public string IDNum { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public string FullName => string.IsNullOrWhiteSpace(MI)
            ? $"{FirstName} {LastName}"
            : $"{FirstName} {MI}. {LastName}";
    }
}