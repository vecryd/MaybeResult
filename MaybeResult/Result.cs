using System;

namespace MaybeResult.ResultMonad
{
    public abstract class Result<T>
    {
        protected internal Result() { }

        public static implicit operator Result<T>(T value) => Success(value);
        public static implicit operator Result<T>(Error error) => Failure(error);

        public static Result<T> Success(T value) => new Success<T>(value);
        public static Result<T> Failure(Error error) => new Failure<T>(error);
    }

    public sealed class Success<T> : Result<T>
    {
        internal Success(T value) : base()
        {
            Value = value;
        }

        public T Value { get; }
    }

    public sealed class Failure<T> : Result<T>
    {
        internal Failure(Error error) : base()
        {
            Error = error;
        }

        public Error Error { get; }
    }

    public static class Result
    {
        public static Result<TOut> Bind<TIn, TOut>(Result<TIn> result, Func<Success<TIn>, Result<TOut>> func)
        {
            if (result is Failure<TIn> failure)
            {
                return failure.Error;
            }

            Success<TIn> success = (Success<TIn>)result;

            return func.Invoke(success);
        }

        public static Result<TOut> Bind<TIn1, TIn2, TOut>(Result<TIn1> first, Result<TIn2> second, Func<Success<TIn1>, Success<TIn2>, Result<TOut>> func)
        {
            if (first is Failure<TIn1> firstFailure)
            {
                return firstFailure.Error;
            }

            if (second is Failure<TIn2> secondFailure)
            {
                return secondFailure.Error;
            }

            Success<TIn1> firstSuccess = (Success<TIn1>)first;
            Success<TIn2> secondSuccess = (Success<TIn2>)second;

            return func.Invoke(firstSuccess, secondSuccess);
        }

        public static Result<TOut> Bind<TIn1, TIn2, TIn3, TOut>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Func<Success<TIn1>, Success<TIn2>, Success<TIn3>, Result<TOut>> func)
        {
            if (first is Failure<TIn1> firstFailure)
            {
                return firstFailure.Error;
            }

            if (second is Failure<TIn2> secondFailure)
            {
                return secondFailure.Error;
            }

            if (third is Failure<TIn3> thirdFailure)
            {
                return thirdFailure.Error;
            }

            Success<TIn1> firstSuccess = (Success<TIn1>)first;
            Success<TIn2> secondSuccess = (Success<TIn2>)second;
            Success<TIn3> thirdSuccess = (Success<TIn3>)third;

            return func.Invoke(firstSuccess, secondSuccess, thirdSuccess);
        }

