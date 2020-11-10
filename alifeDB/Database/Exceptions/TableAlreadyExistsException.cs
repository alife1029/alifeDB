using System;
using System.Collections.Generic;
using System.Text;

namespace alifeDB.Database.Exceptions
{
    class TableAlreadyExistsException : Exception
    {
        public string dbName;
        public Cursor cursor;
        public string tableName;

        public TableAlreadyExistsException() { }
        public TableAlreadyExistsException(string message, string dbName, string tableName, Cursor cursor) : base(message)
        {
            this.dbName = dbName;
            this.cursor = cursor;
            this.tableName = tableName;
        }
        public TableAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
        protected TableAlreadyExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
