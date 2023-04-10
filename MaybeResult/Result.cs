namespace MaybeResult.Result
{
    public abstract class Result<T>
    {
        protected internal Result() { }

        public static implicit operator Result<T>(T value) => Success(value);

        public static Result<T> Success(T value) => new Success<T>(value);
        public static Result<T> Failure(Error error) => new Failure<T>(error);
    }

    public sealed class Success<T> : Result<T>
    {
        internal Success(T value) : base()
        {
            Value = value;
        }

        public T Value { get; }
    }

    public sealed class Failure<T> : Result<T>
    {
        internal Failure(Error error) : base()
        {
            Error = error;
        }

        public Error Error { get; }
    }
}
