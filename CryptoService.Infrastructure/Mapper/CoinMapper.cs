using CryptoService.Domain.Entity;
using CryptoWorkerService.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoService.Infrastructure.Mapper
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
        public static void UpdateEntity(this Coin entity, CoinDTO dto)
        {
            entity.Name = dto.Name;
            entity.CurrentPrice = dto.CurrentPrice;
            entity.HighestPrice24h = dto.HighestPrice24h;
            entity.LowestPrice24h = dto.LowestPrice24h;
            entity.LastUpdate = dto.LastUpdate;
            entity.MarketCap = dto.MarketCap;
            entity.PriceChangePercetage = dto.PriceChangePercetage;
        }

        public static CoinDTO ToDTO(this Coin coin)
        {
            return new CoinDTO
            {
                Id = coin.Id,
                CurrentPrice = coin.CurrentPrice,
                HighestPrice24h = coin.HighestPrice24h,
                LastUpdate = coin.LastUpdate,
                LowestPrice24h = coin.LowestPrice24h,
                MarketCap = coin.MarketCap,
                Name = coin.Name,
                PriceChangePercetage = coin.PriceChangePercetage,
            };
        }
    }
}
