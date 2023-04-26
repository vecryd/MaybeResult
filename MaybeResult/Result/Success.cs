namespace MaybeResult;

public sealed class Success<T> : Result<T>
{
    internal Success(T value) : base()
    {
        Value = value;
    }

    public T Value { get; }
}
