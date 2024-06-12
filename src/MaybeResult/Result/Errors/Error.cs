namespace MaybeResult
{
    public class Error
    {
        public string Code { get; }
        public string Message { get; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public virtual Error GetFormattedError(params object[] parameters)
        {
            return new Error(this.Code, string.Format(this.Message, parameters));
        }

        public bool Equals(Error other)
        {
            if (other is null)
            {
                return false;
            }

            return other.Code == this.Code;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != typeof(Error))
            {
                return false;
            }

            return ((Error)obj).Equals(this);
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode() * 79;
        }
    }
}
