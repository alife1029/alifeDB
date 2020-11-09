using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace alifeDB.Database.Core
{
    public class SaveSystem
    {
        // Vertibanını kaydeder
        public static void SaveDB(Database database)
        {
            FileStream fs = new FileStream(database.GetString(), FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, database);
            fs.Close();
        }
        
        // Veritabanını okur
        public static Database LoadDB(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            Database readedDatabase = (Database)formatter.Deserialize(fs);
            fs.Close();

            return readedDatabase;
        }
    }
}
