using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrderService.Domain.Entites;
using OrderService.Options;

namespace OrderService.Infrastructure.MongoDB
{
    public class OrderContext : IOrderContext
    {
        public OrderContext(IConfiguration configuration , IOptions<OrderDatabaseSettings> OderStoreDatabaseSettings)
        {

            var client = new MongoClient(OderStoreDatabaseSettings.Value.ConnectionString); 
            var database = client.GetDatabase(OderStoreDatabaseSettings.Value.DatabaseName);
            Orders = database.GetCollection<Order>(OderStoreDatabaseSettings.Value.OrderCollectionName);

        }
        public IMongoCollection<Order> Orders { get; }

    }
}
