using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OrderService.Domain.Entites;
using OrderService.Domain.IRepositories;
using OrderService.Options;

namespace OrderService.Infrastructure.MongoDB
{
    public class OrderRepositry : IOrderRepositry
    {
        private readonly IOrderContext _orderContext;

        public OrderRepositry(IOrderContext orderContext)
        {
            _orderContext = orderContext;

        }
        public async Task<List<Order>> GetOrdersAsync() => await _orderContext.Orders.Find(_ => true).ToListAsync();
       


        public async Task CreateOrderAsync(Order order) 
        {
            await _orderContext.Orders.InsertOneAsync(order);
        }
    }
}
