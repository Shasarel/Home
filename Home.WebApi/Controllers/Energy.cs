using Microsoft.AspNetCore.Mvc;

namespace Home.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Energy : ControllerBase
    {

        private readonly ILogger<Energy> _logger;
        private readonly HomeContext _context;

        public Energy(ILogger<Energy> logger, HomeContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public int Get()
        {
            var a = _context.ElectricityMeasurement.Where(x => x.PowerProduction > 3500).ToList();
            return 1;
        }
    }
}