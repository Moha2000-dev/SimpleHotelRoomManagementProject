using SimpleHotelRoomManagementProject.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SimpleHotelRoomManagementProject.Models;
using SimpleHotelRoomManagementProject.Helpers;

namespace SimpleHotelRoomManagementProject.Helpers
{
    public static class RoomFileHelper
    {
        private static readonly string filePath = DataPaths.GetDataFile("rooms.json");
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions { WriteIndented = true };

        public static void SaveRooms(List<Room> rooms)
        {
            var json = JsonSerializer.Serialize(rooms, Options);
            File.WriteAllText(filePath, json);
        }

        public static List<Room> LoadRooms()
        {
            if (!File.Exists(filePath)) return new List<Room>();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
        }
    }
}
