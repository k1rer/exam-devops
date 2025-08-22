using ExamAspNet_WebMarket.Data;
using ExamAspNet_WebMarket.Data.Entities;
using ExamAspNet_WebMarket.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ExamAspNet_WebMarket.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        public readonly ApplicationDbContext _database;

        public ReviewService(ApplicationDbContext database)
        {
            _database = database;
        }
        public void CreateReview(User userTarget, int userId, ReviewDTO reviewDTO)
        {
            User? user = _database.Users.FirstOrDefault(i => i.Id == userId);
            if (user is not null)
            {
                CreateReview(userTarget, user, reviewDTO);
            }
            else
            {
                throw new ArgumentException($"Пользователь с Id {userId} не найден");
            }
        }

        public void CreateReview(User userTarget, User user, ReviewDTO reviewDTO)
        {
            Review review = new()
            {
                Author = user,
                Raiting = reviewDTO.Rating,
                IsDealCompleted = reviewDTO.IsDealCompleted,
                Comment = reviewDTO.Comment,
                UserTarget = userTarget
            };

            _database.Reviews.Add(review);
            _database.SaveChanges();
        }

        public void CreateReview(int authorId, int userTargetId, ReviewDTO dto)
        {
            var author = _database.Users.FirstOrDefault(u => u.Id == authorId)
                         ?? throw new ArgumentException("Автор не найден");
            var target = _database.Users.FirstOrDefault(u => u.Id == userTargetId)
                         ?? throw new ArgumentException("Получатель отзыва не найден");

            var review = new Review
            { 
                Author = author,
                AuthorId = authorId,
                UserTargetId = userTargetId,
                Raiting = dto.Rating,
                IsDealCompleted = dto.IsDealCompleted,
                Comment = dto.Comment,
                UserTarget = target
            };

            _database.Reviews.Add(review);
            _database.SaveChanges();
        }

        public IList<Review> GetReviewsByUserId(int userId)
        {
            return _database.Reviews
                            .Include(a => a.Author)
                            .Where(a => a.Author.Id == userId)
                            .ToList();
        }
    }
}
