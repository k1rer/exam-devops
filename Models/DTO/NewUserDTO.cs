using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamAspNet_WebMarket.Models.DTO
{
    public class NewUserDTO
    {
        private string? _phone;

        [Required(ErrorMessage = "Укажите имя")]
        [MinLength(2, ErrorMessage = "Слишком короткое имя")]
        [MaxLength(64, ErrorMessage = "Слишком длинное имя")]
        [DisplayName("Имя")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Укажите фамилию")]
        [MinLength(2, ErrorMessage = "Слишком короткая фамилия")]
        [MaxLength(64, ErrorMessage = "Слишком длинная фамилия")]
        [DisplayName("Фамилия")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Некорректный формат электронной почты")]
        [MaxLength(128, ErrorMessage = "Слишком длинный адрес электронной почты")]
        [DisplayName("Электронная почта")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Укажите номер телефона")]
        [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Некорректный номер телефона")]
        [DisplayName("Номер телефона")]
        public string? Phone
        {
            get => _phone;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    var cleaned = new string(value.Where(c => char.IsDigit(c) || c == '+').ToArray());
                    _phone = cleaned;
                }
                else
                {
                    _phone = value;
                }
            }
        }

        [Required(ErrorMessage = "Укажите пароль")]
        [MinLength(8, ErrorMessage = "Слишком короткий пароль")]
        [MaxLength(64, ErrorMessage = "Слишком длинный пароль")]
        [DisplayName("Пароль")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DisplayName("Подтверждение пароля")]
        public string? ConfirmPassword { get; set; }
    }
}
