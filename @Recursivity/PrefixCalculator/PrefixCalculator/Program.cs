using System;

namespace PrefixCalculator
{
    public class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');

            int index = 0;
            double result = Compute(input, ref index);

            Console.WriteLine(result);
        }

        static double Compute(string[] list, ref int index)
        {
            if (double.TryParse(list[index], out double value))
            {
                return value;
            }

            int indexNew = index + 1;
            double firstOperand = Compute(list, ref indexNew);
            int indexTwo = indexNew + 1;
            double secondOperand = Compute(list, ref indexTwo);
            double result = PerformCalculationBasedOnOperator(Convert.ToChar(list[index]), firstOperand, secondOperand);
            index = indexTwo;

            return result;
        }

        static double PerformCalculationBasedOnOperator(char operatorSign, double number1, double number2)
        {
            if (operatorSign == '+')
            {
                return number1 + number2;
            }

            if (operatorSign == '-')
            {
                return number1 - number2;
            }

            if (operatorSign == '/')
            {
                return number1 / number2;
            }

            return number1 * number2;
        }
    }
}
