using Home.WebApi.Controllers;
using Home.WebApi.DTOs;

namespace Home.WebApi.Interfaces
{
    public interface IEnergyService
    {
        EnergyDto GetEnergyData(DateTimeOffset fromDate, DateTimeOffset toDate);
    }
}
