using ProtoBuf;

namespace alifeDB.Database.Core
{
    [ProtoContract]
    public class Column
    {
        [ProtoMember(1)]
        public bool IsPrimaryKey { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }

        public Column() 
        { 
            IsPrimaryKey = false;
            Name = "";
        }

        public Column(string columnName)
        {
            Name = columnName;
            IsPrimaryKey = false;
        }
        public Column(string columnName, bool primaryKey)
        {
            Name = columnName;
            IsPrimaryKey = primaryKey;
        }
    }
}
