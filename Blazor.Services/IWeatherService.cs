using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Services
{
  public interface IWeatherService
  {
    ValueTask<IEnumerable<WeatherForecast>> GetForecasts(DateTime date);
  }
}
