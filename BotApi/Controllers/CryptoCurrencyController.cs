using AutoMapper;
using Binance.Crypto.v1;
using BotApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BotApi.Controllers;

[ApiController]
[Route("api/cryptoCurrency")]
public class CryptoCurrencyController : ControllerBase
{
    private readonly CryptoService.CryptoServiceClient _client;
    private IMapper _mapper;

    public CryptoCurrencyController(CryptoService.CryptoServiceClient client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    [HttpGet("crypto")]
    public async Task<ActionResult<CryptoCurrencyDtoResponse>> GetPriceCryptoCurrency([FromQuery]CryptoCurrencyDto currency)
    {
        var crypto = _mapper.Map<CryptoCurrencyDtoRequest>(currency);
        return await _client.GetCryptoCurrencyAsync(crypto);
    }
}