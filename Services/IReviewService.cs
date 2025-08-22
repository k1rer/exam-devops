using ExamAspNet_WebMarket.Data.Entities;
using ExamAspNet_WebMarket.Models.DTO;

namespace ExamAspNet_WebMarket.Services
{
    public interface IReviewService
    {
        IList<Review> GetReviewsByUserId(int userId);
        void CreateReview(User userTarget, int userId, ReviewDTO reviewDTO);
        void CreateReview(User userTarget, User user, ReviewDTO reviewDTO);
        void CreateReview(int authorId, int userTargetId, ReviewDTO reviewDTO);
    }
}
