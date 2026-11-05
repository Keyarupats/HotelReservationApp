using System;

namespace Model
{
    public class GuestModel
    {
        public int GuestId { get; set; }
        public string GuestCode { get; set; }
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

        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(MI))
                {
                    return FirstName + " " + LastName;
                }
                return FirstName + " " + MI + ". " + LastName;
            }
        }

        public GuestModel()
        {
            GuestCode = string.Empty;
            ContactNo = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            MI = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
            IDType = string.Empty;
            IDNum = string.Empty;
            IsActive = true;
            CreatedAt = DateTime.Now;
        }
    }
}