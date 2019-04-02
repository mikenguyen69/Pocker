using System;
using System.Runtime.Serialization;

namespace Poker.Core.Exceptions
{
    public class InvalidNumberOfPlayerException : Exception
    {
        public InvalidNumberOfPlayerException()
        {
        }

        public InvalidNumberOfPlayerException(string message) : base(message)
        {
        }

        public InvalidNumberOfPlayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidNumberOfPlayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
