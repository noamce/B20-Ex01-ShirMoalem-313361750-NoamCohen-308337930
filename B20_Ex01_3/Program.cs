using System;

namespace B20_Ex01_3
{
    class Program
    {
        public static void Main()
        {
            int     hourGlassHeight = getUserInput();

            B20_Ex01_2.Program.PrintHourGlassOfAsterisks(hourGlassHeight);
        }

        private static int getUserInput()
        {
            string      userInput = String.Empty;
            int         hourGlassHeight = -1;
            bool        isInputValid = false;
            bool        isParity = false;

            do
            {
                Console.WriteLine("Please enter the number of lines for the hourglass height:");
                userInput = Console.ReadLine();
                isInputValid = inputValidation(userInput, out hourGlassHeight);
                if(isInputValid == false)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            while(isInputValid == false);

            isParity = (hourGlassHeight % 2 == 0);
            if(isParity == true)
            {
                hourGlassHeight--;
            }
            
            return hourGlassHeight;
        }

        private static bool inputValidation(string i_Input, out int o_HourGlassHeight)
        {
            return int.TryParse(i_Input, out o_HourGlassHeight) && o_HourGlassHeight > 0;
        }
    }
}

