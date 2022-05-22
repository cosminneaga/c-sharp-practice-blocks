using System;

namespace CappedSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumLimit = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            int count = 0;
            int add = 0;

            do
            {
                int number = Convert.ToInt32(Console.ReadLine());
                add += number;
                if(add < sumLimit)
                {
                    sum += number;
                    count++;
                }
                else
                {
                    break;
                }
            } while (sum < sumLimit);

            Console.WriteLine(sum + " " + count);
        }
    }
}
