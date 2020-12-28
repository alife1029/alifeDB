using System;
using System.IO;
using System.Threading.Tasks;
using alifeDB.Database.Core.SerializeOptimizers;
using ProtoBuf;

namespace alifeDB.Database.Core
{
    internal class SaveSystem
    {
        // Vertibanını kaydeder
        public static void SaveDb(Database database)
        {
            using (FileStream fs = File.Create(database.DbString))
            {
                SyncSerializeOptimizer optimizer = new SyncSerializeOptimizer();
                Serializer.Serialize(fs, database);
                optimizer.Stop();
                optimizer = null;
            }
            GC.Collect();
        }
        // Veritabanını asenkron bir şekilde bloklanmadan kaydeder
        public static async void SaveDbAsync(Database database)
        {
            using(FileStream fs = File.Create(database.DbString))
            {
                Task saveTask = Task.Run(() => Serializer.Serialize(fs, database));
                new AsyncSerializeOptimizer(saveTask);
                await saveTask;
            }
            GC.Collect();
        }
        
        // Veritabanını okur
        public static Database LoadDb(string path)
        {
            Database db = null;
            using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                SyncSerializeOptimizer optimizer = new SyncSerializeOptimizer();
                db = Serializer.Deserialize<Database>(fs);
                optimizer.Stop();
                optimizer = null;
            }

            GC.Collect();
            return db;
        }
        // Veritabanını asenkron bir şekilde bloklanmadan okur
        public static async Task<Database> LoadDbAsync(string path)
        {
            Task<Database> dbTask;
            using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                dbTask = Task.Run(() => Serializer.Deserialize<Database>(fs));
                new AsyncSerializeOptimizer(dbTask);
                await dbTask;
            }

            GC.Collect();
            return dbTask.Result;
        }
    }
}
