namespace MaybeResult;

public abstract class Maybe<T>
{
    internal Maybe() { }

    public static implicit operator Maybe<T>(T value) => Some(value);

    public static Maybe<T> Some(T value) => new Some<T>(value);
    public static Maybe<T> None() => new None<T>();

    public T? GetValueOrDefault() => this is Some<T> some ? some.Value : default;

    public Maybe<TOut> Bind<TOut>(Func<T, Maybe<TOut>> func) => this switch
    {
        None<T> => Maybe<TOut>.None(),
        Some<T> some => func.Invoke(some.Value),
        _ => throw new InvalidOperationException()
    };

    public static Maybe<T> Bind<TIn>(Maybe<TIn> Maybe, Func<TIn, Maybe<T>> func) => Maybe.Bind(func);

    public static Maybe<T> Bind<TIn1, TIn2>(Maybe<TIn1> first, Maybe<TIn2> second, Func<TIn1, TIn2, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Func<TIn1, TIn2, TIn3, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Func<TIn1, TIn2, TIn3, TIn4, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        if (seventh is None<TIn7>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;
        Some<TIn7> seventhSuccess = (Some<TIn7>)seventh;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        if (seventh is None<TIn7>)
        {
            return Maybe<T>.None();
        }

        if (eigth is None<TIn8>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;
        Some<TIn7> seventhSuccess = (Some<TIn7>)seventh;
        Some<TIn8> eigthSuccess = (Some<TIn8>)eigth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        if (seventh is None<TIn7>)
        {
            return Maybe<T>.None();
        }

        if (eigth is None<TIn8>)
        {
            return Maybe<T>.None();
        }

        if (ninth is None<TIn9>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;
        Some<TIn7> seventhSuccess = (Some<TIn7>)seventh;
        Some<TIn8> eigthSuccess = (Some<TIn8>)eigth;
        Some<TIn9> ninthSuccess = (Some<TIn9>)ninth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        if (seventh is None<TIn7>)
        {
            return Maybe<T>.None();
        }

        if (eigth is None<TIn8>)
        {
            return Maybe<T>.None();
        }

        if (ninth is None<TIn9>)
        {
            return Maybe<T>.None();
        }

        if (tenth is None<TIn10>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;
        Some<TIn7> seventhSuccess = (Some<TIn7>)seventh;
        Some<TIn8> eigthSuccess = (Some<TIn8>)eigth;
        Some<TIn9> ninthSuccess = (Some<TIn9>)ninth;
        Some<TIn10> tenthSuccess = (Some<TIn10>)tenth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        if (seventh is None<TIn7>)
        {
            return Maybe<T>.None();
        }

        if (eigth is None<TIn8>)
        {
            return Maybe<T>.None();
        }

        if (ninth is None<TIn9>)
        {
            return Maybe<T>.None();
        }

        if (tenth is None<TIn10>)
        {
            return Maybe<T>.None();
        }

        if (eleventh is None<TIn11>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;
        Some<TIn7> seventhSuccess = (Some<TIn7>)seventh;
        Some<TIn8> eigthSuccess = (Some<TIn8>)eigth;
        Some<TIn9> ninthSuccess = (Some<TIn9>)ninth;
        Some<TIn10> tenthSuccess = (Some<TIn10>)tenth;
        Some<TIn11> eleventhSuccess = (Some<TIn11>)eleventh;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Maybe<TIn12> twelfth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        if (seventh is None<TIn7>)
        {
            return Maybe<T>.None();
        }

        if (eigth is None<TIn8>)
        {
            return Maybe<T>.None();
        }

        if (ninth is None<TIn9>)
        {
            return Maybe<T>.None();
        }

        if (tenth is None<TIn10>)
        {
            return Maybe<T>.None();
        }

        if (eleventh is None<TIn11>)
        {
            return Maybe<T>.None();
        }

        if (twelfth is None<TIn12>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;
        Some<TIn7> seventhSuccess = (Some<TIn7>)seventh;
        Some<TIn8> eigthSuccess = (Some<TIn8>)eigth;
        Some<TIn9> ninthSuccess = (Some<TIn9>)ninth;
        Some<TIn10> tenthSuccess = (Some<TIn10>)tenth;
        Some<TIn11> eleventhSuccess = (Some<TIn11>)eleventh;
        Some<TIn12> twelfthSuccess = (Some<TIn12>)twelfth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value, twelfthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Maybe<TIn12> twelfth, Maybe<TIn13> thirteenth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        if (seventh is None<TIn7>)
        {
            return Maybe<T>.None();
        }

        if (eigth is None<TIn8>)
        {
            return Maybe<T>.None();
        }

        if (ninth is None<TIn9>)
        {
            return Maybe<T>.None();
        }

        if (tenth is None<TIn10>)
        {
            return Maybe<T>.None();
        }

        if (eleventh is None<TIn11>)
        {
            return Maybe<T>.None();
        }

        if (twelfth is None<TIn12>)
        {
            return Maybe<T>.None();
        }

        if (thirteenth is None<TIn13>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;
        Some<TIn7> seventhSuccess = (Some<TIn7>)seventh;
        Some<TIn8> eigthSuccess = (Some<TIn8>)eigth;
        Some<TIn9> ninthSuccess = (Some<TIn9>)ninth;
        Some<TIn10> tenthSuccess = (Some<TIn10>)tenth;
        Some<TIn11> eleventhSuccess = (Some<TIn11>)eleventh;
        Some<TIn12> twelfthSuccess = (Some<TIn12>)twelfth;
        Some<TIn13> thirteenthSuccess = (Some<TIn13>)thirteenth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value, twelfthSuccess.Value, thirteenthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Maybe<TIn12> twelfth, Maybe<TIn13> thirteenth, Maybe<TIn14> fourteenth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        if (seventh is None<TIn7>)
        {
            return Maybe<T>.None();
        }

        if (eigth is None<TIn8>)
        {
            return Maybe<T>.None();
        }

        if (ninth is None<TIn9>)
        {
            return Maybe<T>.None();
        }

        if (tenth is None<TIn10>)
        {
            return Maybe<T>.None();
        }

        if (eleventh is None<TIn11>)
        {
            return Maybe<T>.None();
        }

        if (twelfth is None<TIn12>)
        {
            return Maybe<T>.None();
        }

        if (thirteenth is None<TIn13>)
        {
            return Maybe<T>.None();
        }

        if (fourteenth is None<TIn14>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;
        Some<TIn7> seventhSuccess = (Some<TIn7>)seventh;
        Some<TIn8> eigthSuccess = (Some<TIn8>)eigth;
        Some<TIn9> ninthSuccess = (Some<TIn9>)ninth;
        Some<TIn10> tenthSuccess = (Some<TIn10>)tenth;
        Some<TIn11> eleventhSuccess = (Some<TIn11>)eleventh;
        Some<TIn12> twelfthSuccess = (Some<TIn12>)twelfth;
        Some<TIn13> thirteenthSuccess = (Some<TIn13>)thirteenth;
        Some<TIn14> fourteenthSuccess = (Some<TIn14>)fourteenth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value, twelfthSuccess.Value, thirteenthSuccess.Value, fourteenthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Maybe<TIn12> twelfth, Maybe<TIn13> thirteenth, Maybe<TIn14> fourteenth, Maybe<TIn15> fifteenth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        if (seventh is None<TIn7>)
        {
            return Maybe<T>.None();
        }

        if (eigth is None<TIn8>)
        {
            return Maybe<T>.None();
        }

        if (ninth is None<TIn9>)
        {
            return Maybe<T>.None();
        }

        if (tenth is None<TIn10>)
        {
            return Maybe<T>.None();
        }

        if (eleventh is None<TIn11>)
        {
            return Maybe<T>.None();
        }

        if (twelfth is None<TIn12>)
        {
            return Maybe<T>.None();
        }

        if (thirteenth is None<TIn13>)
        {
            return Maybe<T>.None();
        }

        if (fourteenth is None<TIn14>)
        {
            return Maybe<T>.None();
        }

        if (fifteenth is None<TIn15>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;
        Some<TIn7> seventhSuccess = (Some<TIn7>)seventh;
        Some<TIn8> eigthSuccess = (Some<TIn8>)eigth;
        Some<TIn9> ninthSuccess = (Some<TIn9>)ninth;
        Some<TIn10> tenthSuccess = (Some<TIn10>)tenth;
        Some<TIn11> eleventhSuccess = (Some<TIn11>)eleventh;
        Some<TIn12> twelfthSuccess = (Some<TIn12>)twelfth;
        Some<TIn13> thirteenthSuccess = (Some<TIn13>)thirteenth;
        Some<TIn14> fourteenthSuccess = (Some<TIn14>)fourteenth;
        Some<TIn15> fifteenthSuccess = (Some<TIn15>)fifteenth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value, twelfthSuccess.Value, thirteenthSuccess.Value, fourteenthSuccess.Value, fifteenthSuccess.Value);
    }

    public static Maybe<T> Bind<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16>(Maybe<TIn1> first, Maybe<TIn2> second, Maybe<TIn3> third, Maybe<TIn4> fourth, Maybe<TIn5> fifth, Maybe<TIn6> sixth, Maybe<TIn7> seventh, Maybe<TIn8> eigth, Maybe<TIn9> ninth, Maybe<TIn10> tenth, Maybe<TIn11> eleventh, Maybe<TIn12> twelfth, Maybe<TIn13> thirteenth, Maybe<TIn14> fourteenth, Maybe<TIn15> fifteenth, Maybe<TIn16> sixteenth, Func<TIn1, TIn2, TIn3, TIn4, TIn5, TIn6, TIn7, TIn8, TIn9, TIn10, TIn11, TIn12, TIn13, TIn14, TIn15, TIn16, Maybe<T>> func)
    {
        if (first is None<TIn1>)
        {
            return Maybe<T>.None();
        }

        if (second is None<TIn2>)
        {
            return Maybe<T>.None();
        }

        if (third is None<TIn3>)
        {
            return Maybe<T>.None();
        }

        if (fourth is None<TIn4>)
        {
            return Maybe<T>.None();
        }

        if (fifth is None<TIn5>)
        {
            return Maybe<T>.None();
        }

        if (sixth is None<TIn6>)
        {
            return Maybe<T>.None();
        }

        if (seventh is None<TIn7>)
        {
            return Maybe<T>.None();
        }

        if (eigth is None<TIn8>)
        {
            return Maybe<T>.None();
        }

        if (ninth is None<TIn9>)
        {
            return Maybe<T>.None();
        }

        if (tenth is None<TIn10>)
        {
            return Maybe<T>.None();
        }

        if (eleventh is None<TIn11>)
        {
            return Maybe<T>.None();
        }

        if (twelfth is None<TIn12>)
        {
            return Maybe<T>.None();
        }

        if (thirteenth is None<TIn13>)
        {
            return Maybe<T>.None();
        }

        if (fourteenth is None<TIn14>)
        {
            return Maybe<T>.None();
        }

        if (fifteenth is None<TIn15>)
        {
            return Maybe<T>.None();
        }

        if (sixteenth is None<TIn16>)
        {
            return Maybe<T>.None();
        }

        Some<TIn1> firstSuccess = (Some<TIn1>)first;
        Some<TIn2> secondSuccess = (Some<TIn2>)second;
        Some<TIn3> thirdSuccess = (Some<TIn3>)third;
        Some<TIn4> fourthSuccess = (Some<TIn4>)fourth;
        Some<TIn5> fifthSuccess = (Some<TIn5>)fifth;
        Some<TIn6> sixthSuccess = (Some<TIn6>)sixth;
        Some<TIn7> seventhSuccess = (Some<TIn7>)seventh;
        Some<TIn8> eigthSuccess = (Some<TIn8>)eigth;
        Some<TIn9> ninthSuccess = (Some<TIn9>)ninth;
        Some<TIn10> tenthSuccess = (Some<TIn10>)tenth;
        Some<TIn11> eleventhSuccess = (Some<TIn11>)eleventh;
        Some<TIn12> twelfthSuccess = (Some<TIn12>)twelfth;
        Some<TIn13> thirteenthSuccess = (Some<TIn13>)thirteenth;
        Some<TIn14> fourteenthSuccess = (Some<TIn14>)fourteenth;
        Some<TIn15> fifteenthSuccess = (Some<TIn15>)fifteenth;
        Some<TIn16> sixteenthSuccess = (Some<TIn16>)sixteenth;

        return func.Invoke(firstSuccess.Value, secondSuccess.Value, thirdSuccess.Value, fourthSuccess.Value, fifthSuccess.Value, sixthSuccess.Value, seventhSuccess.Value, eigthSuccess.Value, ninthSuccess.Value, tenthSuccess.Value, eleventhSuccess.Value, twelfthSuccess.Value, thirteenthSuccess.Value, fourteenthSuccess.Value, fifteenthSuccess.Value, sixteenthSuccess.Value);
    }
}
