using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamAspNet_WebMarket.Models.DTO
{
    public class UserCredentialsDTO
    {
        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты")]
        [MaxLength(128, ErrorMessage = "Слишком длинный адрес электронной почты")]
        [DisplayName("Электронная почта")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [MaxLength(64, ErrorMessage = "Слишком длинный пароль")]
        [DisplayName("Пароль")]
        public string? Password { get; set; }
    }
}
