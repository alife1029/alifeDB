using System;
using System.Collections.Generic;
using System.Text;

namespace alifeDB.Database.Exceptions
{
    [Serializable]
    class RecordDidNotFoundException : Exception
    {
        public string dbString;
        public string tableName;
        public DatabaseCursor cursor;

        public RecordDidNotFoundException() { }
        public RecordDidNotFoundException(string message, string dbString, string tableName, DatabaseCursor cursor) : base(message)
        {
            this.dbString = dbString;
            this.tableName = tableName;
            this.cursor = cursor;
        }
        public RecordDidNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected RecordDidNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
