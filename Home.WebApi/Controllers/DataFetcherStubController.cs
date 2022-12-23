using Home.Database.Database;
using Home.MeasurementFetcher;
using Home.MeasurementFetcher.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using System.Text.Json;

namespace Home.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DataFetcherStubController: ControllerBase
    {
        private readonly HomeContext _context;

        public DataFetcherStubController(HomeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public string SaveData(AllMeasurments dto)
        {
            _context.Add(dto.MeteoMeasurement);
            _context.Entry(dto.MeteoMeasurement).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            var r = _context.SaveChanges();
            _context.Add(dto.ElectricityMeasurement);
            _context.Entry(dto.ElectricityMeasurement).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            var r2 = _context.SaveChanges();
            return $"meteo: {r}, energy: {r2}, {JsonSerializer.Serialize(dto)}";
        }

        public IotChiefEnergyResponseDto EnergyData()
        {
            var rnd = new Random();

            var powerFlara = rnd.Next() % 2000;
            var powerDeye = rnd.Next() % 2500;
            var powerExport = powerFlara + powerDeye - rnd.Next() % (powerFlara + powerDeye);
            var powerImport = rnd.Next() % 5000;

            var data = _context.ElectricityMeasurement.OrderByDescending(x => x.Id).First();
            SqliteConnection.ClearAllPools();

            return new()
            {
                HasData = true,
                EnergyData = new()
                {
                    DeyeData = new()
                    {
                        Energy = data.EnergyProductionDeye + (powerDeye / 60000.0) + 150,
                        Power = powerDeye
                    },
                    FlaraData = new()
                    {
                        Energy = data.EnergyProduction + (powerFlara / 60000.0) + 100,
                        Power = powerFlara
                    },
                    EnergyExport = data.EnergyExport + (powerExport / 60000.0) + 100,
                    EnergyImport = data.EnergyImport + (powerImport / 60000.0) + 100,
                    PowerExport = powerExport,
                    PowerImport = powerImport
                }
            };
        }

        public IoTChiefMeteoResponseDto MeteoData()
        {
            var rnd = new Random();
            return new()
            {
                HasData = true,
                MeteoData = new()
                {
                    Temperature = ((rnd.Next() % 400) - 100) / 10.0,
                    Pressure = ((rnd.Next() % 80) + 9050) / 10.0,
                    DustPM10 = rnd.Next() % 125,
                    DustPM100 = rnd.Next() % 125,
                    DustPM25 = rnd.Next() % 125,
                    BmpCon = true,
                    Cold = false,
                    PmsCon = true,
                    SiCon = true
                }
            };
        }
    }
}
