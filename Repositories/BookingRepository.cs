using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Helpers;
using SimpleHotelRoomManagementProject.Models;

namespace SimpleHotelRoomManagementProject.Repositories
{
    public class  BookingRepository : IBookingRepository
    {
        private List<Booking> bookings;

        public BookingRepository()
        {
            // Load existing bookings from file (you can use a FileHelper here)
            bookings = BookingFileHelper.LoadBookings();
        }

        public List<Booking> GetAllBookings()
        {
            return bookings;
        }

        public Booking GetBookingById(int bookingId)
        {
            return bookings.FirstOrDefault(b => b.BookingId == bookingId);
        }

        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);
            BookingFileHelper.SaveBookings(bookings);
        }

        public void UpdateBooking(Booking booking)
        {
            var existing = bookings.FirstOrDefault(b => b.BookingId == booking.BookingId);
            if (existing != null)
            {
                // Update fields
                existing.GuestId = booking.GuestId;
                existing.RoomId = booking.RoomId;
                existing.CheckInDate = booking.CheckInDate;
                existing.CheckOutDate = booking.CheckOutDate;
                existing.TotalAmount = booking.TotalAmount;
                existing.Status = booking.Status;

                BookingFileHelper.SaveBookings(bookings);
            }
        }

        public void DeleteBooking(int bookingId)
        {
            var booking = bookings.FirstOrDefault(b => b.BookingId == bookingId);
            if (booking != null)
            {
                bookings.Remove(booking);
                BookingFileHelper.SaveBookings(bookings);
            }
        }
    }
}
