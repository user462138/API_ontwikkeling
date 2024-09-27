using ProductsRouting.Models;

namespace ProductsRouting.Services
{
    public interface IProductsService
    {
        Task<Product?> ApplyDiscountToProduct(int id, int percentage);
        Task CreateProduct(Product product);
        Task DeleteMultipleProducts(List<int> ids);
        Task DeleteProduct(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<List<Product>> GetProductsByCategoryAndPrice(string categoryName, decimal minPrice, decimal maxPrice);
        Task<List<Product>> SearchProductsByName(string name);
        Task<Product?> UpdateProduct(int id, Product product);
    }
}