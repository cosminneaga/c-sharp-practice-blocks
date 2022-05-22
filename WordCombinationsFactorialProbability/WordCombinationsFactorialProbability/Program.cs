using System;

namespace WordCombinationsFactorialProbability
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] occurencesArray = CountOccurences(input, removeDuplicate(input.ToCharArray()));
            Compute(input.Length, occurencesArray);

            //Console.WriteLine(factorial(52));
        }
        static char[] removeDuplicate(char[] str)
        {
            int index = 0;

            for (int i = 0; i < str.Length; i++)
            {
                int j;
                for (j = 0; j < i; j++)
                {
                    if (str[i] == str[j])
                    {
                        break;
                    }
                }
                if (j == i)
                {
                    str[index++] = str[i];
                }
            }

            char[] ans = new char[index];
            Array.Copy(str, ans, index);
            return ans;

        }


        static int[] CountOccurences(string text, char[] distinct)
        {
            int[] occurences = new int[distinct.Length];
            int count = 0;
            foreach (char c in distinct)
            {
                occurences[count] = text.Split(c).Length - 1;
                count++;
            }


            return occurences;

        }
        
        static void Compute(int total, int[] occurencesArray)
        {
            double factorialResultTotalLetters = factorial(total);

            double resultOcc = 1;
            foreach (int i in occurencesArray)
            {
                resultOcc = resultOcc * factorial(i);
            }

            if(factorialResultTotalLetters > resultOcc)
                Console.WriteLine(factorialResultTotalLetters / resultOcc);
            else
                Console.WriteLine(resultOcc / factorialResultTotalLetters);
        }

        static double factorial(int n)
        {
            double fact = n;
            for (int i = 1; i < n; i++)
            {
                fact = fact * (double)i;
            }
            return fact;
        }

    }
}
