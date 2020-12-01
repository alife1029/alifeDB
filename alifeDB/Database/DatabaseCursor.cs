using alifeDB.Database.Core;
using alifeDB.Database.Exceptions;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public string DatabasePath { get { return database.DbString; } }
        public string TableName
        {
            get { return table.Name; }
            set { GoToTable(value); }
        }

        public DatabaseCursor()
        {
            database = null;
            table = null;
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/Connect/*'/>
        public void Connect(string databasePath)
        {
            // Eğer dosya mevcutsa dosyayı okur ve metodu bitirir
            if (File.Exists(databasePath))
            {
                database = SaveSystem.LoadDb(databasePath);
                return;
            }

            // Eğer dosya yoksa yeni dosya oluşturur
            database = new Core.Database(databasePath);
            table = null;
            Commit();
        }
        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/ConnectAsync/*'/>
        public async Task ConnectAsync(string databasePath)
        {
            if (File.Exists(databasePath))
            {
                database = await SaveSystem.LoadDbAsync(databasePath);
                return;
            }

            database = new Core.Database(databasePath);
            table = null;
            await CommitAsync();
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/GoToTable/*'/>
        public void GoToTable(string tableName)
        {
            // Veritabanında bulunan tüm tabloların isimleri ile parametrede girilen değeri karşılaştırır
            foreach (Table t in database.Tables)
                // Eğer aynı adda tablo bulunduysa o tabloyu table değişkenine atar ve metod bitirilir
                if (t.Name == tableName)
                {
                    table = t;
                    return;
                }

            // Eğer metod bitmemişse (tablo bulunamamışsa) hata döner
            throw new TableDidNotFoundException("\"" + tableName + "\" isimli tablo bulunamadı!!!", database.DbString, this);
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/CreateTable/*'/>
        public void CreateTable(string tableName, string[] columns)
        {
            // Eğer aynı adda birden fazla sütun adı varsa hata döndürür
            for (int i = 0; i < columns.Length; i++)
                for (int j = 0; j < columns.Length; j++)
                    if (i != j && columns[i] == columns[j])
                        throw new AlifeDBArgumentException("Bir tablo içerisinde aynı isimde sütunlar olamaz!");

            // Eğer aynı adda tablo varsa hata döndür
            foreach (Table t in database.Tables)
                if (t.Name.Equals(tableName))
                    throw new TableAlreadyExistsException("Tablo zaten mevcut!", database.DbString, tableName, this);

            // Yeni tablo oluşturup veritabanına ekler
            Table table = new Table(tableName, database.DbString);
            for (int i = 0; i < columns.Length; i++)
                table.AddColumn(columns[i]);
            database.Tables.Add(table);
        }
        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/CreateTableIfNotExists/*'/>
        public void CreateTableIfNotExists(string tableName, string[] columns)
        {
            // Eğer aynı adda tablo varsa metodu bitir
            foreach (Table t in database.Tables)
                if (t.Name == tableName)
                    return;

            // Eğer aynı adda birden fazla sütun adı varsa hata döndürür
            for (int i = 0; i < columns.Length; i++)
                for (int j = 0; j < columns.Length; j++)
                    if (i != j && columns[i] == columns[j])
                        throw new AlifeDBArgumentException("Bir tablo içerisinde aynı isimde sütunlar olamaz!");

            // Yeni tablo oluşturup veritabanına ekler
            Table table = new Table(tableName, database.DbString);
            for (int i = 0; i < columns.Length; i++)
                table.AddColumn(columns[i]);

            database.Tables.Add(table);
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/GetTable/*'/>
        public Table GetTable(string tableName)
        {
            foreach (Table table in database.Tables)
            {
                if (table.Name == tableName)
                    return table;
            }

            // Eğer o isimde tablo yoksa hata döndürür
            throw new AlifeDBException("Tablo bulunamadı!", database.DbString, null);
        }
        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/GetTables/*'/>
        public List<Table> GetTables() => database.Tables;

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/AddRecord/*'/>
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
                    if (c.Name == s)
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

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/DeleteRecordByIndex/*'/>
        public void DeleteRecord(int index)
        {
            // Eğer tablo seçilmemişse hata döndürür
            if (table == null)
                throw new TableDidNotSetException("Herhangi bir kayıt silmeden önce bir tablo seçmek zorundasınız!", this);

            table.records.RemoveAt(index);
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/DeleteRecordByCondition/*'/>
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
                        if (c.Column.Name == columns[i] && c.Data == values[i])
                            // Eğer tüm koşullar sağlanmışsa
                            if (++providedConditionCount == columns.Length)
                            {
                                // Şu an üzerinde durduğumuz kaydı siler ve metod sonlanır
                                table.records.Remove(r);
                                return;
                            }
        }
        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/async/DeleteRecordByCondition/*'/>
        public async Task DeleteRecordAsync(string[] columns, object[] values)
        {
            await Task.Run(() => DeleteRecord(columns, values));
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/FetchRecordByIndex/*'/>
        public object[] FetchRecordByIndex(int index)
        {
            // Eğer imleç bir tablo göstermiyorsa hata döndür
            if (table == null)
                throw new TableDidNotSetException("Herhangi bir kayıt çekmeden önce bir tablo seçmelisiniz!", this);

            object[] fetchedRecord = new object[table.records[index].values.Count];
            for (int i = 0; i < table.records[index].values.Count; i++)
            {
                fetchedRecord[i] = table.records[index].values[i].Data;
            }

            return fetchedRecord;
        }
        
        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/FetchDataByIndex'/>
        public object[] FetchDataByIndex(int index, string[] columns)
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
                    if (c.Name == s)
                    {
                        fetchedDatas[counter++] = table.GetRecordByIndex(index).GetValue(s);
                        isColumnFound = true;
                    }

                // Belirtilen adda sütun yoksa hata döndür
                if (!isColumnFound)
                    throw new ColumnDidNotFoundException("\"" + s + "\" isimli sütun bulunamadı!",
                                                        database.DbString, table.Name, s, this);
            }

            return fetchedDatas;
        }

        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/sync/Commit/*'/>
        public void Commit()
        {
            SaveSystem.SaveDb(database);
        }
        /// <include file='Docs/DatabaseCursorDoc.xml' path='docs/async/CommitAsync/*'/>
        public async Task CommitAsync()
        {
            await Task.Run(() => SaveSystem.SaveDbAsync(database));
        }
    }
}
