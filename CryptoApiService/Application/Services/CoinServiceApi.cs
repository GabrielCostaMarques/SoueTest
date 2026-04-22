using Ardalis.Result;
using CryptoApiService.Domain.Contracts;
using CryptoWorkerService.Service;
using CryptoService.Infrastructure.Mapper;

namespace CryptoApiService.Application.Services
{
    public class CoinServiceApi(ICoinRepositoryApi coinRepositoryApi ) : ICoinServiceApi
    {
        private readonly ICoinRepositoryApi _coinRepositoryApi = coinRepositoryApi;
        public async Task<Result<List<CoinDTO>>> GetAllCoinsAsync(CancellationToken cancellationToken)
        {
            var coins = await _coinRepositoryApi.GetAll(cancellationToken);
            var dtoList = coins.Select(x => x.ToDTO()).ToList();

            return Result.Success(dtoList);   
        }
        public async Task<Result<CoinDTO>> GetCoinsByIdAsync(string id, CancellationToken cancellationToken)
        {
            var coins = await _coinRepositoryApi.GetById(id,cancellationToken);
            var dtoList = coins.ToDTO();

            return Result.Success(dtoList);   
        }


    }
}
