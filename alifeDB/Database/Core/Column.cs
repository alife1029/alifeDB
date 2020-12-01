using System;

namespace alifeDB.Database.Core
{
    [Serializable]
    public struct Column
    {
        public bool IsPrimaryKey { get { return primaryKey; } }
        public string Name
        {
            get { return columnName; }
            set { columnName = value; }
        }

        private readonly bool primaryKey;
        private string columnName;

        public Column(string columnName)
        {
            this.columnName = columnName;
            this.primaryKey = false;
        }
        public Column(string columnName, bool primaryKey)
        {
            this.columnName = columnName;
            this.primaryKey = primaryKey;
        }
    }
}
