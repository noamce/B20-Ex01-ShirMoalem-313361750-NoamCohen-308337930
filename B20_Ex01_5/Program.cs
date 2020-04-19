using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex01_5
{
    class Program
    {
        //StringBuilder
        //string.Format
        //int.TryParse
        //Math
        //char

        public static void Main()
        {
            int numberOfDigitsToRecive = 9;
            System.Console.WriteLine("Hi, please type a number with {0} digits (and press enter):", numberOfDigitsToRecive);
            String numberInString;
            numberInString = GetNumberInStringFromUser();
            ClacAndPrintResults(numberInString);
            //for each char convert into int and keep in locals:
            //biggest 
            //smallest 
            //dived by 3 
            //how many digits bigger than the lsd
        }
        public static String GetNumberInStringFromUser()
        {

            return "";
        }
        public static void ClacAndPrintResults(String i_numberInString)
        {
            //int BiggestDigit = CalcBiggestDigit();
            //int SmallestDigit = CalcSmallest() ;
            //int numOfDigitsDivIn3 = CalcNumofDigitsDivIn3();
            //int numOfDigitsBiggerThan = CalcNumOfDigitsBiggerThan(i_numberInString, i_numberInString[8]);

            //printResult

        }

        public static int CalcBiggestDigitInString(String i_string)
        {


            return 0;
        }

        public static int CalcSmallestDigitInStirng(String i_string)
        {


            return 0;
        }

        public static int CalcNumofDigitsDivIn3InStirng(String i_string)
        {


            return 0;
        }

        private static void printResults(int i_BiggestDigit, int SmallestDigit, int i_numOfDigitsDivIn3)
        {

        }
    }
}
