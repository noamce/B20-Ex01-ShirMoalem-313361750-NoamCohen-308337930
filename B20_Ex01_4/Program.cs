using System.Text;
using System;

namespace B20_Ex01_4
{
    class Program
    {
        public static void Main()
        {
            int     requestedLenOfInput = 8;
            AnalyzeString(requestedLenOfInput);
        }

        public static void AnalyzeString(int i_RequestedLenOfInput)
        {
            string      userInput = getInputFromUser(i_RequestedLenOfInput);
            bool        isPalindrom = checkIfInputIsPalindrome(userInput);
            bool        isNumber = int.TryParse(userInput, out int userInputAsNumber);
            bool        isDividedByFive = false;
            int         upperCaseCounter = 0;

            if(isNumber == true)
            {
                isDividedByFive = userInputAsNumber % 5 == 0;
            }
            else
            {
                upperCaseCounter = howManyUpperCaseLetters(userInput, i_RequestedLenOfInput);
            }

            printAnalysis(isPalindrom, isNumber, isDividedByFive, upperCaseCounter);
        }

        private static string getInputFromUser(int i_RequestedLenOfInput)
        {
            string      userInput;
            bool        isInputValid = false;

            do
            {
                Console.WriteLine("Please enter a {0} chars input (and press enter):", i_RequestedLenOfInput);
                userInput = Console.ReadLine();
                if(userInput.Length != i_RequestedLenOfInput || !isAllCharsAreLettersOrDigits(userInput))
                {
                    System.Console.WriteLine("Invalid input!");
                }
                else
                {
                    isInputValid = true;
                }
            }
            while(isInputValid == false);

            return userInput;
        }

        private static bool isAllCharsAreLettersOrDigits(string i_UserInput)
        {
            bool    containeOnlyVaidChars = true;
            bool    containeOnlyVaidDigits = true;

            foreach (char inputChar in i_UserInput)
            {
                if(!char.IsLetter(inputChar))
                {
                    containeOnlyVaidChars = false;
                }
            }

            if (containeOnlyVaidChars == false)
            {
                foreach (char inputChar in i_UserInput)
                {
                    if (!char.IsDigit(inputChar))
                    {
                        containeOnlyVaidDigits = false;
                    }
                }
            }


            return containeOnlyVaidChars || containeOnlyVaidDigits;
        }

        private static bool checkIfInputIsPalindrome(string i_UserInput)
        {
            StringBuilder       stringToCheck = new StringBuilder(i_UserInput);

            return checkIfInputIsPalindromeRec(stringToCheck);
        }

        private static bool checkIfInputIsPalindromeRec(StringBuilder i_UserInput)
        {
            bool        isPalindrome = true;

            if(i_UserInput.Length != 0)
            {
                isPalindrome = i_UserInput[0] == i_UserInput[i_UserInput.Length - 1];
                i_UserInput.Remove(i_UserInput.Length - 1, 1);
                i_UserInput.Remove(0, 1);
                isPalindrome = isPalindrome && checkIfInputIsPalindromeRec(i_UserInput);
            }

            return isPalindrome;
        }

        private static int howManyUpperCaseLetters(string i_StringInput,int i_RequestedLenOfInput)
        {
            int     upperCaseCounter = 0;

            for(int i = 0; i < i_RequestedLenOfInput; i++)
            {
                if (char.IsUpper(i_StringInput[i]) == true)
                {
                    upperCaseCounter++;
                }
            }

            return upperCaseCounter;
        }

        private static void printAnalysis(bool i_IsPalindrome, bool i_IsNumber, bool i_IsDividedByFive, int i_UpperCaseCounter)
        {
            string      outPut = string.Format(
            @"The input's Analysis:
                The input is {0}
                {1}",
                i_IsPalindrome ? "a palindrome" : "not a palindrome",
                i_IsNumber ? (i_IsDividedByFive ? "The number can be divided by five" : "The number cannot be divided by five") : ("The string has " + i_UpperCaseCounter + " upper case letters"));
                Console.WriteLine(outPut);
        }
    }
}
