namespace SimpleHotelRoomManagementProject.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int? GuestId { get; set; } // MAKE IT NULLABLE
        public int? RoomId { get; set; }  // MAKE IT NULLABLE
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
    }

}

