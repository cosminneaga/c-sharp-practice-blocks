using System;

namespace PascalTriangle
{
    class Program
    {
        static void Main()
        {
            ulong rows = ulong.Parse(Console.ReadLine());

            if (rows == 0)
            {
                Console.WriteLine(0);
            }

            for (ulong i = 0; i < rows; i++)
            {
                for (ulong j = 0; j <= i; j++)
                {
                    Console.Write(TriangleComputation(i, j) + " ");
                }

                Console.WriteLine();
            }
        }

        static ulong TriangleComputation(ulong row, ulong col)
        {
            return Factorial(row) / (Factorial(col) * Factorial(row - col));
        }

        static ulong Factorial(ulong n)
        {
            if (n == 1 || n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
