using System;

namespace FromGibberishUgly
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            int i = 0; int k = 0; bool b = true;
            string s2 = s;

            while (i < s.Length)
            {
                b = false;
                if (s[i] == 97 || s[i] == 65 || s[i] == 101 || s[i] == 69 || s[i] == 105 || s[i] == 73 || s[i] == 111 || s[i] == 79 || s[i] == 117 || s[i] == 85)
                {
                    b = true;
                }

                if (!b)
                {
                    i++;
                    k++;
                }
                else
                {
                    s2 = s2.Substring(0, k) + s2[k] + s.Substring(i + 3);
                    i = i + 3;
                    k++;
                }
            }

            Console.WriteLine(s2);
            Console.Read();
        }
    }
}
