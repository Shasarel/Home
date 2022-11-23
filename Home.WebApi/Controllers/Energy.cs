using Home.WebApi.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
        public void Get()
        {
            var watch = new Stopwatch();
            var watch2 = new Stopwatch();
            watch.Start();
            watch2.Start();
            var c = _context.EnergyCorrection.Where(x => x.Correction > 0).ToList();
            var time3 = watch.Elapsed;
            watch.Restart();

            var a = _context.ElectricityMeasurement.Where(x => x.PowerProduction > 3900).ToList();
            var time1 = watch.Elapsed;
            watch.Restart();
            var b = _context.ElectricityMeasurement.Where(x => x.PowerImport > 1000).ToList();
            var time2 = watch.Elapsed;
            watch.Restart();

            var time5 = watch2.Elapsed;
            var abc = 1;
        }
    }
}