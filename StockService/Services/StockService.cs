using Grpc.Core;
using OrderService.Domain.IRepositories;
using StockService.Protos;

namespace StockService.Services
{
    public class StockService : StockProtoService.StockProtoServiceBase
    {
        private readonly IStockRepositry _stockRepositry;
        public StockService(IStockRepositry stockRepositry)
        {
            _stockRepositry = stockRepositry;
        }

        public override async Task<ProductModal> GetProduct(ProductRequet request, ServerCallContext context)
        {
            var product = await _stockRepositry.GetProductByIdAsync(request.ProductId);
            if (product != null)
            {
                return new ProductModal
                {
                   Id = product.Id,
                   Count = product.Count,
                   ProductName = product.Name

                };
            }
            return null;
        }

        public override async Task<ProductModal> UpdateProductCount(UpdateProductCountRequet request, ServerCallContext context)
        {
            var product = await _stockRepositry.GetProductByIdAsync(request.ProductId);
            if (product != null)
            {
                product.Count = request.Count ;
               await  _stockRepositry.UpdateProductAsync(product);
                return new ProductModal
                {
                    Id = product.Id,
                    Count = request.Count,
                    ProductName = product.Name

                };
            }
            return null;
        }
    }
}
