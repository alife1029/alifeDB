using System;

namespace alifeDB.Database
{
    [Serializable]
    public class Database
    {
        private string dbString;

        public Database(string dbString)
        {
            this.dbString = dbString;
        }

        public string GetString() { return dbString; }
    }
}
