using Flunt.Validations;

namespace UtmBuilder.Core.ValueObjects;

public class Campaign : ValueObject
{
    public Campaign( string source, string medium, string name, string? id = null, string? term = null, string? content = null)
    {
        Source = source;
        Medium = medium;
        Name = name;
        Id = id;
        Term = term;
        Content = content;
        
        AddNotifications(new Contract<Campaign>()
            .Requires()
            .IsNotNullOrEmpty(Source, nameof(Source), "Source is required")
            .IsNotNullOrEmpty(Medium, nameof(Medium), "Medium is required")
            .IsNotNullOrEmpty(Name, nameof(Name), "Name is required")
        );
    }

    
    public string Source { get; }
    public string Medium { get; }
    public string Name { get; }
    public string? Id  { get; }
    public string? Term { get; }
    public string? Content { get; }
    
}