using OrderService.Domain.Entites;

namespace OrderService.Domain.IRepositories
{
    public interface IStockRepositry
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
    }
}
