using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Pocker.Core.Exceptions
{
    public class InvalidNumberOfCardException : Exception
    {
        public InvalidNumberOfCardException()
        {
        }

        public InvalidNumberOfCardException(string message) : base(message)
        {
        }

        public InvalidNumberOfCardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidNumberOfCardException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
