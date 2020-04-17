using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex01_1
{
    class Program
    {
        public void Main()
        {
            int requestedLenOfInput = 9;
            int requestedNumOfInputs = 3;
            System.Console.WriteLine("Please enter {0} binary numbers, {1} digits long and then press 'Enter' after each one",
                requestedNumOfInputs, requestedLenOfInput);

            BinarySeries(requestedLen, requestedNumOfInputs);
        }

        private static void BinarySeries(int i_RequestedLen, int i_RequestedNumOfInputs)
        {
            //call to get input,converInputToDec, printTheDecNum, printStatistics, countZerosAndOnes, checkIfNumPowOfTwo
        }

        private static int getInput(int i_RequestedLen)
        {
            //get the input and check his validation. if not valid- error. else- convert to dec and return it.
        }

        private static int converInputToDec(int i_RequestedLen)
        {
            //call to printResults 
        }

        private static void printTheDecNum(int i_DecNum)
        { }

        private static void printStatistics(int i_DecNum)
        { }

        private static void countZerosAndOnes(int i_Num, int i_NumLen, ref int o_NumOfZeros, ref int o_NumOfOnes)
        { }

        private static bool checkIfNumPowOfTwo(int i_Num)
        { }

    }
}
