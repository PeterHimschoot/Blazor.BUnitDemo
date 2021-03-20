using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Components.Pages
{
  public partial class TemplatedList<TItem>
  {
    IEnumerable<TItem>? items;

    [Parameter]
    [MaybeNull]
    public Func<ValueTask<IEnumerable<TItem>>> Loader { get; set; }

    [Parameter]
    [MaybeNull]
    public RenderFragment LoadingContent { get; set; }

    [Parameter]
    [MaybeNull]
    public RenderFragment EmptyContent { get; set; }

    [Parameter]
    [MaybeNull]
    public RenderFragment<TItem> ItemContent { get; set; }

    [Parameter] public string ListGroupClass { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
      if (Loader is object)
      {
        items = await Loader();
      }
    }
  }
}
