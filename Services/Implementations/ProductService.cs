using ExamAspNet_WebMarket.Data;
using ExamAspNet_WebMarket.Data.Entities;
using ExamAspNet_WebMarket.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ExamAspNet_WebMarket.Services.Implementations
{
    public class ProductService : IProductService
    {
        public readonly ApplicationDbContext _database;

        public ProductService(ApplicationDbContext database)
        {
            _database = database;
        }

        public void CreateProduct(ProductDTO productDTO, string sellerName)
        {
            var seller = _database.Users.FirstOrDefault(u => u.Name == sellerName);
            if (seller == null)
                throw new Exception("Пользователь не найден");

            Location location = new()
            {
                Address = productDTO.Location.Address,
                Latitude = productDTO.Location.Latitude,
                Longitude = productDTO.Location.Longitude
            };

            Product product = new()
            {
                Name = productDTO.Name!,
                Price = productDTO.Price!.Value,
                Description = productDTO.Description,
                Location = location,
                Seller = seller
            };

            _database.Locations.Add(location);
            _database.Products.Add(product);
            _database.SaveChanges();
        }

        public Product? GetProductById(int id)
        {
            return _database.Products
                            .Include(s => s.Seller)
                            .Include(p => p.Location)
                            .FirstOrDefault(i => i.Id == id);
        }

        public IList<Product> GetProducts()
        {
            return _database.Products
                            .Include(s => s.Seller)
                            .Include(l => l.Location)
                            .ToList();
        }
    }
}
