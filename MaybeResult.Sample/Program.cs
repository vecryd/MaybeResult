using MaybeResult.ResultMonad;
using MaybeResult.ResultMonad.Extensions;

namespace MaybeResult.Sample
{
    class Program
    {
        static void Main()
        {
            var result = Result.Bind(TagName.Create("dotnet"), x => Tag.Create(x.Value))
                .OnFailure(x => Console.WriteLine(x.Error.Message))
                .OnSuccess(x => Console.WriteLine(x.Value));

            Console.ReadKey();
        }
    }
}