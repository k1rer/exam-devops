using ExamAspNet_WebMarket.Data.Entities;
using ExamAspNet_WebMarket.Models.DTO;

namespace ExamAspNet_WebMarket.Services
{
    public interface IProductService
    {
        IList<Product> GetProducts();
        Product? GetProductById(int id);
        void CreateProduct(ProductDTO productDTO, string sellerName);
    }
}
