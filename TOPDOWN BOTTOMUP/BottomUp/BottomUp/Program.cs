using System;

namespace BottomUp
{
    class Program
    {
        //  METODA BOTTOM UP

        //  SCENARIUL 1 doar luna iulie
        /*
         static void Main(string[] args)
        {
            
            string[] temperatureValuesInJune = Console.ReadLine().Split(' ');
            double sum = 0;
            for (int i = 0; i < temperatureValuesInJune.Length; i++)
                sum += Convert.ToInt32(temperatureValuesInJune[i]);
            int average = (int)Math.Round(sum / temperatureValuesInJune.Length);
            Console.WriteLine("Average temperatures for June:");
            Console.WriteLine(average);
            Console.Read();
        }
        */


        // SCENARIUL 2 temperatura medie pe ultimii trei ani pentru toate lunile de vara
        static void Main(string[] args){

            /* BEFORE ReportAverageTemperatures()
            int[,] temperatures = new int[3, 3];
            int[] averageTemperaturesPerMonth = new int[3];
            int[] averageTemperaturesPerYear = new int[3];
            string message = "Average temperatures for";

            for (int monthIndex = 0; monthIndex < 3; monthIndex++)
                ReadTemperaturesForMonth(temperatures, monthIndex);
            for (int monthIndex = 0; monthIndex < 3; monthIndex++)
                averageTemperaturesPerMonth[monthIndex] = CalculateAverage(temperatures, monthIndex, true);
            string[] labels = new string[] { "June", "July", "August" };
            PrintValues(averageTemperaturesPerMonth, labels, message);

            for (int yearIndex = 0; yearIndex < 3; yearIndex++)
                averageTemperaturesPerYear[yearIndex] = CalculateAverage(temperatures, yearIndex, false);
            labels = new string[] { "2015", "2016", "2017" };
            PrintValues(averageTemperaturesPerYear, labels, message);

            Console.Read();
            */

            int[,] temperatures = new int[3, 3];

            for (int monthIndex = 0; monthIndex < 3; monthIndex++)
                ReadTemperaturesForMonth(temperatures, monthIndex);

            ReportAverageTemperatures(temperatures, true);
            ReportAverageTemperatures(temperatures, false);

            Console.Read();

        }

        // CITIRE
        static void ReadTemperaturesForMonth(int[,] temperatures, int monthIndex)
        {
            string[] temperatureValues = Console.ReadLine().Split(' ');
            for (int i = 0; i < temperatureValues.Length; i++)
                temperatures[monthIndex, i] = Convert.ToInt32(temperatureValues[i]);
        }

        //  CALCULARE
        /* BEFORE
        static int CalculateAverageForMonth(int[,] temperatures, int monthIndex)
        {
            double sum = 0;
            for (int i = 0; i < temperatures.GetLength(1); i++)
                sum += Convert.ToInt32(temperatures[monthIndex, i]);
            return (int)Math.Round(sum / temperatures.GetLength(1));
        }

        static int CalculateAverageForYear(int[,] temperatures, int yearIndex)
        {
            double sum = 0;
            for (int i = 0; i < temperatures.GetLength(0); i++)
                sum += Convert.ToInt32(temperatures[i, yearIndex]);
            return (int)Math.Round(sum / temperatures.GetLength(0));
        }
        */
        static int CalculateAverage(int[,] table, int index, bool perLine)
        {
            int length = perLine ? table.GetLength(1) : table.GetLength(0);
            double sum = 0;
            for (int i = 0; i < length; i++)
                sum += perLine ? table[index, i] : table[i, index];
            return (int)Math.Round(sum / length);
        }



        // TIPARIRE
        /* BEFORE
        static void PrintAverageForMonth(int monthIndex, int average)
        {
            string[] months = { "June", "July", "August" };
            Console.WriteLine("Average temperatures for {0}: {1}", months[monthIndex], average);
        }

        static void PrintAverageForYear(int yearIndex, int average)
        {
            string[] years = { "2015", "2016", "2017" };
            Console.WriteLine("Average temperatures for {0}: {1}", years[yearIndex], average);
        }
        */
        static void PrintValues(int[] values, string[] labels, string message)
        {
            for (int i = 0; i < values.Length; i++)
                Console.WriteLine("{2} {0}: {1}", labels[i], values[i], message);
        }

        static void ReportAverageTemperatures(int[,] temperatures, bool perMonth)
        {
            int length = perMonth ? temperatures.GetLength(0) : temperatures.GetLength(1);
            int[] averageTemperatures = new int[length];

            for (int i = 0; i < length; i++)
                averageTemperatures[i] = CalculateAverage(temperatures, i, perMonth);

            string message = "Average temperatures for";
            string[] labels = perMonth ?
                new string[] { "June", "July", "August" } :
                new string[] { "2015", "2016", "2017" };

            PrintValues(averageTemperatures, labels, message);
        }
    }
}
