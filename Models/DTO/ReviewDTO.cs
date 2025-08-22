using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamAspNet_WebMarket.Models.DTO
{
    public class ReviewDTO
    {
        [Required(ErrorMessage = "Оценка обязательна")]
        [Range(1, 5, ErrorMessage = "Оценка должна быть от 1 до 5")]
        [DisplayName("Оценка")]
        public byte Rating { get; set; }

        [Required(ErrorMessage = "Укажите статус сделки")]
        [DisplayName("Состоялась ли сделка?")]
        public bool IsDealCompleted { get; set; }

        [MaxLength(512, ErrorMessage = "Слишком длинный отзыв")]
        [DisplayName("Комментарий")]
        public string? Comment { get; set; }

        [Required]
        public int UserTargetId { get; set; }
    }
}
