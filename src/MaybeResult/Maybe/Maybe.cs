using System;

namespace MaybeResult
{
    public abstract class Maybe
    {
        public static Maybe<U> Bind<T, U>(Maybe<T> maybe, Func<T, Maybe<U>> binder) => maybe.Bind(binder);

        public static Maybe<U> Bind<T1, T2, U>(Maybe<T1> maybe1, Maybe<T2> maybe2, Func<T1, T2, Maybe<U>> binder)
        {
            if (maybe1 is None<T1> || maybe2 is None<T2>)
            {
                return Maybe<U>.None();
            }

            return binder.Invoke(((Some<T1>)maybe1).Value, ((Some<T2>)maybe2).Value);
        }

        public static Maybe<U> Bind<T1, T2, T3, U>(Maybe<T1> maybe1, Maybe<T2> maybe2, Maybe<T3> maybe3, Func<T1, T2, T3, Maybe<U>> binder)
        {
            if (maybe1 is None<T1> || maybe2 is None<T2> || maybe3 is None<T3>)
            {
                return Maybe<U>.None();
            }

            return binder.Invoke(((Some<T1>)maybe1).Value, ((Some<T2>)maybe2).Value, ((Some<T3>)maybe3).Value);
        }

        public static Maybe<U> Bind<T1, T2, T3, T4, U>(Maybe<T1> maybe1, Maybe<T2> maybe2, Maybe<T3> maybe3, Maybe<T4> maybe4, Func<T1, T2, T3, T4, Maybe<U>> binder)
        {
            if (maybe1 is None<T1> || maybe2 is None<T2> || maybe3 is None<T3> || maybe4 is None<T4>)
            {
                return Maybe<U>.None();
            }

            return binder.Invoke(((Some<T1>)maybe1).Value, ((Some<T2>)maybe2).Value, ((Some<T3>)maybe3).Value, ((Some<T4>)maybe4).Value);
        }

        public static Maybe<U> Bind<T1, T2, T3, T4, T5, U>(Maybe<T1> maybe1, Maybe<T2> maybe2, Maybe<T3> maybe3, Maybe<T4> maybe4, Maybe<T5> maybe5, Func<T1, T2, T3, T4, T5, Maybe<U>> binder)
        {
            if (maybe1 is None<T1> || maybe2 is None<T2> || maybe3 is None<T3> || maybe4 is None<T4> || maybe5 is None<T5>)
            {
                return Maybe<U>.None();
            }

            return binder.Invoke(((Some<T1>)maybe1).Value, ((Some<T2>)maybe2).Value, ((Some<T3>)maybe3).Value, ((Some<T4>)maybe4).Value, ((Some<T5>)maybe5).Value);
        }

        public static Maybe<U> Map<T, U>(Maybe<T> maybe, Func<T, U> mapper) => maybe.Map(mapper);

        public static Maybe<U> Map<T1, T2, U>(Maybe<T1> maybe1, Maybe<T2> maybe2, Func<T1, T2, U> mapper)
        {
            if (maybe1 is None<T1> || maybe2 is None<T2>)
            {
                return Maybe<U>.None();
            }

            return mapper.Invoke(((Some<T1>)maybe1).Value, ((Some<T2>)maybe2).Value);
        }

        public static Maybe<U> Map<T1, T2, T3, U>(Maybe<T1> maybe1, Maybe<T2> maybe2, Maybe<T3> maybe3, Func<T1, T2, T3, U> mapper)
        {
            if (maybe1 is None<T1> || maybe2 is None<T2> || maybe3 is None<T3>)
            {
                return Maybe<U>.None();
            }

            return mapper.Invoke(((Some<T1>)maybe1).Value, ((Some<T2>)maybe2).Value, ((Some<T3>)maybe3).Value);
        }

        public static Maybe<U> Map<T1, T2, T3, T4, U>(Maybe<T1> maybe1, Maybe<T2> maybe2, Maybe<T3> maybe3, Maybe<T4> maybe4, Func<T1, T2, T3, T4, U> mapper)
        {
            if (maybe1 is None<T1> || maybe2 is None<T2> || maybe3 is None<T3> || maybe4 is None<T4>)
            {
                return Maybe<U>.None();
            }

            return mapper.Invoke(((Some<T1>)maybe1).Value, ((Some<T2>)maybe2).Value, ((Some<T3>)maybe3).Value, ((Some<T4>)maybe4).Value);
        }

        public static Maybe<U> Map<T1, T2, T3, T4, T5, U>(Maybe<T1> maybe1, Maybe<T2> maybe2, Maybe<T3> maybe3, Maybe<T4> maybe4, Maybe<T5> maybe5, Func<T1, T2, T3, T4, T5, U> mapper)
        {
            if (maybe1 is None<T1> || maybe2 is None<T2> || maybe3 is None<T3> || maybe4 is None<T4> || maybe5 is None<T5>)
            {
                return Maybe<U>.None();
            }

            return mapper.Invoke(((Some<T1>)maybe1).Value, ((Some<T2>)maybe2).Value, ((Some<T3>)maybe3).Value, ((Some<T4>)maybe4).Value, ((Some<T5>)maybe5).Value);
        }
    }
}
