using Microsoft.VisualBasic.CompilerServices;
using System;

namespace ConvertBaseTwoAndTen
{
    class Program
    {
        /*
         * Date de intrare
         * 1(transforma in baza 2) 45
         * 2 (transforma din baza 2 in baza 10) 100011011
         * 3 (1000101 NOT) = 0111010
        */
        static void Main()
        {
            int method = Convert.ToInt32(Console.ReadLine());
            string input = Console.ReadLine();


            ValidateInput(method, input);
        }


        static void ValidateInput(int method, string valueToCheck)
        {
            const int toBase2 = 1;
            const int toBase10 = 2;
            const int NOT = 3;
            const int OR = 4;
            const int AND = 5;

            if (method == toBase2)
            {
                if(int.TryParse(valueToCheck, out int value))
                {
                    InBazaDoi(value);
                }
                else
                {
                    Console.WriteLine("Programul converteste doar numere intregi pozitive.");
                }
            }
            else if (method == toBase10 || method == NOT)
            {
                if (CheckIfBinary(valueToCheck))
                {
                    DirectToFunctions(method, valueToCheck);
                }
                else
                {
                    Console.WriteLine("Nu s-a introdus un numar binar valid (format doar din 0 si 1).");
                }
            }
            else if (method == OR || method == AND)
            {
                string secondValueToCheckAgainst = Console.ReadLine();
                if (CheckIfBinary(valueToCheck) && CheckIfBinary(secondValueToCheckAgainst))
                {
                    CalculateORorANDForBinary(method, valueToCheck, secondValueToCheckAgainst);
                }
                else
                {
                    Console.WriteLine("Nu s-a introdus un numar binar valid (format doar din 0 si 1).");
                }
            }
            else
            {
                Console.WriteLine("Operatie invalida.");
            }
        }

        static void DirectToFunctions(int method, string firstValue)
        {
            const int toBase10 = 2;
            const int NOT = 3;

            if (method == toBase10)
            {
                InBazaZece(firstValue);
            }
            else if (method == NOT)
            {
                CalculateNOTForBinary(firstValue);
            }
        }

        static void CalculateORorANDForBinary(int method, string first, string second)
        {
            string result = "";
            if (first.Length > second.Length)
            {
                string firstEnd = first.Substring(first.Length - second.Length);
                result += ForLoopForOR(method, firstEnd, second);
                result = first.Substring(0, first.Length - firstEnd.Length) + result;
            }
            else if (second.Length > first.Length)
            {
                string secondEnd = second.Substring(second.Length - first.Length);
                result += ForLoopForOR(method, first, secondEnd);
                result = second.Substring(0, second.Length - secondEnd.Length) + result;
            }
            else
            {
                result += ForLoopForOR(method, first, second);
            }

            Console.WriteLine(result);
        }

        static string ForLoopForOR(int method, string first, string second)
        {
            string result = "";
            const string one = "1";
            const string zero = "0";
            const int OR = 4;
            const int AND = 5;

            for (int i = 0; i < first.Length; i++)
            {
                if (method == OR)
                {
                    result += first[i] == '0' && second[i] == '0' ? zero : one;
                }
                else if (method == AND)
                {
                    result += first[i] == '1' && second[i] == '1' ? one : zero;
                }
            }

            return result;
        }

        static void CalculateNOTForBinary(string value)
        {
            char[] charValue = value.ToCharArray();
            const int magicNo = 18;
            int count = 0;
            foreach (char c in charValue)
            {
                charValue[count] = c == '0' ? '1' : '0';
                count++;
            }

            string stringResult = "";
            string firstPart = "";
            string secondPart = "";

            foreach (char c in charValue)
            {
                stringResult += c;
            }

            if (stringResult.Length > magicNo)
            {
                firstPart = stringResult.Substring(0, magicNo);
                secondPart = stringResult.Substring(magicNo, stringResult.Length - magicNo);
                ulong fortPart = ulong.Parse(firstPart);
                string hello = fortPart.ToString();

                Console.Write(hello + secondPart);
            }
            else
            {
                Console.WriteLine(ulong.Parse(stringResult));
            }
        }

        static void InBazaZece(string valueToCalculate)
        {
            int result = 0;
            const int baza = 2;
            char[] binaryValue = valueToCalculate.ToCharArray();
            Array.Reverse(binaryValue);

            for(int i = 0; i < binaryValue.Length; i++)
            {
                int singleValue = int.Parse(binaryValue[i].ToString());
                result = (int)(singleValue * Math.Pow(baza, i) + result);
            }

            Console.WriteLine(result);
        }
        

        static void InBazaDoi(int value)
        {
            string result = "";
            const int baza = 2;
            if (value > 0)
            {
                while (value > 0)
                {
                    if (value % baza == 0)
                    {
                        result = "0" + result;
                        value /= baza;
                    }
                    else
                    {
                        result = (value % baza).ToString() + result;
                        value /= baza;
                    }
                }
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Programul converteste doar numere intregi pozitive.");
            }
        }


        static bool CheckIfBinary(string value)
        {
            bool result = true;
            foreach (char s in value)
            {
                if (s != '0' && s != '1')
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
