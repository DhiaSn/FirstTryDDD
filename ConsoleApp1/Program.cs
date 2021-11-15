using System;

namespace ConsoleApp1
{
    enum DbMode { None, Debug, Release }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World! {DbMode.Release}");
            Console.ReadKey(); 
        }
    }
}
