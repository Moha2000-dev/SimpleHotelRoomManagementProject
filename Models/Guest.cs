namespace SimpleHotelRoomManagementProject.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

    }
}
