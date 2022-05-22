using System;

namespace ConvertHexadecimalToDecimal
{
    enum BaseLetters
    {
        A = 10,
        B = 11,
        C = 12,
        D = 13,
        E = 14,
        F = 15
    }

    class Program
    {
        static void Main()
        {
            string inputValue = Console.ReadLine();
            int[] returnedIntArrayFromStringInput = GetIntValuesArray(inputValue);
            Console.WriteLine(RecursiveFunctionToComputeBase16ToBase10(returnedIntArrayFromStringInput, result: 0, returnedIntArrayFromStringInput.Length));
        }

        static ulong RecursiveFunctionToComputeBase16ToBase10(int[] arrayNumbers, ulong result, int count)
        {
            if (count <= 0)
            {
                return result;
            }

            return result + RecursiveFunctionToComputeBase16ToBase10(arrayNumbers, (ulong)(arrayNumbers[count - 1] * (int)Math.Pow(16, count - 1)), count - 1);
        }

        static int[] GetIntValuesArray(string stringValue)
        {
            char[] valueCharArray = stringValue.ToCharArray();
            int[] result = new int[valueCharArray.Length];

            for (int i = 0; i < result.Length; i++)
            {
                if (char.IsLetter(valueCharArray[i]))
                {
                    result[i] = SearchEnumForValue(valueCharArray[i]);
                    continue;
                }

                result[i] = int.Parse(stringValue[i].ToString());
            }

            Array.Reverse(result);
            return result;
        }

        static int SearchEnumForValue(char letterToCheckAgainst)
        {
            int result = 0;
            foreach (BaseLetters letter in Enum.GetValues(typeof(BaseLetters)))
            {
                if (letterToCheckAgainst.ToString() == letter.ToString())
                {
                    result = (int)letter;
                }
            }

            return result;
        }
    }
}
