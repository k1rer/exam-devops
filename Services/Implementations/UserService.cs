using ExamAspNet_WebMarket.Data;
using ExamAspNet_WebMarket.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamAspNet_WebMarket.Services.Implementations
{
    public class UserService : IUserService
    {
        public readonly ApplicationDbContext _database;

        public UserService(ApplicationDbContext database)
        {
            _database = database;
        }
        public User? GetUserById(int id)
        {
            return _database.Users
                            .Include(r => r.Reviews)
                            .ThenInclude(r => r.Author)
                            .FirstOrDefault(i => i.Id == id);
        }
    }
}
