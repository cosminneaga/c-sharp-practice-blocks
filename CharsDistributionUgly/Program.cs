using System;

namespace CharsDistributionUgly
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            char[] chs = new char[0];
            for (int i = 0; i < s.Length; i++)
            {
                int k = -1;
                for (int j = 0; j < chs.Length; j++)
                {
                    if (chs[j] == s[i])
                    {
                        k = j;
                    }
                }

                if (k == -1)
                {
                    Array.Resize(ref chs, chs.Length + 1);
                    chs[chs.Length - 1] = s[i];
                }
            }

            double[] chsC = new double[chs.Length];

            for (int i = 0; i < chs.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (chs[i] == s[j])
                    {
                        chsC[i]++;
                    }
                }
            }

            double[] p = new double[chsC.Length];
            for (int i = 0; i < chsC.Length; i++)
            {
                p[i] = chsC[i] * 100 / s.Length;
            }

            for (int i = 0; i < chs.Length; i++)
            {
                Console.WriteLine("{0} {1:N2}", chs[i], p[i]);
            }

            Console.Read();
        }
    }
}
