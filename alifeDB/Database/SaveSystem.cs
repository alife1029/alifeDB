﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace alifeDB.Database
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
        public static void LoadDB(Database database)
        {
            FileStream fs = new FileStream(database.GetString(), FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            Database readedDatabase = (Database)formatter.Deserialize(fs);
            fs.Close();

            database.dbString = readedDatabase.dbString;
            database.tables = readedDatabase.tables;
        }
    }
}