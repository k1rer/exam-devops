using ExamAspNet_WebMarket.Data.Entities;
using ExamAspNet_WebMarket.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ExamAspNet_WebMarket.Models.Views
{
    public class UserViewModel
    {
        [ValidateNever]
        public User? User { get; set; }

        [Required] 
        public int UserId { get; set; }

        [Required]
        public ReviewDTO Review { get; set; } = new();
    }
}
