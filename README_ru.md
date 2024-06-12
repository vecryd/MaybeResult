# MaybeResult
Реализация Maybe и Result монад на языке программирования C# для более лучшей обработки ошибок.
## Построение проекта
Проект является библиотекой классов, созданной на базе .NET Standard 2.0. Построить проект из исходников можно запустив скрипты "build.ps1" на Windows или "build.sh" на Linux. В папке "artifacts" содержатся уже скомпилированные бинарные файлы.
## Использование
### Maybe
Тип Maybe имеет двух наследников: 1) тип ```Some<T>```, представляющий некоторое действительное значение, и 2) тип ```None<T>```, представляющий отсутствие какого-либо значения. Данные типы имеют конструктор с модификатором internal, чтобы убедиться, что всегда будут только два наследника. Это позволяет эмулировать работу размеченных объединений (Discriminated Unions) из функциональных языков программирования вроде F#.

Экземпляры типа Maybe могут быть созданы с помощью статических методов ```Some(T value)``` и ```None()```. Метод ```Some(T value)``` принимает только значения не равные ```null```, иначе будет выброшено ```ArgumentNullException``` исключение.
```csharp
Maybe<string> text = Maybe<string>.Some("Hello");
// или
Maybe<string> text = Maybe<string>.None();

// ArgumentNullException
Maybe<string> text = Maybe<string>.Some(null);
```
Также имеется неявное приведение значения ```T``` к типу ```Maybe<T>```, так что вместо вызова статического метода ```Some(T value)``` можно передавать непосредственно само значение:
```csharp
Maybe<string> text = "Hello";
```
Всего реализовано четыре монадических функций: ```Bind```, ```Fold```, ```Iter``` и ```Map```.

Функция Bind возвращает новый экземпляр типа Maybe в соответствии с предоставленным в качестве аргумента делегатом ```Func<T, Maybe<U>>``` (T -> Maybe\<U\>) в случае наличия некоторого значения ```Some<T>```, иначе возвращается ```None<U>```. Данная функция используется для конвертирования экземпляра типа Maybe, содержащего значение типа ```T```, в экземпляр типа Maybe, содержащий значение другого типа ```U```.
```csharp
Maybe<int> number = 5;
Maybe<string> text = number.Bind(x => Maybe<string>.Some(x.ToString()));
```
Функция Fold изменяет значение, содержащееся в экземпляре типа Maybe, в соответствии с предоставленным в качестве аргумента делегатом ```Func<T, Maybe<T>>``` (T -> Maybe\<T\>) и возвращает новый экземпляр типа Maybe с измененным значением.
```csharp
Maybe<int> number = 5;
Maybe<int> newNumber = number.Fold(old => old + 2);
```
Функция Iter исполняет метод, определяемый делегатом ```Action<T>```, если имеется какое-либо значение и возвращает экземпляр типа Maybe, который вызвал данную функцию.
```csharp
Maybe<int> number = 5;
number.Iter(x => Console.WriteLine(x));
```
Функция Map соотносит экземпляр типа Maybe, содержащий значение типа ```T```, к экземпляру типа Maybe, содержащему значение другого типа ```U```. Эта функция схожа с функцией Bind, но отличается сигнатура делегата, передаваемого в качестве аргумента, ```Func<T, U>``` (T -> U).
```csharp
Maybe<int> number = 5;
Maybe<string> text = number.Map(x => x.ToString());
```
Также имеется не шаблонизированный класс Maybe, который содержит в себе набор статических функций Bind и Map для использования в случаях со множеством передаваемых параметров. Класс является абстрактным и может быть унаследован и расширен дополнительными перегрузками функций Bind и Map для использования с большим количеством шаблонных параметров (по-умолчанию до 5).
```csharp
Maybe<string> name = "Mickey Mouse";
Maybe<int> age = 94;
Maybe<Character> character = Maybe.Map(name, age, (x, y) => new Character(x, y));
```
### Result
Тип Result схож с типом Maybe, но в дополнение может содержать в себе сообщение об ошибке в случаях невозможности инициализации значения, например, если значение не соответствует установленным бизнес-правилам. Тип имеет двух наследников: 1) тип ```Success<T>```, представляющий некоторое действительное значение, и 2) тип ```Failure<T>```, представляющий сообщение об ошибке.

Экземпляры типа Result могут быть созданы с помощью статических методов ```Success(T value)``` и ```Failure(Error error)```. Данные методы принимают только значения не равные ```null```, иначе будет выброшено ```ArgumentNullException``` исключение.
```csharp
Result<string> text = Result<string>.Success("Hello");
// или
Result<string> text = Result<string>.Failure(new Error(
    "Error.MinLengthRequirement",
    "Строка должна состоять из по крайней мере 8 символов"));

// ArgumentNullException
Result<string> text = Result<string>.Success(null);
Result<string> text = Result<string>.Failure(null);
```
Также имеется неявное приведение типов ```T``` и ```Error``` к типу ```Result<T>```:
```csharp
Result<string> text = "Hello";
Result<string> text = new Error("Error.MinLengthRequired", "Строка должна состоять из по крайней мере 8 символов");
```
Здесь реализованы три основные монадические функции ```Bind```, ```Fold```, ```Map```, которые работают точно также, как и для типа Maybe, а также три дополнительные функции ```OnSuccess```, ```OnFailure```, ```OnBoth``` вместо функции ```Iter```.
```csharp
Result<string> name = "Mickey Mouse";
Result<int> age = 94;
Result<Character> character = Result.Map(name, age, (x, y) => new Character(x, y))
    .OnSuccess(c => Console.WriteLine(c.ToString()))
    .OnFailure(error => Console.WriteLine(error.ToString()))
    .OnBoth(() => Console.WriteLine("Сообщение, которое появится вне зависимости от успеха или провала"));
```
Тип Error является классом с двумя неизменяемыми свойствами типа string: ```Code``` и ```Message```. Свойство Message может быть отформатировано с параметрами если экземпляр типа Error был создан в другом месте программы отличным от места его возврата.
```csharp
public static class DomainErrors
{
    public static Error MinLengthRequired = new Error(
        "Error.MinLengthRequired",
        "Строка '{0}' должна состоять из по крайней мере {1} символов");
}

public static Result<Character> Create(string name, int age)
{
    ...
    // Возвращает "Строка 'name' должна состоять из по крайней мере 8 символов"
    return DomainErrors.MinLengthRequired.GetFormattedError(nameof(name), 8);
    ...
}
```
Кроме того, имеется дополнительный тип HttpError, который добавляет целочисленное свойство StatusCode. От данных типов можно наследоваться, чтобы реализовать собственные типы ошибок.

Больше примеров можно увидеть в тестовом проекте MaybeResult.Sample:
- https://github.com/gloriosus/MaybeResult/tree/main/MaybeResult.Sample
- https://gitverse.ru/vecryd/MaybeResult/content/main/MaybeResult.Sample
