namespace SimpleHotelRoomManagementProject.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int GuestId { get; set; }         // Links to Guest
        public int RoomId { get; set; }          // Links to Room
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }       // e.g., "Confirmed", "Cancelled", "CheckedOut"

        // Optional: Add fields like PaymentMethod, SpecialRequests, etc.
    }
}
