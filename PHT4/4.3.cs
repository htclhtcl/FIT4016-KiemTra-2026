using System;

namespace ArrayMethods
{
    class Program
    {
        static int SumArray(int[] numbers)
        {
            int sum = 0;
            foreach (int n in numbers)
                sum += n;
            return sum;
        }

        static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            foreach (int n in numbers)
                if (n > max) max = n;
            return max;
        }

        static void Main(string[] args)
        {
            int[] scores = { 85, 92, 78, 90, 88 };

            Console.WriteLine("Tổng: " + SumArray(scores));
            Console.WriteLine("Lớn nhất: " + FindMax(scores));
        }
    }
}
