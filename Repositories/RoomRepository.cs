using System.Collections.Generic;
using System.Linq;
using SimpleHotelRoomManagementProject.Models;
using HotelManagementSystem.Helpers; // For RoomFileHelper

namespace SimpleHotelRoomManagementProject.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private List<Room> rooms;

        public RoomRepository()
        {
            rooms = RoomFileHelper.LoadRooms();
        }

        public List<Room> GetAllRooms()
        {
            return rooms;
        }

        public Room GetRoomById(int roomId)
        {
            return rooms.FirstOrDefault(r => r.RoomId == roomId);
        }

        public void AddRoom(Room room)
        {
            rooms.Add(room);
            RoomFileHelper.SaveRooms(rooms);
        }

        public void UpdateRoom(Room room)
        {
            var existing = rooms.FirstOrDefault(r => r.RoomId == room.RoomId);
            if (existing != null)
            {
                existing.RoomNumber = room.RoomNumber;
                existing.Type = room.Type;
                existing.PricePerNight = room.PricePerNight;
                existing.IsAvailable = room.IsAvailable;
                existing.Description = room.Description;
                // Add/update any additional fields if you have them
                RoomFileHelper.SaveRooms(rooms);
            }
        }

        public void DeleteRoom(int roomId)
        {
            var room = rooms.FirstOrDefault(r => r.RoomId == roomId);
            if (room != null)
            {
                rooms.Remove(room);
                RoomFileHelper.SaveRooms(rooms);
            }
        }
    }
}
