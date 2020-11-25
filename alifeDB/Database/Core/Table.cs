using alifeDB.Database.Exceptions;
using System;
using System.Collections.Generic;

namespace alifeDB.Database.Core
{
    [Serializable]
    public class Table
    {
        public int ColumnCount{ get { return columns.Count; } }
        public List<Column> Columns { get { return columns; } }
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
                        record[i] = r.GetValue(columns[i].GetName());

                    // Döndürülecek listeye geçerli kaydın array'i eklenir
                    returnVal.Add(record);
                }

                // Liste döndürülür
                return returnVal;
            } 
        }

        // Tablonun bulunduğu veritabanının adı
        private readonly string dbName;
        // Tablonun adı
        private readonly string tableName;
        // Tablo içerisindeki sütunlar
        internal List<Column> columns;
        // Tabloda bulunan kayıtlar
        internal List<Record> records;

        // Tablo constructor'ı parametresine tablonun adını alır
        public Table(string tableName, string dbName)
        {
            this.tableName = tableName;
            this.dbName = dbName;
            columns = new List<Column>();
            records = new List<Record>();
        }

        // Tabloya sütun ekler
        internal void AddColumn(string columnName)
        {
            // Eğer sütun yoksa otomatik artan birincil anahtar ekler
            if (columns.Count == 0)
            {
                columns.Add(new Column(columnName, true));
                return;
            }

            // Eğer aynı isimde bir sütun varsa hata döndürür
            foreach (Column c in columns)
                if (c.GetName() == columnName)
                    throw new AlifeDBException("Sütun zaten mevcut!", dbName, tableName);

            columns.Add(new Column(columnName));
        }

        // Tabloya yeni kayıt ekler
        public void AddRecord(Record record)
        {
            // Yeni eklenecek kaydın birincil anahtarını ayarlar
            int lastIndexPrimaryKey;
            lastIndexPrimaryKey = records.Count > 0 ? (int)records[records.Count - 1].values[0].GetData() : 0;
            record.values[0].SetData(lastIndexPrimaryKey + 1);
            
            records.Add(record);
        }

        // Tablodan birincil anahtarına göre kayıt çeker
        public Record GetRecordByPrimaryKey(int primaryKey)
        {
            // Tüm kayıtlara bakar
            foreach (Record record in records)
                if ((int)record.values[0].GetData() == primaryKey)
                    return record;

            // Kaydı bulamadıysa hata döndürür
            throw new AlifeDBException("Kayıt bulunamadı!", dbName, tableName);
        }
        public Record GetRecordByIndex(int index)
        {
            return records[index];
        }

        // Tablonun adını döndürür
        public string GetName() => tableName;
    }
}
