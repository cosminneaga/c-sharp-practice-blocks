using System;

namespace CountTextOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            int liveziNo = Int32.Parse(input);

            int[,] matrix = new int[liveziNo, 3];

            for (int i = 0; i < liveziNo; i++)
            {
                string line = Console.ReadLine();
                string[] stringNumbers = line.Split(' ');
                for (int j = 0; j < 3; j++)
                    matrix[i, j] = Int32.Parse(stringNumbers[j]);
            }

            foreach (int number in matrix)
            {
                Console.WriteLine(number);
            }


        }
    }
}
