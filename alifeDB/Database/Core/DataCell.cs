using System;

namespace alifeDB.Database.Core
{
    [Serializable]
    public class DataCell
    {
        private readonly Column column;
        private object data;
        
        public DataCell(Column column, object data)
        {
            this.column = column;
            this.data = data;
        }

        public void SetData(object data) => this.data = data;
        public object GetData() => data;
        public Column GetColumn() => column;
    }
}
