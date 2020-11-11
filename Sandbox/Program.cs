using System;
using alifeDB.Database;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseCursor database = new DatabaseCursor();
            database.Connect(@"C:\Users\Ali Efe GÜR\Desktop\database.alfdb", "database");

            database.CreateTableIfNotExists("personalData", new string[] {
                "id", 
                "name", 
                "last_name"
            });
            database.CreateTableIfNotExists("students", new string[] {
                "number",
                "class",
                "markAverage"
            });

            database.Commit();

            database.GoToTable("students");


            for (int i = 0; i < 100000; i++)
            {
                database.AddRecord(Convert.ToUInt64(i), new string[] {
                    "id",
                    "name",
                    "last_name"
                }, new string[] {
                    i.ToString(),
                    "Ali Efe",
                    "GÜR"
                });


                Console.WriteLine(i.ToString() + ". Record append");
            }


            Console.WriteLine("Database saving...");
            database.Commit();
            Console.WriteLine("Database saved!");

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
