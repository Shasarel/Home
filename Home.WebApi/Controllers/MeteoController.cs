using Home.WebApi.Dtos;
using Home.WebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Home.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MeteoController : ControllerBase
    {
        private readonly ILogger<EnergyController> _logger;
        private readonly IMeteoService _meteoService;

        public MeteoController(ILogger<EnergyController> logger, IMeteoService meteoService)
        {
            _logger = logger;
            _meteoService = meteoService;
        }


        public async Task<MeteoDto> Now()
        {
            return await _meteoService.GetCurrentData();
        }

        public MeteoChartDataDto History(DateTimeOffset from, DateTimeOffset to)
        {
            return _meteoService.GetMeteoChartData(from, to);
        }
    }
}
