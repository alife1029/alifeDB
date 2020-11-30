using System;
using System.Collections.Generic;
using System.Text;

namespace alifeDB.Database.Exceptions
{
    [Serializable]
    class TableAlreadyExistsException : Exception
    {
        public string dbString;
        public DatabaseCursor cursor;
        public string tableName;

        public TableAlreadyExistsException() { }
        public TableAlreadyExistsException(string message, string dbString, string tableName, DatabaseCursor cursor) : base(message)
        {
            this.dbString = dbString;
            this.cursor = cursor;
            this.tableName = tableName;
        }
        public TableAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
        protected TableAlreadyExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
