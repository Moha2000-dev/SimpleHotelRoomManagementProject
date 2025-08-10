using System;
using System.Collections.Generic;
using System.Linq;
using SimpleHotelRoomManagementProject.Models;

namespace SimpleHotelRoomManagementProject.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public List<Review> GetAllReviews()
        {
            using var db = new HotelDbContext();
            return db.Reviews.ToList();
        }

        public Review GetReviewById(int reviewId)
        {
            using var db = new HotelDbContext();
            return db.Reviews.FirstOrDefault(r => r.ReviewId == reviewId);
        }

        public void AddReview(Review review)
        {
            using var db = new HotelDbContext();

            // guard requireds / defaults
            review.ReviewerName ??= "Anonymous";
            review.Comment ??= "";
            if (review.Rating < 1) review.Rating = 5;
            if (review.Date == default) review.Date = DateTime.UtcNow;

            db.Reviews.Add(review);
            db.SaveChanges();
        }

        public void UpdateReview(Review review)
        {
            using var db = new HotelDbContext();
            db.Reviews.Update(review);
            db.SaveChanges();
        }

        public void DeleteReview(int reviewId)
        {
            using var db = new HotelDbContext();
            var r = db.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            if (r != null)
            {
                db.Reviews.Remove(r);
                db.SaveChanges();
            }
        }
    }
}
