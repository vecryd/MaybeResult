namespace MaybeResult
{
    public class HttpError : Error
    {
        public int StatusCode { get; }

        public HttpError(string code, string message, int statusCode) : base(code, message)
        {
            StatusCode = statusCode;
        }

        public override Error GetFormattedError(params object[] parameters)
        {
            return new HttpError(this.Code, string.Format(this.Message, parameters), this.StatusCode);
        }
    }
}
