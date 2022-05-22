using System;

namespace ConvertToBaseTwo
{
    class Program
    {
        static void Main()
        {
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                InBazaDoi(value);
            }
            else
            {
                Console.WriteLine("Programul converteste doar numere intregi pozitive.");
            }
        }

        static void InBazaDoi(int value)
        {
            if (value > 0)
            {
                string result = "";
                const int baza = 2;

                while (value > 0)
                {
                    if (value % baza == 0)
                    {
                        result = "0" + result;
                        value /= baza;
                    }
                    else
                    {
                        result = (value % baza).ToString() + result;
                        value /= baza;
                    }
                }

                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Programul converteste doar numere intregi pozitive.");
            }
        }
    }
}
