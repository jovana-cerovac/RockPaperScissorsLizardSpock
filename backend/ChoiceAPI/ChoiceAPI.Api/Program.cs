using ChoiceAPI.Core.Persistence;
using ChoiceAPI.Core.Services;
using ChoiceAPI.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<IChoiceRepository, ChoiceRepository>();
builder.Services.AddScoped<IChoiceService, ChoiceService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();