using Flunt.Validations;

namespace UtmBuilder.Core.ValueObjects;

public class Url : ValueObject
{
    public Url(string address)
    {
        Address = address;
        
        AddNotifications(new Contract<Url>()
            .Requires()
            .IsUrl(Address, nameof(Address), "Address is not a valid url")
        );
    }
    
    public string Address { get; }
}