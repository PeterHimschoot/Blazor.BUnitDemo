namespace Blazor.Components
{
  public record ThemeInfo(string ButtonClass);

  public class ThemeInfos
  {
    public static readonly ThemeInfo Default = new ThemeInfo("btn-primary");
    public static readonly ThemeInfo Green = new ThemeInfo("btn-success");
    public static readonly ThemeInfo Red = new ThemeInfo("btn-danger");
  }
}
