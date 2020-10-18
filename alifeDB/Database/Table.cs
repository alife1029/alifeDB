using System;
using System.Collections.Generic;

namespace alifeDB.Database
{
    [Serializable]
    public class Table
    {
        private readonly string tableName;
        internal List<Column> columns;
        private List<Record> records;

        public Table(string tableName)
        {
            this.tableName = tableName;
            columns = new List<Column>();
            records = new List<Record>();
        }

        public void AddColumn(string columnName) => columns.Add(new Column(columnName));
        public void AddRecord(Record record) => records.Add(record);

        public string GetName() => tableName;
    }
}
