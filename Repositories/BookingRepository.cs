using System;
using System.Collections.Generic;
using System.Linq;
using SimpleHotelRoomManagementProject.Models;

namespace SimpleHotelRoomManagementProject.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        public List<Booking> GetAllBookings()
        {
            using var db = new HotelDbContext();
            return db.Bookings.ToList();
        }

        public Booking GetBookingById(int bookingId)
        {
            using var db = new HotelDbContext();
            return db.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
        }

        public void AddBooking(Booking booking)
        {
            using var db = new HotelDbContext();

            // optional: sanity checks + auto fields
            if (booking.CheckOutDate < booking.CheckInDate)
                throw new ArgumentException("Check-out date must be on/after check-in date.");

            // If you want to auto-calc total based on the room price:
            var room = db.Rooms.FirstOrDefault(r => r.RoomId == booking.RoomId);
            if (room != null)
            {
                var nights = Math.Max(1, (booking.CheckOutDate - booking.CheckInDate).Days);
                booking.TotalAmount = room.PricePerNight * nights; // make sure PricePerNight & TotalAmount are DECIMAL
            }

            if (string.IsNullOrWhiteSpace(booking.Status))
                booking.Status = "Confirmed";

            db.Bookings.Add(booking);
            db.SaveChanges();
        }

        public void UpdateBooking(Booking booking)
        {
            using var db = new HotelDbContext();
            db.Bookings.Update(booking);
            db.SaveChanges();
        }

        public void DeleteBooking(int bookingId)
        {
            using var db = new HotelDbContext();
            var b = db.Bookings.FirstOrDefault(x => x.BookingId == bookingId);
            if (b != null)
            {
                db.Bookings.Remove(b);
                db.SaveChanges();
            }
        }
    }
}
