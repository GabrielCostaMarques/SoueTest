using CryptoWorkerService.Domain.Contracts;
using CryptoWorkerService.Domain.Entity;
using CryptoWorkerService.Service;
using Microsoft.EntityFrameworkCore;

namespace CryptoWorkerService.Infrastructure.Repository
{
    public class CoinRepository(AppDbContext context) : ICoinRepository
    {
        private readonly DbSet<Coin> _dbSet = context.Set<Coin>();

        public async Task Insert(List<Coin> coin, CancellationToken cancellationToken)
        {
            await _dbSet.AddRangeAsync(coin);
        }

        public async Task<Dictionary<string,Coin>> CheckExistDb(List<CoinDTO> data, CancellationToken cancellationToken)
        {
            var ids = data.Select(x => x.Id).ToList();
            var coinsDb=await _dbSet.Where(c => ids.Contains(c.Id)).ToListAsync(cancellationToken);

            return coinsDb.ToDictionary(x => x.Id);
        }



        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

    }
}
