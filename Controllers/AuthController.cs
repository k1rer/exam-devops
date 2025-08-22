using ExamAspNet_WebMarket.Data.Entities;
using ExamAspNet_WebMarket.Models.DTO;
using ExamAspNet_WebMarket.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamAspNet_WebMarket.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Authorization()
        {
            ViewBag.Title = $"Вход - {ViewBag.Brand ?? "Барахолка"}";
            return View();
        }

        [HttpPost]
        public IActionResult Authorization(UserCredentialsDTO userCredentialsDTO)
        {
            ViewBag.Title = $"Вход - {ViewBag.Brand ?? "Барахолка"}";
            if (!ModelState.IsValid)
            {
                return View(userCredentialsDTO);
            }

            User? user = _authService.GetUserByCredentials(userCredentialsDTO);

            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Неправильный адрес электронной почты или пароль.");
                return View(userCredentialsDTO);
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserEmail", user.Email);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            ViewBag.Title = $"Регистрация - { ViewBag.Brand ?? "Барахолка" }";
            return View();
        }

        [HttpPost]
        public IActionResult Registration(NewUserDTO newUserDTO)
        {
            ViewBag.Title = $"Регистрация - {ViewBag.Brand ?? "Барахолка"}";

            if (!ModelState.IsValid)
            {
                return View(newUserDTO);
            }
            _authService.CreateUser(newUserDTO);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
