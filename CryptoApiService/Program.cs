using CryptoApiService.Application.Services;
using CryptoApiService.Domain.Contracts;
using CryptoApiService.Repository;
using CryptoWorkerService.Infrastructure;
using CryptoWorkerService.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICoinRepositoryApi, CoinRepositoryApi>();
builder.Services.AddScoped<ICoinServiceApi, CoinServiceApi>();

var connectionString = "User ID=root;Password=Lagavi30!;Host=localhost;Port=5432;Database=coins;Pooling=true;Connection Lifetime=0;";
builder.Services.AddDbContext<AppDbContext>(
    options =>
        options.UseNpgsql(
            connectionString,
            o => o.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
           )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
