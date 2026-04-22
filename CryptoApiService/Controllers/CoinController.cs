using CryptoApiService.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace CryptoApiService.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CoinController(ICoinServiceApi coinServiceApi) : ControllerBase
    {
        private readonly ICoinServiceApi _coinServiceApi = coinServiceApi;

        [SwaggerResponse((int)HttpStatusCode.OK, "Returns cryptos or empty list when no data is available")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Unexpected error")]
        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = await _coinServiceApi.GetAllCoinsAsync(cancellationToken);

            return Ok(result);
        }

        [SwaggerResponse((int)HttpStatusCode.OK, "Returns crypto by ID or empty list when no data is available")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Unexpected error")]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
        {
            var result = await _coinServiceApi.GetCoinsByIdAsync(id, cancellationToken);

            return Ok(result);  
        }
    }
}
