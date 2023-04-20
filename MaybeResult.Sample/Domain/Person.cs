using MaybeResult.ResultMonad;

namespace MaybeResult.Sample.Domain;

public record Person
{
    protected const int MaxLength = 32;
    protected const char Space = ' ';
    protected const string ForbiddenCharacters = "!@\"#№$;%^:&?*(),./\\=+-[]{}`~0123456789";

    protected Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; protected init; }
    public string LastName { get; protected init; }

    public static Result<Person> Create(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return DomainErrors.ArgumentValueIsNullOrWhiteSpace.GetFormattedError(nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return DomainErrors.ArgumentValueIsNullOrWhiteSpace.GetFormattedError(nameof(lastName));
        }

        if (firstName.Length > MaxLength)
        {
            return DomainErrors.ArgumentValueExceedsMaxLength.GetFormattedError(nameof(firstName), firstName.Length, MaxLength);
        }

        if (lastName.Length > MaxLength)
        {
            return DomainErrors.ArgumentValueExceedsMaxLength.GetFormattedError(nameof(lastName), lastName.Length, MaxLength);
        }

        if (firstName.Contains(Space))
        {
            return DomainErrors.ArgumentValueContainsSpace.GetFormattedError(nameof(firstName));
        }

        if (lastName.Contains(Space))
        {
            return DomainErrors.ArgumentValueContainsSpace.GetFormattedError(nameof(lastName));
        }

        int charIndex;
        if ((charIndex = ForbiddenCharacters.IndexOfAny(firstName.ToCharArray())) != -1)
        {
            return DomainErrors.ArgumentValueContainsForbiddenChars.GetFormattedError(nameof(firstName), ForbiddenCharacters[charIndex]);
        }

        if ((charIndex = ForbiddenCharacters.IndexOfAny(lastName.ToCharArray())) != -1)
        {
            return DomainErrors.ArgumentValueContainsForbiddenChars.GetFormattedError(nameof(lastName), ForbiddenCharacters[charIndex]);
        }

        return new Person(firstName, lastName);
    }
}
