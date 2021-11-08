using System;
using System.Collections.Generic;
using System.Text;
using Titan.Core.DTO;

namespace Titan.BL.Contracts
{
    public interface IWeatherForecastBL
    {
        public IEnumerable<WeatherForecast> GetPrevisionesTiempo();
    }
}
