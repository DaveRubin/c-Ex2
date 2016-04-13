using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    class NumberUtils
    {
        public static int GetBoundedIntFromConsole(int i_min, int i_max)
        {
            int result = GetIntFromConsole();

            while (result<i_min || result > i_max)
            {
                Console.WriteLine(
                    string.Format("Invalid input, please enter a number between {0} and {1} :", i_min, i_max));
                result = GetIntFromConsole();
            }


            return result;
        }

        public static int GetIntFromConsole()
        {
            string userInput = Console.ReadLine();
            int result;

            while (!int.TryParse(userInput, out result))
            {
                Console.WriteLine("Invalid input, please enter a number");
                userInput = Console.ReadLine();
            }

            return result;
        }
    }
}
