using MongoDB.Driver;
using OrderService.Domain.Entites;

namespace OrderService.Infrastructure.MongoDB
{
    public interface IStockContext
    {
        public IMongoCollection<Product> Products { get; }
    }
}