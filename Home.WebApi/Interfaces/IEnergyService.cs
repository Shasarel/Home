using Home.WebApi.Controllers;
using Home.WebApi.Dtos;

namespace Home.WebApi.Interfaces
{
    public interface IEnergyService
    {
        EnergyDto GetEnergyData(DateTimeOffset fromDate, DateTimeOffset toDate);
        Task<PowerDto> CurrentPower();
        double GetMaxEnergyStore();
        ElectricityChartDataDto GetChartData(DateTimeOffset from, DateTimeOffset to);
    }
}
