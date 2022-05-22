using System;

namespace Matrix_Copy
{
    class Program
    {
        static void Main(string[] args)
        {
            // DATE INTRARE
            // 2
            // 1000.75 2000.00 3000.00 1000.00
            // 2500.00 1700.00 2500.00 1000.00

            // DATE IESIRE
            // Trimestrul 3: 5500.00
            // Magazinul 1: 7000.75

            string input = Console.ReadLine();
            int storesNo = Int32.Parse(input);
            decimal[,] profits = new decimal[storesNo, 4];

            for (int i = 0; i < storesNo; i++)
            {
                string line = Console.ReadLine();
                string[] stringNumbers = line.Split(' ');
                for (int j = 0; j < 4; j++)
                    profits[i, j] = Convert.ToDecimal(stringNumbers[j]);
            }

            decimal[] quartersTotals = new decimal[4];

            for (int j = 0; j < 4; j++)
            {
                quartersTotals[j] = 0;
                for (int i = 0; i < storesNo; i++)
                    quartersTotals[j] += profits[i, j];
            }

            decimal maxProfitQuarter = quartersTotals[0];
            decimal maxProfitQuarterIndex = 0;

            for (int i = 1; i < 4; i++)
            {
                if (quartersTotals[i] > maxProfitQuarter)
                {
                    maxProfitQuarter = quartersTotals[i];
                    maxProfitQuarterIndex = i;
                }
            }
            Console.WriteLine(string.Format("Trimestrul {0}: {1:F2}", maxProfitQuarterIndex + 1, maxProfitQuarter));

            decimal[] storeTotals = new decimal[storesNo];

            for (int i = 0; i < storesNo; i++)
            {
                storeTotals[i] = 0;
                for (int j = 0; j < 4; j++)
                    storeTotals[i] += profits[i, j];
            }

            decimal max = 0;
            int index = 0;
            for (int i = 0; i < storeTotals.Length; i++)
            {
                if (storeTotals[i] > max)
                {
                    max = storeTotals[i];
                    index = i + 1;
                }
            }

            Console.WriteLine(string.Format("Magazinul {0}: {1:F2}", index, max));

        }
    }
}
