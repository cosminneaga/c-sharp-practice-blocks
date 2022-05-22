using System;

namespace EnglishAlphabet
{
    class Program
    {
        static void Main()
        {
            int columnNumber = Convert.ToInt32(Console.ReadLine());

            string result = string.Empty;

            while(columnNumber > 0)
            {
                if(columnNumber % 26 == 0)
                {
                    result = 'Z' + result;
                    columnNumber = (columnNumber / 26) - 1;
                }
                else
                {
                    result = (char)((columnNumber % 26) + 64) + result;
                    columnNumber = columnNumber / 26;
                }
            }

            Console.WriteLine(result);
        }
    }
}
