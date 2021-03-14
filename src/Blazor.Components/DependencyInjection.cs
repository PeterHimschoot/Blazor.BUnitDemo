using Blazor.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Components
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddComponents(this IServiceCollection services)
    {
      services.AddSingleton<IWeatherService, WeatherService>();
      return services;
    }
  }
}
