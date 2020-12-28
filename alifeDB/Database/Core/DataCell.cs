using ProtoBuf;

namespace alifeDB.Database.Core
{
    [ProtoContract]
    public class DataCell
    {
        [ProtoMember(1)]
        public Column Column { get; set; }

        [ProtoMember(2)]
        public object Data { get; set; }
        
        public DataCell(Column column, object data)
        {
            Column = column;
            Data = data;
        }
    }
}
