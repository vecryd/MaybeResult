namespace MaybeResult;

public sealed class None<T> : Maybe<T>
{
    internal None() : base() { }
}
