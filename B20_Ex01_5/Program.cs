
namespace B20_Ex01_5
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int i_NumberOfDigitsToRecive = 9;
            int userInputNumber = getNumberFromUser(i_NumberOfDigitsToRecive);
            clacAndPrintStatistics(userInputNumber, i_NumberOfDigitsToRecive);
        }

        private static int getNumberFromUser(int i_NumberOfDigitsToRecive)
        {
            Console.WriteLine("Hi, please type a number with {0} digits (and press enter):", i_NumberOfDigitsToRecive);
            string userInput;
            int userInputAsInt;
            bool isInputValid = false;

            do
            {
                Console.WriteLine("Please enter a {0} digits number", i_NumberOfDigitsToRecive);
                userInput = System.Console.ReadLine();
                isInputValid = inputValidation(userInput, out userInputAsInt, i_NumberOfDigitsToRecive);
                if (isInputValid == false)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            while (isInputValid == false);

            return userInputAsInt;
        }

        private static void clacAndPrintStatistics(int i_Number, int i_NumberOfDigitsToRecive)
        {
            int unityDigit = i_Number % 10;
            int currentDigit = unityDigit;
            int biggestDigit = unityDigit, smallestDigit = unityDigit, dividedByThreeCounter = 0, biggerThanUnityDigitCounter = 0;

            for (int i = 0; i < i_NumberOfDigitsToRecive; i++)
            {
                biggestDigit = Math.Max(currentDigit, biggestDigit);
                smallestDigit = Math.Min(currentDigit, smallestDigit);
                addToCounterIfDividedByThree(currentDigit, ref dividedByThreeCounter);
                addToCounterIfBiggerThanUnityDigit(currentDigit, unityDigit, ref biggerThanUnityDigitCounter);
                i_Number /= 10;
                currentDigit = i_Number % 10;
            }

            printStatistics(biggestDigit, smallestDigit, dividedByThreeCounter, biggerThanUnityDigitCounter);
        }

        private static bool inputValidation(string i_UserInput, out int o_UserInputAsInt, int i_NumberOfDigitsToRecive)
        {
            bool isANumber = int.TryParse(i_UserInput, out o_UserInputAsInt);
            bool isInputValid = i_UserInput.Length == i_NumberOfDigitsToRecive && o_UserInputAsInt > 0;

            return isInputValid && isANumber;
        }

        private static void addToCounterIfDividedByThree(int i_CurrentDigit, ref int io_DividedByThreeCounter)
        {
            if (i_CurrentDigit % 3 == 0)
            {
                io_DividedByThreeCounter++;
            }
        }

        private static void addToCounterIfBiggerThanUnityDigit(int i_CurrentDigit, int i_UnityDigit, ref int io_BiggerThanUnityDigitCounter)
        {
          if (i_CurrentDigit > i_UnityDigit)
            {
                io_BiggerThanUnityDigitCounter++;
            }
        }

        private static void printStatistics(int i_BiggestDigit, int i_SmallestDigit, int i_DividedByThreeCounter, int i_LargerThanUnityDigitCounter)
        {
            string outPut = string.Format(
            @"The number you have entered statistics are:
            The larger digit is: {0}
            The smallest digit is: {1}
            The number of digits that divided by 3 is: {2}
            The number of digits that are larger than the unity digit is: {3}",
            i_BiggestDigit,
            i_SmallestDigit,
            i_DividedByThreeCounter,
            i_LargerThanUnityDigitCounter);

            Console.WriteLine(outPut);
        }
    }
}