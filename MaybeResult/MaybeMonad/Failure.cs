namespace MaybeResult.MaybeMonad;

public sealed class Failure<T> : Maybe<T>
{
    internal Failure() : base() { }
}
