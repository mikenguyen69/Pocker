using System;
using System.Runtime.Serialization;

namespace Poker.Core.Exceptions
{
    public class InvalidSuitException : Exception
    {
        public InvalidSuitException()
        {
        }

        public InvalidSuitException(string message) : base(message)
        {
        }

        public InvalidSuitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSuitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
