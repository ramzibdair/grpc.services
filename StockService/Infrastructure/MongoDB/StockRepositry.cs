
using MongoDB.Driver;
using OrderService.Domain.Entites;
using OrderService.Domain.IRepositories;

namespace OrderService.Infrastructure.MongoDB
{
    public class StockRepositry : IStockRepositry
    {
        private readonly IStockContext _orderContext;

        public StockRepositry(IStockContext orderContext)
        {
            _orderContext = orderContext;

        }
      
        public async Task<List<Product>> GetProductsAsync() => await _orderContext.Products.Find(_ => true).ToListAsync();

        public async Task<Product> GetProductByIdAsync(string id) => await _orderContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateProductAsync(Product product)
        {
            await _orderContext.Products.InsertOneAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _orderContext.Products.ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);
        }
    }
}
