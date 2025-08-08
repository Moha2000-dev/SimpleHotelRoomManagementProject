namespace SimpleHotelRoomManagementProject.Models
{
    // Review.cs
    public class Review
    {
        public int ReviewId { get; set; }
        public int? GuestId { get; set; }   // <- nullable
        public int? RoomId { get; set; }   // <- nullable
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }

}
