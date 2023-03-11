using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Entites;
using OrderService.Domain.IRepositories;
using OrderService.grpcServices;

namespace OrderService.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepositry _orderRepositry;
        private readonly StockServiceClient _stockServiceClient;
        public OrderController(IOrderRepositry orderRepositry, StockServiceClient stockServiceClient)
        {
            _orderRepositry = orderRepositry;
            _stockServiceClient = stockServiceClient;
        }



        [Route("GetOders")]
        [HttpGet]
        public async Task<IActionResult> GetOdersAsync()
        {
            var result = await _orderRepositry.GetOrdersAsync();
            if(result.Count > 0 ) {
               return Json(result);
            }
            return result.Count == 0 ? NotFound() : Ok(result);
        }

        [Route("CreateOders")]
        [HttpPost]
        public async Task<IActionResult> CreateOdersAsync( string odername , string productID , int count)
        {
            var product = await _stockServiceClient.GetProductFromStock(productID);
            if(product == null)
            {
                return NotFound();
            }
            if(product.Count < count)
            {
                return BadRequest("Count is exceeded ");
            }
             var order = new Order() { Id = productID, Name = odername };
             await _orderRepositry.CreateOrderAsync(order);
            
            return Ok(order);
        }
    }
}
