using System;

namespace TopDown
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            La un centru de statistică meteo se analizează temperaturile medii din lunile de vară pe ultimii 3 ani.

            Să se scrie o aplicație ce primește ca date de intrare tabelul cu temperaturile medii astfel:
                -pe prima linie temperaturile medii pe ultimii 3 ani pentru luna iunie, despărțite între ele printr - un spațiu
                 - pe a doua linie temperaturile medii pe ultimii 3 ani pentru luna iulie
                -iar pe a treia linie temperaturile pentru luna august.

            Aplicația va afișa apoi:
                -temperatura medie pe ultimii 3 ani pentru fiecare lună în parte
                -temperatura medie pe perioada verii pentru fiecare an în parte.
            */

            /* METODA 
             * Descompunem problema inițială în subprobleme și creăm câte o funcție pentru fiecare
            Citirea datelor de intrare
            Calcularea temperaturilor medii pe ultimii 3 ani pentru fiecare lună
            Tipărirea temperaturilor medii pentru fiecare lună
            Calcularea temperaturilor medii pe perioada verii pentru fiecare an
            Tipărirea temperaturilor medii pentru fiecare an
            */

            //  PROIECTARE APLICATII METODA TOP-DOWN

            // PRIMA PARTE DIN REZOLVARE
            int[,] averageTemperatures = ReadAverageTemperatures();
            int[] averageTemperaturesPerMonth = CalculateAverages(averageTemperatures, true);
            PrintValues(averageTemperaturesPerMonth, "Average temperatures per month:");
            int[] averageTemperaturesPerYear = CalculateAverages(averageTemperatures, false);
            PrintValues(averageTemperaturesPerYear, "Average temperatures per year:");
            Console.Read();


            //  CITIREA DATELOR DE INTRARE
            static int[,] ReadAverageTemperatures()
            {
                int[,] averageTemperatures = new int[3, 3];

                for (int monthIndex = 0; monthIndex < 3; monthIndex++)
                {
                    ReadAverageTemperaturesPerMonth(averageTemperatures, monthIndex);
                }
                return averageTemperatures;
            }
            static void ReadAverageTemperaturesPerMonth(int[,] averageTemperatures, int monthIndex)
            {
                string[] temperaturesValues = Console.ReadLine().Split(' ');
                for (int yearIndex = 0; yearIndex < 3; yearIndex++)
                    averageTemperatures[monthIndex, yearIndex] = Convert.ToInt32(temperaturesValues[yearIndex]);
            }

            //  BEFORE
            /*
             * Calcularea temperaturilor medii pe ultimii 3 ani pentru fiecare lună
             static int[] CalculateAverageTemperaturesPerMonth(int[,] averageTemperatures) {
                int[] result = new int[3];
                for (int monthIndex = 0; monthIndex < 3; monthIndex++)
                    result[monthIndex] = CalculateAverageTemperatureForMonth(averageTemperatures, monthIndex);
                return result;
            }
            static int CalculateAverageTemperatureForMonth(int[,] averageTemperatures, int monthIndex) {
                double sum = 0;
                for (int yearIndex = 0; yearIndex < 3; yearIndex++)
                    sum += averageTemperatures[monthIndex, yearIndex];
                return (int)Math.Round(sum / 3);
            }

            *Tipărirea temperaturilor medii pentru fiecare lună
            static void PrintAverageTemperaturesPerMonth(int[] averageTemperaturesPerMonth) {
                Console.WriteLine("Average temperatures per month:");
                for (int i = 0; i < averageTemperaturesPerMonth.Length; i++)
                    Console.Write(averageTemperaturesPerMonth[i] + " ");
                Console.Write('\n');
            }

            *Calcularea temperaturilor medii pe perioada verii pentru fiecare an
            static int[] CalculateAverageTemperaturesPerYear(int[,] averageTemperatures) {
                int[] result = new int[3];
                for (int yearIndex = 0; yearIndex < 3; yearIndex++)
                    result[yearIndex] = CalculateAverageTemperatureForYear(averageTemperatures, yearIndex);
                return result;
            }
            static int CalculateAverageTemperatureForYear(int[,] averageTemperatures, int yearIndex) {
                double sum = 0;
                for (int monthIndex = 0; monthIndex < 3; monthIndex++)
                    sum += averageTemperatures[monthIndex, yearIndex];
                return (int)Math.Round(sum / 3);
            }

            *Tipărirea temperaturilor medii pentru fiecare an
            static void PrintAverageTemperaturesPerYear(int[] averageTemperaturesPerYear) {
                Console.WriteLine("Average temperatures per year:");
                for (int i = 0; i < averageTemperaturesPerYear.Length; i++)
                    Console.Write(averageTemperaturesPerYear[i] + " ");
                Console.Write('\n');
            }


            Rezolvarea problemei e acum completă, dar - dacă analizăm cu atenție codul - se mai pot face anumite optimizări
            Într-o aplicație bine proiectată nu trebuie să scriem de mai multe ori cod care face același lucru - repetițiile trebuie eliminate
            Iar în aplicația noastră există câteva funcții care sunt foarte asemănătoare, și care ar putea fi contopite dacă ar fi implementate mai general:
            CalculateAverageTemperatureForMonth și CalculateAverageTemperatureForYear
            CalculateAverageTemperaturesPerMonth și CalculateAverageTemperaturesPerYear
            PrintAverageTemperaturesPerMonth și PrintAverageTemperaturesPerYear
             */



            //  CALCULAREA TEMPERATURILOR MEDII PE ULTIMI 3 ANI PENTRU FIECARE LUNA
            //  CALCULAREA TEMPERATURILOR MEDII PE PERIOADA VERII PENTRU FIECARE AN
            static int[] CalculateAverages(int[,] table, bool perLine)
            {
                int length = perLine ? table.GetLength(0) : table.GetLength(1);
                int[] result = new int[length];
                for (int i = 0; i < length; i++)
                    result[i] = CalculateAverage(table, i, perLine);
                return result;
            }

            static int CalculateAverage(int[,] table, int index, bool perLine)
            {
                int length = perLine ? table.GetLength(1) : table.GetLength(0);
                double sum = 0;
                for (int i = 0; i < length; i++)
                    sum += perLine ? table[index, i] : table[i, index];
                return (int)Math.Round(sum / length);
            }


            //  TIPARIREA TEMPERATURILOR MEDII PENTRU FIECARE LUNA
            //  TIPARIREA TEMPERATURILOR MEDII PENTRU FIECARE AN
            static void PrintValues(int[] values, string message)
            {
                Console.WriteLine(message);
                for (int i = 0; i < values.Length; i++)
                    Console.Write(values[i] + " ");
                Console.Write("\n");
            }
        }
    }
}
