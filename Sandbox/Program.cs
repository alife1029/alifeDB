using System;
using alifeDB.Database;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Database myDB = new Database(@"C:\Users\alife\Desktop\mydb.alfdb");
            Console.WriteLine("Database object created!");

            myDB.AddTable(new Table("Students"));
            myDB.AddTable(new Table("Teachers"));
            myDB.AddTable(new Table("Staff"));
            myDB.AddTable(new Table("StudentMarks"));
            myDB.AddTable(new Table("Prizes"));
            Console.WriteLine("Tables appended");

            SaveSystem.SaveDB(myDB);
            Console.WriteLine("Database saved!");

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
