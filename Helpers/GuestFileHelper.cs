using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SimpleHotelRoomManagementProject.Models;

namespace HotelManagementSystem.Helpers
{
    public static class GuestFileHelper
    {
        private static readonly string filePath = "guests.json";

        public static void SaveGuests(List<Guest> guests)
        {
            var json = JsonSerializer.Serialize(guests, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static List<Guest> LoadGuests()
        {
            if (!File.Exists(filePath))
                return new List<Guest>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Guest>>(json) ?? new List<Guest>();
        }
    }
}
