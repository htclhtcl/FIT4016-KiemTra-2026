using System;

namespace MethodOverloading
{
    class Program
    {
        static void Print(int x)
        {
            Console.WriteLine("Số: " + x);
        }

        static void Print(string text)
        {
            Console.WriteLine("Chuỗi: " + text);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Add(double a, double b)
        {
            return a + b;
        }

        static void Main(string[] args)
        {
            Print(10);
            Print("Xin chào");

            Console.WriteLine(Add(3, 4));
            Console.WriteLine(Add(2.5, 4.5));
        }
    }
}
