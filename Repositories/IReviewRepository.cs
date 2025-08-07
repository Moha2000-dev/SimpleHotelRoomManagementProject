using System.Collections.Generic;
using SimpleHotelRoomManagementProject.Models;

namespace SimpleHotelRoomManagementProject.Repositories
{
    public interface IReviewRepository
    {
        List<Review> GetAllReviews();
        Review GetReviewById(int reviewId);
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(int reviewId);
    }
}
