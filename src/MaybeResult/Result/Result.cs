using System;

namespace MaybeResult
{
    public abstract class Result
    {
        public static Result<U> Bind<T, U>(Result<T> result, Func<T, Result<U>> binder) => result.Bind(binder);

        public static Result<U> Bind<T1, T2, U>(Result<T1> result1, Result<T2> result2, Func<T1, T2, Result<U>> binder)
        {
            if (result1 is Failure<T1> failure1)
            {
                return failure1.Error;
            }

            if (result2 is Failure<T2> failure2)
            {
                return failure2.Error;
            }

            return binder.Invoke(((Success<T1>)result1).Value, ((Success<T2>)result2).Value);
        }

        public static Result<U> Bind<T1, T2, T3, U>(Result<T1> result1, Result<T2> result2, Result<T3> result3, Func<T1, T2, T3, Result<U>> binder)
        {
            if (result1 is Failure<T1> failure1)
            {
                return failure1.Error;
            }

            if (result2 is Failure<T2> failure2)
            {
                return failure2.Error;
            }

            if (result3 is Failure<T3> failure3)
            {
                return failure3.Error;
            }

            return binder.Invoke(((Success<T1>)result1).Value, ((Success<T2>)result2).Value, ((Success<T3>)result3).Value);
        }

        public static Result<U> Bind<T1, T2, T3, T4, U>(Result<T1> result1, Result<T2> result2, Result<T3> result3, Result<T4> result4, Func<T1, T2, T3, T4, Result<U>> binder)
        {
            if (result1 is Failure<T1> failure1)
            {
                return failure1.Error;
            }

            if (result2 is Failure<T2> failure2)
            {
                return failure2.Error;
            }

            if (result3 is Failure<T3> failure3)
            {
                return failure3.Error;
            }

            if (result4 is Failure<T4> failure4)
            {
                return failure4.Error;
            }

            return binder.Invoke(((Success<T1>)result1).Value, ((Success<T2>)result2).Value, ((Success<T3>)result3).Value, ((Success<T4>)result4).Value);
        }

        public static Result<U> Bind<T1, T2, T3, T4, T5, U>(Result<T1> result1, Result<T2> result2, Result<T3> result3, Result<T4> result4, Result<T5> result5, Func<T1, T2, T3, T4, T5, Result<U>> binder)
        {
            if (result1 is Failure<T1> failure1)
            {
                return failure1.Error;
            }

            if (result2 is Failure<T2> failure2)
            {
                return failure2.Error;
            }

            if (result3 is Failure<T3> failure3)
            {
                return failure3.Error;
            }

            if (result4 is Failure<T4> failure4)
            {
                return failure4.Error;
            }

            if (result5 is Failure<T5> failure5)
            {
                return failure5.Error;
            }

            return binder.Invoke(((Success<T1>)result1).Value, ((Success<T2>)result2).Value, ((Success<T3>)result3).Value, ((Success<T4>)result4).Value, ((Success<T5>)result5).Value);
        }

        public static Result<U> Map<T, U>(Result<T> result, Func<T, U> mapper) => result.Map(mapper);

        public static Result<U> Map<T1, T2, U>(Result<T1> result1, Result<T2> result2, Func<T1, T2, U> mapper)
        {
            if (result1 is Failure<T1> failure1)
            {
                return failure1.Error;
            }

            if (result2 is Failure<T2> failure2)
            {
                return failure2.Error;
            }

            return mapper.Invoke(((Success<T1>)result1).Value, ((Success<T2>)result2).Value);
        }

        public static Result<U> Map<T1, T2, T3, U>(Result<T1> result1, Result<T2> result2, Result<T3> result3, Func<T1, T2, T3, U> mapper)
        {
            if (result1 is Failure<T1> failure1)
            {
                return failure1.Error;
            }

            if (result2 is Failure<T2> failure2)
            {
                return failure2.Error;
            }

            if (result3 is Failure<T3> failure3)
            {
                return failure3.Error;
            }

            return mapper.Invoke(((Success<T1>)result1).Value, ((Success<T2>)result2).Value, ((Success<T3>)result3).Value);
        }

        public static Result<U> Map<T1, T2, T3, T4, U>(Result<T1> result1, Result<T2> result2, Result<T3> result3, Result<T4> result4, Func<T1, T2, T3, T4, U> mapper)
        {
            if (result1 is Failure<T1> failure1)
            {
                return failure1.Error;
            }

            if (result2 is Failure<T2> failure2)
            {
                return failure2.Error;
            }

            if (result3 is Failure<T3> failure3)
            {
                return failure3.Error;
            }

            if (result4 is Failure<T4> failure4)
            {
                return failure4.Error;
            }

            return mapper.Invoke(((Success<T1>)result1).Value, ((Success<T2>)result2).Value, ((Success<T3>)result3).Value, ((Success<T4>)result4).Value);
        }

        public static Result<U> Map<T1, T2, T3, T4, T5, U>(Result<T1> result1, Result<T2> result2, Result<T3> result3, Result<T4> result4, Result<T5> result5, Func<T1, T2, T3, T4, T5, U> mapper)
        {
            if (result1 is Failure<T1> failure1)
            {
                return failure1.Error;
            }

            if (result2 is Failure<T2> failure2)
            {
                return failure2.Error;
            }

            if (result3 is Failure<T3> failure3)
            {
                return failure3.Error;
            }

            if (result4 is Failure<T4> failure4)
            {
                return failure4.Error;
            }

            if (result5 is Failure<T5> failure5)
            {
                return failure5.Error;
            }

            return mapper.Invoke(((Success<T1>)result1).Value, ((Success<T2>)result2).Value, ((Success<T3>)result3).Value, ((Success<T4>)result4).Value, ((Success<T5>)result5).Value);
        }
    }
}
