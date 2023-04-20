namespace MaybeResult.MaybeMonad;

public abstract class Maybe<T>
{
    protected internal Maybe() { }

    public static implicit operator Maybe<T>(T value) => Success(value);

    public static Maybe<T> Success(T value) => new Success<T>(value);
    public static Maybe<T> Failure() => new Failure<T>();
}
