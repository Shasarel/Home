using Home.WebApi.Dtos.Energy;
using Home.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Home.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EnergyController : ControllerBase
    {

        private readonly ILogger<EnergyController> _logger;
        private readonly IEnergyService _energyService; 

        public EnergyController(ILogger<EnergyController> logger, IEnergyService energyService)
        {
            _logger = logger;
            _energyService = energyService;
        }

        [HttpGet]
        public EnergyHistoryDto History(DateTimeOffset from, DateTimeOffset to)
        {
            return new()
            {
                Energy = _energyService.GetEnergyData(from, to),
                EnergyPrevious = _energyService.GetEnergyData(from.AddDays(-((to - from).Days + 1)), from.AddDays(-1)),
                ChartData = _energyService.GetChartData(from, to),
            };
        }

        [HttpGet]
        public async Task<PowerDto> CurrentPower()
        {
            return await _energyService.CurrentPower();
        }
    }
}