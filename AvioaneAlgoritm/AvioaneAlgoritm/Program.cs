using System;

namespace AvioaneAlgoritm
{
    class Program
    {
        /*
         * DATE DE INTRARE
        0 0 0 0 0 0 0 0 0 0
        0 0 0 0 0 0 0 0 0 0
        0 0 0 0 0 0 0 0 0 0
        0 0 0 0 0 0 0 0 0 0
        X 0 X 0 0 0 0 0 0 0
        X X X X 0 0 0 0 0 0
        X 0 X 0 0 0 0 0 0 0
        0 0 0 0 0 0 0 0 0 0
        0 0 0 0 0 0 0 0 0 0
        0 0 0 0 0 0 0 0 0 0
        4 a
        5 a
        6 a
        10 a
        10 b
        10 c
        5 b
        4 c
        5 c
        6 c
        5 d
        10 d
        10 e
        10 f
        10 g 
        */

        /* DATE IESIRE
        doborat
        */

        static void Main()
        {
            string[,] careu = new string[10, 10];
            string[,] commands = new string[15, 2];

            
            // insert careu data into matrix
            for (int i = 0; i < careu.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                string[] lineChars = input.Split(' ');

                for(int j = 0; j < careu.GetLength(1); j++)
                {
                    careu[i, j] = lineChars[j];
                }
            }

            // insert commands into matrix
            for (int i = 0; i < commands.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                string[] lineChars = input.Split(' ');

                for (int j = 0; j < commands.GetLength(1); j++)
                {
                    commands[i, j] = lineChars[j];
                }
            }

            PrintResult(careu, commands);
        }


        

        static void PrintResult(string[,] careu, string[,] commands)
        {
            int totalNumberOfX = CountNumberOfX(careu);
            int countWhereHit = 0;
            // print commands
            for (int i = 0; i < commands.GetLength(0); i++)
            {
                string[] command = new string[2];
                command[0] = commands[i, 0];
                command[1] = commands[i, 1];
                countWhereHit += CheckMatrixAgainstCommand(command, careu);
            }

            string result = countWhereHit.ToString();
            if (countWhereHit == totalNumberOfX)
            {
                result = "doborat";
            }
            Console.WriteLine(result);
        }
       
        static int CheckMatrixAgainstCommand(string[] command, string[,] matrix)
        {
            //command[0] = 4, command[1] = a
            char[] letter = command[1].ToCharArray();

            int yAxis = matrix.GetLength(0) - Convert.ToInt32(command[0]); // 4
            int xAxis = (int)letter[0] - 97; // a

            //Console.WriteLine(matrix.GetLength(0));
            //Console.WriteLine(matrix.GetLength(1));

            //Console.WriteLine("Position search index: {0}, {1}", yAxis, xAxis);

            int countIfHit = 0;
            if(matrix[yAxis, xAxis] == 'x'.ToString())
            {
                countIfHit++;
            }
            //Console.WriteLine("Extracted value from matrix: {0}", matrix[yAxis, xAxis]);
            /*
            // print the matrix in the exact format as inserted
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.Write("\n");
            }*/


            return countIfHit;
        }

        static int CountNumberOfX(string[,] matrix)
        {

            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'x'.ToString())
                    {
                        count++;
                    }
                }
            }
            return count;
        }

    }
}
