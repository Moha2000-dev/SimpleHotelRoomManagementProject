using SimpleHotelRoomManagementProject.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HotelManagementSystem.Helpers
{
    public static class RoomFileHelper
    {
        private static readonly string filePath = "rooms.json";

        public static void SaveRooms(List<Room> rooms)
        {
            var json = JsonSerializer.Serialize(rooms, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static List<Room> LoadRooms()
        {
            if (!File.Exists(filePath))
                return new List<Room>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
        }
    }
}
