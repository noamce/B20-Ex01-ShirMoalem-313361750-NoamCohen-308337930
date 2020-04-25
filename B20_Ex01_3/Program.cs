using System;

namespace B20_Ex01_3
{
    class Program
    {

        public static void Main()
        {
            int hourGlassHeight = getUserInput();
            B20_Ex01_2.Program.PrintHourGlassOfAsterisks(hourGlassHeight);
        }

        private static int getUserInput()
        {
            string userInput;
            int hourGlassHeight;
            bool isInputValid = false;

            do
            {
                Console.WriteLine("Please Enter the desired hour glass height");
                userInput = Console.ReadLine();
                isInputValid = inputValidation(userInput, out hourGlassHeight);
                if (isInputValid == false )
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            while (isInputValid == false);

            return hourGlassHeight;
        }

        private static bool inputValidation(string i_Input, out int o_HourGlassHeight)
        {
            return int.TryParse(i_Input, out o_HourGlassHeight) && o_HourGlassHeight > 0;
        }
    }
}

