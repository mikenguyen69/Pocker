using System;
using System.Runtime.Serialization;

namespace Poker.Core.Exceptions
{
    public class InvalidNumberOfRoundException : Exception
    {
        public InvalidNumberOfRoundException()
        {
        }

        public InvalidNumberOfRoundException(string message) : base(message)
        {
        }

        public InvalidNumberOfRoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidNumberOfRoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
