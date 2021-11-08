using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Titan.BL.Contracts;
using Titan.Core.DTO;

namespace Titan.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private IWeatherForecastBL weatherForecastBL;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastBL pollete)
        {
            _logger = logger;
            this.weatherForecastBL = pollete;
        }

        [HttpGet]public IEnumerable<WeatherForecast> Get()
        {
            return this.weatherForecastBL.GetPrevisionesTiempo();
        }
        

        [HttpGet]
        [Route("Saludo")]
        public string GetSaludo()
        {            
            return "Hola mundo";
        }
    }
}
