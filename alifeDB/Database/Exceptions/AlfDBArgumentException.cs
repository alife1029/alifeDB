using System;
using System.Collections.Generic;
using System.Text;

namespace alifeDB.Database.Exceptions
{
    class AlfDBArgumentException : Exception
    {
        public AlfDBArgumentException() { }
        public AlfDBArgumentException(string message) : base(message) { }
        public AlfDBArgumentException(string message, Exception inner) : base(message, inner) { }
        protected AlfDBArgumentException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
