using Home.WebApi.Dtos;
using Home.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Home.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IEnergyService _energyService;

        public HomeController(IEnergyService energyService)
        {
            _energyService = energyService;
        }

        public HomeDto Index()
        {
            return new HomeDto
            {
                EnergyToday = _energyService.GetEnergyData(
                    DateTime.Today, 
                    DateTime.Today.AddDays(1)),
                EnergyYesterday = _energyService.GetEnergyData
                    (DateTime.Today.AddDays(-1),
                    DateTime.Today.AddDays(-1)),
                EnergyThisYear = _energyService.GetEnergyData(
                    new DateTime(DateTime.Now.Year, 1, 1), 
                    DateTime.Today.AddDays(1)),
                EnergyLastYear = _energyService.GetEnergyData(
                    new DateTime(DateTime.Now.Year - 1, 1, 1), 
                    new DateTime(DateTime.Now.Year -1, 12, 31)),
                EnergyAll = _energyService.GetEnergyDataAll(),
                MaxEnergyStore = _energyService.GetMaxEnergyStore()
            };
        }
    }
}
