namespace MaybeResult;

public sealed class Success<T> : Result<T>
{
    internal Success(T value) : base()
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value), $"An instance of type Success<{typeof(T).Name}> must be initialized with a non-nullable value");
        }

        Value = value;
    }

    public T Value { get; }
}
