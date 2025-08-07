using System.Collections.Generic;
using SimpleHotelRoomManagementProject.Models;
using SimpleHotelRoomManagementProject.Repositories;

namespace SimpleHotelRoomManagementProject.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            this.guestRepository = guestRepository;
        }

        public List<Guest> GetAllGuests()
        {
            return guestRepository.GetAllGuests();
        }

        public Guest GetGuestById(int guestId)
        {
            return guestRepository.GetGuestById(guestId);
        }

        public void AddGuest(Guest guest)
        {
            guestRepository.AddGuest(guest);
        }

        public void UpdateGuest(Guest guest)
        {
            guestRepository.UpdateGuest(guest);
        }

        public void DeleteGuest(int guestId)
        {
            guestRepository.DeleteGuest(guestId);
        }
    }
}
