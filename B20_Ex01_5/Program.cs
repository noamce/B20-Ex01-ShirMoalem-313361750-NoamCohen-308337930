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

            System.Console.WriteLine("Hi, please type a number with 9 digits (and press enter):");
            String numberInString;
            numberInString = GetNumberFromUser();
            ClacAndPrintResults(numberInString);
            //for each char convert into int and keep in locals:
            //biggest 
            //smallest 
            //dived by 3 
            //how many digits bigger than the lsd
        }
        public static String GetNumberFromUser()
        {

            return "";
        }
        public static void ClacAndPrintResults(String i_numberInString)
        {

        }
    }
}
