using System.Collections.Generic;
using SimpleHotelRoomManagementProject.Models;
using SimpleHotelRoomManagementProject.Helpers;
using HotelManagementSystem.Helpers;

namespace SimpleHotelRoomManagementProject
{
    public class FileContext
    {
        public List<Room> Rooms { get; private set; }
        public List<Guest> Guests { get; private set; }
        public List<Booking> Bookings { get; private set; }
        public List<Review> Reviews { get; private set; }

        public FileContext()
        {
            // Load all data from files when the context is created
            Rooms = RoomFileHelper.LoadRooms();
            Guests = GuestFileHelper.LoadGuests();
            Bookings = BookingFileHelper.LoadBookings();
            Reviews = ReviewFileHelper.LoadReviews();
        }

        public void SaveRooms()
        {
            RoomFileHelper.SaveRooms(Rooms);
        }

        public void SaveGuests()
        {
            GuestFileHelper.SaveGuests(Guests);
        }

        public void SaveBookings()
        {
            BookingFileHelper.SaveBookings(Bookings);
        }

        public void SaveReviews()
        {
            ReviewFileHelper.SaveReviews(Reviews);
        }

        // Optional: Save everything at once (call after batch updates)
        public void SaveAll()
        {
            SaveRooms();
            SaveGuests();
            SaveBookings();
            SaveReviews();
        }
    }
}
