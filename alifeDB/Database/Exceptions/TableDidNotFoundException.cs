using System;

namespace alifeDB.Database.Exceptions
{
    [Serializable]
    public class TableDidNotFoundException : Exception
    {
        public string dbName;
        public Cursor cursor;

        public TableDidNotFoundException() { }
        public TableDidNotFoundException(string message, string dbName, Cursor cursor) : base(message)
        {
            this.dbName = dbName;
            this.cursor = cursor;
        }
        public TableDidNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected TableDidNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
