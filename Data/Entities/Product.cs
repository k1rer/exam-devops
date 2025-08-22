using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExamAspNet_WebMarket.Data.Entities
{
    public class Product : Entity
    {
        [MaxLength(64)]
        public required string Name { get; set; }

        [Precision(10,2)]
        public required decimal Price { get; set; }

        public required User Seller { get; set; }

        [Required]
        public required Location Location { get; set; }

        [MaxLength(512)]
        public string? Description { get; set; }

        public bool IsExisting { get; set; } = true;
    }
}
