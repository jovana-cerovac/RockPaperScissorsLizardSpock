using ChoiceAPI.Api;
using ChoiceAPI.Api.Middlewares;
using ChoiceAPI.Api.Settings;
using ChoiceAPI.Core;
using ChoiceAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreServices()
    .AddInfrastructureServices()
    .AddApiServices();

builder.Services.Configure<CorsSettings>(builder.Configuration.GetSection(CorsSettings.SectionName));

var corsSettings = builder.Configuration
    .GetSection(CorsSettings.SectionName)
    .Get<CorsSettings>() ?? new CorsSettings();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins(corsSettings.AllowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();

app.Run();