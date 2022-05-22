using System;

namespace SwapArrayValues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] valuesList = ReadValuesList();

            string line = Console.ReadLine();

            while (line != "x")
            {
                string[] lineItems = line.Split(' ');
                int firstIndex = Convert.ToInt32(lineItems[0]);
                int secondIndex = Convert.ToInt32(lineItems[1]);
                SwapValues(valuesList, firstIndex, secondIndex);
                line = Console.ReadLine();
            }

            PrintValuesList(valuesList);
            Console.Read();
        }

        static void SwapValues(int[] valuesList, int index1, int index2)
        {
            // to do: remove line below and implement this function
            int i1 = valuesList[index1];
            valuesList[index1] = valuesList[index2];
            valuesList[index2] = i1;
        }

        static void PrintValuesList(int[] valuesList)
        {
            for (int i = 0; i < valuesList.Length; i++)
                Console.Write(valuesList[i] + " ");
        }

        static int[] ReadValuesList()
        {
            string[] inputValues = Console.ReadLine().Split(' ');
            int[] values = new int[inputValues.Length];

            for (int i = 0; i < values.Length; i++)
                values[i] = Convert.ToInt32(inputValues[i]);

            return values;
        }
    }
}
