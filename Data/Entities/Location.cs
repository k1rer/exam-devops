using System.ComponentModel.DataAnnotations;

namespace ExamAspNet_WebMarket.Data.Entities
{
    public class Location : Entity
    {
        [MaxLength(500)]
        [Required]
        public required string Address { get; set; } = null!;
        [Required]
        public required double Latitude { get; set; } // Широта
        [Required]
        public required double Longitude { get; set; } // Долгота
    }
}
