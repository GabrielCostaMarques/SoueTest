using System.Text.Json.Serialization;

namespace CryptoWorkerService.Service
{
    public class CoinDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("current_price")]
        public decimal? CurrentPrice { get; set; }


        //public string Currency { get; set; }

        [JsonPropertyName("market_cap")]
        public decimal? MarketCap { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public decimal? PriceChangePercetage { get; set; }

        [JsonPropertyName("high_24h")]
        public decimal? HighestPrice24h { get; set; }

        [JsonPropertyName("low_24h")]
        public decimal? LowestPrice24h { get; set; }


        [JsonPropertyName("last_updated")]
        public DateTime LastUpdate { get; set; }
    }
}
