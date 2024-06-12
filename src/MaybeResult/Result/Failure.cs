using System;

namespace MaybeResult
{
    public sealed class Failure<T> : Result<T>
    {
        internal Failure(Error error) : base()
        {
            if (error is null)
            {
                throw new ArgumentNullException(nameof(error), $"An instance of type Failure<{typeof(T).Name}> must be initialized with a non-nullable value");
            }

            Error = error;
        }

        public Error Error { get; }
    }
}
