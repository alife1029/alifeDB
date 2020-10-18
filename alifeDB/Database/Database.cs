using alifeDB.Database.Exceptions;
using System;
using System.Collections.Generic;

namespace alifeDB.Database
{
    [Serializable]
    public class Database
    {
        // Veritabanının adı
        private readonly string dbName;
        // Veritabanının kaydının dosya sistemindeki konumu
        internal string dbString;
        // Veritabanında bulunan tablolar
        internal List<Table> tables;

        // Veritabanı constructor'ı parametresine veritabanının dosya sistemindeki konumunu alır
        public Database(string dbString, string dbName)
        {
            this.dbString = dbString;
            this.dbName = dbName;
            tables = new List<Table>();
        }

        // Veritananının adını döndürür
        public string GetName() => dbName;
        // Veritabanının dosya sistemindeki konumunu döndürür
        public string GetString() => dbString;

        // Tablo ekler
        public void AddTable(Table table)
        {
            // Eğer aynı isimde bir tablo varsa hata döndürür
            foreach(Table t in tables)
            {
                if (t.GetName() == table.GetName())
                    throw new AlifeDBException("Table already exists!", dbName, null);
            }
            
            // Sorun yoksa yeni tabloyu listeye ekler
            tables.Add(table);
        }
        // Veritabanından tablo siler
        public void DeleteTable(string tableName)
        {
            // Tüm tabloların isimlerini karşılaştırır
            foreach (Table table in tables)
                if (table.GetName() == tableName)
                {
                    tables.Remove(table);
                    return;
                }

            // Eğer o isme sahip bir tablo yoksa hata döndürür
            throw new AlifeDBException("Table not found!", dbName, null);
        }
        // Parametreye girilen isimdeki tabloyu döndürür
        public Table GetTable(string tableName)
        {
            foreach(Table table in tables)
            {
                if (table.GetName() == tableName)
                    return table;
            }

            // Eğer o isimde tablo yoksa hata döndürür
            throw new AlifeDBException("Table not found!", dbName, null);
        }
        // Tablolar listesinin tamamını döndürür
        public List<Table> GetTables() => tables;
    }
}