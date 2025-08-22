using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ExamAspNet_WebMarket.Models.DTO
{
    public class LocationDTO
    {
        [Required(ErrorMessage = "Адрес обязателен")]
        [MaxLength(500, ErrorMessage = "Адрес слишком длинный")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "Широта обязательна")]
        [Range(-90, 90, ErrorMessage = "Широта должна быть от -90 до 90 градусов")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "Долгота обязательна")]
        [Range(-180, 180, ErrorMessage = "Долгота должна быть от -180 до 180 градусов")]
        public double Longitude { get; set; }

    }
}
