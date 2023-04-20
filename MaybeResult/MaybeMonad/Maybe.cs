namespace MaybeResult.MaybeMonad;

public abstract class Maybe<T>
{
    protected internal Maybe() { }

    public static implicit operator Maybe<T>(T value) => Success(value);

    public static Maybe<T> Success(T value) => new Success<T>(value);
    public static Maybe<T> Failure() => new Failure<T>();

    public T? GetValueOrDefault() => this is Success<T> success ? success.Value : default;

    public Maybe<TOut> Bind<TOut>(Func<T, Maybe<TOut>> func) => this switch
    {
        Failure<T> => Maybe<TOut>.Failure(),
        Success<T> success => func.Invoke(success.Value),
        _ => throw new InvalidOperationException()
    };

    public static Maybe<T> Bind<TIn>(Maybe<TIn> Maybe, Func<TIn, Maybe<T>> func) => Maybe.Bind(func);

    public static Maybe<T> Bind<TIn1, TIn2>(Maybe<TIn1> first, Maybe<TIn2> second, Func<TIn1, TIn2, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        Success<TIn1> firstSuccess = (Success<TIn1>)first;
        Success<TIn2> secondSuccess = (Success<TIn2>)second;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Func<TIn1, TIn2, TIn3, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        Success<TIn1> firstSuccess = (Success<TIn1>)first;
        Success<TIn2> secondSuccess = (Success<TIn2>)second;
        Success<TIn3> thirdSuccess = (Success<TIn3>)third;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Func<TIn1, TIn2, TIn3, TIn4, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        Success<TIn1> firstSuccess = (Success<TIn1>)first;
        Success<TIn2> secondSuccess = (Success<TIn2>)second;
        Success<TIn3> thirdSuccess = (Success<TIn3>)third;
        Success<TIn4> fourthSuccess = (Success<TIn4>)fourth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        Success<TIn1> firstSuccess = (Success<TIn1>)first;
        Success<TIn2> secondSuccess = (Success<TIn2>)second;
        Success<TIn3> thirdSuccess = (Success<TIn3>)third;
        Success<TIn4> fourthSuccess = (Success<TIn4>)fourth;
        Success<TIn5> fifthSuccess = (Success<TIn5>)fifth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        Success<TIn1> firstSuccess = (Success<TIn1>)first;
        Success<TIn2> secondSuccess = (Success<TIn2>)second;
        Success<TIn3> thirdSuccess = (Success<TIn3>)third;
        Success<TIn4> fourthSuccess = (Success<TIn4>)fourth;
        Success<TIn5> fifthSuccess = (Success<TIn5>)fifth;
        Success<TIn6> sixthSuccess = (Success<TIn6>)sixth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        if (seventh is Failure<TIn7>)
        {
            return Maybe<T>.Failure();
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

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        if (seventh is Failure<TIn7>)
        {
            return Maybe<T>.Failure();
        }

        if (eigth is Failure<TIn8>)
        {
            return Maybe<T>.Failure();
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

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        if (seventh is Failure<TIn7>)
        {
            return Maybe<T>.Failure();
        }

        if (eigth is Failure<TIn8>)
        {
            return Maybe<T>.Failure();
        }

        if (ninth is Failure<TIn9>)
        {
            return Maybe<T>.Failure();
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

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        if (seventh is Failure<TIn7>)
        {
            return Maybe<T>.Failure();
        }

        if (eigth is Failure<TIn8>)
        {
            return Maybe<T>.Failure();
        }

        if (ninth is Failure<TIn9>)
        {
            return Maybe<T>.Failure();
        }

        if (tenth is Failure<TIn10>)
        {
            return Maybe<T>.Failure();
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
        Success<TIn10> tenthSuccess = (Success<TIn10>)tenth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        if (seventh is Failure<TIn7>)
        {
            return Maybe<T>.Failure();
        }

        if (eigth is Failure<TIn8>)
        {
            return Maybe<T>.Failure();
        }

        if (ninth is Failure<TIn9>)
        {
            return Maybe<T>.Failure();
        }

        if (tenth is Failure<TIn10>)
        {
            return Maybe<T>.Failure();
        }

        if (eleventh is Failure<TIn11>)
        {
            return Maybe<T>.Failure();
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
        Success<TIn10> tenthSuccess = (Success<TIn10>)tenth;
        Success<TIn11> eleventhSuccess = (Success<TIn11>)eleventh;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Maybe<TIn12> twelfth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        if (seventh is Failure<TIn7>)
        {
            return Maybe<T>.Failure();
        }

        if (eigth is Failure<TIn8>)
        {
            return Maybe<T>.Failure();
        }

        if (ninth is Failure<TIn9>)
        {
            return Maybe<T>.Failure();
        }

        if (tenth is Failure<TIn10>)
        {
            return Maybe<T>.Failure();
        }

        if (eleventh is Failure<TIn11>)
        {
            return Maybe<T>.Failure();
        }

        if (twelfth is Failure<TIn12>)
        {
            return Maybe<T>.Failure();
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
        Success<TIn10> tenthSuccess = (Success<TIn10>)tenth;
        Success<TIn11> eleventhSuccess = (Success<TIn11>)eleventh;
        Success<TIn12> twelfthSuccess = (Success<TIn12>)twelfth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value, twelfthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Maybe<TIn12> twelfth, Maybe<TIn13> thirteenth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        if (seventh is Failure<TIn7>)
        {
            return Maybe<T>.Failure();
        }

        if (eigth is Failure<TIn8>)
        {
            return Maybe<T>.Failure();
        }

        if (ninth is Failure<TIn9>)
        {
            return Maybe<T>.Failure();
        }

        if (tenth is Failure<TIn10>)
        {
            return Maybe<T>.Failure();
        }

        if (eleventh is Failure<TIn11>)
        {
            return Maybe<T>.Failure();
        }

        if (twelfth is Failure<TIn12>)
        {
            return Maybe<T>.Failure();
        }

        if (thirteenth is Failure<TIn13>)
        {
            return Maybe<T>.Failure();
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
        Success<TIn10> tenthSuccess = (Success<TIn10>)tenth;
        Success<TIn11> eleventhSuccess = (Success<TIn11>)eleventh;
        Success<TIn12> twelfthSuccess = (Success<TIn12>)twelfth;
        Success<TIn13> thirteenthSuccess = (Success<TIn13>)thirteenth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value, twelfthSuccess.Value, thirteenthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Maybe<TIn12> twelfth, Maybe<TIn13> thirteenth, Maybe<TIn14> fourteenth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        if (seventh is Failure<TIn7>)
        {
            return Maybe<T>.Failure();
        }

        if (eigth is Failure<TIn8>)
        {
            return Maybe<T>.Failure();
        }

        if (ninth is Failure<TIn9>)
        {
            return Maybe<T>.Failure();
        }

        if (tenth is Failure<TIn10>)
        {
            return Maybe<T>.Failure();
        }

        if (eleventh is Failure<TIn11>)
        {
            return Maybe<T>.Failure();
        }

        if (twelfth is Failure<TIn12>)
        {
            return Maybe<T>.Failure();
        }

        if (thirteenth is Failure<TIn13>)
        {
            return Maybe<T>.Failure();
        }

        if (fourteenth is Failure<TIn14>)
        {
            return Maybe<T>.Failure();
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
        Success<TIn10> tenthSuccess = (Success<TIn10>)tenth;
        Success<TIn11> eleventhSuccess = (Success<TIn11>)eleventh;
        Success<TIn12> twelfthSuccess = (Success<TIn12>)twelfth;
        Success<TIn13> thirteenthSuccess = (Success<TIn13>)thirteenth;
        Success<TIn14> fourteenthSuccess = (Success<TIn14>)fourteenth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value, twelfthSuccess.Value, thirteenthSuccess.Value, fourteenthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Maybe<TIn12> twelfth, Maybe<TIn13> thirteenth, Maybe<TIn14> fourteenth, Maybe<TIn15> fifteenth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        if (seventh is Failure<TIn7>)
        {
            return Maybe<T>.Failure();
        }

        if (eigth is Failure<TIn8>)
        {
            return Maybe<T>.Failure();
        }

        if (ninth is Failure<TIn9>)
        {
            return Maybe<T>.Failure();
        }

        if (tenth is Failure<TIn10>)
        {
            return Maybe<T>.Failure();
        }

        if (eleventh is Failure<TIn11>)
        {
            return Maybe<T>.Failure();
        }

        if (twelfth is Failure<TIn12>)
        {
            return Maybe<T>.Failure();
        }

        if (thirteenth is Failure<TIn13>)
        {
            return Maybe<T>.Failure();
        }

        if (fourteenth is Failure<TIn14>)
        {
            return Maybe<T>.Failure();
        }

        if (fifteenth is Failure<TIn15>)
        {
            return Maybe<T>.Failure();
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
        Success<TIn10> tenthSuccess = (Success<TIn10>)tenth;
        Success<TIn11> eleventhSuccess = (Success<TIn11>)eleventh;
        Success<TIn12> twelfthSuccess = (Success<TIn12>)twelfth;
        Success<TIn13> thirteenthSuccess = (Success<TIn13>)thirteenth;
        Success<TIn14> fourteenthSuccess = (Success<TIn14>)fourteenth;
        Success<TIn15> fifteenthSuccess = (Success<TIn15>)fifteenth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value, twelfthSuccess.Value, thirteenthSuccess.Value, fourteenthSuccess.Value, fifteenthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Maybe<TIn12> twelfth, Maybe<TIn13> thirteenth, Maybe<TIn14> fourteenth, Maybe<TIn15> fifteenth, Maybe<TIn16> sixteenth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, Maybe<T>> func)
    {
        if (first is Failure<TIn1>)
        {
            return Maybe<T>.Failure();
        }

        if (second is Failure<TIn2>)
        {
            return Maybe<T>.Failure();
        }

        if (third is Failure<TIn3>)
        {
            return Maybe<T>.Failure();
        }

        if (fourth is Failure<TIn4>)
        {
            return Maybe<T>.Failure();
        }

        if (fifth is Failure<TIn5>)
        {
            return Maybe<T>.Failure();
        }

        if (sixth is Failure<TIn6>)
        {
            return Maybe<T>.Failure();
        }

        if (seventh is Failure<TIn7>)
        {
            return Maybe<T>.Failure();
        }

        if (eigth is Failure<TIn8>)
        {
            return Maybe<T>.Failure();
        }

        if (ninth is Failure<TIn9>)
        {
            return Maybe<T>.Failure();
        }

        if (tenth is Failure<TIn10>)
        {
            return Maybe<T>.Failure();
        }

        if (eleventh is Failure<TIn11>)
        {
            return Maybe<T>.Failure();
        }

        if (twelfth is Failure<TIn12>)
        {
            return Maybe<T>.Failure();
        }

        if (thirteenth is Failure<TIn13>)
        {
            return Maybe<T>.Failure();
        }

        if (fourteenth is Failure<TIn14>)
        {
            return Maybe<T>.Failure();
        }

        if (fifteenth is Failure<TIn15>)
        {
            return Maybe<T>.Failure();
        }

        if (sixteenth is Failure<TIn16>)
        {
            return Maybe<T>.Failure();
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
        Success<TIn10> tenthSuccess = (Success<TIn10>)tenth;
        Success<TIn11> eleventhSuccess = (Success<TIn11>)eleventh;
        Success<TIn12> twelfthSuccess = (Success<TIn12>)twelfth;
        Success<TIn13> thirteenthSuccess = (Success<TIn13>)thirteenth;
        Success<TIn14> fourteenthSuccess = (Success<TIn14>)fourteenth;
        Success<TIn15> fifteenthSuccess = (Success<TIn15>)fifteenth;
        Success<TIn16> sixteenthSuccess = (Success<TIn16>)sixteenth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value, twelfthSuccess.Value, thirteenthSuccess.Value, fourteenthSuccess.Value, fifteenthSuccess.Value, sixteenthSuccess.Value);
    }
}
