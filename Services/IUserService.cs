using ExamAspNet_WebMarket.Data.Entities;

namespace ExamAspNet_WebMarket.Services
{
    public interface IUserService
    {
        public User? GetUserById(int id);
    }
}
