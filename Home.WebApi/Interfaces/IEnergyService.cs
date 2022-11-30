using Home.WebApi.Controllers;
using Home.WebApi.Dtos;

namespace Home.WebApi.Interfaces
{
    public interface IEnergyService
    {
        EnergyDto GetEnergyData(DateTimeOffset fromDate, DateTimeOffset toDate);
        EnergyDto GetEnergyDataToday();
        EnergyDto GetEnergyDataAll();
        Task<PowerDto> CurrentPower();
    }
}
