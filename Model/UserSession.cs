namespace HotelReservation.Model
{
    public static class UserSession
    {
        public static string CurrentUsername { get; set; } = string.Empty;

        public static string CurrentRole { get; set; } = string.Empty;

        public static void Clear()
        {
            CurrentUsername = string.Empty;
            CurrentRole = string.Empty;
        }
    }
}