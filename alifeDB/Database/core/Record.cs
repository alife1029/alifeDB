using System;
using System.Collections.Generic;

namespace alifeDB.Database.Core
{
    [Serializable]
    public class Record
    {
        // Kaydın kimliği
        private readonly UInt64 id;
        // Kayıt içerisindeki veriler
        private List<DataCell> values;

        public Record(Table baseTable, UInt64 id)
        {
            this.id = id;
            values = new List<DataCell>();
            List<Column> columns = baseTable.columns;

            foreach(Column c in columns)
            {
                values.Add(new DataCell(c, null));
            }
        }

        public UInt64 GetID() => id;

        public void SetAllValues(string[] columnNames, object[] values)
        {
            for (int i = 0; i < columnNames.Length; i++)
            {
                foreach (DataCell cell in this.values)
                {
                    if (cell.GetColumn().GetName() == columnNames[i])
                    {
                        cell.SetData(values[i]);
                        break;
                    }
                }
            }
        }
        public void SetValue(string column, object value)
        {
            foreach (DataCell cell in values)
                if (cell.GetColumn().GetName() == column)
                    cell.SetData(value);
        }
        public object GetValue(string columnName)
        {
            foreach (DataCell cell in values)
                if (cell.GetColumn().GetName() == columnName)
                    return cell.GetData();

            return null;
        }
    }
}
