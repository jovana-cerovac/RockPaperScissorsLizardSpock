using GameAPI.Core.Persistence;
using GameAPI.Core.Services;
using GameAPI.Core.Services.Abstractions;
using GameAPI.Infrastructure.Persistence;
using GameAPI.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameAPI.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IRulesService, RulesService>();
        
        services.AddScoped<IGameRoundRepository, GameRoundRepository>();

        services.AddHttpClient<IChoicesApiClient, ChoicesApiClient>((provider, client) =>
        {
            var apiSettings = provider.GetRequiredService<IConfiguration>().GetSection("ApiSettings");
            var baseAddress = apiSettings.GetValue<string>("BaseAddress");

            if (!string.IsNullOrWhiteSpace(baseAddress))
            {
                client.BaseAddress = new Uri(baseAddress);
            }
            else
            {
                throw new InvalidOperationException("API BaseAddress is not configured.");
            }
        });

        return services;
    }
}