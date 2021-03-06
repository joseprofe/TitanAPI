using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Titan.BL.Contracts;
using Titan.Core.DTO;

namespace Titan.BL.Implementations
{
    public class WeatherForecastBL : IWeatherForecastBL
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public IEnumerable<WeatherForecast> GetPrevisionesTiempo()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
