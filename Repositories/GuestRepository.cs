using System.Collections.Generic;
using System.Linq;
using SimpleHotelRoomManagementProject.Models;
using HotelManagementSystem.Helpers; // For GuestFileHelper

namespace SimpleHotelRoomManagementProject.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private List<Guest> guests;

        public GuestRepository()
        {
            guests = GuestFileHelper.LoadGuests();
        }

        public List<Guest> GetAllGuests()
        {
            return guests;
        }

        public Guest GetGuestById(int guestId)
        {
            return guests.FirstOrDefault(g => g.GuestId == guestId);
        }

        public void AddGuest(Guest guest)
        {
            guests.Add(guest);
            GuestFileHelper.SaveGuests(guests);
        }

        public void UpdateGuest(Guest guest)
        {
            var existing = guests.FirstOrDefault(g => g.GuestId == guest.GuestId);
            if (existing != null)
            {
                existing.Name = guest.Name;
                existing.Email = guest.Email;
                existing.PhoneNumber = guest.PhoneNumber;
                existing.CheckInDate = guest.CheckInDate;
                existing.CheckOutDate = guest.CheckOutDate;
                // Add any extra fields here
                GuestFileHelper.SaveGuests(guests);
            }
        }

        public void DeleteGuest(int guestId)
        {
            var guest = guests.FirstOrDefault(g => g.GuestId == guestId);
            if (guest != null)
            {
                guests.Remove(guest);
                GuestFileHelper.SaveGuests(guests);
            }
        }
    }
}
