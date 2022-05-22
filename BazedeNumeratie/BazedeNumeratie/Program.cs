using System;

namespace BazedeNumeratie
{
    class Program
    {
        // TRANSFORMARE DIN BAZA 10 IN BAZA 5
        // INPUT: 13647
        // OUTPUT: 414042
        static void Main()
        {
            int columnNumber = Convert.ToInt32(Console.ReadLine());

            string result = string.Empty;

            while (columnNumber > 0)
            {
                if (columnNumber % 5 == 0)
                {
                    result = '0' + result;
                    columnNumber = columnNumber / 5;
                }
                else
                {
                    result = columnNumber % 5 + result;
                    columnNumber = columnNumber / 5;
                }
            }

            Console.WriteLine(result);
        }
    }
}
