using Blazor.Components.Pages;
using Bunit;
using System;
using Xunit;

namespace Blazor.UnitTests
{

  // By inheriting from TestContext you get easy access to bUnit
  public class CounterShould : TestContext
  {
    [Fact]
    public void IncrementCounterWhenClicked()
    {
      var cut = RenderComponent<Counter>();

      cut.Find("button").Click();

      cut.MarkupMatches(@"
        <h1>Counter</h1>
        <p>Current count: 1</p>
        <button class=""btn btn-primary"">Click me</button>
      ");
    }
  }
}
