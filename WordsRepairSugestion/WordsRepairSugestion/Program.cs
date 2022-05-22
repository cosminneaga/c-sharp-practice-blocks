using System;

namespace WordsRepairSugestion
{
    class Program
    {
        /*  string[] inputPhrase = "Acetsa e un texzt excelent da tet".Split(' ');
            int linesNo = Convert.ToInt32(Console.ReadLine());
            string[] word = "acesta e un text de test".Split(' ');
         * 
         */
        static void Main()
        {
            string[] inputPhrase = Console.ReadLine().Split(' ');
            int linesNo = Convert.ToInt32(Console.ReadLine());
            string[] word = new string[linesNo];

            for(int i = 0; i < linesNo; i++)
            {
                word[i] = Console.ReadLine();
            }

            Check(inputPhrase, word);

        }

        // check input array against words array
        static void Check(string[] inputPhrase, string[] wordToCheckAgainst)
        {
            int occurences = CheckTheNumberOfSimilarWordOccurences(inputPhrase, wordToCheckAgainst);

            if(occurences < inputPhrase.Length)
            {
                for (int i = 0; i < inputPhrase.Length; i++)
                {
                    string[] validatedStringsPerWord = CheckAndReturnSimilarStrings(inputPhrase[i], wordToCheckAgainst);
                    int length = validatedStringsPerWord.Length;

                    if(length == 0)
                    {
                        Console.WriteLine(inputPhrase[i] + ": (nu sunt sugestii)");
                    }
                    else
                    {
                        if (!CheckWordIfSame(inputPhrase[i], wordToCheckAgainst))
                        {
                            Console.Write(inputPhrase[i].ToLower() + ": ");
                            foreach (string s in validatedStringsPerWord)
                            {
                                Console.Write(s + " ");
                            }

                            Console.WriteLine();
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("Text corect!");
            }
            
        }

        // check and return the similarity strings for each word from main array of strings
        static string[] CheckAndReturnSimilarStrings(string mainWord, string[] wordToCheckAgainst)
        {
            string[] result = new string[0];
            int count = 0;

            for (int i = 0; i < wordToCheckAgainst.Length; i++)
            {
                
                if(CheckIfWordsStartsWithSameLettersAndLengthIsNotSmallerThanTwoCharacters(mainWord, wordToCheckAgainst[i]) && CheckAndValidateLetterByLetterOccurences(mainWord, wordToCheckAgainst[i]))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[count] = wordToCheckAgainst[i];
                    count++;
                    CheckAndValidateLetterByLetterOccurences("texzt", "text");
                }

            }

            return result;
        }
        
        static bool CheckAndValidateLetterByLetterOccurences(string mainWord, string wordToCheckAgainst)
        {
            bool result = false;
            char[] main = mainWord.ToCharArray();
            int count = 0;
            // mainWord = acetsa
            for(int i = 0; i < main.Length; i++)
            {
                if (wordToCheckAgainst.Contains(Char.ToLower(main[i])))
                {
                    count++;
                }
            }

            if (count >= main.Length - 1)
                result = true;

            return result;
        }

               
        static bool CheckIfWordsStartsWithSameLettersAndLengthIsNotSmallerThanTwoCharacters(string mainWord, string wordToCheckAgainst)
        {
            char firstLetterOfMainWord = Char.ToLower(mainWord[0]);
            char firstLetterOfWordToCheckAgainst = Char.ToLower(wordToCheckAgainst[0]);
            //char lastLetterOfMainWord = Char.ToLower(mainWord[mainWord.Length - 1]);
            //char lastLetterOfWordToCheckAgainst = Char.ToLower(wordToCheckAgainst[wordToCheckAgainst.Length - 1]);

            return firstLetterOfMainWord == firstLetterOfWordToCheckAgainst && wordToCheckAgainst.Length > mainWord.Length - 2;
        }

        // check and count similar occurences against both arrays
        static int CheckTheNumberOfSimilarWordOccurences(string[] mainWordArray, string[] wordToCheckAgainstArray)
        {
            int result = 0;
            for(int i = 0; i < mainWordArray.Length; i++)
            {
                if(CheckWordIfSame(mainWordArray[i], wordToCheckAgainstArray))
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
            for(int i = 0; i < wordToCheckAgainst.Length; i++)
            {
                if(mainWord == wordToCheckAgainst[i])
                {
                    result = true;
                }
            }

            return result;
        }

        /*static int FindAndReturnHighestPositionInArray(int[] values)
        {
            int min = values[0];
            int max = values[0];
            for (int i = 0; i < values.Length; i++)
            {
                if (min > values[i])
                    min = values[i]; // get min value
                else if (max < values[i])
                    max = values[i]; // get max value
            }

            int maxIndex = Array.IndexOf(values, max);
            int minIndex = Array.IndexOf(values, min);

            return maxIndex;
        }*/

    }
}
