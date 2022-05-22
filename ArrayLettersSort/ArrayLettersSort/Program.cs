using System;
using System.Threading;

namespace ArrayLettersSort
{
    class Program
    {
        // Entry Data: tttesst Resulted: tetstst
        // Entry Data: aaaabc  Resulted: a
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            char[] wordChars = word.ToCharArray();

            AnalyseAndPrintResult(wordChars);
        }

        static void AnalyseAndPrintResult(char[] wordChars)
        {
            char[] distinct = GetDistinctChars(wordChars);
            int[] occurences = CountCharOccurencesByDistinct(wordChars, distinct);


            //Console.WriteLine(lengthDouble);
            //Console.WriteLine(Math.Round(lengthDouble, 0, MidpointRounding.AwayFromZero));

            char checkOccurencesAgainstLength = CheckOccurencesAgainstLength(wordChars, distinct, occurences);

            string finalString = "";
            char[] distinctCopy = distinct;
            int[] occurencesCopy = occurences;

            if (checkOccurencesAgainstLength != '0')
            {
                Console.WriteLine(checkOccurencesAgainstLength);
            }
            else
            {
                for (int i = 0; i < wordChars.Length; i++)
                {
                    // get the index for the letter with many appearences
                    int maxIndex = FindAndReturnHighestPosition(occurencesCopy);



                    if (finalString.Length > 0)
                    {
                        // get last character inserted
                        string lastCharacther = finalString.Substring(finalString.Length - 1);

                        if (lastCharacther == distinctCopy[maxIndex].ToString())
                        {
                            if (occurencesCopy[maxIndex + 1] != 0)
                            {
                                finalString += distinctCopy[maxIndex + 1];
                                occurencesCopy[maxIndex + 1]--;
                            }
                            else
                            {
                                finalString += distinctCopy[maxIndex + 2];
                                occurencesCopy[maxIndex + 2]--;
                            }
                        }
                        else
                        {
                            finalString += distinctCopy[maxIndex];
                            occurencesCopy[maxIndex]--;
                        }

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

        static int FindAndReturnHighestPosition(int[] values)
        {
            int min = values[0];
            int max = values[0];
            for(int i = 0; i < values.Length; i++)
            {
                if (min > values[i])
                    min = values[i]; // get min value
                else if (max < values[i])
                    max = values[i]; // get max value
            }

            int maxIndex = Array.IndexOf(values, max);
            int minIndex = Array.IndexOf(values, min);

            return maxIndex;
        }

        static char CheckOccurencesAgainstLength(char[] originalCharArray, char[] distinct, int[] occurences)
        {
            char resultedLetter = '0';
            double lengthDouble = (double)originalCharArray.Length / 2.0;
            for (int i = 0; i < distinct.Length; i++)
            {
                if (occurences[i] > (Math.Round(lengthDouble, 0, MidpointRounding.AwayFromZero)))
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
            foreach(char a in distinct)
            {
                foreach (char c in array)
                {
                    if(c == a)
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
            foreach(char c in array)
            {
                if(result.IndexOf(c) == -1)
                {
                    result += c;
                }
            }
            char[] final = result.ToCharArray();
            return final;
        }

    }
}