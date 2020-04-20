using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex01_1
{
    class Program
    {

        public static void Main()
        {
            int requestedLenOfInput = 9;
            int requestedNumOfInputs = 3;
            System.Console.WriteLine("Please enter {0} binary numbers, {1} digits long and then press 'Enter' after each one",
                requestedNumOfInputs, requestedLenOfInput);

            BinarySeries(requestedLenOfInput, requestedNumOfInputs);
        }

        private static void BinarySeries(int i_RequestedLen, int i_RequestedNumOfInputs)
        {
            //call to getInput,converInputToDec, printTheDecNum, printStatistics, countZerosAndOnes, checkIfNumPowOfTwo

            int BinaryNumInput, numOfOnes = 0, numOfZeros = 0, numOfNumbersPowOfTwo = 0, numOfNumbersIncreaseSeries = 0, biggestInputNum, lowestInputNum, oneDecNum = 0, twoDecNum = 0, treeDecNum = 0;
            float numOfZerosAvg = 0, numOfOnesAvg = 0;

            for (int i = 0; i < i_RequestedNumOfInputs; ++i)
            {
                BinaryNumInput = getInput(i_RequestedLen);

                numOfOnes += countOnes(BinaryNumInput, i_RequestedLen);
                numOfZeros += countZeros(BinaryNumInput, i_RequestedLen);

                numOfNumbersIncreaseSeries += isIncreaseNum(BinaryNumInput, i_RequestedLen);
                if (i == 0)
                {
                    oneDecNum = convertInputToDec(BinaryNumInput, i_RequestedLen);
                    numOfNumbersPowOfTwo += isPowOfTwo(oneDecNum);
                }
                else if (i == 1)
                {
                    twoDecNum = convertInputToDec(BinaryNumInput, i_RequestedLen);
                    numOfNumbersPowOfTwo += isPowOfTwo(twoDecNum);
                }
                else
                {
                    treeDecNum = convertInputToDec(BinaryNumInput, i_RequestedLen);
                    numOfNumbersPowOfTwo += isPowOfTwo(treeDecNum);
                }
            }
            biggestInputNum = findTheBiggest(oneDecNum, twoDecNum, treeDecNum);
            lowestInputNum = findTheLowest(oneDecNum, twoDecNum, treeDecNum);


            numOfZerosAvg = (float)numOfZeros / i_RequestedNumOfInputs;
            numOfOnesAvg = (float)numOfOnes / i_RequestedNumOfInputs;

            System.Console.WriteLine(@"The average number of zeros is: {0}.
                The average number of ones is: {1}.
                The number of numbers which are power of 2 is: {2} 
                The number of increase is: {3}.
                The dec numbers are {4}, {5}, {6}
                The max num is {7}
                The min num is {8}",
                numOfZerosAvg, numOfOnesAvg, numOfNumbersPowOfTwo, numOfNumbersIncreaseSeries, oneDecNum, twoDecNum, treeDecNum, biggestInputNum, lowestInputNum);

        }

        private static int findTheBiggest(int i_NumOne, int i_NumTwo, int i_NumTree)
        {
            int maxNum = i_NumOne;

            if (maxNum < i_NumTwo)
            {
                maxNum = i_NumTwo;
            }

            if (maxNum < i_NumTree)
            {
                maxNum = i_NumTree;
            }

            return maxNum;
        }

        private static int findTheLowest(int i_NumOne, int i_NumTwo, int i_NumTree)
        {
            int mimNum = i_NumOne;

            if (mimNum > i_NumTwo)
            {
                mimNum = i_NumTwo;
            }

            if (mimNum > i_NumTree)
            {
                mimNum = i_NumTree;
            }

            return mimNum;
        }


        private static int isIncreaseNum(int i_Num, int i_RequestedLen)
        {
            int DecNum = convertInputToDec(i_Num, i_RequestedLen);
            int rightDig = DecNum % 10;
            DecNum /= 10;
            int unity, FlagIsIncrease = 1;

            while (DecNum > 0 && FlagIsIncrease == 1)
            {
                unity = DecNum % 10; ;
                if (unity >= rightDig)
                {
                    FlagIsIncrease = 0;
                }
                else
                {
                    rightDig = unity;
                }
                DecNum /= 10;
            }
            return FlagIsIncrease;
        }

        private static int getInput(int i_RequestedLen)
        {
            //get the input and check his validation. if not valid- error. else- convert to dec and return it.
            string inputNumStr = System.Console.ReadLine();
            int inputNum;
            bool isValidInputNum = int.TryParse(inputNumStr, out inputNum);
            //TryParse - converts the string representation of a number to its 32-bit signed integer equivalent. A return value indicates whether the conversion succeeded.

            if (isValidInputNum)
            {
                isValidInputNum = checkIfValidBinaryNum(inputNum, i_RequestedLen);
            }

            if (!isValidInputNum || inputNumStr.Length != i_RequestedLen)
            {// the input is not valid
                System.Console.WriteLine("Please try again with a valid input");
                getInput(i_RequestedLen);
            }

            return inputNum;
        }

        private static bool checkIfValidBinaryNum(int i_Num, int i_NumLen)
        {
            bool isValidBinNum = true;
            int partialNum;


            for (int i = 0; i < i_NumLen; i++)
            {
                partialNum = i_Num % 10;

                if (partialNum != 1 && partialNum != 0)
                {
                    isValidBinNum = false;
                }

                i_Num /= 10;
            }

            return isValidBinNum;
        }

        private static int convertInputToDec(int i_Num, int i_RequestedLen)
        {
            int decResult = 0;

            for (int i = 0; i < i_RequestedLen; ++i)
            {
                int unity = i_Num % 10;

                if (unity == 1)
                {
                    decResult += unity * (int)System.Math.Pow(2, i);
                }

                i_Num /= 10;
            }

            return decResult;
        }

        //private static void printTheDecNum(int i_DecNum){ }

        //private static void printStatistics(int i_DecNum){ }

        private static int countZeros(int i_Num, int i_NumLen)
        {
            int ZerosNumber = 0;

            for (int i = 0; i < i_NumLen; ++i)
            {
                int unity = i_Num % 10;

                if (unity == 0)
                {
                    ZerosNumber++;
                }
                i_Num /= 10;
            }
            return ZerosNumber;
        }

        private static int countOnes(int i_Num, int i_NumLen)
        {
            int OnesNumber = 0;

            for (int i = 0; i < i_NumLen; ++i)
            {
                int unity = i_Num % 10;

                if (unity == 1)
                {
                    OnesNumber++;
                }
                i_Num /= 10;
            }
            return OnesNumber;
        }

        private static int isPowOfTwo(int i_Num)
        {
            double log = Math.Log(i_Num, 2);
            double pow = Math.Pow(2, Math.Round(log));
            int FlagIsPow = 0;

            if (pow == i_Num)
                FlagIsPow = 1;

            return FlagIsPow;

        }
    }
}

