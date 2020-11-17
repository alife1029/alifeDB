using System;
using System.Collections.Generic;
using System.Text;

namespace alifeDB.Database.Exceptions
{
    [Serializable]
    class AlifeDBArgumentException : Exception
    {
        public AlifeDBArgumentException() { }
        public AlifeDBArgumentException(string message) : base(message) { }
        public AlifeDBArgumentException(string message, Exception inner) : base(message, inner) { }
        protected AlifeDBArgumentException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
