using Home.WebApi.Database;
using Home.WebApi.Dtos;
using Home.WebApi.Extensions;
using Home.WebApi.Interfaces;
using Home.WebApi.Enums;

namespace Home.WebApi.Services
{
    public class EnergyService : IEnergyService
    {
        const int PowerChartTimeSeparation = 5;

        private readonly HomeContext _context;

        public EnergyService(HomeContext context)
        {
            _context = context;
        }

        public EnergyDto GetEnergyData(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var energyDto = new EnergyDto();

            if (toDate > DateTime.Today)
            {
                energyDto += GetEnergyToday();
            }

            if (fromDate < DateTime.Today)
            {
                energyDto += GetEnergyPast(fromDate, toDate);
            }

            return energyDto;
        }

        public async Task<PowerDto> CurrentPower()
        {
            var electricityMeasurement = await MeasurementFetcher.MeasurementFetcher.GetElectricityMeasurement();

            return new()
            {
                Production = electricityMeasurement.PowerProductionAll,
                Consumption = electricityMeasurement.PowerConsumption,
                Use = electricityMeasurement.PowerUse,
                Import = electricityMeasurement.PowerImport,
                Export = electricityMeasurement.PowerExport,
                Store = electricityMeasurement.PowerStore,
            };
        }

        public double GetMaxEnergyStore() =>
            _context
            .DailyElectricitySummary
            .AsEnumerable()
            .Max(x => x.EnergyStoreTotal +
                _context
                .EnergyCorrection
                .AsEnumerable()
                .Where(y => y.Date <= x.Date)
                .Sum(x => x.Correction));


        public ElectricityChartDataDto GetChartData(DateTimeOffset from, DateTimeOffset to)
        {
            var dateOnlyFrom = from.Date;
            var dateOnlyTo = to.Date;

            var difference = (dateOnlyTo - dateOnlyFrom).Days;

            if (difference == 0)
                return GetPowerChartData(dateOnlyFrom);

            if (difference <= 30)
                return GetEnergyChartData(dateOnlyFrom, dateOnlyTo, EnergyChartGrouping.Day);

            if (difference <= 365)
                return GetEnergyChartData(dateOnlyFrom, dateOnlyTo, EnergyChartGrouping.Month);

            return GetEnergyChartData(dateOnlyFrom, dateOnlyTo, EnergyChartGrouping.Year);
        }

        private ElectricityChartDataDto GetPowerChartData(DateTimeOffset day)
        {
            var groups = _context.ElectricityMeasurement
                .Where(x => x.DateTime > day && x.DateTime < day.AddDays(1))
                .ToList()
                .GroupBy(x => (int)((x.DateTime - day).TotalMinutes / PowerChartTimeSeparation))
                .AddMissingGroups(x => day.AddMinutes(PowerChartTimeSeparation * x.Key), 24 * 60 / PowerChartTimeSeparation);

            return new ElectricityChartDataDto
            {
                Production = groups.SelectMax(x => x.PowerProductionAll),
                Consumption = groups.SelectMax(x => x.PowerConsumption),
                Use = groups.SelectMax(x => x.PowerUse),
                Import = groups.SelectMax(x => x.PowerImport),
                Export = groups.SelectMax(x => x.PowerExport),
                Store = groups.SelectMax(x => x.PowerStore),
                Labels = groups.Select(x => x.Key.ToString("HH:mm")).ToList(),
                ChartType = "line"
            };
        }

