namespace MaybeResult;

public abstract class Maybe<T> : IEquatable<Maybe<T>>
{
    internal Maybe() { }

    public static implicit operator Maybe<T>(T value) => Some(value);

    public static bool operator ==(Maybe<T>? left, Maybe<T>? right) => left is not null && right is not null && left.Equals(right);
    public static bool operator !=(Maybe<T>? left, Maybe<T>? right) => !(left == right);

    public static Maybe<T> Some(T value) => new Some<T>(value);
    public static Maybe<T> None() => new None<T>();

    public bool IsSome => this is Some<T> ? true : false;
    public bool IsNone => this is None<T> ? true : false;

    public T? GetValueOrDefault(T defaultValue = default!) => this is Some<T> some ? some.Value : defaultValue;

    public bool Contains(T value) => this switch
    {
        Some<T> some => some.Value.Equals(value),
        None<T> => false,
        _ => throw new InvalidOperationException()
    };

    public Maybe<U> Bind<U>(Func<T, Maybe<U>> binder) => this switch
    {
        Some<T> some => binder.Invoke(some.Value),
        None<T> => Maybe<U>.None(),
        _ => throw new InvalidOperationException()
    };

    public Maybe<T> Fold(Func<T, Maybe<T>> folder) => this switch
    {
        Some<T> some => folder.Invoke(some.Value),
        None<T> => this,
        _ => throw new InvalidOperationException()
    };

    public Maybe<T> Iter(Action<T> action) => this switch
    {
        Some<T> some => new Func<Maybe<T>>(() => { action.Invoke(some.Value); return this; }).Invoke(),
        None<T> => this,
        _ => throw new InvalidOperationException()
    };

    public Maybe<U> Map<U>(Func<T, U> mapper) => this switch
    {
        Some<T> some => mapper.Invoke(some.Value),
        None<T> => Maybe<U>.None(),
        _ => throw new InvalidOperationException()
    };

    public bool Equals(Maybe<T>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != this.GetType())
        {
            return false;
        }

        if (other.IsNone)
        {
            return true;
        }

        T otherValue = ((Some<T>)other).Value;
        T value = ((Some<T>)this).Value;

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

        if (obj is not Maybe<T> maybe)
        {
            return false;
        }

        return maybe.Equals(this);
    }

    public override int GetHashCode() => this switch
    {
        Some<T> some => some.Value.GetHashCode(),
        None<T> => "None".GetHashCode() * 79,
        _ => throw new InvalidOperationException()
    };

    public override string ToString() => this switch
    {
        Some<T> some => some.Value.ToString(),
        None<T> => string.Empty,
        _ => throw new InvalidOperationException()
    };
}
