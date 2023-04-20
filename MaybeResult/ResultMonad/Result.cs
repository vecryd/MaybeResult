namespace MaybeResult.ResultMonad;

public abstract class Result<T>
{
    protected internal Result() { }

    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure(error);

    public static Result<T> Success(T value) => new Success<T>(value);
    public static Result<T> Failure(Error error) => new Failure<T>(error);

    public T? GetValueOrDefault() => this is Success<T> success ? success.Value : default;

    public Result<TOut> Bind<TOut>(Func<T, Result<TOut>> func) => this switch
    {
        Failure<T> failure => failure.Error,
        Success<T> success => func.Invoke(success.Value),
        _ => throw new InvalidOperationException()
    };

    public static Result<T> Bind<TIn>(Result<TIn> result, Func<TIn, Result<T>> func) => result.Bind(func);

    public static Result<T> Bind<TIn1, TIn2>(Result<TIn1> first, Result<TIn2> second, Func<TIn1, TIn2, Result<T>> func)
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

        return func.Invoke(firstSuccess.Value, secondSuccess.Value);
    }

    public static Result<T> Bind<TIn1, TIn2, TIn3>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Func<TIn1, TIn2, TIn3, Result<T>> func)
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

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value);
    }

    public static Result<T> Bind<TIn1, TIn2, TIn3, TIn4>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Func<TIn1, TIn2, TIn3, TIn4, Result<T>> func)
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

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value);
    }

    public static Result<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Result<TIn5> fifth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, Result<T>> func)
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

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value);
    }

    public static Result<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Result<TIn5> fifth, Result<TIn6> sixth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, Result<T>> func)
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

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value);
    }

    public static Result<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Result<TIn5> fifth, Result<TIn6> sixth, Result<TIn7> seventh, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, Result<T>> func)
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

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value);
    }

    public static Result<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Result<TIn5> fifth, Result<TIn6> sixth, Result<TIn7> seventh, Result<TIn8> eigth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, Result<T>> func)
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

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value);
    }

    public static Result<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>(Result<TIn1> first, Result<TIn2> second, Result<TIn3> third, Result<TIn4> fourth, Result<TIn5> fifth, Result<TIn6> sixth, Result<TIn7> seventh, Result<TIn8> eigth, Result<TIn9> ninth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, Result<T>> func)
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

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value);
    }
}
