using CryptoApiService.Domain.Contracts;
using CryptoService.Domain.Entity;
using CryptoService.Infrastructure;
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

        public async Task<Coin> GetById(string id, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
