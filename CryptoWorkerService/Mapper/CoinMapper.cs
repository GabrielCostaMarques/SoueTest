using CryptoWorkerService.Domain.Entity;
using CryptoWorkerService.Service;

namespace CryptoWorkerService.Mapper
{
    public static class CoinMapper
    {
        public static Coin ToEntity(this CoinDTO dto)
        {
            return new Coin
            {
                Id = dto.Id,
                Name = dto.Name,
                CurrentPrice = dto.CurrentPrice,
                HighestPrice24h = dto.HighestPrice24h,
                LowestPrice24h = dto.LowestPrice24h,
                LastUpdate = dto.LastUpdate,
                MarketCap = dto.MarketCap,
                PriceChangePercetage = dto.PriceChangePercetage,
            };
        }
    }
}
