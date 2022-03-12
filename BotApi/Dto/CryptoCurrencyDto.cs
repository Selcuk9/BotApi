using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BotApi.Dto;

/// <summary>
/// Список поддерживаемых криптовалют
/// </summary>

public class CryptoCurrencyDto
{
    [Required]
    [DefaultValue("BTC")]
    public string CryptoFrom { get; set; }
    
    [Required]
    [DefaultValue("USDT")]
    public string CryptoTo { get; set; }
}