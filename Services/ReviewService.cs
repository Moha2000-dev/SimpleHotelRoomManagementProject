using System.Collections.Generic;
using SimpleHotelRoomManagementProject.Models;
using SimpleHotelRoomManagementProject.Repositories;

namespace SimpleHotelRoomManagementProject.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }

        public List<Review> GetAllReviews()
        {
            return reviewRepository.GetAllReviews();
        }

        public Review GetReviewById(int reviewId)
        {
            return reviewRepository.GetReviewById(reviewId);
        }

        public void AddReview(Review review)
        {
            reviewRepository.AddReview(review);
        }

        public void UpdateReview(Review review)
        {
            reviewRepository.UpdateReview(review);
        }

        public void DeleteReview(int reviewId)
        {
            reviewRepository.DeleteReview(reviewId);
        }
    }
}
