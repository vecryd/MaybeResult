using System;

namespace MaybeResult
{
    public abstract class Maybe<T> : IEquatable<Maybe<T>>
    {
        internal Maybe() { }

        public static implicit operator Maybe<T>(T value) => Some(value);

        public static bool operator ==(Maybe<T> left, Maybe<T> right) => left != null && right != null && left.Equals(right);
        public static bool operator !=(Maybe<T> left, Maybe<T> right) => !(left == right);

        public static Maybe<T> Some(T value) => new Some<T>(value);
        public static Maybe<T> None() => new None<T>();

        public bool IsSome => this is Some<T> ? true : false;
        public bool IsNone => this is None<T> ? true : false;

        public T GetValueOrDefault(T defaultValue = default) => this is Some<T> some ? some.Value : defaultValue;

        public bool Contains(T value)
        {
            switch (this)
            {
                case Some<T> some:
                    return some.Value.Equals(value);
                case None<T> none:
                    return false;
                default:
                    throw new InvalidOperationException();
            }
        }

        public Maybe<U> Bind<U>(Func<T, Maybe<U>> binder)
        {
            switch (this)
            {
                case Some<T> some:
                    return binder.Invoke(some.Value);
                case None<T> none:
                    return Maybe<U>.None();
                default:
                    throw new InvalidOperationException();
            }
        }

        public Maybe<T> Fold(Func<T, Maybe<T>> folder)
        {
            switch (this)
            {
                case Some<T> some:
                    return folder.Invoke(some.Value);
                case None<T> none:
                    return this;
                default:
                    throw new InvalidOperationException();
            }
        }

        public Maybe<T> Iter(Action<T> action)
        {
            switch (this)
            {
                case Some<T> some:
                    return new Func<Maybe<T>>(() => { action.Invoke(some.Value); return this; }).Invoke();
                case None<T> none:
                    return this;
                default:
                    throw new InvalidOperationException();
            }
        }

        public Maybe<U> Map<U>(Func<T, U> mapper)
        {
            switch (this)
            {
                case Some<T> some:
                    return mapper.Invoke(some.Value);
                case None<T> none:
                    return Maybe<U>.None();
                default:
                    throw new InvalidOperationException();
            }
        }

        public bool Equals(Maybe<T> other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != this.GetType())
            {
                return false;
            }

            if (other.IsNone)
            {
                return true;
            }

            T otherValue = ((Some<T>)other).Value;
            T value = ((Some<T>)this).Value;

            return otherValue.Equals(value);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            switch (obj)
            {
                case Maybe<T> maybe:
                    return maybe.Equals(this);
                default:
                    return false;
            }
        }

        public override int GetHashCode()
        {
            switch (this)
            {
                case Some<T> some:
                    return some.Value.GetHashCode();
                case None<T> none:
                    return "None".GetHashCode() * 79;
                default:
                    throw new InvalidOperationException();
            }
        }

        public override string ToString()
        {
            switch (this)
            {
                case Some<T> some:
                    return some.Value.ToString();
                case None<T> none:
                    return string.Empty;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
