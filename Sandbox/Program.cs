using System;
using Sandbox.Examples;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            // Menü
            Console.WriteLine(
                "1 - Verileri Kaydet\n" +
                "2 - Verileri Çek"
            );

            // Basılan tuşu algılar
            ConsoleKeyInfo a = Console.ReadKey();
            Console.WriteLine("\n");
            // Verileri kaydeder
            if (a.Key == ConsoleKey.NumPad1)
                new SaveData();
            // Verileri Çeker
            else if (a.Key == ConsoleKey.NumPad2)
                new FetchData();

            // Uygulama biter
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
