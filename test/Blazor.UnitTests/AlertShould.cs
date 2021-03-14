using Blazor.Components.Pages;
using Blazor.Components.Shared;
using Bunit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Blazor.UnitTests
{
  public class AlertShould : TestContext
  {
    [Fact]
    public void HideWhenShowIsFalse()
    {
      var cut = RenderComponent<Alert>(
        parameters =>
          parameters.Add(alert => alert.Show, false)
                    .AddChildContent<SurveyPrompt>(
                       promptParameters => 
                         promptParameters.Add(prompt => prompt.Title, "Hello")
            )
        );

      cut.MarkupMatches($@"");
    }

    [Fact]
    public void ShowWhenShowIsTrue()
    {
      var cut = RenderComponent<Alert>(
        parameters =>
          parameters.Add(alert => alert.Show, true)
                    .AddChildContent<SurveyPrompt>(
                       promptParameters =>
                         promptParameters.Add(prompt => prompt.Title, "Hello")
            )
        );

      // Here we will the diff to ignore the SurveyPrompt (which has a div as root)

      cut.MarkupMatches($@"
        <div class=""alert alert-secondary mt-4"" role=""alert"">
          <div diff:ignore >
          </div>
          <button type = ""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
            <span aria-hidden=""true"">&times;</span>
          </button>
        </div>
      ");

    }
  }
}
