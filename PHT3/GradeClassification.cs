using System;

namespace GradeClassification
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 75;

            if (score >= 90)
                Console.WriteLine("A (Xuất sắc)");
            else if (score >= 80)
                Console.WriteLine("B (Khá)");
            else if (score >= 70)
                Console.WriteLine("C (Trung bình)");
            else if (score >= 60)
                Console.WriteLine("D (Yếu)");
            else
                Console.WriteLine("F (Không đạt)");
        }
    }
}
