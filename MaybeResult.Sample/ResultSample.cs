using MaybeResult.ResultMonad;

namespace MaybeResult.Sample;

public sealed record TagId(Guid Value)
{
    public static Result<TagId> Create()
    {
        return new TagId(Guid.NewGuid());
    }
}

public sealed record TagName(string Value)
{
    public static Result<TagName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return new Error("Error.StringIsNullOrWhiteSpace", "The argument value is null, empty or consists only of whitespaces");
        }

        return new TagName(value);
    }
}

public class Tag
{
    protected Tag(TagId id, TagName name)
    {
        Id = id;
        Name = name;
    }

    public TagId Id { get; protected init; }
    public TagName Name { get; set; }

    public static Result<Tag> Create(TagName name)
    {
        return Result.Bind<TagId, Tag>(TagId.Create(), success => new Tag(success.Value, name));
    }

    public override string ToString()
    {
        return $"Id: {Id.Value},\nName: {Name.Value}";
    }
}
