using GameAPI.Core.Persistence;
using GameAPI.Core.Services;
using GameAPI.Core.Services.Abstractions;
using GameAPI.Infrastructure.Persistence;
using GameAPI.Infrastructure.Services;
using GameAPI.Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GameAPI.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IRulesService, RulesService>();

        services.AddScoped<IGameRoundRepository, GameRoundRepository>();

        services.AddOptions<ChoicesApiSettings>()
            .BindConfiguration(ChoicesApiSettings.SectionName)
            .Validate(api => !string.IsNullOrWhiteSpace(api.BaseAddress))
            .ValidateOnStart();

        services.AddSingleton(serviceProvider =>
            serviceProvider.GetRequiredService<IOptions<ChoicesApiSettings>>().Value);

        services.AddHttpClient<IChoicesApiClient, ChoicesApiClient>((provider, client) =>
        {
            var apiSettings = provider.GetRequiredService<ChoicesApiSettings>();
            client.BaseAddress = new Uri(apiSettings.BaseAddress);
        });

        return services;
    }
}