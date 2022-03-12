using AutoMapper;
using AutoMapper.Internal;
using Binance.Crypto.v1;
using BotApi.Dto;

namespace BotApi.MapperProfiles;

public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        ((IProfileExpressionInternal) this).ForAllMaps((map, expression) => expression.ForAllMembers(conf =>
        {
            conf.Condition(cond =>
            {
                if (cond != null) return true;
                conf.Ignore();
                return false;
            });
        }));
        
        // Crypto price
        CreateMap<CryptoCurrencyDto, CryptoCurrencyDtoRequest>();
    }
}