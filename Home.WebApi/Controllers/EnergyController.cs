using Home.WebApi.Dtos;
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
        public EnergyDto GetHistoryData(DateTimeOffset start, DateTimeOffset end)
        {
            return _energyService.GetEnergyData(start, end);
        }

        [HttpGet]
        public async Task<PowerDto> CurrentPower()
        {
            return await _energyService.CurrentPower();
        }
    }
}