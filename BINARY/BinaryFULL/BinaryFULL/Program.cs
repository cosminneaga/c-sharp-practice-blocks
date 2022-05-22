using System;

namespace BinaryFULL
{
    class Program
    {
        static void Main()
        {
            int method = Convert.ToInt32(Console.ReadLine());
            string input = Console.ReadLine();
            const int toBase2 = 1;
            const int toBase10 = 2;
            const int NOT = 3;
            const int OR = 4;
            const int XOR = 6;
            const int moveLeft = 7;
            const int moveRight = 8;
            const int compareLess = 9;
            const int compareNotEqual = 12;
            const int addBinary = 13;
            const int substractBinary = 14;

            switch (method)
            {
                case int n when n >= toBase2 && n <= toBase10:
                    ValidateAndDirectInputToBaseFunctions(method, input);
                    break;
                case NOT:
                    ValidateAndDirectInputToNOT(input);
                    break;
                case int n when n >= OR && n <= XOR:
                    ValidateAndDirectInputToORANDXOR(method, input);
                    break;
                case int n when n >= moveLeft && n <= moveRight:
                    ValidateAndDirectInputToMove(method, input);
                    break;
                case int n when n >= compareLess && n <= compareNotEqual:
                    ValidateAndDirectInputToCompare(method, input);
                    break;
                case int n when n >= addBinary && n <= substractBinary:
                    ValidateAndDirectInputToAddandDivide(method, input);
                    break;
                default:
                    Console.WriteLine("Operatie invalida.");
                    break;
            }
        }

        // DATA VALIDATION FUNCTIONS AND DATA REDIRECT SECTION
        static void ValidateAndDirectInputToBaseFunctions(int method, string value)
        {
            const string convertError = "Programul converteste doar numere intregi pozitive.";
            const int toBase10 = 2;

            if (method == 1 && ValidateInteger(value, out int returnedValue))
            {
                InBazaDoi(returnedValue, convertError);
            }
            else if (method == toBase10)
            {
                string base10String = CheckIfBinary(value);
                if (base10String != null)
                {
                    InBazaZece(base10String);
                }
            }
        }

        static void ValidateAndDirectInputToNOT(string value)
        {
            string notBinaryValue = CheckIfBinary(value);
            if (notBinaryValue == null)
            {
                return;
            }

            CalculateNOTForBinary(value);
        }

        static void ValidateAndDirectInputToORANDXOR(int method, string firstValue)
        {
            const int OR = 4;
            string checkedFirstValue = CheckIfBinary(firstValue);
            string checkedSecondValue = CheckIfBinary(Console.ReadLine());

            if (checkedFirstValue == null || checkedSecondValue == null)
            {
                return;
            }

            if (method == OR)
            {
                CalculateORForBinary(checkedFirstValue, checkedSecondValue);
            }
            else
            {
                CalculateANDandXORForBinary(method, checkedFirstValue, checkedSecondValue);
            }
        }

        static void ValidateAndDirectInputToMove(int method, string value)
        {
            string firstValue = CheckIfBinary(value);
            if (firstValue == null)
            {
                return;
            }

            if (!int.TryParse(Console.ReadLine(), out int returnedInt) || returnedInt < 0)
            {
                Console.WriteLine("Numarul de pozitii trebuie sa fie intreg si pozitiv.");
                return;
            }

            MoveLeftORRight(method, firstValue, returnedInt);
        }

        static void ValidateAndDirectInputToCompare(int method, string value)
        {
            string firstValue = CheckIfBinary(value);
            string secondValue = CheckIfBinary(Console.ReadLine());
            if (firstValue == null || secondValue == null)
            {
                return;
            }

            CompareEqualNotequalGreaterthanLessThan(method, firstValue, secondValue);
        }

        static void ValidateAndDirectInputToAddandDivide(int method, string value)
        {
            const int addBinary = 13;
            string firstValue = CheckIfBinary(value);
            string secondValue = CheckIfBinary(Console.ReadLine());
            if (firstValue == null || secondValue == null)
            {
                return;
            }

            if (method == addBinary)
            {
                AddBinary(firstValue, secondValue);
            }
            else
            {
                SubstractBinary(firstValue, secondValue);
            }
        }// DATA VALIDATION FUNCTIONS AND DATA REDIRECT SECTION ENDS

