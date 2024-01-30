using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests;

public class CampaignTests
{
    [Theory]
    [InlineData("","","",false)]
    [InlineData("source","","",false)]
    [InlineData("source","medium","",false)]
    [InlineData("source","medium","name",true)]
    public void TestCampaign(string source, string medium, string name, bool expected)
    {
        var campaign = new Campaign(source, medium, name);
        Assert.Equal(expected, campaign.IsValid);
    }
}