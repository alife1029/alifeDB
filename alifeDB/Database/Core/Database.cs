using alifeDB.Database.Exceptions;
using System;
using System.Collections.Generic;

namespace alifeDB.Database.Core
{
    [Serializable]
    public class Database
    {
        /// <include file='Docs/CoreDoc.xml' path='docs/database/prop[@name="DbString"]/*'/>
        public string DbString
        {
            get { return dbString; }
            set { dbString = value; }
        }
        /// <include file='Docs/CoreDoc.xml' path='docs/database/prop[@name="TableNames"]/*'/>
        public string[] TableNames
        {
            get
            {
                string[] returnVal = new string[tables.Count];

                for (int i = 0; i < tables.Count; i++)
                    returnVal[i] = tables[i].Name;

                return returnVal;
            }
        }
        /// <include file='Docs/CoreDoc.xml' path='docs/database/prop[@name="Tables"]/*'/>
        public List<Table> Tables { get { return tables; } }

        // Veritabanının kaydının dosya sistemindeki konumu
        private string dbString;
        // Veritabanında bulunan tablolar
        private readonly List<Table> tables;

        // Veritabanı constructor'ı parametresine veritabanının dosya sistemindeki konumunu alır
        public Database(string dbString)
        {
            this.dbString = dbString;
            tables = new List<Table>();
        }

        // Tablo ekler
        public void AddTable(Table table)
        {
            // Eğer aynı isimde bir tablo varsa hata döndürür
            foreach(Table t in tables)
            {
                if (t.Name == table.Name)
                    throw new AlifeDBException("Tablo zaten mevcut!", dbString, null);
            }
            
            // Sorun yoksa yeni tabloyu listeye ekler
            tables.Add(table);
        }
        // Veritabanından tablo siler
        public void DeleteTable(string tableName)
        {
            // Tüm tabloların isimlerini karşılaştırır
            foreach (Table table in tables)
                if (table.Name == tableName)
                {
                    tables.Remove(table);
                    return;
                }

            // Eğer o isme sahip bir tablo yoksa hata döndürür
            throw new AlifeDBException("Tablo bulunamadı!", dbString, null);
        }
        // Parametreye girilen isimdeki tabloyu döndürür
        public Table GetTable(string tableName)
        {
            foreach(Table table in tables)
            {
                if (table.Name == tableName)
                    return table;
            }

            // Eğer o isimde tablo yoksa hata döndürür
            throw new AlifeDBException("Tablo bulunamadı!", dbString, null);
        }
    }
}