using CryptoService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CryptoWorkerService.Configuration
{
    public static class DbConfiguration
    {
        public static void AddDbConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            service.AddDbContext<AppDbContext>(
                options =>
                    options.UseNpgsql(connectionString, o => o.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null)
                       )
            );
        }
    }
}
