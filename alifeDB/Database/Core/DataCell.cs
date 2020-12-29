using ProtoBuf;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace alifeDB.Database.Core
{
    [ProtoContract]
    public class DataCell
    {
        [ProtoMember(1)]
        public Column Column { get; set; }

        [ProtoMember(2)]
        public byte[] Data { get; set; }
        
        public DataCell() 
        { 
            Column = new Column();
            Data = new byte[0];
        }

        public DataCell(Column column, object data)
        {
            Column = column;

            SetData(data);
        }

        public void SetData(object data)
        {
            if (data == null)
                return;

            // System.Object türünden gelen data nesnesini byte dizisine dönüştürür
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                Console.WriteLine("System.Object, byte[] dönüştürülüyor...");
                bf.Serialize(ms, data);
                Console.WriteLine("System.Object, byte[] dönüştürüldü!");
                Data = ms.ToArray();
                Console.WriteLine("Data ToArray() edildi!");
            }
        }

        public T GetData<T>()
        {
            if (Data == null)
                return default;
            
            T data;

            // Byte dizisi olan datayı istenilen türe dönüştürüp döndürür
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(Data))
            {
                data = (T) bf.Deserialize(ms);
            }

            return data;
        }
    }
}
