using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SimpleHotelRoomManagementProject.Models; 

namespace SimpleHotelRoomManagementProject.Helpers
{
    public static class ReviewFileHelper
    {
        private static string filePath = "reviews.json"; // or your preferred file

        // Save all reviews to file
        public static void SaveReviews(List<Review> reviews)
        {
            string json = JsonSerializer.Serialize(reviews);
            File.WriteAllText(filePath, json);
        }

        // Load all reviews from file
        public static List<Review> LoadReviews()
        {
            if (!File.Exists(filePath))
                return new List<Review>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Review>>(json);
        }

        // Add a single review
        public static void AddReview(Review review)
        {
            var reviews = LoadReviews();
            reviews.Add(review);
            SaveReviews(reviews);
        }
    }
}
