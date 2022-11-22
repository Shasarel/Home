using Home.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using TBD.DbModels;

namespace Home.WebApi
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options)
        {

        }
        public DbSet<BlindSchedule> BlindSchedule { get; set; }
        public DbSet<BlindTask> BlindTask { get; set; }
        public DbSet<DailyElectricitySummary> DailyElectricitySummary { get; set; }
        public DbSet<DailyMeteoSummary> DailyMeteoSummary { get; set; }
        public DbSet<ElectricityMeasurement> ElectricityMeasurement { get; set; }
        public DbSet<EnergyCorrection> EnergyCorrection { get; set; }
        public DbSet<MeteoMeasurement> MeteoMeasurement { get; set; }
    }
}
