using System;

namespace MaybeResult
{
    public sealed class Some<T> : Maybe<T>
    {
        internal Some(T value) : base()
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), $"An instance of type Some<{typeof(T).Name}> must be initialized with a non-nullable value");
            }

            Value = value;
        }

        public T Value { get; }
    }
}
