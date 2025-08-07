using System.Collections.Generic;
using SimpleHotelRoomManagementProject.Models;

namespace SimpleHotelRoomManagementProject.Services
{
    public interface IReviewService
    {
        List<Review> GetAllReviews();
        Review GetReviewById(int reviewId);
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int reviewId);
    }
}
