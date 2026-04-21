using CryptoWorkerService.Domain.Entity;
using CryptoWorkerService.Service;

namespace CryptoWorkerService.Domain.Contracts
{
    public interface ICoinRepository
    {
        public Task Insert(List<Coin> coin, CancellationToken cancellationToken = default);
        public Task<Dictionary<string, Coin>> CheckExistDb(List<CoinDTO> data, CancellationToken cancellationToken);
        public Task CommitAsync(CancellationToken cancellationToken);
    }
}
