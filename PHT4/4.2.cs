using System;

namespace VoidMethods
{
    class Program
    {
        static void PrintBox(string text)
        {
            Console.WriteLine("***********");
            Console.WriteLine("* " + text + "   *");
            Console.WriteLine("***********");
        }

        static void Main(string[] args)
        {
            PrintBox("Hello");
            PrintBox("C#");
        }
    }
}
