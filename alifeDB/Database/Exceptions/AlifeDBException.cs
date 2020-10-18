using System;

namespace alifeDB.Database.Exceptions
{
    [Serializable]
    public class AlifeDBException : Exception
    {
        public string dbName;
        public string tableName;

        public AlifeDBException() { }
        public AlifeDBException(string message, string dbName, string tableName) : base(message)
        {
            this.dbName = dbName;
            this.tableName = tableName;
        }
        public AlifeDBException(string message, Exception inner) : base(message, inner) { }
        protected AlifeDBException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
