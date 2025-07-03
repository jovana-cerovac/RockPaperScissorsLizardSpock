using ChoiceAPI.Core.Persistence;
using ChoiceAPI.Core.Services.Abstractions;
using ChoiceAPI.Infrastructure.Persistence;
using ChoiceAPI.Infrastructure.Services;
using ChoiceAPI.Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ChoiceAPI.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IChoiceRepository, ChoiceRepository>();

        services.AddOptions<RandomApiSettings>()
            .BindConfiguration(RandomApiSettings.SectionName)
            .Validate(api => !string.IsNullOrWhiteSpace(api.BaseAddress))
            .ValidateOnStart();
        
        services.AddSingleton(serviceProvider => 
            serviceProvider.GetRequiredService<IOptions<RandomApiSettings>>().Value);

        services.AddHttpClient<IRandomNumberService, RandomNumberService>((provider, client) =>
        {
            var apiSettings = provider.GetRequiredService<RandomApiSettings>();
            client.BaseAddress = new Uri(apiSettings.BaseAddress);
        });

        return services;
    }
}