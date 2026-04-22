using CryptoService.Domain.Entity;

namespace CryptoApiService.Domain.Contracts
{
    public interface ICoinRepositoryApi
    {
        public Task<List<Coin>> GetAll(CancellationToken cancellationToken);
        public Task<Coin> GetById(string id, CancellationToken cancellationToken);
    }
}
