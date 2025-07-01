using ChoiceAPI.Core.Services;
using ChoiceAPI.Core.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ChoiceAPI.Core;

public static class ConfigureServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IChoiceService, ChoiceService>();
        return services;
    }
}