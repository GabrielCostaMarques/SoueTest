using CryptoWorkerService.Domain.Contracts;
using CryptoWorkerService.Domain.Entity;
using CryptoWorkerService.Infrastructure;
using CryptoWorkerService.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace CryptoWorkerService.Service
{
    public class CoinWorkerService(HttpClient httpClient, AppDbContext context) : ICoinWorkerService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly AppDbContext _context = context;
        private readonly DbSet<Coin> _dbSet = context.Set<Coin>();


        //public async Task<List<Coin>> GetCoinMarketById(string id)
        //{
        //    var data = await _httpClient.GetFromJsonAsync<List<CoinDTO>>($"/coins/markets?vs_currency=usd&ids={id}");

        //    return data.ToList(;
        //}

        public async Task InsertCoin(CancellationToken cancellationToken)
        {
            var data = await _httpClient.GetFromJsonAsync<List<CoinDTO>>("coins/markets?vs_currency=usd&ids=bitcoin,ethereum");

            var ids = data.Select(x => x.Id).ToList();

            var existingCoins = await _dbSet
                .Where(c => ids.Contains(c.Id)).ToListAsync();

            foreach (var item in data)
            {
                var existId = existingCoins.FirstOrDefault(c => c.Id == item.Id);

                if (existId is null)
                {
                    _dbSet.Add(new Coin
                    {
                        Id = item.Id,
                        CurrentPrice = item.CurrentPrice,
                        HighestPrice24h = item.HighestPrice24h,
                        LowestPrice24h = item.LowestPrice24h,
                        LastUpdate = item.LastUpdate,
                        MarketCap = item.MarketCap,
                        Name = item.Name,
                        PriceChangePercetage = item.PriceChangePercetage,
                    });
                }
                else
                {
                    existId.CurrentPrice = item.CurrentPrice;
                    existId.HighestPrice24h = item.HighestPrice24h;
                    existId.LowestPrice24h = item.LowestPrice24h;
                    existId.LastUpdate = item.LastUpdate;
                    existId.MarketCap = item.MarketCap;
                    existId.Name = item.Name;
                    existId.PriceChangePercetage = item.PriceChangePercetage;
                }
            }


            await _context.SaveChangesAsync();



        }

    }
}
