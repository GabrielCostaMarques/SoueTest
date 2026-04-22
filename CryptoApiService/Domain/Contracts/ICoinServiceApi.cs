using Ardalis.Result;
using CryptoWorkerService.Service;

namespace CryptoApiService.Domain.Contracts
{
    public interface ICoinServiceApi
    {
        public Task<Result<List<CoinDTO>>> GetAllCoinsAsync(CancellationToken cancellationToken);
    }
}
