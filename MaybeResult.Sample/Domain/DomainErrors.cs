using MaybeResult.ResultMonad;

namespace MaybeResult.Sample.Domain;

public static class DomainErrors
{
    /// <summary>
    /// The value of the argument '{0}' is null, empty or consists only of whitespaces
    /// </summary>
    public static Error ArgumentValueIsNullOrWhiteSpace = new Error("Error.ArgumentValueIsNullOrWhiteSpace", "The value of the argument '{0}' is null, empty or consists only of whitespaces");

    /// <summary>
    /// The value of the argument '{0}' has length of {1}, but must be no more than {2}
    /// </summary>
    public static Error ArgumentValueExceedsMaxLength = new Error("Error.ArgumentValueExceedsMaxLength", "The value of the argument '{0}' has length of {1}, but must be no more than {2}");

    /// <summary>
    /// The value of the argument '{0}' contains space characters
    /// </summary>
    public static Error ArgumentValueContainsSpace = new Error("Error.ArgumentValueContainsSpace", "The value of the argument '{0}' contains space characters");

    /// <summary>
    /// The value of the argument '{0}' contains the following forbidden character: '{1}'
    /// </summary>
    public static Error ArgumentValueContainsForbiddenChars = new Error("Error.ArgumentValueContainsForbiddenChars", "The value of the argument '{0}' contains the following forbidden character: '{1}'");
}
