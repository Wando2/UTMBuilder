using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

public class UrlTests
{
    private readonly Url _ValidUrl = new("https://www.google.com.br/");
    private readonly Url _InvalidUrl = new("https://www.google");
    
    [Fact(DisplayName = "Should create a valid url")]
    public void ShouldCreateAValidUrl()
    {
        Assert.True(_ValidUrl.IsValid);
    }
    
    [Fact(DisplayName = "Should create a invalid url")]
    public void ShouldCreateAInvalidUrl()
    {
        Assert.False(_InvalidUrl.IsValid);
    }
    
    
}