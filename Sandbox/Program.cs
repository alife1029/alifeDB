using System;
using alifeDB.Database;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Database myDB = new Database(@"C:\Users\alife\Desktop\mydb.alfdb", "myDB");
            Console.WriteLine("Database object created!");

            myDB.AddTable(new Table("Students", "myDB"));
            myDB.AddTable(new Table("Teachers", "myDB"));
            myDB.AddTable(new Table("Staff", "myDB"));
            myDB.AddTable(new Table("StudentMarks", "myDB"));
            myDB.AddTable(new Table("Prizes", "myDB"));
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

            Record alifegur = new Record(studentsTable, 0);
            alifegur.SetAllValues(new string[] { "ID", "Ad", "Soyad", "No", "Sınıf", "Şube" },
                                  new object[] { 0, "Ali Efe", "Gür", 247, 11, 'B' });
            Record orhunegegur = new Record(studentsTable, 1);
            orhunegegur.SetAllValues(new string[] { "ID", "Ad", "Soyad", "No", "Sınıf", "Şube" },
                                  new object[] { 1, "Orhun Ege", "Gür", 60, 7, 'H' });
            Record edagokcegur = new Record(studentsTable, 2);
            edagokcegur.SetAllValues(new string[] { "ID", "Ad", "Soyad", "No", "Sınıf", "Şube" },
                                  new object[] { 2, "Eda Gökçe", "Gür", 57, 1, 'A' });

            Console.WriteLine("Öğrenci bilgileri düzenendi");

            SaveSystem.SaveDB(myDB);
            Console.WriteLine("Veritabanı kaydedildi");

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
