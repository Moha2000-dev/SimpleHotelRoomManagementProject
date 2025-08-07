using System.Collections.Generic;
using SimpleHotelRoomManagementProject.Models;

namespace SimpleHotelRoomManagementProject.Repositories
{
    public interface IGuestRepository
    {
        List<Guest> GetAllGuests();
        Guest GetGuestById(int guestId);
        void AddGuest(Guest guest);
        void UpdateGuest(Guest guest);
        void DeleteGuest(int guestId);
    }
}
