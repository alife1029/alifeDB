using System;
using System.Collections.Generic;

namespace alifeDB.Database
{
    [Serializable]
    public class Database
    {
        internal string dbString;
        internal List<Table> tables;

        public Database(string dbString)
        {
            this.dbString = dbString;
            tables = null;
        }

        public string GetString() { return dbString; }

        public Table GetTable(string tableName)
        {
            foreach(Table table in tables)
            {
                if (table.GetName() == tableName)
                    return table;
            }

            return null;
        }
    }
}
