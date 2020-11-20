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

            database.GoToTable("personalData");
            database.AddRecord( new string[] { "name", "last_name" },
                                new string[] { "Ali Efe", "GÜR" });
            database.AddRecord( new string[] { "name", "last_name" },
                                new string[] { "Mehmet", "YILMAZ" });
            database.AddRecord( new string[] { "name", "last_name" },
                                new string[] { "Hale", "KAYA" });
            database.AddRecord( new string[] { "name", "last_name" },
                                new string[] { "Orhun Ege", "GÜR" });

            Console.WriteLine("Database saving...");
            database.Commit();
            Console.WriteLine("Database saved!");
        }
    }
}
