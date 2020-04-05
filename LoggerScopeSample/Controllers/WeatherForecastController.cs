using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggerScopeSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly MyService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, MyService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public string Get()
        {
            using (_logger.BeginScope("Scope:{id}", Guid.NewGuid().ToString("N")))
            {
                _logger.LogTrace("start get");
                
                var result = _service.Test();
                _logger.LogTrace("result={result}", result);
                
                _logger.LogTrace("end get");
                return result;
            }
        }
    }
}