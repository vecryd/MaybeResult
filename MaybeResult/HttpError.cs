namespace MaybeResult.ResultMonad;

public record HttpError(string Code, string Message, int StatusCode)
    : Error(Code, Message)
{
    public override HttpError GetFormattedError(params object[] parameters) =>
        this with { Message = string.Format(Message, parameters) };
}
