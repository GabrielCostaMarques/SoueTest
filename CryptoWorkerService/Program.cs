using CryptoWorkerService;
using CryptoWorkerService.Configuration;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddDbConfiguration(builder.Configuration);
builder.Services.AddApplicationConfiguration();
builder.Services.AddHttpClientConfiguration();

var host = builder.Build();
host.Run();
