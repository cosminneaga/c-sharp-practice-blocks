using System;
using System.Collections.Specialized;

namespace ValidateDataSudoku
{
    class Program
    {
        static void Main()
        {
            string[,] careuSudoku = new string[9, 9];
            int countRow = 0;
            int countRowOnStep = 0;

            // insert into matrix
            for (int i = 0; i < (careuSudoku.GetLength(0) + countRow); i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                int countString = 0;
                int countMatrix = 0;
                int limit = ReturnLimitNumber(input);

                if (input.Length > 1 && !CheckInputLine(input, careuSudoku.GetLength(0)))
                {
                    break;
                }

                for (int j = 0; j < (careuSudoku.GetLength(1) + limit); j++)
                {
                    if (input.Length > 1 && input[countString] != "")
                    {
                        careuSudoku[countRowOnStep, countMatrix] = input[countString];
                        countMatrix++;
                    }

                    countString++;
                }

                countRowOnStep++;

                if (input[0] == "")
                {
                    countRow++;
                    countRowOnStep--;
                }
            }

            bool check = ValidateSudokuData(careuSudoku);

            Console.WriteLine(check);
        }

        static int ReturnLimitNumber(string[] input)
        {
            const int stringPositionThree = 3;
            const int stringPositionSeven = 7;
            int count = 0;

            if (input.Length > 1 && input[stringPositionThree] == "")
            {
                count++;
            }

            if (input.Length > 1 && input[stringPositionSeven] == "")
            {
                count++;
            }

            return count;
        }

        static bool CheckInputLine(string[] lineArray, int motherMatrixSize)
        {
            string[] purged = new string[motherMatrixSize];
            int countForEntry = 0;
            int count = 0;
            if (lineArray.Length > motherMatrixSize + 1 + 1)
            {
                return false;
            }

            foreach (string s in lineArray)
            {
                if (lineArray[countForEntry] != "")
                {
                    purged[count] = lineArray[countForEntry];
                    count++;
                }

                countForEntry++;
            }

            if (count == motherMatrixSize)
            {
                return true;
            }
            else if (count > motherMatrixSize)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        static bool ValidateSudokuData(string[,] careuSudoku)
        {
            int[,] result = new int[careuSudoku.GetLength(0), careuSudoku.GetLength(1)];
            int[] countTotalOnRow = new int[careuSudoku.GetLength(0)];
            int[] rowDigits = new int[careuSudoku.GetLength(0)];
            int[] countTotalOnColumn = new int[careuSudoku.GetLength(1)];
            int[] columnDigits = new int[careuSudoku.GetLength(1)];
            const int limit = 45;

            for (int i = 0; i < careuSudoku.GetLength(0); i++)
            {
                for (int j = 0; j < careuSudoku.GetLength(1); j++)
                {
                    if (!int.TryParse(careuSudoku[i, j], out result[i, j]))
                    {
                        return false;
                    }

                    countTotalOnRow[i] += Convert.ToInt32(careuSudoku[i, j]);
                    countTotalOnColumn[i] += Convert.ToInt32(careuSudoku[j, i]);
                    rowDigits[j] = Convert.ToInt32(careuSudoku[i, j]);
                    columnDigits[j] = Convert.ToInt32(careuSudoku[j, i]);
                    result[i, j] = Convert.ToInt32(careuSudoku[i, j]);
                }

                if (ContainsDuplicates(rowDigits))
                {
                    return false;
                }
                else if (ContainsDuplicates(columnDigits))
                {
                    return false;
                }
            }

            foreach (int i in countTotalOnRow)
            {
                if (i > limit)
                {
                    return false;
                }
            }

            return VerifyFirstBlock(result);
        }

        static bool VerifyFirstBlock(int[,] careu)
        {
            int[] checkArray = new int[careu.GetLength(0)];
            const int limit = 3;
            int count = 0;
            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < limit; j++)
                {
                    checkArray[count] = careu[i, j];
                    count++;
                }
            }

            return !ContainsDuplicates(checkArray);
        }

        static bool ContainsDuplicates(int[] a)
        {
            int[] arr2 = new int[a.Length];
            int[] arr3 = new int[a.Length];
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                arr2[i] = a[i];
                arr3[i] = 0;
            }

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[i] == arr2[j])
                    {
                        arr3[j] = count;
                        count++;
                    }
                }

                count = 1;
            }

            foreach (int i in arr3)
            {
                if (i > 1)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
