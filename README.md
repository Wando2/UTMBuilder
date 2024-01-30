# UtmBuilder.Core

UtmBuilder.Core is a C# library designed to facilitate the creation and management of UTM (Urchin Tracking Module) parameters. It provides a set of classes and methods to handle UTM parameters in a structured and validated way.

## Key Components

- `Utm`: The main class that represents a UTM parameter set. It provides functionality to convert between a `Utm` object and a string.

- `Url`: A class that represents a URL and validates its format.

- `Campaign`: A class that represents a campaign, storing and validating its properties such as source, medium, name, ID, term, and content.

- `ListExtensions`: A static class that provides an extension method `AddIfNotNull` for adding a key-value pair to a list if the value is not null.

## Testing

The project includes unit tests for the `Campaign` class in the `CampaignTests` class.

## Dependencies

The project uses the `Flunt.Validations` library for property validation in the `Url` and `Campaign` classes.