using System.Collections.Generic;
using System.Linq;
using SimpleHotelRoomManagementProject.Models;
using SimpleHotelRoomManagementProject.Helpers; // For ReviewFileHelper

namespace SimpleHotelRoomManagementProject.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private List<Review> reviews;

        public ReviewRepository()
        {
            reviews = ReviewFileHelper.LoadReviews();
        }

        public List<Review> GetAllReviews()
        {
            return reviews;
        }

        public Review GetReviewById(int reviewId)
        {
            return reviews.FirstOrDefault(r => r.ReviewId == reviewId);
        }

        public void AddReview(Review review)
        {
            reviews.Add(review);
            ReviewFileHelper.SaveReviews(reviews);
        }

        public void UpdateReview(Review review)
        {
            var existing = reviews.FirstOrDefault(r => r.ReviewId == review.ReviewId);
            if (existing != null)
            {
                existing.GuestId = review.GuestId;
                existing.RoomId = review.RoomId;
                existing.ReviewerName = review.ReviewerName;
                existing.Comment = review.Comment;
                existing.Rating = review.Rating;
                existing.Date = review.Date;
                ReviewFileHelper.SaveReviews(reviews);
            }
        }

        public void DeleteReview(int reviewId)
        {
            var review = reviews.FirstOrDefault(r => r.ReviewId == reviewId);
            if (review != null)
            {
                reviews.Remove(review);
                ReviewFileHelper.SaveReviews(reviews);
            }
        }
    }
}
