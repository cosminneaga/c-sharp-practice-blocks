using System;

namespace Factorial
{
    class Program
    {
        static void Main()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Factorial(n));

            static int Factorial(int n)
            {
                if (n <= 0)
                {
                    return 1;
                }
                return n * Factorial(n - 1);
            }
        }
    }
}
