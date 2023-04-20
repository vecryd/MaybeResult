namespace MaybeResult.MaybeMonad.Extensions;

public static class MaybeExtensions
{
    public static Maybe<T> OnSuccess<T>(this Maybe<T> maybe, Action action)
    {
        if (maybe is Success<T>)
        {
            action.Invoke();
        }

        return maybe;
    }

    public static Maybe<T> OnSuccess<T>(this Maybe<T> maybe, Action<T> action)
    {
        if (maybe is Success<T> success)
        {
            action.Invoke(success.Value);
        }

        return maybe;
    }

    public static Maybe<T> OnFailure<T>(this Maybe<T> maybe, Action action)
    {
        if (maybe is Failure<T>)
        {
            action.Invoke();
        }

        return maybe;
    }

    public static Maybe<T> OnBoth<T>(this Maybe<T> maybe, Action action)
    {
        action.Invoke();

        return maybe;
    }
}
