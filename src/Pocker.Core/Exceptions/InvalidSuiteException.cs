using System;
using System.Runtime.Serialization;

namespace Pocker.Core.Exceptions
{
    public class InvalidSuiteException : Exception
    {
        public InvalidSuiteException()
        {
        }

        public InvalidSuiteException(string message) : base(message)
        {
        }

        public InvalidSuiteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSuiteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
