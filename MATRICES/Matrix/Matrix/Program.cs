using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {


            // DATE INTRARE
            // 2
            // 2 1 6
            // 3 1 8
            // Livada 1: 9
            // Livada 2: 12
            // Meri: 5
            // Peri: 2
            // Ciresi: 14


            string input = Console.ReadLine();
            int liveziNo = Int32.Parse(input);

            int[,] matrix = new int[liveziNo, 3];

            // insert data into matrix
            for (int i = 0; i < liveziNo; i++)
            {
                string line = Console.ReadLine();
                string[] stringNumbers = line.Split(' ');
                for (int j = 0; j < 3; j++)
                    matrix[i, j] = Int32.Parse(stringNumbers[j]);
            }

            // get total per each row
            int[] rowTotal = new int[liveziNo];
            int rowIndex = 0;
            for (int i = 0; i < liveziNo; i++)
            {
                rowIndex = i + 1;
                rowTotal[i] = 0;
                for (int j = 0; j < 3; j++)
                    rowTotal[i] += matrix[i, j];
            }

            for (int i = 0; i < rowIndex; i++)
            {
                Console.WriteLine(string.Format("Livada {0}: {1}", i + 1, rowTotal[i]));
            }

            // get total per each column
            int[] colTotal = new int[3];
            for (int j = 0; j < 3; j++)
            {
                colTotal[j] = 0;
                for (int i = 0; i < liveziNo; i++)
                    colTotal[j] += matrix[i, j];
            }


            Console.WriteLine("Meri: " + colTotal[0]);
            Console.WriteLine("Peri: " + colTotal[1]);
            Console.WriteLine("Ciresi: " + colTotal[2]);

        }
    }
}
