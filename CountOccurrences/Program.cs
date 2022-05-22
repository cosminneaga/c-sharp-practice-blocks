using System;

namespace CountOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberToFind = Convert.ToInt32(Console.ReadLine());

            int count = 0;
            string line = Console.ReadLine();

            while (line != "x")
            {
                
                int number = Convert.ToInt32(line);
                if (number == numberToFind)
                {
                    count++;
                }
                line = Console.ReadLine();
            }

            Console.WriteLine(numberToFind * count);
        }
    }
}
