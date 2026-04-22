using CryptoApiService.Domain.Contracts;
using CryptoWorkerService.Domain.Entity;
using CryptoWorkerService.Infrastructure;
using CryptoWorkerService.Service;
using Microsoft.EntityFrameworkCore;

namespace CryptoApiService.Repository
{
    public class CoinRepositoryApi(AppDbContext context) : ICoinRepositoryApi
    {
        private readonly DbSet<Coin> _dbSet = context.Set<Coin>();

        public async Task<List<Coin>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public Task<Coin> GetById(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
