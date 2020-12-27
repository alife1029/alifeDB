using System;
using alifeDB.Database;

namespace Sandbox.Tests
{
    public class Save
    {
        public Save()
        {
            DatabaseCursor db = new DatabaseCursor();
            db.Connect(@"C:\Users\Ali Efe GÜR\Desktop\saveTestAsync.alfdb");

            DateTime start = DateTime.Now;
            DateTime start1 = DateTime.Now;

            db.CreateTable("students", 
                            true, 
                            new string[] { "id", "name", "last_name", "class", "mark" });
            db.GoToTable("students");

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10000; j++)
                {
                    db.AddRecord(new string[] {
                        "name", "last_name", "class", "mark"
                    }, new string[] {
                        "Ali Efe", "GÜR", "11/B", "97.38"
                    });
                }

                DateTime finishTime1 = DateTime.Now;
                Console.WriteLine(((i + 1) * 10000).ToString() + " tane kayıt keydedildi!");
                Console.WriteLine((finishTime1 - start1).TotalMilliseconds.ToString() + " milisaniyede\n");
                start1 = DateTime.Now;
            }

            Console.WriteLine("Tüm kayıtlar", (DateTime.Now - start).ToString() + " sürede işlendi!");

            db.CommitAsync();

            Console.WriteLine(DateTime.Now - start);
        }
    }
}