using System.Collections.Generic;
using SimpleHotelRoomManagementProject.Models;

namespace SimpleHotelRoomManagementProject.Repositories
{
    public interface IBookingRepository
    {
        List<Booking> GetAllBookings();
        Booking GetBookingById(int bookingId);
        void AddBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(int bookingId);
    }
}
