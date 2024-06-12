namespace MaybeResult.Sample.Domain;

public record Markup
{
    protected Markup(string value)
    {
        Value = value;
    }

    public string Value { get; protected init; }

    public static Result<Markup> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return DomainErrors.ArgumentValueIsNullOrWhiteSpace.GetFormattedError(nameof(value));
        }

        return new Markup(value);
    }
}
