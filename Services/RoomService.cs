using System.Collections.Generic;
using SimpleHotelRoomManagementProject.Models;
using SimpleHotelRoomManagementProject.Repositories;

namespace SimpleHotelRoomManagementProject.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        public List<Room> GetAllRooms()
        {
            return roomRepository.GetAllRooms();
        }

        public Room GetRoomById(int roomId)
        {
            return roomRepository.GetRoomById(roomId);
        }

        public void AddRoom(Room room)
        {
            roomRepository.AddRoom(room);
        }

        public void UpdateRoom(Room room)
        {
            roomRepository.UpdateRoom(room);
        }

        public void DeleteRoom(int roomId)
        {
            roomRepository.DeleteRoom(roomId);
        }
    }
}
