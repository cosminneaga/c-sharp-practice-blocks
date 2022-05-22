using System;

namespace ToGibberish
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Console.WriteLine(TranslateToGibberish(text));
            Console.Read();
        }

        private static string TranslateToGibberish(string text)
        {
            string translatedText = "";
            foreach (char c in text)
            {
                translatedText += c;
                if (IsVowel(c))
                {
                    translatedText += "p" + c.ToString().ToLower();
                }
            }
            return translatedText;
        }

        private static bool IsVowel(char c)
        {
            return "aeiouAEIOU".IndexOf(c) != -1;
        }
    }
}
