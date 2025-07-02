using ChoiceAPI.Api;
using ChoiceAPI.Api.Middlewares;
using ChoiceAPI.Core;
using ChoiceAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreServices()
    .AddInfrastructureServices()
    .AddApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();

app.Run();