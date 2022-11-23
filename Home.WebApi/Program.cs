using Home.WebApi.Database;
using Home.WebApi.Interfaces;
using Home.WebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HomeContext>(options =>
{
    options.UseSqlite("Data Source=home.sqlite;");
});

builder.Services.AddTransient<IEnergyService, EnergyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
