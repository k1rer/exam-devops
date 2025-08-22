using Azure.Identity;
using ExamAspNet_WebMarket.Models.DTO;
using ExamAspNet_WebMarket.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamAspNet_WebMarket.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = $"{ViewBag.Brand ?? "Барахолка"}: товары";
            var products = _productService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return RedirectToAction("Index");

            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return Unauthorized();
            }
            ViewBag.Title = $"{ViewBag.Brand ?? "Барахолка"}: создание объявления товара";
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductDTO productDTO)
        {
            ViewBag.Title = $"{ViewBag.Brand ?? "Барахолка"}: создание объявления товара";
            var sellerName = HttpContext.Session.GetString("UserName");

            if (sellerName == null)
            {
                return Unauthorized();
            }
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(productDTO);
            }

            _productService.CreateProduct(productDTO,sellerName);

            return RedirectToAction("Index", "Home");
        }
    }
}
