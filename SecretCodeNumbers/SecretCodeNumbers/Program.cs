using System;

namespace SecretCodeNumbers
{
    class Program
    {
        // SE TRANSFORMA NUMARUL INTRODUS N DIN BAZA 10 IN BAZA 5
        // 13647 = 414042 CARE SPUNE POZITIA CARACTERELOR
        // 414042 VA FI INTRODUS DE CATRE UTILIZATOR IN FORMATUL '10ol1O' acesta pe pozitie e 413042 at unde 'o' se afla mai trebuie adaugat un 1
        static void Main()
        {
            string codeInput = Console.ReadLine();

            int[] codeTransformedIntoNumbers = ReturnCharBasedOnCharPosition(codeInput);

            const int baza = 5;
            TransformFromBase10ToBaseN(baza, codeTransformedIntoNumbers);
        }

        static int[] ReturnCharBasedOnCharPosition(string codeInput)
        {
            // 10ol1O == 302431 == 413042 must transform into 414042

            string[] code = codeInput.Split(' ');
            char[] codeCharacters = new char[] { 'l', '0', 'O', 'o', '1' };
            string[] codeCharactersTransformedIntoNumber = new string[code.Length];

            int count = 0;
            foreach(string s in code)
            {
                char[] charsOfS = s.ToCharArray();
                if(s.Length > 10)
                {
                    foreach(char c in charsOfS)
                    {
                        string position = Array.IndexOf(codeCharacters, c).ToString();
                        codeCharactersTransformedIntoNumber[count] += position;
                    }
                }
                else
                {
                    foreach(char c in charsOfS)
                    {
                        string position = Array.IndexOf(codeCharacters, c).ToString();
                        /*
                        if (position == "0")
                        {
                            codeCharactersTransformedIntoNumber[count] += Convert.ToInt32(position + 5);
                        }
                        else
                        {
                            codeCharactersTransformedIntoNumber[count] += position;
                        }*/
                        codeCharactersTransformedIntoNumber[count] += position != "0" ? position : Convert.ToInt32(position + positionOfL).ToString();
                    }
                }

            }

            int[] numbers = new int[codeCharactersTransformedIntoNumber.Length];
            int countNumbers = 0;
            foreach(string c in codeCharactersTransformedIntoNumber)
            {
                numbers[countNumbers] = Convert.ToInt32(c);
                countNumbers++;
            }

            return numbers;
        }

        static void TransformFromBase10ToBaseN(int baza, int[] numbers)
        {
            foreach(int number in numbers)
            {
                int no = number;
                string noString = no.ToString();

                int result = 0;
                int exponential = noString.Length - 1;

                // number = 413042
                foreach(char c in noString)
                {
                    int charNo = Convert.ToInt32(c.ToString());
                    result += charNo * Convert.ToInt32(Math.Pow(baza, exponential));
                    exponential--;
                }

                Console.Write(result + " ");
            }
        }

    }
}
