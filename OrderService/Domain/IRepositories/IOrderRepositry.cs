using OrderService.Domain.Entites;

namespace OrderService.Domain.IRepositories
{
    public interface IOrderRepositry
    {
        Task<List<Order>> GetOrdersAsync();
        Task CreateOrderAsync(Order order);

    }
}
