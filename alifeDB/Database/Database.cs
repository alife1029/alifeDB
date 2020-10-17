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
            tables = new List<Table>();
        }

        public string GetString() => dbString;

        public void AddTable(Table table) => tables.Add(table);
        public void DeleteTable(string tableName)
        {
            foreach (Table table in tables)
                if (table.GetName() == tableName)
                {
                    tables.Remove(table);
                    return;
                }
        }
        public Table GetTable(string tableName)
        {
            foreach(Table table in tables)
            {
                if (table.GetName() == tableName)
                    return table;
            }

            return null;
        }
        public List<Table> GetTables() => tables;
    }
}
