namespace StockService.Options
{
    public class StockDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProductCollectionName { get; set; } = null!;
    }
}
