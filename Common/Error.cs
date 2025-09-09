namespace homepageV2.Common;

public record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "A null value was provided.");
}

public record NotFoundError(string Code, string Description) : Error(Code, Description);