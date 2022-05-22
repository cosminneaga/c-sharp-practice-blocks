using System;

namespace learning
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            int batoane = Int32.Parse(input);

            if(batoane > 10)
            {
                int numar = 1;
                for(int i = 0; i < batoane/10; i++)
                {
                    Console.WriteLine(numar + " x 10 buc");
                    numar++;
                }
            }

        }
    }
}
