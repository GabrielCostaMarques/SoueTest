using Ardalis.Result;
using CryptoWorkerService.Service;

namespace CryptoApiService.Domain.Contracts
{
    public interface ICoinServiceApi
    {
        public Task<Result<List<CoinDTO>>> GetAllCoinsAsync(CancellationToken cancellationToken);
        public Task<Result<CoinDTO>> GetCoinsByIdAsync(string id, CancellationToken cancellationToken);
    }
}
