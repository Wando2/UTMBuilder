using Flunt.Notifications;
using Flunt.Validations;
using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core;

public class Utm : Notifiable<Notification>
{
    public Utm(Url url, Campaign campaign)
    {
        Url = url;
        Campaign = campaign;
    }
    
    public Url Url { get; }
    public Campaign Campaign { get; }
    
    public static implicit operator string(Utm utm) 
        => utm.ToString();
    
    public static implicit operator Utm(string s)
    {
        var uri = new Uri(s);
        var url = new Url(uri.GetLeftPart(UriPartial.Path));
        
        if (!url.IsValid)
            throw new ArgumentException("Url is not valid");
        
        
        
        var parameters = ParseQueryString(uri.Query);
        var campaign = new Campaign(
            parameters["utm_source"],
            parameters["utm_medium"],
            parameters["utm_campaign"],
            parameters["utm_id"],
            parameters["utm_term"],
            parameters["utm_content"]
        );

        return new Utm(url, campaign);
    }
    
     
    private static Dictionary<string, string> ParseQueryString(string queryString)
    {
        var result = new Dictionary<string, string>();
        var parameters = queryString.TrimStart('?').Split('&');

        foreach (var parameter in parameters)
        {
            var parts = parameter.Split('=');
            if (parts.Length == 2)
            {
                result[parts[0]] = parts[1];
            }
        }

        return result;
    }
    
    public override string ToString()
    {
        var segments = new List<string>();
        segments.AddIfNotNull("utm_source", Campaign.Source);
        segments.AddIfNotNull("utm_medium", Campaign.Medium);
        segments.AddIfNotNull("utm_campaign", Campaign.Name);
        segments.AddIfNotNull("utm_id", Campaign.Id);
        segments.AddIfNotNull("utm_term", Campaign.Term);
        segments.AddIfNotNull("utm_content", Campaign.Content);
        return $"{Url.Address}?{string.Join("&", segments)}";

        
    }
}