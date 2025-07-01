using Microsoft.OpenApi.Models;

namespace ChoiceAPI.Api;

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
                Title = "ChoiceAPI",
                Description = "Choice API service"
            });
        });
        
        return services;
    }
}