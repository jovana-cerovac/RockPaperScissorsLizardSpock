using GameAPI.Core.Services.Abstractions;
using GameAPI.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameAPI.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddHttpClient<IChoiceService, ChoiceService>((provider, client) =>
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