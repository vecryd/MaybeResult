namespace MaybeResult.ResultMonad;

public record Error(string Code, string Message)
{
    public virtual Error Bind(params object[] parameters) =>
        this with { Message = string.Format(Message, parameters) };
}
