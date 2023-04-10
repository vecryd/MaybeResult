using System;

namespace MaybeResult.Result
{
    public class Error : IEquatable<Error>
    {
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }
        public string Message { get; }

        public static bool operator ==(Error first, Error second)
        {
            return first != null && second != null && first.Equals(second);
        }

        public static bool operator !=(Error first, Error second)
        {
            return !(first == second);
        }

        public bool Equals(Error other)
        {
            if (other == null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }

            return other.Code == Code && other.Message == Message;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            Error error = obj as Error;
            if (error == null)
            {
                return false;
            }

            return error.Code == Code && error.Message == Message;
        }

        public override int GetHashCode()
        {
            return (Code, Message).GetHashCode() * 79;
        }
    }
}
