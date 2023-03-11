using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Entites;
using OrderService.Domain.IRepositories;

namespace OrderService.Controllers
{
    public class OrderController : Controller
    {
        private readonly IStockRepositry _stockRepositry;
        public OrderController(IStockRepositry stockRepositry ) 
        {
            _stockRepositry = stockRepositry;
        }

        [Route("GetProducts")]
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _stockRepositry.GetProductsAsync();
            if (result.Count > 0)
            {
                return Json(result);
            }
            return result.Count == 0 ? NotFound() : Ok(result);
        }

        [Route("CreateProducts")]
        [HttpPost]
        public async Task<IActionResult> CreateProductsAsync(string id , string name)
        {
            var product = new Product() { Id =  id, Name = name};
            await _stockRepositry.CreateProductAsync(product);

            return Ok(product);
        }
    }
}
