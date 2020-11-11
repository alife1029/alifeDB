using System;
using System.Collections.Generic;
using System.Text;

namespace alifeDB.Database.Exceptions
{
    [Serializable]
    class RecordDidNotFoundException : Exception
    {
        public string dbName;
        public string tableName;
        public DatabaseCursor cursor;

        public RecordDidNotFoundException() { }
        public RecordDidNotFoundException(string message, string dbName, string tableName, DatabaseCursor cursor) : base(message)
        {
            this.dbName = dbName;
            this.tableName = tableName;
            this.cursor = cursor;
        }
        public RecordDidNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected RecordDidNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
