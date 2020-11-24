using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using alifeDB.Database.Core.SerializeOptimizers;

namespace alifeDB.Database.Core
{
    internal class SaveSystem
    {
        // Vertibanını kaydeder
        public static void SaveDb(Database database)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream(database.GetString(), FileMode.Create, FileAccess.Write))
            {
                SyncSerializeOptimizer optimizer = new SyncSerializeOptimizer();
                formatter.Serialize(fs, database);
                optimizer.Stop();
                optimizer = null;
            }
            GC.Collect();
        }
        // Veritabanını asenkron bir şekilde bloklanmadan kaydeder
        public static async void SaveDbAsync(Database database)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream(database.GetString(), FileMode.Create, FileAccess.Write))
            {
                Task saveTask = Task.Run(() => formatter.Serialize(fs, database));
                new AsyncSerializeOptimizer(saveTask);
                await saveTask;
            }
            GC.Collect();
        }
        
        // Veritabanını okur
        public static Database LoadDb(string path)
        {
            Database db = null;
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                SyncSerializeOptimizer optimizer = new SyncSerializeOptimizer();
                db = (Database)formatter.Deserialize(fs);
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
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                dbTask = Task.Run(() => (Database)formatter.Deserialize(fs));
                new AsyncSerializeOptimizer(dbTask);
                await dbTask;
            }

            GC.Collect();
            return dbTask.Result;
        }
    }
}
