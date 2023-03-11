using MongoDB.Driver;
using OrderService.Domain.Entites;

namespace OrderService.Infrastructure.MongoDB
{
    public class ProductSeeding
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            var exsitProducts = productCollection.Find(p => true).Any();
            if (!exsitProducts)
            {
                productCollection.InsertMany(GetSeedProduct());
            }
        }
        private static IEnumerable<Product> GetSeedProduct()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone X",
                    Count = 10
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Samsung 10",
                    Count = 10
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Huawei Plus",
                    Count = 10
                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Xiaomi Mi 9",
                    Count = 10

                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "HTC U11+ Plus",
                    Count = 10

                },
                new Product()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "LG G7 ThinQ",
                    Count = 10

                }
            };
        }
    }
}