        public static Result<TOut> Bind<TIn1, TIn2, TIn3, TIn4, TOut>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Func<Success<TIn1>, Success<TIn2>, Success<TIn3>, Success<TIn4>, Result<TOut>> func)
        {
            if (first is Failure<TIn1> firstFailure)
            {
                return firstFailure.Error;
            }

            if (second is Failure<TIn2> secondFailure)
            {
                return secondFailure.Error;
            }

            if (third is Failure<TIn3> thirdFailure)
            {
                return thirdFailure.Error;
            }

            if (fourth is Failure<TIn4> fourthFailure)
            {
                return fourthFailure.Error;
            }

            Success<TIn1> firstSuccess = (Success<TIn1>)first;
            Success<TIn2> secondSuccess = (Success<TIn2>)second;
            Success<TIn3> thirdSuccess = (Success<TIn3>)third;
            Success<TIn4> fourthSuccess = (Success<TIn4>)fourth;

            return func.Invoke(firstSuccess, secondSuccess, thirdSuccess, fourthSuccess);
        }

        public static Result<TOut> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TOut>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Result<TIn5> fifth, Func<Success<TIn1>, Success<TIn2>, Success<TIn3>, Success<TIn4>, Success<TIn5>, Result<TOut>> func)
        {
            if (first is Failure<TIn1> firstFailure)
            {
                return firstFailure.Error;
            }

            if (second is Failure<TIn2> secondFailure)
            {
                return secondFailure.Error;
            }

            if (third is Failure<TIn3> thirdFailure)
            {
                return thirdFailure.Error;
            }

            if (fourth is Failure<TIn4> fourthFailure)
            {
                return fourthFailure.Error;
            }

            if (fifth is Failure<TIn5> fifthFailure)
            {
                return fifthFailure.Error;
            }

            Success<TIn1> firstSuccess = (Success<TIn1>)first;
            Success<TIn2> secondSuccess = (Success<TIn2>)second;
            Success<TIn3> thirdSuccess = (Success<TIn3>)third;
            Success<TIn4> fourthSuccess = (Success<TIn4>)fourth;
            Success<TIn5> fifthSuccess = (Success<TIn5>)fifth;

            return func.Invoke(firstSuccess, secondSuccess, thirdSuccess, fourthSuccess, fifthSuccess);
        }

        public static Result<TOut> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TOut>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Result<TIn5> fifth, Result<TIn6> sixth, Func<Success<TIn1>, Success<TIn2>, Success<TIn3>, Success<TIn4>, Success<TIn5>, Success<TIn6>, Result<TOut>> func)
        {
            if (first is Failure<TIn1> firstFailure)
            {
                return firstFailure.Error;
            }

            if (second is Failure<TIn2> secondFailure)
            {
                return secondFailure.Error;
            }

            if (third is Failure<TIn3> thirdFailure)
            {
                return thirdFailure.Error;
            }

            if (fourth is Failure<TIn4> fourthFailure)
            {
                return fourthFailure.Error;
            }

            if (fifth is Failure<TIn5> fifthFailure)
            {
                return fifthFailure.Error;
            }

            if (sixth is Failure<TIn6> sixthFailure)
            {
                return sixthFailure.Error;
            }

            Success<TIn1> firstSuccess = (Success<TIn1>)first;
            Success<TIn2> secondSuccess = (Success<TIn2>)second;
            Success<TIn3> thirdSuccess = (Success<TIn3>)third;
            Success<TIn4> fourthSuccess = (Success<TIn4>)fourth;
            Success<TIn5> fifthSuccess = (Success<TIn5>)fifth;
            Success<TIn6> sixthSuccess = (Success<TIn6>)sixth;

            return func.Invoke(firstSuccess, secondSuccess, thirdSuccess, fourthSuccess, fifthSuccess, sixthSuccess);
        }

        public static Result<TOut> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TOut>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Result<TIn5> fifth, Result<TIn6> sixth, Result<TIn7> seventh, Func<Success<TIn1>, Success<TIn2>, Success<TIn3>, Success<TIn4>, Success<TIn5>, Success<TIn6>, Success<TIn7>, Result<TOut>> func)
        {
            if (first is Failure<TIn1> firstFailure)
            {
                return firstFailure.Error;
            }

            if (second is Failure<TIn2> secondFailure)
            {
                return secondFailure.Error;
            }

            if (third is Failure<TIn3> thirdFailure)
            {
                return thirdFailure.Error;
            }

            if (fourth is Failure<TIn4> fourthFailure)
            {
                return fourthFailure.Error;
            }

            if (fifth is Failure<TIn5> fifthFailure)
            {
                return fifthFailure.Error;
            }

            if (sixth is Failure<TIn6> sixthFailure)
            {
                return sixthFailure.Error;
            }

            if (seventh is Failure<TIn7> seventhFailure)
            {
                return seventhFailure.Error;
            }

            Success<TIn1> firstSuccess = (Success<TIn1>)first;
            Success<TIn2> secondSuccess = (Success<TIn2>)second;
            Success<TIn3> thirdSuccess = (Success<TIn3>)third;
            Success<TIn4> fourthSuccess = (Success<TIn4>)fourth;
            Success<TIn5> fifthSuccess = (Success<TIn5>)fifth;
            Success<TIn6> sixthSuccess = (Success<TIn6>)sixth;
            Success<TIn7> seventhSuccess = (Success<TIn7>)seventh;

            return func.Invoke(firstSuccess, secondSuccess, thirdSuccess, fourthSuccess, fifthSuccess, sixthSuccess, seventhSuccess);
        }

        public static Result<TOut> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TOut>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Result<TIn5> fifth, Result<TIn6> sixth, Result<TIn7> seventh, Result<TIn8> eigth, Func<Success<TIn1>, Success<TIn2>, Success<TIn3>, Success<TIn4>, Success<TIn5>, Success<TIn6>, Success<TIn7>, Success<TIn8>, Result<TOut>> func)
        {
            if (first is Failure<TIn1> firstFailure)
            {
                return firstFailure.Error;
            }

            if (second is Failure<TIn2> secondFailure)
            {
                return secondFailure.Error;
            }

            if (third is Failure<TIn3> thirdFailure)
            {
                return thirdFailure.Error;
            }

            if (fourth is Failure<TIn4> fourthFailure)
            {
                return fourthFailure.Error;
            }

            if (fifth is Failure<TIn5> fifthFailure)
            {
                return fifthFailure.Error;
            }

            if (sixth is Failure<TIn6> sixthFailure)
            {
                return sixthFailure.Error;
            }

            if (seventh is Failure<TIn7> seventhFailure)
            {
                return seventhFailure.Error;
            }

            if (eigth is Failure<TIn8> eigthFailure)
            {
                return eigthFailure.Error;
            }

            Success<TIn1> firstSuccess = (Success<TIn1>)first;
            Success<TIn2> secondSuccess = (Success<TIn2>)second;
            Success<TIn3> thirdSuccess = (Success<TIn3>)third;
            Success<TIn4> fourthSuccess = (Success<TIn4>)fourth;
            Success<TIn5> fifthSuccess = (Success<TIn5>)fifth;
            Success<TIn6> sixthSuccess = (Success<TIn6>)sixth;
            Success<TIn7> seventhSuccess = (Success<TIn7>)seventh;
            Success<TIn8> eigthSuccess = (Success<TIn8>)eigth;

            return func.Invoke(firstSuccess, secondSuccess, thirdSuccess, fourthSuccess, fifthSuccess, sixthSuccess, seventhSuccess, eigthSuccess);
        }

        public static Result<TOut> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TOut>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Result<TIn5> fifth, Result<TIn6> sixth, Result<TIn7> seventh, Result<TIn8> eigth, Result<TIn9> ninth, Func<Success<TIn1>, Success<TIn2>, Success<TIn3>, Success<TIn4>, Success<TIn5>, Success<TIn6>, Success<TIn7>, Success<TIn8>, Success<TIn9>, Result<TOut>> func)
        {
            if (first is Failure<TIn1> firstFailure)
            {
                return firstFailure.Error;
            }

            if (second is Failure<TIn2> secondFailure)
            {
                return secondFailure.Error;
            }

            if (third is Failure<TIn3> thirdFailure)
            {
                return thirdFailure.Error;
            }

            if (fourth is Failure<TIn4> fourthFailure)
            {
                return fourthFailure.Error;
            }

            if (fifth is Failure<TIn5> fifthFailure)
            {
                return fifthFailure.Error;
            }

            if (sixth is Failure<TIn6> sixthFailure)
            {
                return sixthFailure.Error;
            }

            if (seventh is Failure<TIn7> seventhFailure)
            {
                return seventhFailure.Error;
            }

            if (eigth is Failure<TIn8> eigthFailure)
            {
                return eigthFailure.Error;
            }

            if (ninth is Failure<TIn9> ninthFailure)
            {
                return ninthFailure.Error;
            }

            Success<TIn1> firstSuccess = (Success<TIn1>)first;
            Success<TIn2> secondSuccess = (Success<TIn2>)second;
            Success<TIn3> thirdSuccess = (Success<TIn3>)third;
            Success<TIn4> fourthSuccess = (Success<TIn4>)fourth;
            Success<TIn5> fifthSuccess = (Success<TIn5>)fifth;
            Success<TIn6> sixthSuccess = (Success<TIn6>)sixth;
            Success<TIn7> seventhSuccess = (Success<TIn7>)seventh;
            Success<TIn8> eigthSuccess = (Success<TIn8>)eigth;
            Success<TIn9> ninthSuccess = (Success<TIn9>)ninth;

            return func.Invoke(firstSuccess, secondSuccess, thirdSuccess, fourthSuccess, fifthSuccess, sixthSuccess, seventhSuccess, eigthSuccess, ninthSuccess);
        }
    }
}
