using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SimpleHotelRoomManagementProject.Models;  // Make sure this namespace is correct

namespace HotelManagementSystem.Helpers
{
    public static class BookingFileHelper
    {
        private static readonly string filePath = "bookings.json";

        public static void SaveBookings(List<Booking> bookings)
        {
            var json = JsonSerializer.Serialize(bookings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static List<Booking> LoadBookings()
        {
            if (!File.Exists(filePath))
                return new List<Booking>();

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Booking>>(json) ?? new List<Booking>();
        }
    }
}
