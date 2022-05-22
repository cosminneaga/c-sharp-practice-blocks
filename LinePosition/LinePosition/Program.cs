using System;
using System.Data;
using System.Linq;

namespace LinePosition
{
    class Program
    {
        static void Main()
        {
            int numberOfCommands = Convert.ToInt32(Console.ReadLine());

            string[] commands = new string[numberOfCommands];

            for(int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                commands[i] = command;
            }

            Console.WriteLine(LineIntersectionCheck(commands));
        }

        static bool LineIntersectionCheck(string[] commands)
        {
            int x = commands.Length;
            int y = commands.Length;
            string[] position = new string[commands.Length + 1];

            //start
            position[0] = y.ToString() + x.ToString();

            int count = 1;
            foreach(string command in commands)
            {
                switch (command)
                {
                    case "down":
                        y -= 1;
                        position[count] = (y).ToString() + x.ToString();
                        break;
                    case "up":
                        y += 1;
                        position[count] = (y).ToString() + x.ToString();
                        break;
                    case "right":
                        x += 1;
                        position[count] = y.ToString() + (x).ToString();
                        break;
                    case "left":
                        x -= 1;
                        position[count] = y.ToString() + (x).ToString();
                        break;
                }
                count++;
            }

            bool result = false;
            if(position.Distinct().Count() != position.Count())
            {
                result = true;
            }

            return result;
        }
    }
}
