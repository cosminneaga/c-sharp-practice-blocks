using System;

namespace FibonacciSequence
{
    class Program
    {
        static void Main()
        {
            int n = 6;
            Console.WriteLine(Fibonacci(n));

            static int Fibonacci(int n)
            {
                if (n < 2) return n;
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
    }
}
