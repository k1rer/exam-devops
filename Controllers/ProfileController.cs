using ExamAspNet_WebMarket.Data.Entities;
using ExamAspNet_WebMarket.Models.DTO;
using ExamAspNet_WebMarket.Models.Views;
using ExamAspNet_WebMarket.Services;
using ExamAspNet_WebMarket.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ExamAspNet_WebMarket.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IReviewService _reviewService;
        private readonly IUserService _userService;
        public ProfileController(IReviewService reviewService, IUserService userService)
        {
            _reviewService = reviewService;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Index([FromRoute] int? id)
        {
            ViewBag.Title = $"{ViewBag.Brand ?? "Барахолка"}: профиль";

            if (id is null)
                return RedirectToAction("Index", "Home");

            User? user = _userService.GetUserById((int)id);

            if (user is null)
                return RedirectToAction("Index", "Home");

            UserViewModel model = new UserViewModel()
            {
                User = user,
                Review = new ReviewDTO()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddReview(UserViewModel model)
        {
            ViewBag.Title = $"{ViewBag.Brand ?? "Барахолка"}: профиль";

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }

                model.User = _userService.GetUserById(model.UserId); 
                return View("Index", model);
            }

            var authorId = HttpContext.Session.GetInt32("UserId");
            if (authorId is null)
                return RedirectToAction("Authorization", "Auth");

            _reviewService.CreateReview(authorId.Value, model.UserId, model.Review);

            return RedirectToAction("Index", new { id = model.UserId });
        }
    }
}
