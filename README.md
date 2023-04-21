# MaybeResult
C# implementation of the Maybe and Result monads for better error handling.
## How to build
The project is a class library and targets .NET 7. It can be build with Visual Studio 2022 or MSBuild command line tool like so:
```PowerShell
msbuild MaybeResult\MaybeResult.csproj /p:OutputPath=\test /p:Configuration=Release /p:Optimize=true /p:DebugSymbols=false /p:DebugType=None
```
## How to use
1. Create entities or value objects with methods that returns the Result or Maybe type:
```csharp
public record TagName
{
    protected TagName(string value)
    {
        Value = value;
    }
    
    public string Value { get; protected init; }
    
    public static Result<TagName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            // Implicit conversion from the Error type to the Failure<TagName> type
            return new Error("Error.ArgumentValueIsNullOrWhiteSpace",
                "The value of the argument is null, empty or consists only of whitespaces");
        }
        
        // Implicit conversion from the TagName type to the Success<TagName> type
        return new TagName(value);
    }
}
```
2. The Result or Maybe type can be processed in different ways:
```csharp
// 1) with switch statement
var result = TagName.Create("dotnet");

switch (result)
{
    case Failure<TagName> failure:
        Console.WriteLine(failure.Error);
        break;
    case Success<TagName> success:
        Console.WriteLine(success.Value);
        break;
    default:
        throw new InvalidOperationException();
}

// 2) with conditional statement
if (result is Failure<TagName> failure)
{
    Console.WriteLine(failure.Error);
}

if (result is Success<TagName> success)
{
    Console.WriteLine(success.Value);
}

// 3) or with extension methods
TagName.Create("dotnet")
    .OnFailure(failure => Console.WriteLine(failure.Error))
    .OnSuccess(success => Console.WriteLine(success.Value))
    .OnBoth(() => Console.WriteLine("Action on both"));
```
3. Also results can be binded together with the instance and static Bind methods:
```csharp
TagName.Create("dotnet").Bind(name => Tag.Create(name));
// or
Result<Tag>.Bind(TagName.Create("dotnet"), name => Tag.Create(name));
```
