using System;

namespace alifeDB.Database.Exceptions
{
    [Serializable]
    public class AlfDBException : Exception
    {
        public string dbName;
        public string tableName;

        public AlfDBException() { }
        public AlfDBException(string message, string dbName, string tableName) : base(message)
        {
            this.dbName = dbName;
            this.tableName = tableName;
        }
        public AlfDBException(string message, Exception inner) : base(message, inner) { }
        protected AlfDBException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
