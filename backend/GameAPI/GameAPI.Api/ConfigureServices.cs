using Microsoft.OpenApi.Models;

namespace GameAPI.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "GameAPI",
                Description = "Game API service"
            });
        });
        
        return services;
    }
}