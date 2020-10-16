using System;
using alifeDB.Database;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database(@"C:\users\alife\Desktop\dbSave.alfdb");
            SaveSystem.LoadDB(db);

            /*try
            {
                SaveSystem.SaveDB(db);
            }
            catch (AlifeDBException ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            Console.ReadKey();
        }
    }
}
