using CryptoService.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CryptoService.Infrastructure
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
