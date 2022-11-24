using Home.WebApi.Database.Models;
using Home.WebApi.Database.ValueConverters;
using Microsoft.EntityFrameworkCore;

namespace Home.WebApi.Database
{
   public sealed class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<BlindTask>()
                .Property(e => e.DateTime)
                .HasConversion<DateTimeOffsetTimestampConverter>();

            modelBuilder
                .Entity<ElectricityMeasurement>()
                .Property(e => e.DateTime)
                .HasConversion<DateTimeOffsetTimestampConverter>();

            modelBuilder
                .Entity<MeteoMeasurement>()
                .Property(e => e.DateTime)
                .HasConversion<DateTimeOffsetTimestampConverter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.Date)
                .HasConversion<DateTimeOffsetDateIntConverter>();

            modelBuilder
                .Entity<DailyMeteoSummary>()
                .Property(e => e.Date)
                .HasConversion<DateTimeOffsetDateIntConverter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyProduction)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder.
                Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyExport)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyImport)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyProductionSum)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyImportSum)
                .HasConversion<IntDouble1000Converter>();
            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyExportSum)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<ElectricityMeasurement>()
                .Property(e => e.EnergyProduction)
                .HasConversion<IntDouble1000Converter>();
            modelBuilder
               .Entity<ElectricityMeasurement>()
               .Property(e => e.EnergyProductionDeye)
               .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<ElectricityMeasurement>()
                .Property(e => e.EnergyImport)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<ElectricityMeasurement>()
                .Property(e => e.EnergyExport)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<EnergyCorrection>()
                .Property(e => e.Correction)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<MeteoMeasurement>()
                .Property(e => e.Temperature)
               .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<MeteoMeasurement>()
                .Property(e => e.Pressure)
                .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<DailyMeteoSummary>()
                .Property(e => e.TemperatureMin)
                .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<DailyMeteoSummary>()
                .Property(e => e.TemperatureAvg)
                .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<DailyMeteoSummary>()
                .Property(e => e.TemperatureMax)
                .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<DailyMeteoSummary>()
                .Property(e => e.HumidityMin)
                .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<DailyMeteoSummary>()
                .Property(e => e.HumidityAvg)
                .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<DailyMeteoSummary>()
                .Property(e => e.HumidityMax)
                .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<DailyMeteoSummary>()
                .Property(e => e.PressureMin)
                .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<DailyMeteoSummary>()
                .Property(e => e.PressureAvg)
                .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<DailyMeteoSummary>()
                .Property(e => e.PressureMax)
                .HasConversion<IntDouble100Converter>();

            modelBuilder
                .Entity<EnergyCorrection>()
                .Property(e => e.Correction)
                .HasConversion<IntDouble1000Converter>();
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
