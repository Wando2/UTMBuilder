using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

public class Utm_Tests
{
    private readonly Url url = new("https://www.google.com.br/");
    private readonly Campaign campaign = new("source", "medium", "name", "id", "term", "content");
    
    [Fact(DisplayName = "Should create a valid url string from utm")]
    public void ShouldCreateAValidUrlStringFromUtm()
    {
        var utm = new Utm(url, campaign);
        var expected = "https://www.google.com.br/?utm_source=source&utm_medium=medium&utm_campaign=name&utm_id=id&utm_term=term&utm_content=content";
        Assert.Equal(expected, utm.ToString());
       
    }
    
    [Fact(DisplayName = "Should create a valid utm from url string")]
    public void ShouldCreateAValidUtmFromUrlString()
    {
        Utm utm = "https://www.google.com.br/?utm_source=source&utm_medium=medium&utm_campaign=name&utm_id=id&utm_term=term&utm_content=content";
        Assert.Equal("https://www.google.com.br/", utm.Url.Address);
        Assert.Equal("source", utm.Campaign.Source);
        Assert.Equal("medium", utm.Campaign.Medium);
        Assert.Equal("name", utm.Campaign.Name);
        Assert.Equal("id", utm.Campaign.Id);
        Assert.Equal("term", utm.Campaign.Term);
        Assert.Equal("content", utm.Campaign.Content);
        

    }
}