using alifeDB.Database.Core;
using alifeDB.Database.Exceptions;
using System;

namespace alifeDB.Database
{
    /// <summary>
    /// Veritabanının içerisinde gezinip kaydetme, güncelleme, silme gibi işlemlerin yapılmasını sağlar.
    /// </summary>
    public class Cursor
    {
        // Bulunduğu veritabanı
        private readonly Core.Database database;
        // Bulunduğu tablo
        private Table table;


        public Cursor(Core.Database database)
        {
            this.database = database;
            table = null;
        }

        /// <summary>
        /// İmlecin veritabanı içerisindeki bir tabloya gitmesini sağlar.
        /// </summary>
        /// <exception cref="TableDidNotFoundException"></exception>
        /// <param name="tableName">İmlecin hareket edeceği tablonun adı</param>
        public void GoToTable(string tableName)
        {
            // Veritabanında bulunan tüm tabloların isimleri ile parametrede girilen değeri karşılaştırır
            foreach(Table t in this.database.GetTables())
                // Eğer aynı adda tablo bulunduysa o tabloyu table değişkenine atar ve metod bitirilir
                if (t.GetName() == tableName)
                {
                    table = t;
                    return;
                }

            // Eğer metod bitmemişse (tablo bulunamamışsa) hata döner
            throw new TableDidNotFoundException("Table did not found named " + tableName + " !!!", database.dbName, this);
        }

        /// <summary>
        /// Veritabanına yeni tablo ekler
        /// </summary>
        /// <param name="tableName">Veritabanına elenecek olan tablonun adı</param>
        /// <param name="columns">Tablonun içerisinde bulunacak olan sütunlar</param>
        public void CreateTable(string tableName, string[] columns)
        {
            // Eğer aynı adda tablo varsa hata döndür
            foreach (Table t in database.tables)
                if (t.GetName() == tableName)
                    throw new TableAlreadyExistsException("Table already exists!", database.dbName, tableName, this);

            // Yeni tablo oluşturup veritabanına ekler
            Table table = new Table(tableName, database.GetName());
            for (int i = 0; i < columns.Length; i++)
                table.AddColumn(columns[i]);
        }

        /// <summary>
        /// İmlecin içerisinde bulunduğu tabloya kayıt eklemesini sağlar.
        /// </summary>
        /// <param name="columns">Kayıt içerisindeki sütunlar</param>
        /// <param name="values">Kayıt içerisindeki değerler</param>
        /// <exception cref="TableDidNotSetException"></exception>
        public void AddRecord(UInt64 id, string[] columns, object[] values)
        {
            // TODO: Eğer parametreye girilen sütun sayısıyla değer sayısı aynı değilse hata döndür

            // Eğer imleç bir tabloyu göstermiyorsa hata döndür.
            if (table == null)
                throw new TableDidNotSetException("You must set a table before add any record!", this);

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
                throw new TableDidNotSetException("You must set a table before delete any record!", this);

            // Tüm kayıtları dolaşır ve id'si eşleşeni siler
            foreach(Record r in table.records)
                if (r.GetID() == id)
                {
                    table.records.Remove(r);
                    return;
                }

            // Eğer o id'ye sahip bir kayıt yoksa hata döndürür
            throw new RecordDidNotFoundException("Record not found with ID: " + id.ToString(), 
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
                throw new TableDidNotSetException("You must set a table before delete any record!", this);
            // Eğer belirtilen index rekor sayısını aşıyorsa
            if (index >= table.records.Count)
                throw new RecordDidNotFoundException("Record index out of range!", 
                                                    database.dbName, table.GetName(), this);
            // Eğer index sınıfdan küçükse
            if (index < 0)
                throw new RecordDidNotFoundException("Record index can not be less than zero!",
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
                throw new TableDidNotSetException("You must set a table before delete any record!", this);

            // TODO: Eğer girilen sütun sayısı ile değer sayısı aynı değilse hata döndür

            // Kaç koşul sağlandı?
            int providedConditionCount = 0;

            // Tablo içindeki tüm kayıtları dolaşır
            foreach (Record r in table.records)
                // Kayıt içindeki tüm veri hücrelerini dolaşır
                foreach(DataCell c in r.values)
                    // Parametrede girilen tüm sütunları dolaşır
                    for (int i = 0; i < columns.Length; i++)
                        // Eğer istenilen şartın birini sağlamişsa
                        if (c.GetColumn().GetName() == columns[i] && c.GetData() == values[i])
                            // Eğer tüm koşullar sağlanmışsa
                            if(++providedConditionCount == columns.Length)
                            {
                                // Şu an üzerinde durduğumuz kaydı siler ve metod sonlanır
                                table.records.Remove(r);
                                return;
                            }
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
