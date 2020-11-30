using System;
using System.Collections.Generic;
using System.Text;

namespace alifeDB.Database.Exceptions
{
    [Serializable]
    public class ColumnDidNotFoundException : Exception
    {
        public string dbString;
        public string tableName;
        public string columnName;
        public DatabaseCursor cursor;

        public ColumnDidNotFoundException() { }
        public ColumnDidNotFoundException(string message, string dbString, string tableName, string columnName, DatabaseCursor cursor) : base(message)
        {
            this.dbString = dbString;
            this.tableName = tableName;
            this.columnName = columnName;
            this.cursor = cursor;
        }
        public ColumnDidNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected ColumnDidNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
