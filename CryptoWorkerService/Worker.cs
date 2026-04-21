using CryptoWorkerService.Domain.Contracts;

namespace CryptoWorkerService
{
    public class Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory) : BackgroundService
    {

        private readonly IServiceScopeFactory _scopeFactory = scopeFactory;
       
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var coinWorkerService = scope.ServiceProvider.GetRequiredService<ICoinWorkerService>();

                if (logger.IsEnabled(LogLevel.Information))
                {
                    logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await coinWorkerService.UpdateCoins();

                await Task.Delay(60000, stoppingToken);
            }
        }
    }
}
