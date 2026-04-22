using CryptoService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CryptoApiService.Configuration
{
    public static class DbConfiguration
    {
        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            services.AddDbContext<AppDbContext>(
                options =>
                    options.UseNpgsql(
                        connectionString,
                        o => o.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                       )
            );
        }
    }
}
