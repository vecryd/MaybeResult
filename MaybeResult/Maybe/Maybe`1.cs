namespace MaybeResult;

public abstract class Maybe<T>
{
    internal Maybe() { }

    public static implicit operator Maybe<T>(T value) => Some(value);

    public static Maybe<T> Some(T value) => new Some<T>(value);
    public static Maybe<T> None() => new None<T>();

    public T? GetValueOrDefault() => this is Some<T> some ? some.Value : default;

    public Maybe<U> Bind<U>(Func<T, Maybe<U>> binder) => this switch
    {
        Some<T> some => binder.Invoke(some.Value),
        None<T> => Maybe<U>.None(),
        _ => throw new InvalidOperationException()
    };

    public Maybe<U> Map<U>(Func<T, U> mapper) => this switch
    {
        Some<T> some => mapper.Invoke(some.Value),
        None<T> => Maybe<U>.None(),
        _ => throw new InvalidOperationException()
    };
}
