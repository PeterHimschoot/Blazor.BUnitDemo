using Blazor.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.UnitTests.Helpers
{
  class ForecastMockFactory
  {
    public Mock<IWeatherService> GenerateMockForecastServiceWith(params (string summary, int temp)[] data)
    {
      var forecasts = this.ForecastsWith(data);
      return MockFor(forecasts);
    }

    public Mock<IWeatherService> GenerateMockForecastServiceWithNrOfElements(int count)
    {
      var forecasts = this.Forecasts(count);
      return MockFor(forecasts);
    }

    private Mock<IWeatherService> MockFor(ValueTask<IEnumerable<WeatherForecast>> forecasts)
    {
      var mock = new Mock<IWeatherService>();
      mock.Setup(ws => ws.GetForecasts(It.IsAny<DateTime>()))
          .Returns(forecasts);
      return mock;
    }

    public IEnumerable<WeatherForecast> GenerateForecastsWith(params (string summary, int temp)[] data)
    {
      DateTime date = DateTime.Now;
      foreach ((string summary, int temp) in data)
      {
        yield return new WeatherForecast
        {
          Date = date,
          Summary = summary,
          TemperatureC = temp
        };
        date = date.AddDays(1);
      }
    }

    private ValueTask<IEnumerable<WeatherForecast>> ForecastsWith(params (string summary, int temp)[] data)
    {
      var forecasts = GenerateForecastsWith(data);
      return new ValueTask<IEnumerable<WeatherForecast>>(forecasts);
    }

    private ValueTask<IEnumerable<WeatherForecast>> Forecasts(int count)
    {
      (string summary, int temp)[] data =
        Enumerable.Repeat(("Warm", 27), count).ToArray();
      return ForecastsWith(data);
    }
  }
}
