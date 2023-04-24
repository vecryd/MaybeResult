namespace MaybeResult;

public static class MaybeExtensions
{
    public static Maybe<T> OnSuccess<T>(this Maybe<T> maybe, Action action)
    {
        if (maybe is Some<T>)
        {
            action.Invoke();
        }

        return maybe;
    }

    public static Maybe<T> OnSuccess<T>(this Maybe<T> maybe, Action<T> action)
    {
        if (maybe is Some<T> some)
        {
            action.Invoke(some.Value);
        }

        return maybe;
    }

    public static Maybe<T> OnFailure<T>(this Maybe<T> maybe, Action action)
    {
        if (maybe is None<T>)
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
