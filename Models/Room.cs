namespace SimpleHotelRoomManagementProject.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; } = "";   // required
        public string Type { get; set; } = "";         // required
        public decimal PricePerNight { get; set; } = 0m;
        public bool IsAvailable { get; set; } = false;
        public string? Description { get; set; }
    }
}
