using System;

namespace AddVeryLargeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = "15676347800134";
            string second = "47800134";

            AddLargeNumbers(second, first);
        }

        static void AddLargeNumbers(string firstNumber, string secondNumber)
        {
            // add zeros for shorter
            if (firstNumber.Length > secondNumber.Length)
            {
                int length = firstNumber.Length - secondNumber.Length;
                secondNumber = Zeros(length) + secondNumber;
            }
            else
            {
                int length = secondNumber.Length - firstNumber.Length;
                firstNumber = Zeros(length) + firstNumber;
            }

            char[] first = firstNumber.ToCharArray();
            char[] second = secondNumber.ToCharArray();
            int[] result = new int[first.Length];

            int count = first.Length - 1;
            int carry = 0;
            Array.Reverse(first);
            Array.Reverse(second);

            for (int i = 0; i < first.Length; i++)
            {
                string d = (int.Parse(first[i].ToString()) + int.Parse(second[i].ToString())).ToString();

                int leftOver;
                if (d.Length > 1)
                {
                    leftOver = int.Parse(d[1].ToString());
                }
                else
                {
                    leftOver = int.Parse(d[0].ToString());
                }

                result[count] = leftOver + carry;
                carry = int.Parse(d.ToString()) / 10;
                count--;
            }

            foreach (int i in result)
            {
                Console.Write(i);
            }
        }

        // function used to add zeros for the shorter number
        static string Zeros(int value)
        {
            string result = "";
            for (int i = 0; i < value; i++)
            {
                result += "0";
            }
            return result;
        }
    }
}
