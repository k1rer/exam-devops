using ExamAspNet_WebMarket.Data;
using ExamAspNet_WebMarket.Data.Entities;
using ExamAspNet_WebMarket.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace ExamAspNet_WebMarket.Services.Implementations
{
    public class AuthService : IAuthService
    {
        public readonly ApplicationDbContext _database;

        public AuthService(ApplicationDbContext database)
        {
            _database = database;
        }

        private string HashWithSha256(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha256.ComputeHash(textBytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte hashByte in hashBytes)
                {
                    builder.Append(hashByte.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void CreateUser(NewUserDTO newUserDTO)
        {
            User user = new()
            {
                Name = newUserDTO.Name!,
                LastName = newUserDTO.LastName!,
                Email = newUserDTO.Email!,
                Phone = newUserDTO.Phone!,
                Password = HashWithSha256(newUserDTO.Password!)
            };

            _database.Users.Add(user);
            _database.SaveChanges();
        }

        public User? GetUserByCredentials(UserCredentialsDTO userCredentialsDTO)
        {
            string email = userCredentialsDTO.Email!;
            string hashedPassword = HashWithSha256(userCredentialsDTO.Password!);

            return _database.Users.Where(u => u.Email == email && u.Password == hashedPassword)
                                  .FirstOrDefault();
        }
    }
}
