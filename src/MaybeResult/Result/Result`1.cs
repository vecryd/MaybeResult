using System;

namespace MaybeResult
{
    public abstract class Result<T> : IEquatable<Result<T>>
    {
        internal Result() { }

        public static implicit operator Result<T>(T value) => Success(value);
        public static implicit operator Result<T>(Error error) => Failure(error);

        public static bool operator ==(Result<T> left, Result<T> right) => left != null && right != null && left.Equals(right);
        public static bool operator !=(Result<T> left, Result<T> right) => !(left == right);

        public static Result<T> Success(T value) => new Success<T>(value);
        public static Result<T> Failure(Error error) => new Failure<T>(error);

        public bool IsSuccess => this is Success<T> ? true : false;
        public bool IsFailure => this is Failure<T> ? true : false;

        public T GetValueOrDefault(T defaultValue = default) => this is Success<T> success ? success.Value : defaultValue;

        public bool Contains(T value)
        {
            switch (this)
            {
                case Success<T> success:
                    return success.Value.Equals(value);
                case Failure<T> failure:
                    return false;
                default:
                    throw new InvalidOperationException();
            }
        }

        public Result<U> Bind<U>(Func<T, Result<U>> binder)
        {
            switch (this)
            {
                case Success<T> success:
                    return binder.Invoke(success.Value);
                case Failure<T> failure:
                    return failure.Error;
                default:
                    throw new InvalidOperationException();
            }
        }

        public Result<T> Fold(Func<T, Result<T>> folder)
        {
            switch (this)
            {
                case Success<T> success:
                    return folder.Invoke(success.Value);
                case Failure<T> failure:
                    return this;
                default:
                    throw new InvalidOperationException();
            }
        }

        public Result<U> Map<U>(Func<T, U> mapper)
        {
            switch (this)
            {
                case Success<T> success:
                    return mapper.Invoke(success.Value);
                case Failure<T> failure:
                    return failure.Error;
                default:
                    throw new InvalidOperationException();
            }
        }

        public Result<T> OnSuccess(Action<T> action)
        {
            switch (this)
            {
                case Success<T> success:
                    return new Func<Result<T>>(() => { action.Invoke(success.Value); return this; }).Invoke();
                case Failure<T> failure:
                    return this;
                default:
                    throw new InvalidOperationException();
            }
        }

        public Result<T> OnFailure(Action<Error> action)
        {
            switch (this)
            {
                case Success<T> success:
                    return this;
                case Failure<T> failure:
                    return new Func<Result<T>>(() => { action.Invoke(failure.Error); return this; }).Invoke();
                default:
                    throw new InvalidOperationException();
            }
        }

        public Result<T> OnBoth(Action action) => new Func<Result<T>>(() => { action.Invoke(); return this; }).Invoke();

        public bool Equals(Result<T> other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != this.GetType())
            {
                return false;
            }

            if (other.IsFailure)
            {
                return ((Failure<T>)other).Error.Equals(((Failure<T>)this).Error);
            }

            T otherValue = ((Success<T>)other).Value;
            T value = ((Success<T>)this).Value;

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
                case Result<T> result:
                    return result.Equals(this);
                default:
                    return false;
            }
        }

        public override int GetHashCode()
        {
            switch (this)
            {
                case Success<T> success:
                    return success.Value.GetHashCode();
                case Failure<T> failure:
                    return failure.Error.GetHashCode();
                default:
                    throw new InvalidOperationException();
            }
        }

        public Maybe<T> ToMaybe()
        {
            switch (this)
            {
                case Success<T> success:
                    return Maybe<T>.Some(success.Value);
                case Failure<T> failure:
                    return Maybe<T>.None();
                default:
                    throw new InvalidOperationException();
            }
        }

        public override string ToString()
        {
            switch (this)
            {
                case Success<T> success:
                    return success.Value.ToString();
                case Failure<T> failure:
                    return failure.Error.ToString();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
