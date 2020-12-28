using ProtoBuf;
using System.Collections.Generic;

namespace alifeDB.Database.Core
{
    [ProtoContract]
    public class Record
    {
        // Kayıt içerisindeki veriler
        [ProtoMember(1)]
        internal List<DataCell> Values { get; set; }

        public Record(Table baseTable)
        {
            Values = new List<DataCell>();
            List<Column> columns = baseTable.Columns;

            foreach(Column c in columns)
            {
                Values.Add(new DataCell(c, null));
            }
        }

        public void SetAllValues(string[] columnNames, object[] values)
        {
            for (int i = 0; i < columnNames.Length; i++)
            {
                foreach (DataCell cell in this.Values)
                {
                    if (cell.Column.Name == columnNames[i])
                    {
                        // Eğer alan birincil anahtar değilse değeri ata
                        if (!cell.Column.IsPrimaryKey)
                        {
                            cell.Data = values[i];
                            break;
                        }

                        // Eğer alan birincil anahtarsa değeri null yap
                        cell.Data = null;
                        break;
                    }
                }
            }
        }
        public void SetValue(string column, object value)
        {
            foreach (DataCell cell in Values)
                if (cell.Column.Name == column)
                    cell.Data = value;
        }
        public object GetValue(string columnName)
        {
            foreach (DataCell cell in Values)
                if (cell.Column.Name == columnName)
                    return cell.Data;

            return null;
        }
    }
}
