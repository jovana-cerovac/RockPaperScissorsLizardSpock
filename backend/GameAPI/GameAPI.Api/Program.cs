using GameAPI.Api;
using GameAPI.Core;
using GameAPI.Infrastructure;

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();