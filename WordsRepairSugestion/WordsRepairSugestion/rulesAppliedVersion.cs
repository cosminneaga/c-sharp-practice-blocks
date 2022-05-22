using System;

namespace Learning
{
    class Program
    {
        static void Main()
        {
            string[] inputPhrase = Console.ReadLine().Split(' ');
            int linesNo = Convert.ToInt32(Console.ReadLine());
            string[] word = new string[linesNo];

            for (int i = 0; i < linesNo; i++)
            {
                word[i] = Console.ReadLine();
            }

            Validate(inputPhrase, word);
        }

        static void Validate(string[] inputPhrase, string[] wordToCheckAgainst)
        {
            int occurences = CheckTheNumberOfSimilarWordOccurences(inputPhrase, wordToCheckAgainst);

            if (occurences < inputPhrase.Length)
            {
                for (int i = 0; i < inputPhrase.Length; i++)
                {
                    string[] validatedStringsPerWord = CheckAndReturnSimilarStrings(inputPhrase[i], wordToCheckAgainst);

                    if (validatedStringsPerWord.Length == 0)
                    {
                        Console.WriteLine(inputPhrase[i] + ": (nu sunt sugestii)");
                    }
                    else
                    {
                        PrintIfFound(inputPhrase[i], wordToCheckAgainst, validatedStringsPerWord);
                    }
                }
            }
            else
            {
                Console.WriteLine("Text corect!");
            }
        }

        static void PrintIfFound(string inputWord, string[] wordToCheckAgainst, string[] validatedStringsPerWord)
        {
            if (CheckWordIfSame(inputWord, wordToCheckAgainst))
            {
                return;
            }

            Console.Write(inputWord.ToLower() + ": ");
            foreach (string s in validatedStringsPerWord)
            {
                Console.Write(s + " ");
            }

            Console.WriteLine();
        }

        // check and return the similarity strings for each word from main array of strings
        static string[] CheckAndReturnSimilarStrings(string mainWord, string[] wordToCheckAgainst)
        {
            string[] result = new string[0];
            int count = 0;

            for (int i = 0; i < wordToCheckAgainst.Length; i++)
            {
                if (CheckIfWordsStartsWithSameLetters(mainWord, wordToCheckAgainst[i]) && CheckAndValidateLetterByLetterOccurences(mainWord, wordToCheckAgainst[i]))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[count] = wordToCheckAgainst[i];
                    count++;
                }
            }

            return result;
        }

        static bool CheckAndValidateLetterByLetterOccurences(string mainWord, string wordToCheckAgainst)
        {
            bool result = false;
            char[] main = mainWord.ToLower().ToCharArray();
            int count = 0;

            for (int i = 0; i < main.Length; i++)
            {
                if (wordToCheckAgainst.ToLower().Contains(char.ToLower(main[i])))
                {
                    count++;
                }
            }

            if (count >= wordToCheckAgainst.Length - 1)
            {
                result = true;
            }

            return result;
        }

        static bool CheckIfWordsStartsWithSameLetters(string mainWord, string wordToCheckAgainst)
        {
            char firstLetterOfMainWord = char.ToLower(mainWord[0]);
            char firstLetterOfWordToCheckAgainst = char.ToLower(wordToCheckAgainst[0]);
            const int i = 2;

            return firstLetterOfMainWord == firstLetterOfWordToCheckAgainst && wordToCheckAgainst.Length > mainWord.Length - i;
        }

        // check and count similar occurences against both arrays
        static int CheckTheNumberOfSimilarWordOccurences(string[] mainWordArray, string[] wordToCheckAgainstArray)
        {
            int result = 0;
            for (int i = 0; i < mainWordArray.Length; i++)
            {
                if (CheckWordIfSame(mainWordArray[i], wordToCheckAgainstArray))
                {
                    result++;
                }
            }

            return result;
        }

        // check
        static bool CheckWordIfSame(string mainWord, string[] wordToCheckAgainst)
        {
            bool result = false;
            for (int i = 0; i < wordToCheckAgainst.Length; i++)
            {
                if (mainWord.ToLower() == wordToCheckAgainst[i].ToLower())
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
