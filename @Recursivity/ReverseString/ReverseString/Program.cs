using System;

namespace ReverseString
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(ReverseString(input));

            static string ReverseString(string input)
            {
                if (input.Length > 0)
                {
                    return input[input.Length - 1] + ReverseString(input.Substring(0, input.Length - 1));
                }

                return input;
            }
        }
    }
}
