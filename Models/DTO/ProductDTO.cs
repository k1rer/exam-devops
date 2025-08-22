using ExamAspNet_WebMarket.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExamAspNet_WebMarket.Models.DTO
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Укажите название товара")]
        [MinLength(2, ErrorMessage = "Название товара слишком короткое")]
        [MaxLength(64, ErrorMessage = "Название товара слишком длинное")]
        [Display(Name = "Название товара")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Укажите цену товара")]
        [Range(0.01, 9999999999.99, ErrorMessage = "Цена должна быть больше 0 и не превышать 10 млрд")]
        [Precision(10, 2)]
        [Display(Name = "Цена")]
        public decimal? Price { get; set; }

        public required User? Seller { get; set; }

        [Required]
        public required LocationDTO Location { get; set; }

        [MaxLength(512,ErrorMessage = "Слишком большое описание товара")]
        [Display(Name = "Описание")]
        public string? Description { get; set; }

    }
}
