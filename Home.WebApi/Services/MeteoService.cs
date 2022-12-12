using Home.WebApi.Database;
using Home.WebApi.Dtos;
using Home.WebApi.Enums;
using Home.WebApi.Extensions;
using Home.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq;

namespace Home.WebApi.Services
{
    public class MeteoService : IMeteoService
    {
        const int MeteoChartGroupCount = 288;

        private readonly HomeContext _context;

        public MeteoService(HomeContext context)
        {
            _context = context;
        }

        public async Task<MeteoDto> GetCurrentData()
        {
            var meteoData = await MeasurementFetcher.MeasurementFetcher.GetMeteoMeasurement();

            var hourAgo = DateTime.Now.AddHours(-1);

            var measurement = _context.MeteoMeasurement.Where(x => x.DateTime >= hourAgo).OrderBy(x => x.DateTime).FirstOrDefault();

            return new()
            {
                Temperature = meteoData.Temperature,
                TemperatureChange = measurement == null ? 0.0 : Math.Round(measurement.Temperature - meteoData.Temperature, 1),
                Pressure = meteoData.Pressure,
                PressureChange = measurement == null ? 0.0 : Math.Round(measurement.Pressure - meteoData.Pressure, 1),
                Dust = meteoData.DustPM25,
            };
        }

        public MeteoChartDataDto GetMeteoChartData(DateTimeOffset from, DateTimeOffset to)
        {
            var timespan = (to.AddDays(1) - from);

            if (timespan.Days <= 31)
                return GetMeteoChartDataShort(from, to);
            else
                return GetMeteoChartDataLong(from, to);
        }

        private MeteoChartDataDto GetMeteoChartDataShort(DateTimeOffset from, DateTimeOffset to)
        {
            var timespan = (to.AddDays(1) - from);

            var labelFormat = "HH:mm";

            if (timespan.Days > 7)
                labelFormat = "dd-MM-yyyy";

            var meteoChartTimeSeparation = timespan.TotalMinutes / MeteoChartGroupCount;

            var groups = _context.MeteoMeasurement.Where(x => x.DateTime > from && x.DateTime < to.AddDays(1))
                .ToList()
                .GroupBy(x => (int)((x.DateTime - from).TotalMinutes / meteoChartTimeSeparation))
                .AddMissingGroups(x => from.AddMinutes(meteoChartTimeSeparation * x.Key), MeteoChartGroupCount);

            return new()
            {
                Temperature = new()
                {
                    Max = groups.SelectMax(x => x.Temperature),
                    Min = groups.SelectMin(x => x.Temperature),
                    Avg = groups.SelectAvg(x => x.Temperature),
                },
                Pressure = new()
                {
                    Max = groups.SelectMax(x => x.Pressure),
                    Min = groups.SelectMin(x => x.Pressure),
                    Avg = groups.SelectAvg(x => x.Pressure),
                },
                Dust = new()
                {
                    Max  = groups.SelectMax(x => x.DustPM25),
                    Min = groups.SelectMin(x => x.DustPM25),
                    Avg = groups.SelectAvg(x => x.DustPM25),
                },
                Labels = groups.Select(x => x.Key.ToString(labelFormat)).ToList(),
            };
        }

        private MeteoChartDataDto GetMeteoChartDataLong(DateTimeOffset from, DateTimeOffset to)
        {
            var groups = _context.DailyMeteoSummary
                .Where(x => x.Date >= from && x.Date <= to && x.IsDataCorrect)
                .OrderBy(x => x.Date)
                .ToList()
                .GroupBy(x => (x.Date - from).Days)
                .AddMissingGroups(x => from.AddDays(x.Key), (to - from).Days + 1);

            return new()
            {
                Temperature = new()
                {
                    Max = groups.SelectMax(x => x.TemperatureMax),
                    Avg = groups.SelectMin(x => x.TemperatureAvg),
                    Min = groups.SelectAvg(x => x.TemperatureMin)
                },
                Pressure = new()
                {
                    Max = groups.SelectMax(x => x.PressureMax),
                    Min = groups.SelectMin(x => x.PressureMin),
                    Avg = groups.SelectAvg(x => x.PressureAvg),
                },
                Dust = new()
                {
                    Max = groups.SelectMax(x => x.DustPM25Max),
                    Min = groups.SelectMin(x => x.DustPM25Min),
                    Avg = groups.SelectAvg(x => x.DustPM25Avg),
                },
                Labels = groups.Select(x => x.Key.ToString("dd-MM-yyyy")).ToList(),
            };
        }
    }
}