using System.ComponentModel.DataAnnotations;

namespace ExamAspNet_WebMarket.Data.Entities
{
    public class User : Entity
    {
        [MaxLength(64)]
        [Required]
        public required string Name { get; set; }
        [MaxLength(64)]
        [Required]
        public required string LastName { get; set; }
        [MaxLength(128)]
        [Required]
        public required string Email { get; set; }
        [MaxLength(15)]
        [Required]
        public required string Phone { get; set; }
        [MaxLength(64)]
        [Required]
        public required string Password { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public char Status { get; set; } = '0';
        // Коды статусов
        // Пользователь - 0
        // Модератор - 1
        // Администратор - 2
    }
}
