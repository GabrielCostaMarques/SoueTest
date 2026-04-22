using CryptoService.Domain.Contracts;
using CryptoService.Infrastructure.Repository;
using CryptoWorkerService.Contracts;
using CryptoWorkerService.Service;

namespace CryptoWorkerService.Configuration
{
    public static class ApplicationConfiguration
    {
        public static void AddApplicationConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICoinWorkerService, CoinWorkerService>();
            services.AddScoped<ICoinRepository, CoinRepository>();
        }
    }
}
