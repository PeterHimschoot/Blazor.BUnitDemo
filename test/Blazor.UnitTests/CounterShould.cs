using Blazor.Components.Pages;
using Bunit;
using FluentAssertions;
using Xunit;

namespace Blazor.UnitTests
{

  // By inheriting from TestContext you get easy access to bUnit
  public class CounterShould : TestContext
  {

    [Fact]
    public void IncrementCounterWhenClickedWithFind()
    {
      var cut = RenderComponent<Counter>();

      cut.Find(cssSelector: "button").Click();

      // With find we can select (using a css-selector) any element from the component to compare
      cut.Find(cssSelector: "p")
         .OuterHtml
         .Should().Be(@"<p>Current count: 1</p>");
    }

    [Fact]
    public void IncrementCounterWhenClickedWithFindAndTextContent()
    {
      var cut = RenderComponent<Counter>();

      cut.Find(cssSelector: "button").Click();

      // With find we can select (using a css-selector) any element from the component to compare
      cut.Find(cssSelector: "p")
         .TextContent
         .Should().Be(@"Current count: 1");
    }


    [Fact]
    public void IncrementCounterWhenClickedWithMarkup()
    {
      var cut = RenderComponent<Counter>();

      cut.Find("button").Click();

      // Comparing Markup has the disadvantage that you need to be very carefull with 
      // whitespace. Simply indenting this code will break the test.

      cut.Markup.Should().Be(@"<h1>Counter</h1>

<p>Current count: 1</p>

<button class=""btn btn-primary"" blazor:onclick=""1"">Click me</button>");

      // This comparison will fail because the classes of the button are in the wrong order

      //    cut.Markup.Should().Be(@"<h1>Counter</h1>

      //<p>Current count: 1</p>

      //<button class=""btn-primary btn"" blazor:onclick=""1"">Click me</button>");
    }


    [Fact]
    public void IncrementCounterWhenClickedWithSemanticCompare()
    {
      var cut = RenderComponent<Counter>();

      cut.Find("button").Click();

      cut.MarkupMatches(@"
        <h1>Counter</h1>
        <p>Current count: 1</p>
        <button class=""btn-primary btn"">Click me</button>
      ");

      cut.MarkupMatches(@"
        <h1>Counter</h1>
        <p>Current count: 1</p>
        <button class=""btn btn-primary"">Click me</button>
      ");
    }
  }
}
