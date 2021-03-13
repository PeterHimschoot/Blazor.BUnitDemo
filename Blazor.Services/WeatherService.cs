using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Services
{
  public class WeatherService : IWeatherService
  {
    private static readonly string[] Summaries = new[]
    {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public ValueTask<IEnumerable<WeatherForecast>> GetForecasts(DateTime date)
    {
      var rng = new Random();
      var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      });
      return new ValueTask<IEnumerable<WeatherForecast>>(forecasts);
    }
  }
}
