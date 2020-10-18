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

            Table studentsTable = myDB.GetTable("Students");
            Table teachersTable = myDB.GetTable("Teachers");
            Table staffTable = myDB.GetTable("Staff");
            Table marksTable = myDB.GetTable("StudentMarks");
            Table prızesTable = myDB.GetTable("Prizes");
            Console.WriteLine("Veritabanında oluşturulan tablolar GetTable() metodu ile alındı");

            studentsTable.AddColumn("ID");
            studentsTable.AddColumn("Ad");
            studentsTable.AddColumn("Soyad");
            studentsTable.AddColumn("No");
            studentsTable.AddColumn("Sınıf");
            studentsTable.AddColumn("Şube");

            Record alifegur = new Record(studentsTable);
            alifegur.SetAllValues(new string[] { "ID", "Ad", "Soyad", "No", "Sınıf", "Şube" },
                                  new object[] { 1, "Ali Efe", "Gür", 247, 11, 'B' });
            Record orhunegegur = new Record(studentsTable);
            orhunegegur.SetAllValues(new string[] { "ID", "Ad", "Soyad", "No", "Sınıf", "Şube" },
                                  new object[] { 2, "Orhun Ege", "Gür", 60, 7, 'H' });
            Record edagokcegur = new Record(studentsTable);
            edagokcegur.SetAllValues(new string[] { "ID", "Ad", "Soyad", "No", "Sınıf", "Şube" },
                                  new object[] { 3, "Eda Gökçe", "Gür", 57, 1, 'A' });

            Console.WriteLine("Öğrenci bilgileri düzenendi");

            SaveSystem.SaveDB(myDB);
            Console.WriteLine("Database saved!");

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
