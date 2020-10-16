using System;

namespace alifeDB
{
    [Serializable]
    public class AlifeDBException : Exception
    {
        public AlifeDBException() { }
        public AlifeDBException(string message) : base(message) { }
        public AlifeDBException(string message, Exception inner) : base(message, inner) { }
        protected AlifeDBException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
