using alifeDB.Database.Exceptions;
using System.Collections.Generic;
using ProtoBuf;

namespace alifeDB.Database.Core
{
    [ProtoContract]
    public class Database
    {
        /// <include file='Docs/CoreDoc.xml' path='docs/database/prop[@name="DbString"]/*'/>
        [ProtoMember(1)]
        public string DbString { get; set; }

        /// <include file='Docs/CoreDoc.xml' path='docs/database/prop[@name="Tables"]/*'/>
        [ProtoMember(2)]
        public List<Table> Tables { get; set; }


        /// <include file='Docs/CoreDoc.xml' path='docs/database/prop[@name="TableNames"]/*'/>
        public string[] TableNames
        {
            get
            {
                string[] returnVal = new string[Tables.Count];

                for (int i = 0; i < Tables.Count; i++)
                    returnVal[i] = Tables[i].Name;

                return returnVal;
            }
        }

        public Database() 
        {
            DbString = "";
            Tables = new List<Table>();
        }

        // Veritabanı constructor'ı parametresine veritabanının dosya sistemindeki konumunu alır
        public Database(string dbString)
        {
            DbString = dbString;
            Tables = new List<Table>();
        }

        // Tablo ekler
        public void AddTable(Table table)
        {
            // Eğer aynı isimde bir tablo varsa hata döndürür
            foreach(Table t in Tables)
            {
                if (t.Name == table.Name)
                    throw new AlifeDBException("Tablo zaten mevcut!", DbString, null);
            }
            
            // Sorun yoksa yeni tabloyu listeye ekler
            Tables.Add(table);
        }
        // Veritabanından tablo siler
        public void DeleteTable(string tableName)
        {
            // Tüm tabloların isimlerini karşılaştırır
            foreach (Table table in Tables)
                if (table.Name == tableName)
                {
                    Tables.Remove(table);
                    return;
                }

            // Eğer o isme sahip bir tablo yoksa hata döndürür
            throw new AlifeDBException("Tablo bulunamadı!", DbString, null);
        }
        // Parametreye girilen isimdeki tabloyu döndürür
        public Table GetTable(string tableName)
        {
            foreach(Table table in Tables)
            {
                if (table.Name == tableName)
                    return table;
            }

            // Eğer o isimde tablo yoksa hata döndürür
            throw new AlifeDBException("Tablo bulunamadı!", DbString, null);
        }
    }
}