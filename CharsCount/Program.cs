using System;

namespace CharsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string distinctChars = GetDistinctChars(text);
            foreach (char c in distinctChars)
            {
                Console.WriteLine(c + " " + CountCharOccurrences(text, c));
            }
            Console.ReadLine();
        }

        private static int CountCharOccurrences(string text, char charToCount)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (c == charToCount)
                {
                    count++;
                }
            }
            return count;
        }

        private static string GetDistinctChars(string text)
        {
            string result = "";
            foreach (char c in text)
            {
                if (result.IndexOf(c) == -1)
                {
                    result += c;
                }
            }
            return result;
        }
    }
}
