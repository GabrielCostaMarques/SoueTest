using CryptoApiService.Application.Services;
using CryptoApiService.Domain.Contracts;
using CryptoApiService.Repository;

namespace CryptoApiService.Configuration
{
    public static class ApplicationConfiguration
    {
        public static void AddApplicationConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICoinRepositoryApi, CoinRepositoryApi>();
            services.AddScoped<ICoinServiceApi, CoinServiceApi>();
        }
    }
}
