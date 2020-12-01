using System;

namespace alifeDB.Database.Core
{
    [Serializable]
    public class DataCell
    {
        public Column Column { get { return column; } }
        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        private readonly Column column;
        private object data;
        
        public DataCell(Column column, object data)
        {
            this.column = column;
            this.data = data;
        }
    }
}
