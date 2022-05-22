using System;

namespace HiddenMessageA
{
    class Program
    {
        static void Main(string[] args)
        {
            string encodedMessageFirstPart = Console.ReadLine();
            string encodedMessageSecondPart = Console.ReadLine();
            string message = string.Empty;

            for (int i = 0; i < encodedMessageSecondPart.Length; i++)
            {
                message += encodedMessageFirstPart[i].ToString() + encodedMessageSecondPart[i].ToString();
            }

            if (encodedMessageFirstPart.Length > encodedMessageSecondPart.Length)
            {
                message += encodedMessageFirstPart[encodedMessageFirstPart.Length - 1].ToString();
            }

            Console.WriteLine(message);
        }
    }
}
