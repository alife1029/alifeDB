using System;
using alifeDB.Database;

namespace Sandbox.Examples
{
    class SaveData
    {
        public SaveData()
        {
            // Veritabanı imleci oluşturup bir veritabanına bağlanır
            DatabaseCursor database = new DatabaseCursor();
            database.Connect(@"C:\Users\Ali Efe GÜR\Desktop\myDatabase.alfdb", "database");

            database.CreateTableIfNotExists("personalData", new string[] {
                "id",
                "name",
                "last_name"
            });

            database.Commit();
            database.GoToTable("personalData");
            database.AddRecord(0, new string[] { "id", "name", "last_name" },
                                new string[] { "0", "Ali Efe", "GÜR" });
            database.AddRecord(1, new string[] { "id", "name", "last_name" },
                                new string[] { "1", "Ahmet", "YILMAZ" });
            database.AddRecord(2, new string[] { "id", "name", "last_name" },
                                new string[] { "2", "Elif", "KORKMAZ" });
            database.AddRecord(3, new string[] { "id", "name", "last_name" },
                                new string[] { "3", "Fatih", "YILMAZ" });
            database.AddRecord(4, new string[] { "id", "name", "last_name" },
                                new string[] { "4", "Sude", "NUR" });

            Console.WriteLine("Database saving...");
            database.Commit();
            Console.WriteLine("Database saved!");
        }
    }
}
