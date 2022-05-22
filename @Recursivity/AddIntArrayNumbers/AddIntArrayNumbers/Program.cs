using System;

namespace AddIntArrayNumbers
{
    class Program
    {
        static void Main()
        {
            int[] arr = new int[] { 2, 2, 2, 2, 2, 2 };
            int Sum = ArraySumNumbers(arr, arr.Length);

            static int ArraySumNumbers(int[] data, int n)
            {
                if (n <= 0 || n > data.Length)
                {
                    return 0;
                }

                return data[n - 1] + ArraySumNumbers(data, n - 1);
            }
        }
    }
}
