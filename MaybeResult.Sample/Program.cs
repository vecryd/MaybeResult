using MaybeResult.MaybeMonad;

namespace MaybeResult.Sample
{
    class Program
    {
        static void Main()
        {
            Number number = new Number();
            var result = number.GetNumber(-6);
            
            switch (result)
            {
                case Success<int> success:
                    Console.WriteLine("The value is " + success.Value.ToString());
                    break;
                case Failure<int> failure:
                    Console.WriteLine("The provided ID is not correct");
                    break;
            }

            Console.ReadKey();
        }
    }

    public class Number
    {
        List<int> list = new List<int> { 1, 2, 3 };

        public Maybe<int> GetNumber(int id)
        {
            if (list.Count != 0 && (id >= 0 & id < list.Count))
                return Maybe<int>.CreateSuccess(list[id]);

            return Maybe<int>.CreateFailure();
        }
    }
}