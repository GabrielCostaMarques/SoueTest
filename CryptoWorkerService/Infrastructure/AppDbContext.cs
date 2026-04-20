using CryptoWorkerService.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CryptoWorkerService.Infrastructure
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        DbSet<Coin> Coins { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    
}
