using CryptoWorkerService;
using CryptoWorkerService.Domain.Contracts;
using CryptoWorkerService.Infrastructure;
using CryptoWorkerService.Infrastructure.Repository;
using CryptoWorkerService.Service;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();


var connectionString = "User ID=root;Password=Lagavi30!;Host=localhost;Port=5432;Database=coins;Pooling=true;Connection Lifetime=0;";
builder.Services.AddDbContext<AppDbContext>(
    options =>
        options.UseNpgsql(
            connectionString,
            o => o.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
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
