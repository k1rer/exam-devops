using Microsoft.AspNetCore.Mvc;

namespace ExamAspNet_WebMarket.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = $"{ ViewBag.Brand ?? "Барахолка" }: главная страница";
            return View();
        }
    }
}
