namespace MaybeResult.MaybeMonad;

public sealed class Success<T> : Maybe<T>
{
    internal Success(T value) : base()
    {
        Value = value;
    }

    public T Value { get; }
}
