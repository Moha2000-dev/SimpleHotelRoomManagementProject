namespace SimpleHotelRoomManagementProject.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int GuestId { get; set; }           // Foreign key reference to Guest
        public int RoomId { get; set; }            // Foreign key reference to Room
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }            // Rating out of 5 (for example)
        public DateTime Date { get; set; }

        public Review()
        {
            Date = DateTime.Now;
        }
    }
}
