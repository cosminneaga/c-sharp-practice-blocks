using System;

namespace LoterieSanseCastig
{
    class Program
    {
        static void Main(string[] args)
        {
            int numereTotal = Convert.ToInt32(Console.ReadLine());
            int numereExtrase = Convert.ToInt32(Console.ReadLine());
            int categorieNumarTotalCastigator = Categorie(Console.ReadLine(), numereExtrase);

            CalculateAndPrintResult(numereTotal, categorieNumarTotalCastigator, numereExtrase);

            //Console.WriteLine(CombineTwoNumbers(5, 5));

            //Console.WriteLine(factorial(40) / (factorial(5) * factorial(35)));
        }

        static void CalculateAndPrintResult(int numarTotalBile, int numarCategorie, int numarBileExtrase)
        {
            // gaseste combinarile intre total: 6/49
            double combineTotal = CombineTwoNumbers(numarTotalBile, numarBileExtrase);

            // daca numarCategorie e mai mare decat bile extrase calculeaza combinarile intre cele castigatoare si cele pierdute
            double combineWinningBalls = 1;
            double combineLosingBalls = 1;
            if (numarBileExtrase > numarCategorie)
            {
                int losingNumbers = numarBileExtrase - numarCategorie;
                int remainingNumbersFromTotal = numarTotalBile - numarBileExtrase;
                combineWinningBalls = CombineTwoNumbers(numarBileExtrase, numarCategorie);
                combineLosingBalls = CombineTwoNumbers(remainingNumbersFromTotal, losingNumbers);
            }
            else
            {
                combineWinningBalls = CombineTwoNumbers(numarCategorie, numarBileExtrase);
            }

            decimal endResult = Convert.ToDecimal((combineWinningBalls * combineLosingBalls) / combineTotal);

            /*
            Console.WriteLine("Categorie: {0}", numarCategorie);
            
            Console.WriteLine("Combine Total {0}/{1}: {2}", numarCategorie, numarTotalBile, combineTotal);
            Console.WriteLine("Combine Winning Balls: {0}", combineWinningBalls);
            Console.WriteLine("Combine Losing Balls: {0}", combineLosingBalls);

            Console.WriteLine("Result of combination between winning and losing balls: {0} x {1} = {2}", combineWinningBalls, combineLosingBalls, combineWinningBalls * combineLosingBalls);
            Console.WriteLine("End Result: {0}", Math.Round(endResult, 10));
            */
            Console.WriteLine(Math.Round(endResult, 10));
        }

        static double CombineTwoNumbers(int x, int y)
        {
            double result;
            if (x == y)
            {
                result = 1;
            }
            else
            {
                result = factorial(x) / (factorial(y) * factorial(x - y));
            }
            return result;
        }

        static double factorial(int n)
        {
            double fact = n;
            for (double i = 1; i < n; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        static int Categorie(string categorie, int numarMaximBile)
        {
            int result = 1;
            /*
            switch (categorie)
            {
                case "I":
                    result = 15;
                    break;
                case "II":
                    result = 14;
                    break;
                case "III":
                    result = 13;
                    break;
            }
            */
            if (categorie == "I")
            {
                result = numarMaximBile;
            }
            if (categorie == "II")
            {
                result = numarMaximBile - 1;
            }
            if (categorie == "III")
            {
                result = numarMaximBile - 2;
            }

            return result;
        }

    }
}
