using HamsterWarsV2.Client.HttpRepository.HamsterHttp;
using HamsterWarsV2.Client.HttpRepository.MatchHttp;

namespace HamsterWarsV2.Client.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHamsterHttpRepository, HamsterHttpRepository>();
        services.AddScoped<IMatchHttpRepository, MatchHttpRepository>();
    } 
}
