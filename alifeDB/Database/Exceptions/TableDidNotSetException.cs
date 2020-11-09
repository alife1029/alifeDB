using System;
using System.Collections.Generic;
using System.Text;

namespace alifeDB.Database.Exceptions
{
    class TableDidNotSetException : Exception
    {
        public Cursor cursor;

        public TableDidNotSetException() { }
        public TableDidNotSetException(string message, Cursor cursor) : base(message)
        {
            this.cursor = cursor;
        }
        public TableDidNotSetException(string message, Exception inner) : base(message, inner) { }
        protected TableDidNotSetException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