        static void SubstractBinary(string firstValue, string secondValue)
        {
            if (firstValue.Length > secondValue.Length)
            {
                secondValue = ZerosForLoop(firstValue.Length - secondValue.Length) + secondValue;
            }
            else
            {
                firstValue = ZerosForLoop(secondValue.Length - firstValue.Length) + firstValue;
            }

            if (string.Compare(secondValue, firstValue) == 1)
            {
                string hold = firstValue;
                firstValue = secondValue;
                secondValue = hold;
            }

            string result = "";
            char[] first = firstValue.ToCharArray();
            char[] second = secondValue.ToCharArray();
            Array.Reverse(first);
            Array.Reverse(second);

            int count = 0;
            int length = first.Length;
            for (int i = 0; i < length; i++)
            {
                int numberOne = int.Parse(first[count].ToString());
                int numberTwo = int.Parse(second[count].ToString());

                int substract = numberOne - numberTwo;

                if (substract == -1)
                {
                    char[] startSliceWhereOccurs = first[count..];
                    char[] slicedArray = startSliceWhereOccurs[0..(Array.IndexOf(startSliceWhereOccurs, '1') + 1)];

                    char[] preResult = ModifyArrayForSubstraction(slicedArray);
                    int b = count;
                    foreach (char c in preResult)
                    {
                        first[b++] = c;
                    }

                    length++;
                    continue;
                }

                int noOneAfter = int.Parse(first[count].ToString());

                int substractAfter = noOneAfter - numberTwo;

                result = substractAfter.ToString() + result;

                count++;
            }

            Console.WriteLine(RemoveZerosBefore(result));
        }

        static char[] ModifyArrayForSubstraction(char[] array)
        {
            int stopIndex = Array.IndexOf(array, '1');

            char[] finalArray = new char[array.Length];
            finalArray[0] = '2';

            for (int i = 1; i < finalArray.Length - 1; i++)
            {
                finalArray[i] = '1';
            }

            finalArray[stopIndex] = '0';

            return finalArray;
        }

        static void CompareEqualNotequalGreaterthanLessThan(int method, string firstValue, string secondValue)
        {
            if (firstValue.Length > secondValue.Length)
            {
                secondValue = ZerosForLoop(firstValue.Length - secondValue.Length) + secondValue;
            }
            else
            {
                firstValue = ZerosForLoop(secondValue.Length - firstValue.Length) + firstValue;
            }

            const int notEqual = 12;
            int methodSelected = 0;
            int[] methodArray = new[] { 9, 10, 11 };
            int[] valuesToCompare = new[] { -1, 1, 0 };
            foreach (int i in methodArray)
            {
                if (method == i)
                {
                    methodSelected = i;
                }
            }

            int index = Array.IndexOf(methodArray, methodSelected);

            bool result = false;
            if (method == notEqual)
            {
                result = firstValue != secondValue;
            }
            else if (string.Compare(firstValue, secondValue) == valuesToCompare[index])
            {
                result = true;
            }

            Console.WriteLine(result);
        }

        static void MoveLeftORRight(int method, string binaryValue, int positionNumber)
        {
            const int moveLeft = 7;
            const int moveRight = 8;
            int remove = positionNumber;

            string zeros = ZerosForLoop(positionNumber);
            string result = binaryValue;
            if (method == moveLeft)
            {
                result += zeros;
            }

            if (method == moveRight && positionNumber < binaryValue.Length)
            {
                result = result.Substring(0, result.Length - remove);
            }
            else if (positionNumber >= binaryValue.Length)
            {
                result = "0";
            }

            Console.WriteLine(result);
        }

        static void CalculateANDandXORForBinary(int method, string first, string second)
        {
            string hopResult = "";
            string firstMod = first;
            string secondMod = second;

            if (first.Length > second.Length)
            {
                int length = first.Length - second.Length;
                for (int i = 0; i < length; i++)
                {
                    hopResult += "0";
                }

                secondMod = hopResult + secondMod;
            }
            else if (second.Length > first.Length)
            {
                int length = second.Length - first.Length;
                for (int i = 0; i < length; i++)
                {
                    hopResult += "0";
                }

                firstMod = hopResult + firstMod;
            }

            char[] result = ForLoopForORANDXOR(method, firstMod, secondMod).ToCharArray();
            int indexOfOne = Array.IndexOf(result, '1');
            string resultString = "";
            if (indexOfOne == -1)
            {
                resultString = "0";
            }
            else if (indexOfOne == 0)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    resultString += result[i];
                }
            }
            else
            {
                for (int i = indexOfOne; i < result.Length; i++)
                {
                    resultString += result[i];
                }
            }

