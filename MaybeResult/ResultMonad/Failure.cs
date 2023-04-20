namespace MaybeResult.ResultMonad;

public sealed class Failure<T> : Result<T>
{
    internal Failure(Error error) : base()
    {
        Error = error;
    }

    public Error Error { get; }
}
