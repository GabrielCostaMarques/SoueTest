namespace CryptoWorkerService.Domain.Entity
{
    public class Coin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }
        public string Currency { get; set; }
        public decimal MarketCap { get; set; }
        public decimal PriceChangePercetage { get; set; }
        public decimal HighestPrice24h { get; set; }
        public decimal LowestPrice24h { get; set; }
        public DateTime LastUpdate { get; set; }


    }
}
