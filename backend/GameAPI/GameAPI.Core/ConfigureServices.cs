using GameAPI.Core.Services;
using GameAPI.Core.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GameAPI.Core;

public static class ConfigureServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IGameService, GameService>();
        return services;
    }
}