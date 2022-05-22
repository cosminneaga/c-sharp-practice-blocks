using System;

namespace ConvertDecimalToBinary
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(ConvertToBinary(14));

            static string ConvertToBinary(int number)
            {
                if (number == 0)
                {
                    return "";
                }

                return ConvertToBinary(number / 2) + (number % 2);
            }
        }
    }
}
