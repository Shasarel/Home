using Home.WebApi.Database;
using Home.WebApi.Interfaces;
using Home.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HomeContext>();

builder.Services.AddTransient<IEnergyService, EnergyService>();

var app = builder.Build();

//app.UseStaticFiles();

app.MapControllers();

app.Run();
