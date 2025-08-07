namespace SimpleHotelRoomManagementProject.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }      // e.g. "101", "A-12"
        public string Type { get; set; }            // e.g. "Single", "Double", "Suite"
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }     // Optional: Room details

        // Optional: Add more fields like Floor, Capacity, etc.
    }
}
