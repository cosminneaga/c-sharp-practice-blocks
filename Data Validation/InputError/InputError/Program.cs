using System;

namespace InputError
{
    class Program
    {
        static void Main()
        {
            if(int.TryParse(Console.ReadLine(), out int n) && n >= 0)
            {
                Console.WriteLine(Factorial(n));
            }
            else
            {
                Console.WriteLine("Introduceti un numar natural!");
            }
            Console.Read();
        }

        static double Factorial(int n)
        {
            double result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;
            return result;
        }
    }
}
