using System;
using System.IO;

namespace SimpleHotelRoomManagementProject.Helpers
{
    public static class DataPaths
    {
        public static string GetDataFile(string fileName)
        {
            string dataDir = Path.Combine(AppContext.BaseDirectory, "data");
            Directory.CreateDirectory(dataDir); // makes sure it exists
            return Path.Combine(dataDir, fileName);
        }
    }
}
