using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes; 

namespace OrderService.Domain.Entites
{
    public class Order
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
