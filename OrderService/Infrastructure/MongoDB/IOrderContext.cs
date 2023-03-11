using MongoDB.Driver;
using OrderService.Domain.Entites;

namespace OrderService.Infrastructure.MongoDB
{
    public interface IOrderContext
    {
         public IMongoCollection<Order> Orders { get; }

    }
}