using System;
using System.Collections.Generic;
using System.Linq;
using SimpleHotelRoomManagementProject.Models;

namespace SimpleHotelRoomManagementProject.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public List<Room> GetAllRooms()
        {
            using var db = new HotelDbContext();
            return db.Rooms.ToList();
        }

        public Room GetRoomById(int roomId)
        {
            using var db = new HotelDbContext();
            return db.Rooms.FirstOrDefault(r => r.RoomId == roomId);
        }

        public void AddRoom(Room room)
        {
            using var db = new HotelDbContext();

            if (string.IsNullOrWhiteSpace(room.RoomNumber))
                throw new ArgumentException("RoomNumber is required.");
            if (string.IsNullOrWhiteSpace(room.Type))
                throw new ArgumentException("Type is required.");

            // if your column isn’t nullable, keep this; otherwise it’s safe too:
            room.Description ??= null;

            db.Rooms.Add(room);
            db.SaveChanges();
        }

        public void UpdateRoom(Room room)
        {
            using var db = new HotelDbContext();
            db.Rooms.Update(room);
            db.SaveChanges();
        }

        public void DeleteRoom(int roomId)
        {
            using var db = new HotelDbContext();
            var room = db.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            if (room != null)
            {
                db.Rooms.Remove(room);
                db.SaveChanges();
            }
        }
    }
}
