using alifeDB.Database.Core;
using alifeDB.Database.Exceptions;
using System.Collections.Generic;
using System.IO;

namespace alifeDB.Database
{
    /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/DatabaseCursor/*'/>
    public class DatabaseCursor
    {
        // İmlecin bulunduğu veritabanı
        private Core.Database database;
        // İmlecin bulunduğu tablo
        private Table table;

        public DatabaseCursor()
        {
            database = null;
            table = null;
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/Connect/*'/>
        public void Connect(string databasePath, string databaseName)
        {
            // Eğer dosya mevcutsa dosyayı okur ve metodu bitirir
            if (File.Exists(databasePath))
            {
                database = SaveSystem.LoadDB(databasePath);
                return;
            }

            // Eğer dosya yoksa yeni dosya oluşturur
            database = new Core.Database(databasePath, databaseName);
            table = null;
            Commit();
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/GoToTable/*'/>
        public void GoToTable(string tableName)
        {
            // Veritabanında bulunan tüm tabloların isimleri ile parametrede girilen değeri karşılaştırır
            foreach (Table t in database.GetTables())
                // Eğer aynı adda tablo bulunduysa o tabloyu table değişkenine atar ve metod bitirilir
                if (t.GetName() == tableName)
                {
                    table = t;
                    return;
                }

            // Eğer metod bitmemişse (tablo bulunamamışsa) hata döner
            throw new TableDidNotFoundException("\"" + tableName + "\" isimli tablo bulunamadı!!!", database.dbName, this);
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/CreateTable/*'/>
        public void CreateTable(string tableName, string[] columns)
        {
            // Eğer aynı adda birden fazla sütun adı varsa hata döndürür
            for (int i = 0; i < columns.Length; i++)
                for (int j = 0; j < columns.Length; j++)
                    if (i != j && columns[i] == columns[j])
                        throw new AlifeDBArgumentException("Bir tablo içerisinde aynı isimde sütunlar olamaz!");

            // Eğer aynı adda tablo varsa hata döndür
            foreach (Table t in database.tables)
                if (t.GetName().Equals(tableName))
                    throw new TableAlreadyExistsException("Tablo zaten mevcut!", database.dbName, tableName, this);

            // Yeni tablo oluşturup veritabanına ekler
            Table table = new Table(tableName, database.GetName());
            for (int i = 0; i < columns.Length; i++)
                table.AddColumn(columns[i]);
            database.tables.Add(table);
        }
        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/CreateTableIfNotExists/*'/>
        public void CreateTableIfNotExists(string tableName, string[] columns)
        {
            // Eğer aynı adda tablo varsa metodu bitir
            foreach (Table t in database.tables)
                if (t.GetName() == tableName)
                    return;

            // Eğer aynı adda birden fazla sütun adı varsa hata döndürür
            for (int i = 0; i < columns.Length; i++)
                for (int j = 0; j < columns.Length; j++)
                    if (i != j && columns[i] == columns[j])
                        throw new AlifeDBArgumentException("Bir tablo içerisinde aynı isimde sütunlar olamaz!");

            // Yeni tablo oluşturup veritabanına ekler
            Table table = new Table(tableName, database.GetName());
            for (int i = 0; i < columns.Length; i++)
                table.AddColumn(columns[i]);

            database.tables.Add(table);
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/GetTable/*'/>
        public Table GetTable(string tableName)
        {
            foreach (Table table in database.GetTables())
            {
                if (table.GetName() == tableName)
                    return table;
            }

            // Eğer o isimde tablo yoksa hata döndürür
            throw new AlifeDBException("Tablo bulunamadı!", database.GetString(), null);
        }
        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/GetTables/*'/>
        public List<Table> GetTables() => database.GetTables();

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/AddRecord/*'/>
        public void AddRecord(string[] columns, object[] values)
        {
            // Eğer girilen sütun sayısı ile değer sayısı aynı değilse hata döndürür
            if (columns.Length != values.Length)
                throw new AlifeDBArgumentException("Sütun sayısı ile veri sayısı birbirine eşit olmak zorundadır!");

            // Eğer imleç bir tabloyu göstermiyorsa hata döndür.
            if (table == null)
                throw new TableDidNotSetException("Veritabanına herhangi bir kayıt eklemeden önce bir tablo seçmek zorundasınız!", this);

            // Columns parametresine tabloda var olmayan bir sütun girildiyse hata döndür
            foreach(string s in columns)
            {
                bool isColumnExists = false;
                foreach(Column c in table.columns)
                    if (c.GetName() == s)
                        isColumnExists = true;

                if (!isColumnExists)
                    throw new AlifeDBArgumentException("Tabloda \"" + s + "\" isimli sütun bulunmamakta!");
            }

            // Yeni bir kayıt nesnesi oluşturur ve değerleri içine atar
            Record record = new Record(table);
            record.SetAllValues(columns, values);

            // Yeni kaydı tablodaki kayıtlar listesine ekler
            table.AddRecord(record);
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/DeleteRecordByIndex/*'/>
        public void DeleteRecord(int index)
        {
            // Eğer tablo seçilmemişse hata döndürür
            if (table == null)
                throw new TableDidNotSetException("Herhangi bir kayıt silmeden önce bir tablo seçmek zorundasınız!", this);

            table.records.RemoveAt(index);
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/DeleteRecordByCondition/*'/>
        public void DeleteRecord(string[] columns, object[] values)
        {
            // Eğer kullanıcı imleci bir tabloyla ilişkilendirmediyse hata döndür
            if (table == null)
                throw new TableDidNotSetException("Herhangi bir kayıt silmeden önce bir tablo seçmeniz gerekir!", this);

            // Eğer girilen sütun sayısı ile değer sayısı aynı değilse hata döndürür
            if (columns.Length != values.Length)
                throw new AlifeDBArgumentException("Sütun sayısı veri sayasına eşit olmalıdır!");

            // Kaç koşul sağlandı?
            int providedConditionCount = 0;

            // Tablo içindeki tüm kayıtları dolaşır
            foreach (Record r in table.records)
                // Kayıt içindeki tüm veri hücrelerini dolaşır
                foreach (DataCell c in r.values)
                    // Parametrede girilen tüm sütunları dolaşır
                    for (int i = 0; i < columns.Length; i++)
                        // Eğer istenilen şartın birini sağlamişsa
                        if (c.GetColumn().GetName() == columns[i] && c.GetData() == values[i])
                            // Eğer tüm koşullar sağlanmışsa
                            if (++providedConditionCount == columns.Length)
                            {
                                // Şu an üzerinde durduğumuz kaydı siler ve metod sonlanır
                                table.records.Remove(r);
                                return;
                            }
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/FetchRecordByIndex/*'/>
        public object[][] FetchRecord(int index)
        {
            // Eğer imleç bir tablo göstermiyorsa hata döndür
            if (table == null)
                throw new TableDidNotSetException("Herhangi bir kayıt çekmeden önce bir tablo seçmelisiniz!", this);

            object[][] fetchedRecord = new object[table.records[index].values.Count][];
            for (int i = 0; i < table.records[index].values.Count; i++)
            {
                fetchedRecord[i][0] = table.records[index].values[i].GetColumn().GetName();
                fetchedRecord[i][1] = table.records[index].values[i].GetData();
            }

            return fetchedRecord;
        }

        public object[] FetchData(int index, string[] columns)
        {
            // Tablo seçilmediyse hata döndürür
            if (table == null)
                throw new TableDidNotSetException("Herhangi bir veri çekmeden önce bir tablo seçmelisiniz!", this);

            // Çekilen verilerin bulunduğu array
            object[] fetchedDatas = new object[columns.Length];

            // Sayaç
            int counter = 0;
            foreach (string s in columns)
            {
                // Belirtilen adda sütun var mı
                bool isColumnFound = false;
                
                // Tablodaki tüm sütunları dolaşır
                foreach (Column c in table.columns)
                    // Eğer aynı adda sütun bulunduysa veriyi listeye ekler
                    if (c.GetName() == s)
                    {
                        fetchedDatas[counter++] = table.GetRecordByIndex(index).GetValue(s);
                        isColumnFound = true;
                    }

                // Belirtilen adda sütun yoksa hata döndür
                if (!isColumnFound)
                    throw new ColumnDidNotFoundException("\"" + s + "\" isimli sütun bulunamadı!",
                                                        database.GetName(), table.GetName(), s, this);
            }

            return fetchedDatas;
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/Commit/*'/>
        public void Commit()
        {
            SaveSystem.SaveDB(database);
        }
    }
}
