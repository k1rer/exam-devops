using System.ComponentModel.DataAnnotations;

namespace ExamAspNet_WebMarket.Data.Entities
{
    public class Review : Entity
    {
        [Required]
        public int AuthorId { get; set; }
        public required User Author { get; set; }

        [Required]
        public int UserTargetId { get; set; }
        public required User UserTarget { get; set; }

        [Required]
        public required byte Raiting { get; set; }

        [Required]
        public required bool IsDealCompleted { get; set; }

        [MaxLength(512)]
        public string? Comment { get; set; }
    }
}
