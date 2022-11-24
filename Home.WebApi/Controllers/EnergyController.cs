using Home.WebApi.Database;
using Home.WebApi.DTOs;
using Home.WebApi.Interfaces;
using Home.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Home.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnergyController : ControllerBase
    {

        private readonly ILogger<EnergyController> _logger;
        private readonly HomeContext _context;
        private readonly IEnergyService _energyService; 

        public EnergyController(ILogger<EnergyController> logger, HomeContext context, IEnergyService energyService)
        {
            _logger = logger;
            _context = context;
            _energyService = energyService;
        }

        [HttpGet]
        public EnergyDto Get(DateTimeOffset start, DateTimeOffset end)
        {
            return _energyService.GetEnergyData(start, end);
        }
    }
}