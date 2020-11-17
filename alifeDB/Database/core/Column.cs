using System;

namespace alifeDB.Database.Core
{
    [Serializable]
    public struct Column
    {
        private readonly bool primaryKey;
        private readonly string columnName;

        public Column(string columnName)
        {
            this.columnName = columnName;
            this.primaryKey = false;
        }
        public Column(string columnName, bool primaryKey)
        {
            this.columnName = columnName;
            this.primaryKey = true;
        }

        public string GetName() => columnName;
        public bool IsPrimaryKey() => primaryKey;
    }
}
