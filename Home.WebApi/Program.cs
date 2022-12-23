using Home.Database.Database;
using Home.WebApi.Interfaces;
using Home.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HomeContext>();

builder.Services.AddTransient<IEnergyService, EnergyService>();
builder.Services.AddTransient<IMeteoService, MeteoService>();
builder.Services.AddTransient<IBlindsService, BlindsService>();

var app = builder.Build();

app.MapControllers();

app.Run();
