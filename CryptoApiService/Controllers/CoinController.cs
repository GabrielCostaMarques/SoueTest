using CryptoApiService.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CryptoApiService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CoinController(ICoinServiceApi coinServiceApi) : ControllerBase
    {
        private readonly ICoinServiceApi _coinServiceApi = coinServiceApi;


        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _coinServiceApi.GetAllCoinsAsync(cancellationToken);

            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _coinServiceApi.GetCoinsByIdAsync(id, cancellationToken);

            return Ok(result);  
        }
    }
}
