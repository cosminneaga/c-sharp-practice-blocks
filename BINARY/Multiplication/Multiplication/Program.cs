using System;

namespace Multiplication
{
    class Program
    {
        const int NumericalBase = 2;

        static void Main()
        {
            byte[] valueOne = new byte[] { 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1 };
            byte[] valueTwo = new byte[] { 1, 0, 1, 0 };
            Array.Reverse(valueOne);
            Array.Reverse(valueTwo);

            byte[] multiplyResult = BinaryMultiply(valueOne, valueTwo);
            Console.WriteLine(BinaryNumberToString(multiplyResult));
        }

        static byte[] BinaryMultiply(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {
            if (firstBinaryNumber.Length > secondBinaryNumber.Length)
            {
                secondBinaryNumber = AddZerosAtBeggingForShorter(secondBinaryNumber, firstBinaryNumber.Length - secondBinaryNumber.Length);
            }
            else
            {
                firstBinaryNumber = AddZerosAtBeggingForShorter(firstBinaryNumber, secondBinaryNumber.Length - firstBinaryNumber.Length);
            }

            byte[] innerResult = new byte[firstBinaryNumber.Length];

            for (int i = 0; i < secondBinaryNumber.Length; i++)
            {
                byte[] innerNextLineResult = new byte[secondBinaryNumber.Length];

                for (int j = 0; j < firstBinaryNumber.Length; j++)
                {
                    if (i <= 0)
                    {
                        innerResult[j] = (byte)(secondBinaryNumber[i] * firstBinaryNumber[j]);
                    }
                    else
                    {
                        byte[] zeros = AddZerosForBinaryMultiply(i);
                        if (j <= 0)
                        {
                            for (int z = 0; z < zeros.Length; z++)
                            {
                                Array.Resize(ref innerNextLineResult, innerNextLineResult.Length + 1);
                                innerNextLineResult[z] = zeros[z];
                            }
                        }

                        innerNextLineResult[j + zeros.Length] = (byte)(secondBinaryNumber[i] * firstBinaryNumber[j]);
                    }
                }

                innerResult = BinaryAdd(innerResult, innerNextLineResult);
            }

            return innerResult;
        }

        static byte[] AddZerosAtBeggingForShorter(byte[] value, int zerosNumber)
        {
            Array.Reverse(value);
            byte[] retainedOriginal = value;
            for (int i = 0; i < zerosNumber; i++)
            {
                Array.Resize(ref value, value.Length + 1);
                value[i] = (byte)0;
            }

            for (int i = zerosNumber; i < retainedOriginal.Length + zerosNumber; i++)
            {
                value[i] = retainedOriginal[i - zerosNumber];
            }

            Array.Reverse(value);
            return value;
        }

        static byte[] AddZerosForBinaryMultiply(int numberOfZeros)
        {
            byte[] result = new byte[numberOfZeros];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (byte)0;
            }

            return result;
        }



        static byte[] BinaryAdd(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {
            var (shorter, longer) = GetShorterAndLongerNumber(firstBinaryNumber, secondBinaryNumber);
            byte[] result = new byte[longer.Length];
            int reminder = 0;

            for (int i = 0; i < shorter.Length; i++)
            {
                result[i] = (byte)((shorter[i] + longer[i] + reminder) % NumericalBase);
                reminder = (shorter[i] + longer[i] + reminder) / NumericalBase;
            }

            for (int i = shorter.Length; i < longer.Length; i++)
            {
                result[i] = (byte)((longer[i] + reminder) % NumericalBase);
                reminder = (longer[i] + reminder) / NumericalBase;
            }

            if (reminder == 1)
            {
                result = AddBinaryDigit(result, 1);
            }

            return result;
        }

        static (byte[] shorter, byte[] longer) GetShorterAndLongerNumber(byte[] firstBinaryNumber, byte[] secondBinaryNumber)
        {
            byte[] shorter;
            byte[] longer;

            if (firstBinaryNumber.Length > secondBinaryNumber.Length)
            {
                shorter = secondBinaryNumber;
                longer = firstBinaryNumber;
            }
            else
            {
                shorter = firstBinaryNumber;
                longer = secondBinaryNumber;
            }

            return (shorter, longer);
        }

        static byte[] AddBinaryDigit(byte[] binaryNumber, byte digit)
        {
            byte[] result = binaryNumber ?? (new byte[0]);
            Array.Resize(ref result, result.Length + 1);

            result[result.Length - 1] = digit;
            return result;
        }

        static string BinaryNumberToString(byte[] binaryNumber)
        {
            string result = "";
            bool initialZeros = true;
            for (int i = binaryNumber.Length - 1; i >= 0; i--)
            {
                if (binaryNumber[i] == 0 && initialZeros)
                {
                    continue;
                }

                initialZeros = false;
                result += binaryNumber[i];
            }

            if (result == "")
            {
                result = "0";
            }

            return result;
        }
    }
}
