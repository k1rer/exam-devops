using ExamAspNet_WebMarket.Data.Entities;
using ExamAspNet_WebMarket.Models.DTO;

namespace ExamAspNet_WebMarket.Services
{
    public interface IAuthService
    {
        void CreateUser(NewUserDTO newUserDTO);
        User? GetUserByCredentials(UserCredentialsDTO userCredentialsDTO);
    }
}
