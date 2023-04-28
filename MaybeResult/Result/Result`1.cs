namespace MaybeResult;

public abstract class Result<T> : IEquatable<Result<T>>
{
    internal Result() { }

    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure(error);

    public static bool operator ==(Result<T>? left, Result<T>? right) => left is not null && right is not null && left.Equals(right);
    public static bool operator !=(Result<T>? left, Result<T>? right) => !(left == right);

    public static Result<T> Success(T value) => new Success<T>(value);
    public static Result<T> Failure(Error error) => new Failure<T>(error);

    public bool IsSuccess => this is Success<T> ? true : false;
    public bool IsFailure => this is Failure<T> ? true : false;

    public T? GetValueOrDefault(T defaultValue = default!) => this is Success<T> success ? success.Value : defaultValue;

    public bool Contains(T value) => this switch
    {
        Success<T> success => success.Value.Equals(value),
        Failure<T> => false,
        _ => throw new InvalidOperationException()
    };

    public Result<U> Bind<U>(Func<T, Result<U>> binder) => this switch
    {
        Success<T> success => binder.Invoke(success.Value),
        Failure<T> failure => failure.Error,
        _ => throw new InvalidOperationException()
    };

    public Result<T> Fold(Func<T, Result<T>> folder) => this switch
    {
        Success<T> success => folder.Invoke(success.Value),
        Failure<T> => this,
        _ => throw new InvalidOperationException()
    };

    public Result<U> Map<U>(Func<T, U> mapper) => this switch
    {
        Success<T> success => mapper.Invoke(success.Value),
        Failure<T> failure => failure.Error,
        _ => throw new InvalidOperationException()
    };

    public Result<T> OnSuccess(Action<T> action) => this switch
    {
        Success<T> success => new Func<Result<T>>(() => { action.Invoke(success.Value); return this; }).Invoke(),
        Failure<T> => this,
        _ => throw new InvalidOperationException()
    };

    public Result<T> OnFailure(Action<Error> action) => this switch
    {
        Success<T> => this,
        Failure<T> failure => new Func<Result<T>>(() => { action.Invoke(failure.Error); return this; }).Invoke(),
        _ => throw new InvalidOperationException()
    };

    public Result<T> OnBoth(Action action) => new Func<Result<T>>(() => { action.Invoke(); return this; }).Invoke();

    public bool Equals(Result<T>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != this.GetType())
        {
            return false;
        }

        if (other.IsFailure)
        {
            return ((Failure<T>)other).Error.Equals(((Failure<T>)this).Error);
        }

        T otherValue = ((Success<T>)other).Value;
        T value = ((Success<T>)this).Value;

        return otherValue.Equals(value);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != this.GetType())
        {
            return false;
        }

        if (obj is not Result<T> result)
        {
            return false;
        }

        return result.Equals(this);
    }

    public override int GetHashCode() => this switch
    {
        Success<T> success => success.Value.GetHashCode(),
        Failure<T> failure => failure.Error.GetHashCode(),
        _ => throw new InvalidOperationException()
    };

    public Maybe<T> ToMaybe() => this switch
    {
        Success<T> success => Maybe<T>.Some(success.Value),
        Failure<T> => Maybe<T>.None(),
        _ => throw new InvalidOperationException()
    };

    public override string ToString() => this switch
    {
        Success<T> success => success.Value.ToString(),
        Failure<T> failure => failure.Error.ToString(),
        _ => throw new InvalidOperationException()
    };
}
