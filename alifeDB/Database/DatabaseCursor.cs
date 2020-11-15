using alifeDB.Database.Core;
using alifeDB.Database.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace alifeDB.Database
{
    /// <summary>
    /// Veritabanının içerisinde gezinip kaydetme, güncelleme, silme gibi işlemlerin yapılmasını sağlar.
    /// </summary>
    public class DatabaseCursor
    {
        // Bulunduğu veritabanı
        private Core.Database database;
        // Bulunduğu tablo
        private Table table;


        public DatabaseCursor()
        {
            database = null;
            table = null;
        }
        public DatabaseCursor(Core.Database database)
        {
            this.database = database;
            table = null;
        }

        /// <summary>
        /// Belirtilen yoldaki veritabanı dosyasıyla bağlantı kurar. Eğer velirtilen yolda
        /// veritabanı dosyası mevcut değilse yeni bir veritabanı dosyası oluşturur.
        /// </summary>
        /// <param name="databasePath">Veritabanı dosyasının dosya sistemindeki konumu.</param>
        /// <param name="databaseName">Veritabanı adı.</param>
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

        /// <summary>
        /// İmlecin veritabanı içerisindeki bir tabloya gitmesini sağlar.
        /// </summary>
        /// <exception cref="TableDidNotFoundException"></exception>
        /// <param name="tableName">İmlecin hareket edeceği tablonun adı</param>
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

        /// <summary>
        /// Veritabanına yeni tablo ekler
        /// </summary>
        /// <param name="tableName">Veritabanına elenecek olan tablonun adı</param>
        /// <param name="columns">Tablonun içerisinde bulunacak olan sütunlar</param>
        /// <exception cref="TableAlreadyExistsException"></exception>
        public void CreateTable(string tableName, string[] columns)
        {
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
        /// <summary>
        /// Veritabanına yeni tablo ekler. Eğer aynı adda bir tablo zaten mevcutsa herhangi bir değişiklik yapmaz.
        /// </summary>
        /// <param name="tableName">Veritabanına elenecek olan tablonun adı</param>
        /// <param name="columns">Tablonun içerisinde bulunacak olan sütunlar</param>
        public void CreateTableIfNotExists(string tableName, string[] columns)
        {
            // Eğer aynı adda tablo varsa metodu bitir
            foreach (Table t in database.tables)
                if (t.GetName() == tableName)
                    return;

            // Yeni tablo oluşturup veritabanına ekler
            Table table = new Table(tableName, database.GetName());
            for (int i = 0; i < columns.Length; i++)
                table.AddColumn(columns[i]);

            database.tables.Add(table);
        }

        public Table GetTable(string tableName)
        {
            foreach (Table table in database.GetTables())
            {
                if (table.GetName() == tableName)
                    return table;
            }

            // Eğer o isimde tablo yoksa hata döndürür
            throw new AlfDBException("Tablo bulunamadı!", database.GetString(), null);
        }
        public List<Table> GetTables() => database.GetTables();

        /// <summary>
        /// İmlecin içerisinde bulunduğu tabloya kayıt eklemesini sağlar.
        /// </summary>
        /// <param name="columns">Kayıt içerisindeki sütunlar</param>
        /// <param name="values">Kayıt içerisindeki değerler</param>
        /// <exception cref="TableDidNotSetException"></exception>
        public void AddRecord(UInt64 id, string[] columns, object[] values)
        {
            // Eğer girilen sütun sayısı ile değer sayısı aynı değilse hata döndürür
            if (columns.Length != values.Length)
                throw new AlfDBArgumentException("Sütun sayısı ile veri sayısı birbirine eşit olmak zorundadır!");

            // Eğer imleç bir tabloyu göstermiyorsa hata döndür.
            if (table == null)
                throw new TableDidNotSetException("Veritabanına herhangi bir kayıt eklemeden önce bir tablo seçmek zorundasınız!", this);

            // Yeni bir kayıt nesnesi oluşturur ve değerleri içine atar
            Record record = new Record(table, id);
            record.SetAllValues(columns, values);

            // Yeni kaydı tablodaki kayıtlar listesine ekler
            table.AddRecord(record);
        }

        /// <summary>
        /// İmlecin içerisinde bylunduğu tablodan ID'sine göre kayıt siler.
        /// </summary>
        /// <param name="id">Silinecek kaydın ID'si</param>
        /// <exception cref="TableDidNotSetException"></exception>
        /// <exception cref="RecordDidNotFoundException"></exception>
        public void DeleteRecord(UInt64 id)
        {
            // Eğer imleç bir tablo göstermiyorsa hata döndür
            if (table == null)
                throw new TableDidNotSetException("Herhangi bir kayıt silmeden önce bir tablo seçmek zorundasınız!", this);

            // Tüm kayıtları dolaşır ve id'si eşleşeni siler
            foreach (Record r in table.records)
                if (r.GetID() == id)
                {
                    table.records.Remove(r);
                    return;
                }

            // Eğer o id'ye sahip bir kayıt yoksa hata döndürür
            throw new RecordDidNotFoundException("Belirtilen kimliğe sahip kayıt bulunamadı!\n" +
                                                "Kimlik: " + id.ToString(),
                                                database.dbName, table.GetName(), this);
        }

        /// <summary>
        /// Kaydın tablodaki indeksine göre kaydı siler.
        /// </summary>
        /// <param name="index">Silinecek kaydın indeksi.</param>
        /// <exception cref="TableDidNotSetException"></exception>
        /// <exception cref="RecordDidNotFoundException"></exception>
        public void DeleteRecord(int index)
        {
            // Eğer tablo seçilmemişse hata döndürür
            if (table == null)
                throw new TableDidNotSetException("Herhangi bir kayıt silmeden önce bir tablo seçmek zorundasınız!", this);
            // Eğer belirtilen index rekor sayısını aşıyorsa
            if (index >= table.records.Count)
                throw new RecordDidNotFoundException("Kayıt indeksi menzil dışında!",
                                                    database.dbName, table.GetName(), this);
            // Eğer index sınıfdan küçükse
            if (index < 0)
                throw new RecordDidNotFoundException("Kayıt indeksi sıfırdan küçük olamaz!",
                                                    database.dbName, table.GetName(), this);


            table.records.Remove(table.records[index]);
        }

        /// <summary>
        /// Parametreye girilen şartları sağlayan kayıtları siler.
        /// </summary>
        /// <param name="columns">Şart sütunları</param>
        /// <param name="values">Şartın sağlanması için istenen değerler</param>
        /// <exception cref="RecordDidNotFoundException"></exception>
        /// <exception cref="TableDidNotSetException"></exception>
        public void DeleteRecord(string[] columns, object[] values)
        {
            // Eğer kullanıcı imleci bir tabloyla ilişkilendirmediyse hata döndür
            if (table == null)
                throw new TableDidNotSetException("Herhangi bir kayıt silmeden önce bir tablo seçmeniz gerekir!", this);

            // Eğer girilen sütun sayısı ile değer sayısı aynı değilse hata döndürür
            if (columns.Length != values.Length)
                throw new AlfDBArgumentException("Sütun sayısı veri sayasına eşit olmalıdır!");

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

        /// <summary>
        /// Belli bir id'ye sahip kaydı bir <c>Record</c> nesnesi olarak veritabanından çeker.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Record FetchRecord(UInt64 id)
        {
            // Eğer imleç bir tablo göstermiyorsa hata döndür
            if (table == null)
                throw new TableDidNotSetException("Herhangi bir kayıt çekmeden önce bir tablo seçmelisiniz!", this);

            // Tüm kayıtları dolaşır ve id'si eşleşeni siler
            foreach (Record r in table.records)
                if (r.GetID() == id)
                {
                    return r;
                }

            // Eğer o id'ye sahip bir kayıt yoksa hata döndürür
            throw new RecordDidNotFoundException("Belirtilen kimliğe sahip kayıt bulunamadı!\n" +
                                                "Kayıt Kimliği: " + id.ToString(),
                                                database.dbName, table.GetName(), this);
        }

        public object[] FetchData(UInt64 id, string[] columns)
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
                        fetchedDatas[counter++] = table.GetRecord(id).GetValue(s);
                        isColumnFound = true;
                    }

                // Belirtilen adda sütun yoksa hata döndür
                if (!isColumnFound)
                    throw new ColumnDidNotFoundException("\"" + s + "\" isimli sütun bulunamadı!",
                                                        database.GetName(), table.GetName(), s, this);
            }

            return fetchedDatas;
        }

        /// <summary>
        /// Veritabanını kaydeder
        /// </summary>
        public void Commit()
        {
            SaveSystem.SaveDB(database);
        }
    }
}
