using Home.WebApi.Database;
using Home.WebApi.Database.Models;
using Home.WebApi.Dtos;
using Home.WebApi.Interfaces;

namespace Home.WebApi.Services
{
    public class EnergyService : IEnergyService
    {
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
        public EnergyDto GetEnergyDataAll()
        {
            var correction = _context.EnergyCorrection.Sum(x => x.Correction);
            var energyDto = GetEnergyData(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);

            energyDto.Store += correction;

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

        private EnergyDto GetEnergyPast(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var minDate = new DateTime(1900, 1, 1);

            var toDateUpToToday = toDate > DateTime.Today ? DateTime.Today : toDate;
            var fromDateAdjusted = fromDate > minDate ? fromDate.AddDays(-1) : fromDate;

            var fromMeasurement = _context.DailyElectricitySummary
                .Where(x => x.Date >= fromDateAdjusted && x.Date < toDateUpToToday)
                .OrderBy(x => x.Date)
                .FirstOrDefault();

            var toMeasurement = _context.DailyElectricitySummary
                .Where(x => x.Date > fromDateAdjusted && x.Date <= toDateUpToToday)
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();

            toMeasurement ??= new DailyElectricitySummary();
            fromMeasurement ??= new DailyElectricitySummary();

            if (fromMeasurement.Id == 1)
                fromMeasurement = new DailyElectricitySummary();

            return new EnergyDto
            {
                Production = toMeasurement.EnergyProductionTotalAll - fromMeasurement.EnergyProductionTotalAll,
                Import = toMeasurement.EnergyImportTotal - fromMeasurement.EnergyImportTotal,
                Export = toMeasurement.EnergyExportTotal - fromMeasurement.EnergyExportTotal,
                Use = toMeasurement.EnergyUseTotal - fromMeasurement.EnergyUseTotal,
                Consumption = toMeasurement.EnergyConsumptionTotal - fromMeasurement.EnergyConsumptionTotal,
                Store = toMeasurement.EnergyStoreTotal - fromMeasurement.EnergyStoreTotal,
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

            toMeasurement ??= new ElectricityMeasurement();
            fromMeasurement ??= new ElectricityMeasurement();

            if (fromMeasurement.Id == 1)
                fromMeasurement = new ElectricityMeasurement();

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
