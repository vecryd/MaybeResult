using System;
using System.Collections.Generic;
using System.Text;

namespace MaybeResult.MaybeMonad
{
    public sealed class Success<T> : Maybe<T>
    {
        public T Value { get; private set; }
        internal Success(T value) => Value = value;
    }
}
