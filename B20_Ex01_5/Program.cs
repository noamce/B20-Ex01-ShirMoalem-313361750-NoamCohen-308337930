using System;

namespace B20_Ex01_5
{
    public class Program
    {
        public const int k_NumberOfDigitsToRecive = 9;
        public const int k_Base = 10;

        public static void Main()
        {
            int userInputNumber = GetNumberFromUser();
            ClacAndPrintStatistics(userInputNumber);
        }

        public static int GetNumberFromUser()
        {
            System.Console.WriteLine("Hi, please type a number with {0} digits (and press enter):", k_NumberOfDigitsToRecive);
            string userInput;
            int userInputAsInt;
            bool isInputValid = false;
            do
            {
                Console.WriteLine("Please enter a {0} digits number", k_NumberOfDigitsToRecive);
                userInput = Console.ReadLine();
                isInputValid = InputValidation(userInput, out userInputAsInt);
                if (isInputValid == false)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
            while (isInputValid == false);
            return userInputAsInt;
        }

        public static void ClacAndPrintStatistics(int i_Number)
        {
            int unityDigit = i_Number % k_Base;
            int currentDigit = unityDigit;
            int biggestDigit = unityDigit, smallestDigit = unityDigit, dividedByThreeCounter = 0, biggerThanUnityDigitCounter = 0;

            for (int i = 0; i < k_NumberOfDigitsToRecive; i++)
            {
                biggestDigit = Math.Max(currentDigit, biggestDigit);
                smallestDigit = Math.Min(currentDigit, smallestDigit);
                AddToCounterIfDividedByThree(currentDigit, ref dividedByThreeCounter);
                AddToCounterIfBiggerThanUnityDigit(currentDigit, unityDigit, ref biggerThanUnityDigitCounter);
                i_Number /= k_Base;
                currentDigit = i_Number % k_Base;
            }

            PrintStatistics(biggestDigit, smallestDigit, dividedByThreeCounter, biggerThanUnityDigitCounter);
        }

        private static bool InputValidation(string i_UserInput, out int o_UserInputAsInt)
        {
            bool isInputValid = int.TryParse(i_UserInput, out o_UserInputAsInt) && i_UserInput.Length == k_NumberOfDigitsToRecive && o_UserInputAsInt >= 0;
            return isInputValid;
        }

        private static void AddToCounterIfDividedByThree(int i_CurrentDigit, ref int io_DividedByThreeCounter)
        {
            if (i_CurrentDigit % 3 == 0)
            {
                io_DividedByThreeCounter++;
            }
        }

        private static void AddToCounterIfBiggerThanUnityDigit(int i_CurrentDigit, int i_UnityDigit, ref int io_BiggerThanUnityDigitCounter)
        {
          if (i_CurrentDigit > i_UnityDigit)
            {
                io_BiggerThanUnityDigitCounter++;
            }
        }

        private static void PrintStatistics(int i_BiggestDigit, int i_SmallestDigit, int i_DividedByThreeCounter, int i_LargerThanUnityDigitCounter)
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