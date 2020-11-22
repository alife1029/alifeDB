using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace alifeDB.Database.Core
{
    public class SaveSystem
    {
        // Vertibanını kaydeder
        public static void SaveDb(Database database)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream(database.GetString(), FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, database);
            }
            GC.Collect();
        }
        // Veritabanını asenkron bir şekilde bloklanmadan kaydeder
        public static async void SaveDbAsync(Database database)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream(database.GetString(), FileMode.Create, FileAccess.Write))
            {
                await Task.Run(() => formatter.Serialize(fs, database));
            }
            GC.Collect();
        }
        
        // Veritabanını okur
        public static Database LoadDb(string path)
        {
            Database db;
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                db = (Database)formatter.Deserialize(fs);
            }

            GC.Collect();
            return db;
        }
        // Veritabanını asenkron bir şekilde bloklanmadan okur
        public static async Task<Database> LoadDbAsync(string path)
        {
            Database db;
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                db = await Task.Run(() => (Database)formatter.Deserialize(fs));
            }

            GC.Collect();
            return db;
        }
    }
}
