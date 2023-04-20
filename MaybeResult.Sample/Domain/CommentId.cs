using MaybeResult.ResultMonad;

namespace MaybeResult.Sample.Domain;

public readonly record struct CommentId
{
    private CommentId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public static Result<CommentId> Create()
    {
        return new CommentId(Guid.NewGuid());
    }

    public static Result<CommentId> Create(Guid value)
    {
        return new CommentId(value);
    }
}
