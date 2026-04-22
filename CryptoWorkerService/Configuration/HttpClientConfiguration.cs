using CryptoWorkerService.Contracts;
using CryptoWorkerService.Service;

namespace CryptoWorkerService.Configuration
{
    public static class HttpClientConfiguration
    {
        public static void AddHttpClientConfiguration(this IServiceCollection services)
        {
            services.AddHttpClient<ICoinWorkerService, CoinWorkerService>(client =>
            {
                client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
                client.DefaultRequestHeaders.Add("x-cg-demo-api-key", "CG-vysRBLYqUQcvMtm36zEgcdUE");
            });
        }
    }
}
