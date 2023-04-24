namespace MaybeResult;

public sealed class Some<T> : Maybe<T>
{
    internal Some(T value) : base()
    {
        Value = value;
    }

    public T Value { get; }
}
