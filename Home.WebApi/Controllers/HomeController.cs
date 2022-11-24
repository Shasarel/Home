using Home.WebApi.DTOs;
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
                EnergyToday = _energyService.GetEnergyDataToday(),
                EnergyAll = _energyService.GetEnergyDataAll(),
            };
        }
    }
}
