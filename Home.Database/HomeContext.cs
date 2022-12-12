using Home.Configuration;
using Home.WebApi.Database.Models;
using Home.WebApi.Database.ValueConverters;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Home.WebApi.Database
{
   public sealed class HomeContext : DbContext
    {
        public DbSet<BlindSchedule> BlindSchedule { get; set; }
        public DbSet<BlindTask> BlindTask { get; set; }
        public DbSet<DailyElectricitySummary> DailyElectricitySummary { get; set; }
        public DbSet<DailyMeteoSummary> DailyMeteoSummary { get; set; }
        public DbSet<ElectricityMeasurement> ElectricityMeasurement { get; set; }
        public DbSet<EnergyCorrection> EnergyCorrection { get; set; }
        public DbSet<MeteoMeasurement> MeteoMeasurement { get; set; }
        public HomeContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(HomeConfig.Default.DatabasePath);
            optionsBuilder.LogTo(message => Console.WriteLine(message));
            optionsBuilder.EnableSensitiveDataLogging();
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
                .Property(e => e.EnergyProductionDaily)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyProductionDeyeDaily)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder.
                Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyExportDaily)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyImportDaily)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyProductionTotal)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyProductionDeyeTotal)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyImportTotal)
                .HasConversion<IntDouble1000Converter>();

            modelBuilder
                .Entity<DailyElectricitySummary>()
                .Property(e => e.EnergyExportTotal)
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
    }
}
