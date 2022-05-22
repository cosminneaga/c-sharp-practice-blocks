using System;

namespace Learning
{
    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            char[] wordChars = word.ToCharArray();
            AnalyseAndPrintResult(wordChars);
        }

        static void AnalyseAndPrintResult(char[] wordChars)
        {
            char[] distinct = GetDistinctChars(wordChars);
            int[] occurences = CountCharOccurencesByDistinct(wordChars, distinct);

            string finalString = "";
            char[] distinctCopy = distinct;
            int[] occurencesCopy = occurences;

            char checkOccurencesAgainstLength = CheckOccurencesAgainstLength(wordChars, distinct, occurences);

            if (checkOccurencesAgainstLength != '0')
            {
                Console.WriteLine(checkOccurencesAgainstLength);
            }
            else
            {
                for (int i = 0; i < wordChars.Length; i++)
                {
                    int maxIndex = FindAndReturnHighestPosition(occurencesCopy);

                    if (finalString.Length > 0)
                    {
                        // get last character inserted
                        string lastCharacther = finalString.Substring(finalString.Length - 1);

                        finalString += DestructureFunction(lastCharacther, distinctCopy, ref occurencesCopy, maxIndex);
                    }
                    else
                    {
                        finalString += distinctCopy[maxIndex];
                        occurencesCopy[maxIndex]--;
                    }
                }
            }

            Console.WriteLine(finalString);
        }

        static string DestructureFunction(string lastCharacther, char[] distinctCopy, ref int[] occurencesCopy, int maxIndex)
        {
            string result = "";

            const int oneStep = 1;
            const int twoSteps = 2;

            if (lastCharacther == distinctCopy[maxIndex].ToString())
            {
                if (occurencesCopy[maxIndex + 1] != 0)
                {
                    result += distinctCopy[maxIndex + oneStep];
                    occurencesCopy[maxIndex + oneStep]--;
                }
                else
                {
                    result += distinctCopy[maxIndex + twoSteps];
                    occurencesCopy[maxIndex + twoSteps]--;
                }
            }
            else
            {
                result += distinctCopy[maxIndex];
                occurencesCopy[maxIndex]--;
            }

            return result;
        }

        static int FindAndReturnHighestPosition(int[] values)
        {
            int max = values[0];
            for (int i = 0; i < values.Length; i++)
            {
                if (max < values[i])
                {
                    max = values[i];
                }
            }

            return Array.IndexOf(values, max);
        }

        static char CheckOccurencesAgainstLength(char[] originalCharArray, char[] distinct, int[] occurences)
        {
            char resultedLetter = '0';
            double lengthDouble = (double)originalCharArray.Length / 2.0;
            for (int i = 0; i < distinct.Length; i++)
            {
                if (occurences[i] > Math.Round(lengthDouble, 0, MidpointRounding.AwayFromZero))
                {
                    resultedLetter = distinct[i];
                }
            }

            return resultedLetter;
        }

        static int[] CountCharOccurencesByDistinct(char[] array, char[] distinct)
        {
            int[] occurences = new int[distinct.Length];
            int count = 0;
            int countLetter = 1;
            foreach (char a in distinct)
            {
                foreach (char c in array)
                {
                    if (c == a)
                    {
                        occurences[count] = countLetter;
                        countLetter++;
                    }
                }

                count++;
                countLetter = 1;
            }

            return occurences;
        }

        static char[] GetDistinctChars(char[] array)
        {
            string result = "";
            foreach (char c in array)
            {
                if (result.IndexOf(c) == -1)
                {
                    result += c;
                }
            }

            return result.ToCharArray();
        }
    }
}
