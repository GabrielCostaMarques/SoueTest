using CryptoService.Domain.Contracts;
using CryptoService.Domain.Entity;
using CryptoWorkerService.Contracts;
using System.Net.Http.Json;
using CryptoService.Infrastructure.Mapper;

namespace CryptoWorkerService.Service
{
    public class CoinWorkerService(HttpClient httpClient, ICoinRepository coinRepository, ILogger<CoinWorkerService> logger) : ICoinWorkerService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ICoinRepository _coinRepository = coinRepository;

        public async Task UpdateCoins(CancellationToken cancellationToken)
        {

            var task = _httpClient.GetAsync("coins/markets?vs_currency=usd");
            try
            {
                var data = await _httpClient
                .GetFromJsonAsync<List<CoinDTO>>("coins/markets?vs_currency=usd");



                var existingCoins = await _coinRepository.CheckExistDb(data, cancellationToken);

                var newCoins = new List<Coin>();

                foreach (var item in data)
                {
                    if (existingCoins.TryGetValue(item.Id, out var coinDb))
                    {
                        coinDb.UpdateEntity(item);
                    }
                    else
                    {
                        newCoins.Add(item.ToEntity());
                    }
                }

                await _coinRepository.Insert(newCoins, cancellationToken);
                await _coinRepository.CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError($"was not possible to connect api - {task.Result.StatusCode}");
            }



        }

    }
}
