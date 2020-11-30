using System;

namespace alifeDB.Database.Exceptions
{
    [Serializable]
    public class TableDidNotFoundException : Exception
    {
        public string dbString;
        public DatabaseCursor cursor;

        public TableDidNotFoundException() { }
        public TableDidNotFoundException(string message, string dbString, DatabaseCursor cursor) : base(message)
        {
            this.dbString = dbString;
            this.cursor = cursor;
        }
        public TableDidNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected TableDidNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
