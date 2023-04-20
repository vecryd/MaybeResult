namespace MaybeResult.ResultMonad.Extensions;

public static class ResultExtensions
{
    public static Result<T> OnSuccess<T>(this Result<T> result, Action action)
    {
        if (result is Success<T>)
        {
            action.Invoke();
        }

        return result;
    }

    public static Result<T> OnSuccess<T>(this Result<T> result, Action<Success<T>> action)
    {
        if (result is Success<T> success)
        {
            action.Invoke(success);
        }

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

    public static Result<T> OnFailure<T>(this Result<T> result, Action<Failure<T>> action)
    {
        if (result is Failure<T> failure)
        {
            action.Invoke(failure);
        }

        return result;
    }

    public static Result<T> OnBoth<T>(this Result<T> result, Action action)
    {
        action.Invoke();

        return result;
    }
}
