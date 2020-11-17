using System;
using Sandbox.Examples;
using Sandbox.Tests;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            // Menü
            Console.WriteLine(
                "1 - Verileri Kaydet\n" +
                "2 - Verileri Çek\n" +
                "3 - Kayıt Testi"
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
            else if (a.Key == ConsoleKey.NumPad3)
                new Save();

            // Uygulama biter
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
