using alifeDB.Database.Exceptions;
using System.Collections.Generic;
using ProtoBuf;

namespace alifeDB.Database.Core
{
    [ProtoContract]
    public class Table
    {
        // Tablonun adı
        [ProtoMember(1)]
        public string Name { get; set; }

        // Tabloda birincil anahtar var mı
        [ProtoMember(2)]
        internal bool IsPrimaryKeyExists { get; set; }

        // Tablonun bulunduğu veritabanının yolu
        [ProtoMember(3)]
        private string ParentDbString { get; set; }

        // Tablo içerisindeki sütunlar
        [ProtoMember(4)]        
        internal List<Column> Columns { get; set; }

        // Tabloda bulunan kayıtlar
        [ProtoMember(5)]
        internal List<Record> Records { get; set; }


        [ProtoIgnore]
        public int ColumnCount{ get { return Columns.Count; } }

        [ProtoIgnore]
        public string[] ColumnNames
        {
            get
            {
                string[] returnVal = new string[Columns.Count];

                for (int i = 0; i < Columns.Count; i++)
                    returnVal[i] = Columns[i].Name;

                return returnVal; 
            }
        }

        [ProtoIgnore]
        public int RecordCount { get { return Records.Count; } }

        [ProtoIgnore]
        public List<object[]> TableRecords 
        { 
            get
            {
                // Döndürülecek liste
                List<object[]> returnVal = new List<object[]>();
                
                // Tüm kayıtları dolaşır
                foreach(Record r in Records)
                {
                    // Geçerli kayıttaki veriler
                    object[] record = new object[ColumnCount];

                    // Kayıttan sütunlarına göre sırasıyla verileri çekip diziye ekler
                    for (int i = 0; i < ColumnCount; i++)
                        record[i] = r.GetValue(Columns[i].Name);

                    // Döndürülecek listeye geçerli kaydın array'i eklenir
                    returnVal.Add(record);
                }

                // Liste döndürülür
                return returnVal;
            } 
        }

        [ProtoIgnore]
        public string ParentDBString { get { return ParentDbString; } }

        public Table()
        {
            Name = "";
            ParentDbString = "";
            IsPrimaryKeyExists = false;
            Columns = new List<Column>();
            Records = new List<Record>();
        }

        // Tablo constructor'ı parametresine tablonun adını alır
        public Table(string tableName, string parentDbString, bool isPrimaryKeyExists)
        {
            Name = tableName;
            ParentDbString = parentDbString;
            IsPrimaryKeyExists = isPrimaryKeyExists;
            Columns = new List<Column>();
            Records = new List<Record>();
        }

        // Tabloya sütun ekler
        public void AddColumn(string columnName)
        {
            // Eğer aynı isimde bir sütun varsa hata döndürür
            foreach (Column c in Columns)
                if (c.Name == columnName)
                    throw new AlifeDBException("Sütun zaten mevcut!", ParentDbString, Name);

            Columns.Add(new Column(columnName));
        }

        // Tabloya yeni kayıt ekler
        public void AddRecord(Record record)
        {
            if (IsPrimaryKeyExists) {
                // Yeni eklenecek kaydın birincil anahtarını ayarlar
                int lastIndexPrimaryKey;
                lastIndexPrimaryKey = Records.Count > 0 ? Records[Records.Count - 1].Values[0].GetData<int>() : 0;
                record.Values[0].SetData(lastIndexPrimaryKey + 1);
            }
            
            Records.Add(record);
        }

        // Tablodan birincil anahtarına göre kayıt çeker
        public Record GetRecordByPrimaryKey(int primaryKey)
        {
            // Eğer tabloda birincil anahtar yoksa hata döndürür
            if (!IsPrimaryKeyExists)
                throw new AlifeDBException("Bu tabloda birincil anahtar bulunmamakta!", ParentDbString, Name);

            // Tüm kayıtlara bakar
            foreach (Record record in Records)
                if (record.Values[0].GetData<int>() == primaryKey)
                    return record;

            // Kaydı bulamadıysa hata döndürür
            throw new AlifeDBException("Kayıt bulunamadı!", ParentDbString, Name);
        }
        public Record GetRecordByIndex(int index)
        {
            return Records[index];
        }
    }
}
