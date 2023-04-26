namespace MaybeResult;

public record Error(string Code, string Message)
{
    public virtual Error GetFormattedError(params object[] parameters) =>
        this with { Message = string.Format(Message, parameters) };
}
