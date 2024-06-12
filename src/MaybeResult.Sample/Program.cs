using MaybeResult;
using MaybeResult.Sample.Domain;

// The static method to bind multiple results
var result = Result.Bind(Person.Create("Mickey", "Mouse"), Markup.Create("You're the best, pal!"), Comment.Create)
// Use extension methods to execute some actions on failure, success and both ...
    .OnFailure(error => Console.WriteLine(error.Message))
    .OnSuccess(value => Console.WriteLine($"The comment with {value.Id} was successfully created at {DateTime.UtcNow}"))
    .OnBoth(() => Console.WriteLine("Some operation in the end"));

// ... or use switch statement 
string message = result switch
{
    Failure<Comment> failure => failure.Error.ToString(),
    Success<Comment> success => success.Value.ToString(),
    _ => throw new InvalidOperationException()
};

Console.WriteLine(message);

// Unpack a value from the result instance
var comment = result.GetValueOrDefault();

Console.ReadKey();