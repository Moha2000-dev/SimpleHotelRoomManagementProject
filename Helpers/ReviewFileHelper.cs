using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SimpleHotelRoomManagementProject.Models; 

namespace SimpleHotelRoomManagementProject.Helpers
{
    public static class ReviewFileHelper
    {
        private static readonly string filePath =
            DataPaths.GetDataFile("reviews.json");

        private static readonly JsonSerializerOptions Options =
            new JsonSerializerOptions { WriteIndented = true };

        // Save all reviews
        public static void SaveReviews(List<Review> reviews)
        {
            string json = JsonSerializer.Serialize(reviews, Options);
            File.WriteAllText(filePath, json);
        }

        // Load all reviews
        public static List<Review> LoadReviews()
        {
            if (!File.Exists(filePath)) return new List<Review>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Review>>(json) ?? new List<Review>();
        }

        // Add a single review (helper)
        public static void AddReview(Review review)
        {
            var reviews = LoadReviews();
            reviews.Add(review);
            SaveReviews(reviews);
        }
    }
}
