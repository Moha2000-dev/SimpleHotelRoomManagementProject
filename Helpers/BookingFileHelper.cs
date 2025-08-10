using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SimpleHotelRoomManagementProject.Helpers;
using SimpleHotelRoomManagementProject.Models;  // Make sure this namespace is correct

namespace SimpleHotelRoomManagementProject.Helpers
{
    public static class BookingFileHelper
    {
        private static readonly string filePath =
            DataPaths.GetDataFile("bookings.json");

        private static readonly JsonSerializerOptions Options =
            new JsonSerializerOptions { WriteIndented = true };

        public static void SaveBookings(List<Booking> bookings)
        {
            string json = JsonSerializer.Serialize(bookings, Options);
            File.WriteAllText(filePath, json);
        }

        public static List<Booking> LoadBookings()
        {
            if (!File.Exists(filePath)) return new List<Booking>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Booking>>(json) ?? new List<Booking>();
        }
    }
}
