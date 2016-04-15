using System;
using System.Collections.Generic;
using System.Text;

namespace B16_Ex02
{
    internal class InputUtils
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

        /// <summary>
        /// Gets a single  char from console, 
        /// if validChars are given, then only those characters will count as valid input
        /// </summary>
        /// <param name="validChars"></param>
        /// <returns></returns>
        public static char GetSepcificCharsFromConsole(params char[] validChars)
        {
            char result;
            if (validChars.Length > 0)
            {
                string validcharsString = new string(validChars);
                result = GetSingleCharFromConsole();

                while (validcharsString.IndexOf(result) == -1)
                {
                    Console.WriteLine("Please enter a charecter from these valid characters: '{0}' ", validcharsString);
                    result = GetSingleCharFromConsole();
                }

            }
            else
            {
                throw new Exception("Missing valid character params");   
            }

            return result;
        }

        /// <summary>
        /// Get a single char from the user (from write line);
        /// </summary>
        /// <returns></returns>
        public static char GetSingleCharFromConsole()
        {
            string userInput = Console.ReadLine();
            while (userInput.Length != 1)
            {
                Console.WriteLine("Invalid input, Please enter a single character:");
                userInput = Console.ReadLine();
            }

            return userInput[0];
        }
    }
}