            Console.WriteLine(resultString);
        }

        // FOR LOOP FUNCTION TO CREATE THE RESULTANT STRING FOR OR, AND and XOR
        static string ForLoopForORANDXOR(int method, string first, string second) // complexity problem
        {
            string result = "";
            const string one = "1";
            const string zero = "0";
            const int OR = 4;
            const int AND = 5;
            const int XOR = 6;

            for (int i = 0; i < first.Length; i++)
            {
                switch (method)
                {
                    case OR:
                        result += first[i] == '0' && second[i] == '0' ? zero : one;
                        break;
                    case AND:
                        result += first[i] == '1' && second[i] == '1' ? one : zero;
                        break;
                    case XOR:
                        result += first[i] != second[i] ? one : zero;
                        break;
                }
            }

            return result;
        }

        // NOT BINARY
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

            foreach (char c in charValue)
            {
                stringResult += c;
            }

            if (stringResult.Length > magicNo)
            {
                string firstPart = stringResult.Substring(0, magicNo);
                string secondPart = stringResult[magicNo..];
                ulong fortPart = ulong.Parse(firstPart);
                string hello = fortPart.ToString();

                Console.Write(hello + secondPart);
            }
            else
            {
                Console.WriteLine(ulong.Parse(stringResult));
            }
        }

        // OR BINARY
        static void CalculateORForBinary(string first, string second)
        {
            string result = "";
            const int method = 4;
            if (first.Length > second.Length)
            {
                string firstEnd = first.Substring(first.Length - second.Length);
                result += ForLoopForORANDXOR(method, firstEnd, second);
                result = first.Substring(0, first.Length - firstEnd.Length) + result;
            }
            else if (second.Length > first.Length)
            {
                string secondEnd = second.Substring(second.Length - first.Length);
                result += ForLoopForORANDXOR(method, first, secondEnd);
                result = second.Substring(0, second.Length - secondEnd.Length) + result;
            }
            else
            {
                result += ForLoopForORANDXOR(method, first, second);
            }

            Console.WriteLine(result);
        }

        // BINARY ADDITION
        static void AddBinary(string firstValue, string secondValue)
        {
            if (firstValue.Length > secondValue.Length)
            {
                secondValue = ZerosForLoop(firstValue.Length - secondValue.Length) + secondValue;
            }
            else
            {
                firstValue = ZerosForLoop(secondValue.Length - firstValue.Length) + firstValue;
            }

            string result = "";
            char[] first = firstValue.ToCharArray();
            char[] second = secondValue.ToCharArray();
            Array.Reverse(first);
            Array.Reverse(second);
            string number = "";
            int carry = 0;

            for (int i = 0; i < first.Length; i++)
            {
                const int three = 3;
                const int two = 2;
                int firstNumber = int.Parse(first[i].ToString());
                int secondNumber = int.Parse(second[i].ToString());
                int addition = carry + firstNumber + secondNumber;

                if (addition == two)
                {
                    number = "10";
                }
                else if (addition == 1)
                {
                    number = "01";
                }
                else if (addition == 0)
                {
                    number = "00";
                }
                else if (addition == three)
                {
                    number = "11";
                }

                string half = number[1].ToString();
                carry = int.Parse(number[0].ToString());

                result = half + result;

                if (i == first.Length - 1)
                {
                    result = carry.ToString() + result;
                }
            }

            Console.WriteLine(RemoveZerosBefore(result));
        }

        // CONVERSION BASE 2
        static void InBazaDoi(int value, string errorMessage)
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
                Console.WriteLine(errorMessage);
            }
        }

        // CONVERSION TO BASE 10
        static void InBazaZece(string valueToCalculate)
        {
            int result = 0;
            const int baza = 2;
            char[] binaryValue = valueToCalculate.ToCharArray();
            Array.Reverse(binaryValue);

            for (int i = 0; i < binaryValue.Length; i++)
            {
                int singleValue = int.Parse(binaryValue[i].ToString());
                result = (int)(singleValue * Math.Pow(baza, i) + result);
            }

            Console.WriteLine(result);
        }

        // HELPER FUNCTIONS TO REMOVE FIRST ZEROS FOR RESULTANT STRING
        static string RemoveZerosBefore(string value)
        {
            int index = value.IndexOf("1");
            if (index == -1)
            {
                return "0";
            }
            else if (index > 0)
            {
                return value[index..];
            }
            else
            {
                return value;
            }
        }

        // HELPER FUNCTION TO CHECK THE STRING IF IS BINARY OR NOT AND RETURN THE VALUE OR null
        static string CheckIfBinary(string value)
        {
            const string binaryError = "Nu s-a introdus un numar binar valid (format doar din 0 si 1).";
            string valueToReturn = null;
            bool result = true;
            foreach (char s in value)
            {
                if (s != '0' && s != '1')
                {
                    result = false;
                }
            }

            if (!result)
            {
                Console.WriteLine(binaryError);
            }
            else
            {
                valueToReturn = value;
            }

            return valueToReturn;
        }

        // CREATES STRING OF ZEROS DEPENDANT ON VALUE AND RETURN THEM AS STRING
        static string ZerosForLoop(int value)
        {
            string result = "";
            for (int i = 0; i < value; i++)
            {
                result += "0";
            }

            return result;
        }

        // function to validate an integer returns value or 0 and also false or right
        static bool ValidateInteger(string value, out int valueToReturn)
        {
            bool result = false;
            valueToReturn = 0;
            if (int.TryParse(value, out int valueInteger))
            {
                valueToReturn = valueInteger;
                result = true;
            }
            else if (valueToReturn < 0)
            {
                Console.WriteLine("Programul converteste doar numere intregi pozitive.");
            }
            else
            {
                Console.WriteLine("Programul converteste doar numere intregi pozitive.");
            }

            return result;
        }
    }
}
