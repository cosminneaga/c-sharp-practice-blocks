using System;

namespace BatoaneCiocolata
{
    public class Program
    {
        static void Main()
        {
            int strips = int.Parse(Console.ReadLine());
            int[] ciocolatePackages = new int[] { 1, 2, 3, 5, 10 };
            Console.WriteLine(GetNumberOfPackages(strips, ciocolatePackages));
        }

        static int GetNumberOfPackages(int ciocolateStrips, int[] packages)
        {
            if (ciocolateStrips == 0)
            {
                return 0;
            }

            return ciocolateStrips / packages[GetHighestValueIndex(ciocolateStrips, packages)] + 
                GetNumberOfPackages(
                    ciocolateStrips % packages[GetHighestValueIndex(ciocolateStrips, packages)],
                    RemoveElementFromArrayAtGivenIndex(packages, GetHighestValueIndex(ciocolateStrips, packages)));
        }

        public static int GetHighestValueIndex(int number, int[] arrayNumbersToCompare)
        {
            int index = 0;
            for (int i = 0; i < arrayNumbersToCompare.Length; i++)
            {
                if (number >= arrayNumbersToCompare[i])
                {
                    index = Array.IndexOf(arrayNumbersToCompare, arrayNumbersToCompare[i]);
                }
            }

            return index;
        }

        public static int[] RemoveElementFromArrayAtGivenIndex(int[] arrayNumbers, int indexToRemove)
        {
            int[] result = new int[arrayNumbers.Length - 1];

            int countForResult = 0;
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                if (Array.IndexOf(arrayNumbers, arrayNumbers[i]) != indexToRemove)
                {
                    result[countForResult] = arrayNumbers[i];
                    countForResult++;
                }
            }

            return result;
        }
    }
}
