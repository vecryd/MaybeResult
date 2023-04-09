using System;
using System.Collections.Generic;
using System.Text;

namespace MaybeResult.MaybeMonad
{
    public abstract class Maybe<T>
    {
        public static Maybe<T> CreateSuccess(T value) => new Success<T>(value);
        public static Maybe<T> CreateFailure() => new Failure<T>();
    }
}
