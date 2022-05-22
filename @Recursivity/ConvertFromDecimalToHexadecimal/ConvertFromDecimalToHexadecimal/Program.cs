using System;

namespace ConvertFromDecimalToHexadecimal
{
    enum BaseLetters
    {
        A = 10,
        B = 11,
        C = 12,
        D = 13,
        E = 14,
        F = 15
    }

    class Program
    {
        static void Main()
        {
            string[] stringNumbers = ConvertRecursive(459238459238459238).Split(':');
            stringNumbers = stringNumbers[0..(stringNumbers.Length - 1)];
            Console.WriteLine(ReturnBase16Number(stringNumbers));
        }

        static string ConvertRecursive(ulong value)
        {
            if (value <= 0)
            {
                return "";
            }

            return ConvertRecursive(value / 16) + value % 16 + ":";
        } 

        static string ReturnBase16Number(string[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                foreach (BaseLetters letter in Enum.GetValues(typeof(BaseLetters)))
                {
                    if (int.Parse(numbers[i]) == (int)letter)
                    {
                        numbers[i] = Convert.ToString(letter);
                        break;
                    }
                }
            }

            string result = "";
            foreach (string c in numbers)
            {
                result += c;
            }

            return result;
        }
    }
}
