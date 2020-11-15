using System;
using System.Collections.Generic;
using System.Text;

namespace alifeDB.Database.Exceptions
{
    [Serializable]
    class TableDidNotSetException : Exception
    {
        public DatabaseCursor cursor;

        public TableDidNotSetException() { }
        public TableDidNotSetException(string message, DatabaseCursor cursor) : base(message)
        {
            this.cursor = cursor;
        }
        public TableDidNotSetException(string message, Exception inner) : base(message, inner) { }
        protected TableDidNotSetException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
