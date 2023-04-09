using System;
using System.Collections.Generic;
using System.Text;

namespace MaybeResult.MaybeMonad
{
    public sealed class Failure<T> : Maybe<T>
    {
        internal Failure() { }
    }
}
