using alifeDB.Database.Exceptions;
using System;
using System.Collections.Generic;

namespace alifeDB.Database
{
    [Serializable]
    public class Table
    {
        // Tablonun bulunduğu veritabanının adı
        private readonly string dbName;
        // Tablonun adı
        private readonly string tableName;
        // Tablo içerisindeki sütunlar
        internal List<Column> columns;
        // Tabloda bulunan kayıtlar
        private List<Record> records;

        // Tablo constructor'ı parametresine tablonun adını alır
        public Table(string tableName, string dbName)
        {
            this.tableName = tableName;
            this.dbName = dbName;
            columns = new List<Column>();
            records = new List<Record>();
        }

        // Tabloya sütun ekler
        public void AddColumn(string columnName)
        {
            // Eğer aynı isimde bir sütun varsa hata döndürür
            foreach (Column c in columns)
                if (c.GetName() == columnName)
                    throw new AlifeDBException("Column already exists", dbName, tableName);

            columns.Add(new Column(columnName));
        }

        // Tabloya yeni kayıt ekler
        public void AddRecord(Record record)
        {
            // Aynı id'ye sahip kayıt varsa hata döndürür
            foreach (Record r in records)
                if (r.GetID() == record.GetID())
                    throw new AlifeDBException("Record with this id already exists!", dbName, tableName);

            // Sorun yoksa yeni kaydı listeye ekler
            records.Add(record);
        }

        // Tablodan kimlik numarasına göre kayıt çeker
        public Record GetRecord(UInt64 id)
        {
            // Tüm kayıtlara bakar
            foreach (Record record in records)
                if (record.GetID() == id)
                    return record;

            // Kaydı bulamadıysa hata döndürür
            throw new AlifeDBException("Record not found!", dbName, tableName);
        }

        // Tablonun adını döndürür
        public string GetName() => tableName;
    }
}
