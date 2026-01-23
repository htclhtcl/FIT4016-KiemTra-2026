using System;

namespace BasicMethods
{
    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Multiply(double x, double y)
        {
            return x * y;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Tổng: " + Add(5, 3));
            Console.WriteLine("Tích: " + Multiply(2.5, 4));
        }
    }
}
