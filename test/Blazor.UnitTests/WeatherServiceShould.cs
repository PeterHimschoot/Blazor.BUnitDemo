using Blazor.Services;
using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.UnitTests
{
  public class WeatherServiceShould
  {
    [Fact]
    public async Task AlwaysReturn5Forecasts()
    {
      var sut = new WeatherService();

      var actual = await sut.GetForecasts(DateTime.Now);

      actual.Count().Should().Be(5);
    }
  }
}