        private ElectricityChartDataDto GetEnergyChartData(DateTimeOffset from, DateTimeOffset to, EnergyChartGrouping grouping)
        {
            var dbSet = _context.DailyElectricitySummary.Where(x => x.Date >= from && x.Date <= to).OrderBy(x => x.Date).ToList();

            Dictionary<DateTimeOffset, List<Database.Models.DailyElectricitySummary>> groups;

            string labelsFormat;

            switch (grouping)
            {
                case EnergyChartGrouping.Day:
                    groups = dbSet
                        .GroupBy(x => x.Date.Day - 1)
                        .AddMissingGroups(x => from.AddDays(x.Key), (to - from).Days + 1);

                    labelsFormat = "dd";
                break;
                case EnergyChartGrouping.Month:
                groups = dbSet
                        .GroupBy(x => x.Date.Month -1)
                        .AddMissingGroups(x => from.AddMonths(x.Key), (to.Year - from.Year) * 12 + to.Month - from.Month + 1);

                    labelsFormat = "MM";
                    break;
                case EnergyChartGrouping.Year:
                    groups = dbSet
                        .GroupBy(x => x.Date.Year - from.Year)
                        .AddMissingGroups(x => from.AddYears(x.Key), to.Year - from.Year + 1);

                    labelsFormat = "yyyy";
                    break;
                default:
                    groups = new();
                    labelsFormat = "";
                break;

            }

            return new ElectricityChartDataDto
            {
                Production = groups.SelectDifference(x => x.EnergyProductionTotalAll, x => x.EnergyProductionDailyAll),
                Consumption = groups.SelectDifference(x => x.EnergyConsumptionTotal, x => x.EnergyConsumptionDaily),
                Use = groups.SelectDifference(x => x.EnergyUseTotal, x => x.EnergyUseDaily),
                Import = groups.SelectDifference(x => x.EnergyImportTotal, x => x.EnergyImportDaily),
                Export = groups.SelectDifference(x => x.EnergyExportTotal, x => x.EnergyExportDaily),
                Store = groups.SelectDifference(x => x.EnergyStoreTotal, x => x.EnergyStoreDaily),
                Labels = groups.Select(x => x.Key.ToString(labelsFormat)).ToList(),
                ChartType = "bar",
            };
        }

        private EnergyDto GetEnergyPast(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var toDateUpToToday = toDate > DateTime.Today ? DateTime.Today : toDate;

            var fromMeasurement = _context.DailyElectricitySummary
                .Where(x => x.Date >= fromDate && x.Date <= toDateUpToToday)
                .OrderBy(x => x.Date)
                .FirstOrDefault();

            var toMeasurement = _context.DailyElectricitySummary
                .Where(x => x.Date >= fromDate && x.Date <= toDateUpToToday)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();

            toMeasurement ??= new();
            fromMeasurement ??= new();

            var storeCorrection = 0.0;

            if (fromMeasurement.Id == 1)
            {
                fromMeasurement = new();
                storeCorrection = _context
                    .EnergyCorrection
                    .AsEnumerable()
                    .Where(x => x.Date <= toDate)
                    .Sum(x => x.Correction);
            }

            return new EnergyDto
            {
                Production = toMeasurement.EnergyProductionTotalAll - fromMeasurement.EnergyProductionTotalAll + fromMeasurement.EnergyProductionDailyAll,
                Import = toMeasurement.EnergyImportTotal - fromMeasurement.EnergyImportTotal + fromMeasurement.EnergyImportDaily,
                Export = toMeasurement.EnergyExportTotal - fromMeasurement.EnergyExportTotal + fromMeasurement.EnergyExportDaily,
                Use = toMeasurement.EnergyUseTotal - fromMeasurement.EnergyUseTotal + fromMeasurement.EnergyUseDaily,
                Consumption = toMeasurement.EnergyConsumptionTotal - fromMeasurement.EnergyConsumptionTotal + fromMeasurement.EnergyConsumptionDaily,
                Store = toMeasurement.EnergyStoreTotal - fromMeasurement.EnergyStoreTotal + fromMeasurement.EnergyStoreDaily + storeCorrection,
            };
        }

        private EnergyDto GetEnergyToday()
        {
            var fromMeasurement = _context.ElectricityMeasurement
                .Where(x => x.DateTime >= DateTime.Today && x.DateTime < DateTime.Today.AddDays(1))
                .OrderBy(x => x.DateTime)
                .FirstOrDefault();

            var toMeasurement = _context.ElectricityMeasurement
                .Where(x => x.DateTime > DateTime.Today && x.DateTime <= DateTime.Today.AddDays(1))
                .OrderByDescending(x => x.DateTime)
                .FirstOrDefault();

            toMeasurement ??= new();
            fromMeasurement ??= new();

            if (fromMeasurement.Id == 1)
                fromMeasurement = new();

            return new EnergyDto
            {
                Production = toMeasurement.EnergyProductionAll - fromMeasurement.EnergyProductionAll,
                Import = toMeasurement.EnergyImport - fromMeasurement.EnergyImport,
                Export = toMeasurement.EnergyExport - fromMeasurement.EnergyExport,
                Use = toMeasurement.EnergyUse - fromMeasurement.EnergyUse,
                Consumption = toMeasurement.EnergyConsumption - fromMeasurement.EnergyConsumption,
                Store = toMeasurement.EnergyStore - fromMeasurement.EnergyStore,
            };
        }
    }
}
