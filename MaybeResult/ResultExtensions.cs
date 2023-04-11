using System;

namespace MaybeResult.Result.Extensions
{
    public static class ResultExtensions
    {
        public static Result<T> OnSuccess<T>(this Result<T> result, Func<Result<T>> func)
        {
            if (result is Failure<T> failure)
            {
                return failure;
            }

            return func.Invoke();
        }

        public static Result<T> OnSuccess<T>(this Result<T> result, Func<T, Result<T>> func)
        {
            if (result is Failure<T> failure)
            {
                return failure;
            }

            Success<T> success = (Success<T>)result;

            return func.Invoke(success.Value);
        }

        public static Result<T> OnSuccess<T>(this Result<T> result, Action action)
        {
            if (result is Failure<T> failure)
            {
                return failure;
            }

            action.Invoke();

            return result;
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Action action)
        {
            if (result is Failure<T>)
            {
                action.Invoke();
            }

            return result;
        }

        public static Result<T> OnBoth<T>(this Result<T> result, Func<Result<T>> func)
        {
            return func.Invoke();
        }

        public static Result<T> OnBoth<T>(this Result<T> result, Action action)
        {
            action.Invoke();

            return result;
        }
    }
}
