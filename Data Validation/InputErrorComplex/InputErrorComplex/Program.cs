using System;

namespace InputErrorComplex
{
    class Program
    {
        /*
        Pentru o aplicație ce calculează maximul dintre 3 numere introduse pe o singură linie,
        despărțite printr-un spațiu, trebuie validat că utilizatorul a introdus un șir de
        3 elemente despărțite prin spațiu și că cele 3 elemente sunt numere.
        */
        static void Main()
        {
            string[] stringValues = Console.ReadLine().Split(' ');
            if(!ValidateInputData(stringValues, out double[] values))
            {
                Console.WriteLine("Introduceti 3 numere, pe o singura linie, despartite printr-un spatiu!");
            }
            else
            {
                Console.WriteLine("Maximul este: " + Maximum(values));
            }
            Console.Read();
        }

        // verifica fiecare linie daca are 3 pozitii si daca sun numere
        static bool ValidateInputData(string[] stringValues, out double[] values)
        {
            values = new double[3];
            if (stringValues.Length != 3)
                return false;

            for (int i = 0; i < 3; i++)
            {
                if (!double.TryParse(stringValues[i], out values[i]))
                return false;
            }
            return true;
        }

        // returneaza numarul cel mai mare din sir
        static double Maximum(double[] values)
        {
            double max = values[0];
            for(int i = 1; i < values.Length; i++)
            {
                if (max < values[i])
                    max = values[i];
            }
            return max;
        }
    }
}
