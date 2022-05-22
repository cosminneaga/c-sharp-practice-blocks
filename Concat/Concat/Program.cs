using System;

namespace Concat
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "ianuarie", "februarie", "martie", "aprilie", "mai", "iunie",
                "iulie", "august", "septembrie", "octombrie", "noiembrie", "decembrie"};

            string day = Console.ReadLine();
            string month = months[Convert.ToInt32(Console.ReadLine()) - 1];
            string year = Console.ReadLine();

            PrintDate(day, month, year, Console.ReadLine());
            Console.Read(); ;
        }

        static void PrintDate(string day, string month, string year, string option)
        {

            switch (option)
            {
                case "1":
                    Console.WriteLine(Concat(day, month));
                    break;
                case "2":
                    Console.WriteLine(Concat(month, year));
                    break;
                case "3":
                    Console.WriteLine(Concat(day, month, year));
                    break;
            }

        }

        static string Concat(params string[] words)
        {
            string date = string.Empty;
            for(int i =0; i < words.Length; i++)
            {
                date += words[i]+" ";
            }
            return date;
        }
    }
}
