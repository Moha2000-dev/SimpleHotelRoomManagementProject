using System.Collections.Generic;
using SimpleHotelRoomManagementProject.Models;
using SimpleHotelRoomManagementProject.Repositories;

namespace SimpleHotelRoomManagementProject.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public List<Booking> GetAllBookings()
        {
            return bookingRepository.GetAllBookings();
        }

        public Booking GetBookingById(int bookingId)
        {
            return bookingRepository.GetBookingById(bookingId);
        }

        public void AddBooking(Booking booking)
        {
            bookingRepository.AddBooking(booking);
        }

        public void UpdateBooking(Booking booking)
        {
            bookingRepository.UpdateBooking(booking);
        }

        public void DeleteBooking(int bookingId)
        {
            bookingRepository.DeleteBooking(bookingId);
        }
    }
}
