namespace MaybeResult;

public abstract class Result<T>
{
    internal Result() { }

    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure(error);

    public static Result<T> Success(T value) => new Success<T>(value);
    public static Result<T> Failure(Error error) => new Failure<T>(error);

    public T? GetValueOrDefault() => this is Success<T> success ? success.Value : default;

    public Result<U> Bind<U>(Func<T, Result<U>> binder) => this switch
    {
        Success<T> success => binder.Invoke(success.Value),
        Failure<T> failure => failure.Error,
        _ => throw new InvalidOperationException()
    };

    public Result<U> Map<U>(Func<T, U> mapper) => this switch
    {
        Success<T> success => mapper.Invoke(success.Value),
        Failure<T> failure => failure.Error,
        _ => throw new InvalidOperationException()
    };
}
