# MaybeResult
C# implementation of the Maybe and Result monads for better error handling.
## How to build
The project is a class library and targets .NET 7. It can be build with Visual Studio 2022 or MSBuild command line tool like so:
```PowerShell
msbuild MaybeResult\MaybeResult.csproj /p:OutputPath=\test /p:Configuration=Release /p:Optimize=true /p:DebugSymbols=false /p:DebugType=None
```
## How to use
### Maybe
The Maybe type has two inheritors: 1) ```Some<T>``` presents some valid value, 2) ```None<T>``` means that there is no any value. The types have internal constructors to ensure that there will not be any other inherited types and thus emulate Discriminated Unions from F#.

Instances of the Maybe type can be created with the static methods ```Some(T value)``` and ```None()```. A non-nullable value must be passed to the ```Some(T value)``` method, otherwise the ```ArgumentNullException``` will be thrown.
```csharp
Maybe<string> text = Maybe<string>.Some("Hello");
// or
Maybe<string> text = Maybe<string>.None();

// ArgumentNullException
Maybe<string> text = Maybe<string>.Some(null);
```
Also there is implicit conversion of ```T``` value to ```Maybe<T>```, so the code above can be rewritten as:
```csharp
Maybe<string> text = "Hello";
```
There are four monadic functions: ```Bind```, ```Fold```, ```Iter```, and ```Map```.

The Bind function produces a new instance of the Maybe type based on the provided delegate ```Func<T, Maybe<U>>``` (T -> Maybe\<U\>) if some value is presented, otherwise returns ```None<U>```. It is used for converting an instance of the Maybe type which holds a value of one type ```T``` to the instance of the Maybe type which holds a value of different type ```U```.
```csharp
Maybe<int> number = 5;
Maybe<string> text = number.Bind(x => Maybe<string>.Some(x.ToString()));
```
The Fold function allows to change the value and pack it to another Maybe instance of the same type. The delegate ```Func<T, Maybe<T>>``` (T -> Maybe\<T\>) determines the folder function.
```csharp
Maybe<int> number = 5;
Maybe<int> newNumber = number.Fold(old => old + 2);
```
The Iter function allows to execute Action delegate ```Action<T>``` if some value is presented. Returns the instance of the Maybe type which called the function.
```csharp
Maybe<int> number = 5;
number.Iter(x => Console.WriteLine(x));
```
The Map function allows to map a Maybe instance of one type to Maybe instance of different type. It is similar to the Bind function, but differs in the delegate signature ```Func<T, U>``` (T -> U).
```csharp
Maybe<int> number = 5;
Maybe<string> text = number.Map(x => x.ToString());
```
There is also a non-generic class Maybe that holds a bunch of static Bind and Map functions for multiple parameter cases. The class is abstract and can be extended in the client application if the number of generic parameters is not enough (it is 5 by default).
```csharp
Maybe<string> name = "Mickey Mouse";
Maybe<int> age = 94;
Maybe<Character> character = Maybe.Map(name, age, (x, y) => new Character(x, y));
```
### Result
The Result type is similar to the Maybe type, but also holds an error message if the value can't be constructed. It has two inheritors: 1) ```Success<T>``` holds some valid value, 2) ```Failure<T>``` holds an error message of what went wrong.

Instances of the Result type can be created with the static methods ```Success(T value)``` and ```Failure(Error error)```. A non-nullable value must be passed to the methods, otherwise the ```ArgumentNullException``` will be thrown.
```csharp
Result<string> text = Result<string>.Success("Hello");
// or
Result<string> text = Result<string>.Failure(new Error(
    "Error.MinLengthRequirement",
    "The string must be at least 8 characters long"));

// ArgumentNullException
Result<string> text = Result<string>.Success(null);
Result<string> text = Result<string>.Failure(null);
```
Also there are implicit conversions of ```T``` and ```Error``` values to ```Result<T>```:
```csharp
Result<string> text = "Hello";
Result<string> text = new Error("Error.MinLengthRequired", "The string must be at least 8 characters long");
```
There are three monadic functions: ```Bind```, ```Fold```, ```Map``` that work exactly the same as in the Maybe type, and plus three more functions ```OnSuccess```, ```OnFailure```, ```OnBoth``` (instead of Iter) to execute some Action delegate.
```csharp
Result<string> name = "Mickey Mouse";
Result<int> age = 94;
Result<Character> character = Result.Map(name, age, (x, y) => new Character(x, y))
    .OnSuccess(c => Console.WriteLine(c.ToString()))
    .OnFailure(error => Console.WriteLine(error.ToString()))
    .OnBoth(() => Console.WriteLine("Some message whether it succeded or failed"));
```
The Error type is a record that consists of two string properties: ```Code``` and ```Message```. The Message property can be formatted with parameters if the Error instance was created in the location that differs from the returning location.
```csharp
public static class DomainErrors
{
    public static Error MinLengthRequired = new Error(
        "Error.MinLengthRequired",
        "The string '{0}' must be at least {1} characters long");
}

public static Result<Character> Create(string name, int age)
{
    ...
    // Returns "The string 'name' must be at least 8 characters long"
    return DomainErrors.MinLengthRequired.GetFormattedError(nameof(name), 8);
    ...
}
```
Besides there is the HttpError that adds the integer property StatusCode. These two error types can be inherited to construct other error types.

For more examples see the sample project [MaybeResult.Sample](https://github.com/gloriosus/MaybeResult/tree/main/MaybeResult.Sample).
