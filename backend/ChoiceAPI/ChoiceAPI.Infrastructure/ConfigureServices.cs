using ChoiceAPI.Core.Persistence;
using ChoiceAPI.Core.Services.Abstractions;
using ChoiceAPI.Infrastructure.Persistence;
using ChoiceAPI.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChoiceAPI.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IChoiceRepository, ChoiceRepository>();
        
        services.AddHttpClient<IRandomNumberService, RandomNumberService>((provider, client) =>
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