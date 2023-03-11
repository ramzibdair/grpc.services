using StockService.Protos;

namespace OrderService.grpcServices
{
    public class StockServiceClient 
    {
        private readonly StockProtoService.StockProtoServiceClient _stockProtoServiceClient;

        public StockServiceClient(StockProtoService.StockProtoServiceClient stockProtoServiceClient)
        {
            _stockProtoServiceClient = stockProtoServiceClient;
        }

        public async Task<ProductModal> GetProductFromStock(string ID)
        {
            var request = new ProductRequet() { ProductId= ID };
            var product = await _stockProtoServiceClient.GetProductAsync(request);
            return product;
        }
    }
}
