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
            database.Connect(@"C:\Users\Ali Efe GÜR\Desktop\myDatabase.alfdb");

            database.CreateTableIfNotExists("personalData", new string[] 
            {
                "id",
                "name",
                "last_name"
            });
            database.CreateTableIfNotExists("students", new string[]
            {
                "no",
                "class",
                "school",
                "markAverage"
            });
            database.CreateTableIfNotExists("teachers", new string[] 
            {
                "name",
                "last_name",
                "branch"
            });
            database.CreateTableIfNotExists("workers", new string[]
            {
                "name",
                "last_name",
                "department",
                "salary"
            });
            database.CreateTableIfNotExists("products", new string[]
            {
                "model",
                "brand",
                "price",
                "rate"
            });
            database.CreateTableIfNotExists("films", new string[]
            {
                "name",
                "director",
                "imdb"
            });
            database.CreateTableIfNotExists("games", new string[]
            {
                "name",
                "platform",
                "type"
            });
            database.CreateTableIfNotExists("programmingLanguages", new string[]
            {
                "name",
                "compilable",
                "platform"
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
