using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SimpleHotelRoomManagementProject.Helpers;
using SimpleHotelRoomManagementProject.Models;


namespace SimpleHotelRoomManagementProject.Helpers
{
    public static class GuestFileHelper
    {
        private static readonly string filePath =
            DataPaths.GetDataFile("guests.json");

        private static readonly JsonSerializerOptions Options =
            new JsonSerializerOptions { WriteIndented = true };

        public static void SaveGuests(List<Guest> guests)
        {
            var json = JsonSerializer.Serialize(guests, Options);
            File.WriteAllText(filePath, json);
        }

        public static List<Guest> LoadGuests()
        {
            if (!File.Exists(filePath)) return new List<Guest>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Guest>>(json) ?? new List<Guest>();
        }
    }
}
