using System.Collections.Generic;

namespace alifeDB.Database
{
    public class Record
    {
        private List<DataCell> values;

        public Record(Table baseTable)
        {
            List<Column> columns = baseTable.columns;

            foreach(Column c in columns)
                values.Add(new DataCell(c, null));
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
