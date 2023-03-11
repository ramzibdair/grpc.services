using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrderService.Domain.Entites;
using StockService.Options;

namespace OrderService.Infrastructure.MongoDB
{
    public class StockContext : IStockContext
    {
        public StockContext(IConfiguration configuration , IOptions<StockDatabaseSettings> OderStoreDatabaseSettings)
        {

            var client = new MongoClient(OderStoreDatabaseSettings.Value.ConnectionString); 
            var database = client.GetDatabase(OderStoreDatabaseSettings.Value.DatabaseName);
            Products = database.GetCollection<Product>(OderStoreDatabaseSettings.Value.ProductCollectionName);
            ProductSeeding.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
