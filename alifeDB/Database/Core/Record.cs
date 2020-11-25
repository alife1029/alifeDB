﻿using System;
using System.Collections.Generic;

namespace alifeDB.Database.Core
{
    [Serializable]
    public class Record
    {
        // Kayıt içerisindeki veriler
        internal List<DataCell> values;

        public Record(Table baseTable)
        {
            values = new List<DataCell>();
            List<Column> columns = baseTable.columns;

            foreach(Column c in columns)
            {
                values.Add(new DataCell(c, null));
            }
        }

        public void SetAllValues(string[] columnNames, object[] values)
        {
            for (int i = 0; i < columnNames.Length; i++)
            {
                foreach (DataCell cell in this.values)
                {
                    if (cell.GetColumn().GetName() == columnNames[i])
                    {
                        // Eğer alan birincil anahtar değilse değeri ata
                        if (!cell.GetColumn().IsPrimaryKey())
                        {
                            cell.SetData(values[i]);
                            break;
                        }

                        // Eğer alan birincil anahtarsa değeri null yap
                        cell.SetData(null);
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