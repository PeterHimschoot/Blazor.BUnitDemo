using Blazor.Components;
using Blazor.Components.Pages;
using Bunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.UnitTests
{
  public class CounterWithThemeShould : TestContext
  {
    [Fact]
    public void UseButtonTheme()
    {
      var cut = RenderComponent<CounterWithTheme>(parameters =>
        parameters.AddCascadingValue(ThemeInfos.Green)
        );
      cut
        .Find("button")
        .MarkupMatches(@"<button class=""btn btn-success"">Click me</button>");
    }
  }
}
