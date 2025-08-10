using System;
using System.Collections.Generic;
using System.Linq;
using SimpleHotelRoomManagementProject.Models;

namespace SimpleHotelRoomManagementProject.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        public List<Guest> GetAllGuests()
        {
            using var db = new HotelDbContext();
            return db.Guests.ToList();
        }

        public Guest GetGuestById(int guestId)
        {
            using var db = new HotelDbContext();
            return db.Guests.FirstOrDefault(g => g.GuestId == guestId);
        }

        public void AddGuest(Guest guest)
        {
            using var db = new HotelDbContext();

            // basic guards (Name is usually required in your UI)
            guest.Name = string.IsNullOrWhiteSpace(guest.Name) ? "Unknown" : guest.Name;
            guest.Email = guest.Email ?? "";
            guest.PhoneNumber = guest.PhoneNumber ?? "";

            // optional: ensure dates make sense
            if (guest.CheckOutDate < guest.CheckInDate)
                guest.CheckOutDate = guest.CheckInDate;

            db.Guests.Add(guest);
            db.SaveChanges();
        }

        public void UpdateGuest(Guest guest)
        {
            using var db = new HotelDbContext();
            db.Guests.Update(guest);
            db.SaveChanges();
        }

        public void DeleteGuest(int guestId)
        {
            using var db = new HotelDbContext();
            var g = db.Guests.FirstOrDefault(x => x.GuestId == guestId);
            if (g != null)
            {
                db.Guests.Remove(g);
                db.SaveChanges();
            }
        }
    }
}
