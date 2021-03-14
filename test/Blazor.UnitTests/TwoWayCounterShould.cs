using Blazor.Components.Pages;
using Bunit;
using FluentAssertions;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.UnitTests
{
  public class TwoWayCounterShould : TestContext
  {
    [Fact]
    public void IncrementCounterWhenClicked()
    {
      var cut = RenderComponent<TwoWayCounter>(
        parameters =>
            parameters.Add(counter => counter.CurrentCount, 0)
                      .Add(counter => counter.Increment, 1)
          );

      cut.Find("button").Click();

      cut.MarkupMatches(@"
        <h1>Counter</h1>
        <p>Current count: 1</p>
        <button class=""btn btn-primary"">Click me</button>
      ");
    }

    [Theory]
    [InlineData(3)]
    [InlineData(-3)]
    public void IncrementCounterWithIncrementWhenClicked(int increment)
    {
      var cut = RenderComponent<TwoWayCounter>(
            (nameof(TwoWayCounter.CurrentCount), 0),
            (nameof(TwoWayCounter.Increment), increment)
          );

      cut.Find("button").Click();

      cut.MarkupMatches($@"
        <h1>Counter</h1>
        <p>Current count: {increment}</p>
        <button class=""btn btn-primary"">Click me</button>
      ");
    }

    [Fact]
    public void TriggerChangedEventForCurrentCounter()
    {
      int nrOfCurrentCountChanged = 0;
      int nrOfIncrementChanged = 0;

      var cut = RenderComponent<TwoWayCounter>(parameters =>
            parameters.Add(counter => counter.CurrentCount, 0)
                      .Add(counter => counter.Increment, 1)
                      .Add(counter => counter.CurrentCountChanged, () => nrOfCurrentCountChanged++)
                      .Add(counter => counter.IncrementChanged, () => nrOfIncrementChanged++)
                      );

      cut.Instance.Increment = 2;
      cut.Find("button").Click();

      nrOfCurrentCountChanged.Should().Be(1);
      nrOfIncrementChanged.Should().Be(1);
    }


  }
}
 