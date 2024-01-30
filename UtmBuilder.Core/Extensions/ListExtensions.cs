namespace UtmBuilder.Core.Extensions;

public static class ListExtensions
{
    public static void AddIfNotNull(this List<string> list,string key, string? item)
    {
      if (!string.IsNullOrEmpty(item))
      {
          list.Add($"{key}={item}");
      }
    }
    
}