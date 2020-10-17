using System;
using System.Collections.Generic;
using System.Text;

namespace alifeDB.Database
{
    public struct Column
    {
        private readonly string columnName;

        public Column(string columnName)
        {
            this.columnName = columnName;
        }

        public string GetName() => columnName;
    }
}
