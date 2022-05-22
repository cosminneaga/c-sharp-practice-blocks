using System;

namespace AdditionBinary
{
    class Program
    {
        static void Main()
        {
            long val1, val2, sum = 0;
            val1 = 1111011110111101;
            val2 = 11100;

            Console.WriteLine("Binary one: " + val1);
            Console.WriteLine("Binary two: " + val2);

            sum = displaySum(val1, val2);
            Console.WriteLine("Sum = {0}", sum);
        }

        static long displaySum(long val1, long val2)
        {
            long i = 0, rem = 0, res = 0;
            long[] sum = new long[30];

            while (val1 != 0 || val2 != 0)
            {
                sum[i++] = (val1 % 10 + val2 % 10 + rem) % 2;
                rem = (val1 % 10 + val2 % 10 + rem) / 2;
                val1 = val1 / 10;
                val2 = val2 / 10;
            }
            if (rem != 0)
                sum[i++] = rem;

            i = i - 1;

            while (i >= 0)
                res = res * 10 + sum[i--];
            return res;
        }
    }
}
