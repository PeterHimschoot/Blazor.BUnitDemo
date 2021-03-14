using Blazor.Components.Pages;
using Blazor.Services;
using Blazor.UnitTests.Helpers;
using Bunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace Blazor.UnitTests
{
  public class FetchDataShould : TestContext
  {
    [Fact]
    public void UseWeatherService()
    {
      // Use Services for dependency injection
      Services.AddSingleton<IWeatherService, WeatherService>();
      var cut = RenderComponent<FetchData>();
      // Use the instance to access the component's instance
      cut.Instance.Forecasts.Should().NotBeNull()
                            .And.HaveCount(5);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public void ShowCorrectNumberOfForecasts(int nrOfForecasts)
    {
      var mock = new ForecastMockFactory()
        .GenerateMockForecastServiceWithNrOfElements(count: nrOfForecasts);

      Services.AddSingleton<IWeatherService>(mock.Object);

      var cut = RenderComponent<FetchData>();

      cut.FindAll(cssSelector: "tbody tr")
         .Count.Should().Be(nrOfForecasts);
    }

    [Fact]
    public async Task ShowCorrectForecastInformation()
    {
      var data = new (string summary, int temp)[]
      {
        ("Warm", 27),
        ("Freezing", -6),
        ("Cold", 0)
      };
      var mock = new ForecastMockFactory().GenerateMockForecastServiceWith(data);
      Services.AddSingleton<IWeatherService>(mock.Object);

      var cut = RenderComponent<FetchData>();

      var rows = cut.FindAll("tbody tr");
      int i = 0;
      foreach(var row in rows)
      {
        (string summary, int temp) = data[i];
        row.MarkupMatches($@"
        <tr>
          <td diff:ignore></td>
          <td>{temp}</td>
          <td diff:ignore></td>
          <td>{summary}</td>
        </tr>
        ");
        i += 1;
      }
    }
  }
}
