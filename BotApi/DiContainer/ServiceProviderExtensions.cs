using Binance.Crypto.v1;

namespace BotApi.DiContainer;
public static class ServiceProviderExtensions
{
    private static void AddGrpcClient<TClient>(this IServiceCollection services, Uri address) 
        where TClient : class
    {
        services.AddGrpcClient<TClient>(o => o.Address = address);
    }
    public static void AddGrpcDbClients(this IServiceCollection services, Uri DbUri)
    {
        services.AddGrpcClient<CryptoService.CryptoServiceClient>(DbUri);
    }
}