using alifeDB.Database.Exceptions;
using System;
using System.Collections.Generic;

namespace alifeDB.Database.Core
{
    [Serializable]
    public class Table
    {
        public bool IsPrimaryKeyExists { get { return isPrimaryKeyExists; } }
        public int ColumnCount{ get { return columns.Count; } }
        public string[] ColumnNames
        {
            get
            {
                string[] returnVal = new string[columns.Count];

                for (int i = 0; i < columns.Count; i++)
                    returnVal[i] = columns[i].Name;

                return returnVal; 
            }
        }
        public int RecordCount { get { return records.Count; } }
        public List<object[]> Records 
        { 
            get
            {
                // Döndürülecek liste
                List<object[]> returnVal = new List<object[]>();
                
                // Tüm kayıtları dolaşır
                foreach(Record r in records)
                {
                    // Geçerli kayıttaki veriler
                    object[] record = new object[ColumnCount];

                    // Kayıttan sütunlarına göre sırasıyla verileri çekip diziye ekler
                    for (int i = 0; i < ColumnCount; i++)
                        record[i] = r.GetValue(columns[i].Name);

                    // Döndürülecek listeye geçerli kaydın array'i eklenir
                    returnVal.Add(record);
                }

                // Liste döndürülür
                return returnVal;
            } 
        }
        public string Name
        {
            get { return tableName; }
            set { tableName = value; }
        }
        public string ParentDbString { get { return parentDbString; } }

        // Tablonun adı
        private string tableName;
        // Tablonun bulunduğu veritabanının yolu
        private readonly string parentDbString;
        // Tablo içerisindeki sütunlar
        internal List<Column> columns;
        // Tabloda bulunan kayıtlar
        internal List<Record> records;
        // Tabloda birincil anahtar var mı?
        private bool isPrimaryKeyExists;

        // Tablo constructor'ı parametresine tablonun adını alır
        public Table(string tableName, string parentDbString, bool isPrimaryKeyExists)
        {
            this.tableName = tableName;
            this.parentDbString = parentDbString;
            this.isPrimaryKeyExists = isPrimaryKeyExists;
            columns = new List<Column>();
            records = new List<Record>();
        }

        // Tabloya sütun ekler
        public void AddColumn(string columnName, bool primaryKey)
        {
            // Eğer aynı isimde bir sütun varsa hata döndürür
            foreach (Column c in columns)
                if (c.Name == columnName)
                    throw new AlifeDBException("Sütun zaten mevcut!", parentDbString, tableName);

            columns.Add(new Column(columnName, primaryKey));
        }

        // Tabloya yeni kayıt ekler
        public void AddRecord(Record record)
        {
            if (IsPrimaryKeyExists) {
                // Yeni eklenecek kaydın birincil anahtarını ayarlar
                int lastIndexPrimaryKey;
                lastIndexPrimaryKey = records.Count > 0 ? (int)records[records.Count - 1].values[0].Data : 0;
                record.values[0].Data = lastIndexPrimaryKey + 1;
            }
            
            records.Add(record);
        }

        // Tablodan birincil anahtarına göre kayıt çeker
        public Record GetRecordByPrimaryKey(int primaryKey)
        {
            // Eğer tabloda birincil anahtar yoksa hata döndürür
            if (!IsPrimaryKeyExists)
                throw new AlifeDBException("Bu tabloda birincil anahtar bulunmamakta!", parentDbString, tableName);

            // Tüm kayıtlara bakar
            foreach (Record record in records)
                if ((int)record.values[0].Data == primaryKey)
                    return record;

            // Kaydı bulamadıysa hata döndürür
            throw new AlifeDBException("Kayıt bulunamadı!", parentDbString, tableName);
        }
        public Record GetRecordByIndex(int index)
        {
            return records[index];
        }
    }
}
