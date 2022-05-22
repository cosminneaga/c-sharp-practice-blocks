using System;

namespace Sudoku
{
    class Program
    {
        const int SudokuBoardSize = 9;
        const int SudokuBlockSize = 3;

        static void Main()
        {
            byte[,] sudokuBoard = new byte[SudokuBoardSize, SudokuBoardSize];
            Console.WriteLine(ReadSudokuBoard(sudokuBoard) && IsValidSudokuBoard(sudokuBoard));
            Console.Read();
        }

        static bool IsValidSudokuBoard(byte[,] sudokuBoard)
        {
            for (int i = 0; i < SudokuBoardSize; i++)
            {
                if (!IsValidSudokuItem(sudokuBoard, "line", i) ||
                    !IsValidSudokuItem(sudokuBoard, "column", i) ||
                    !IsValidSudokuItem(sudokuBoard, "block", i))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsValidSudokuItem(byte[,] sudokuBoard, string itemType, int itemIndex)
        {
            byte[] sudokuValuesCount = new byte[SudokuBoardSize];

            for (int i = 0; i < SudokuBoardSize; i++)
            {
                byte sudokuValue = GetSudokuValue(sudokuBoard, itemType, itemIndex, i);
                sudokuValuesCount[sudokuValue - 1]++;
                if (itemType == "line" && sudokuValuesCount[sudokuValue - 1] > 1)
                {
                    Console.WriteLine("Elementul {0} apare de mai multe ori pe linia {1}", sudokuValue, itemIndex + 1);
                    return false;
                }

                if (itemType == "column" && sudokuValuesCount[sudokuValue - 1] > 1)
                {
                    Console.WriteLine("Elementul {0} apare de mai multe ori pe coloana {1}", sudokuValue, itemIndex + 1);
                    return false;
                }

                if (itemType == "block" && sudokuValuesCount[sudokuValue - 1] > 1)
                {
                    Console.WriteLine("Elementul {0} apare de mai multe ori in blocul {1}", sudokuValue, itemIndex + 1);
                    return false;
                }
            }

            return true;
        }

        static byte GetSudokuValue(byte[,] sudokuBoard, string itemType, int itemIndex, int position)
        {
            switch (itemType)
            {
                case "line":
                    return sudokuBoard[itemIndex, position];
                case "column":
                    return sudokuBoard[position, itemIndex];
                case "block":
                    int line = itemIndex / SudokuBlockSize * SudokuBlockSize + position / SudokuBlockSize;
                    int column = itemIndex % SudokuBlockSize * SudokuBlockSize + position % SudokuBlockSize;
                    return sudokuBoard[line, column];
            }

            return 0;
        }

        static bool ReadSudokuBoard(byte[,] sudokuBoard)
        {
            for (int i = 0; i < SudokuBoardSize; i++)
            {
                string[] lineValues = ReadLineValues();
                if (lineValues.Length != SudokuBoardSize)
                {
                    Console.WriteLine(lineValues.Length < SudokuBoardSize ? "Sunt sub 9 elemente pe linia {0}" : "Sunt mai mult de 9 elemente pe linia {0}", i + 1);
                    return false;
                }

                for (int j = 0; j < SudokuBoardSize; j++)
                {
                    if (!IsValidSudokuValue(lineValues[j], out int value))
                    {
                        Console.WriteLine("Element invalid pe linia {0}: {1}", i + 1, lineValues[j]);
                        return false;
                    }

                    sudokuBoard[i, j] = (byte)value;
                }
            }

            return true;
        }

        static string[] ReadLineValues()
        {
            string line;
            do
            {
                line = Console.ReadLine();
            }
            while (line == "");

            return line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }

        static bool IsValidSudokuValue(string stringValue, out int value)
        {
            if (!int.TryParse(stringValue, out value))
            {
                return false;
            }

            if (value < 1 || value > SudokuBoardSize)
            {
                return false;
            }

            return true;
        }
    }
}
