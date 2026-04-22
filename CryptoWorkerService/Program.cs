using CryptoService.Domain.Contracts;
using CryptoService.Infrastructure;
using CryptoService.Infrastructure.Repository;
using CryptoWorkerService;
using CryptoWorkerService.Contracts;
using CryptoWorkerService.Service;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<AppDbContext>(
    options =>
        options.UseNpgsql(
            connectionString,
            o => o.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null)
           )
);

builder.Services.AddScoped<ICoinWorkerService, CoinWorkerService>();
builder.Services.AddScoped<ICoinRepository, CoinRepository>();

builder.Services.AddHttpClient<ICoinWorkerService, CoinWorkerService>(client =>
{
    client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
    client.DefaultRequestHeaders.Add("x-cg-demo-api-key", "CG-vysRBLYqUQcvMtm36zEgcdUE");
});

var host = builder.Build();
host.Run();
