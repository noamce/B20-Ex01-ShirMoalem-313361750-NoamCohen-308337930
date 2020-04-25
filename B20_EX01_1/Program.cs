using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex01_1
{
    class Program
    {
        protected const int k_RequestedLenOfInput = 9;
        protected const int k_RequestedNumOfInputs = 3;

        public static void Main()
        {

            System.Console.WriteLine("Please enter {0} binary numbers, {1} digits long and then press 'Enter' after each one", k_RequestedLenOfInput, k_RequestedNumOfInputs);

            BinarySeries(k_RequestedLenOfInput, k_RequestedNumOfInputs);
        }

        private static void BinarySeries(int i_RequestedLen, int i_RequestedNumOfInputs)
        {
            int binaryNumInput, numOfOnes = 0, numOfZeros = 0, decInputNum, numOfNumbersPowOfTwo = 0, numOfNumbersIncreaseSeries = 0, biggestInputNum, lowestInputNum, oneDecNum = 0, twoDecNum = 0, treeDecNum = 0;
            float numOfZerosAvg, numOfOnesAvg;

            for (int i = 0; i < i_RequestedNumOfInputs; ++i)
            {
                binaryNumInput = GetInput(i_RequestedLen);

                numOfOnes += CountOnes(binaryNumInput, i_RequestedLen);
                numOfZeros += CountZeros(binaryNumInput, i_RequestedLen);

                decInputNum = ConvertInputToDec(binaryNumInput, i_RequestedLen);

                numOfNumbersIncreaseSeries += IsIncreaseNum(decInputNum);

                if (i == 0)
                {
                    oneDecNum = decInputNum;
                    numOfNumbersPowOfTwo += IsPowOfTwo(oneDecNum);
                }
                else if (i == 1)
                {
                    twoDecNum = decInputNum;
                    numOfNumbersPowOfTwo += IsPowOfTwo(twoDecNum);
                }
                else
                {
                    treeDecNum = decInputNum;
                    numOfNumbersPowOfTwo += IsPowOfTwo(treeDecNum);
                }
            }

            biggestInputNum = FindTheBiggest(oneDecNum, twoDecNum, treeDecNum);
            lowestInputNum = FindTheLowest(oneDecNum, twoDecNum, treeDecNum);
            numOfZerosAvg = (float)numOfZeros / i_RequestedNumOfInputs;
            numOfOnesAvg = (float)numOfOnes / i_RequestedNumOfInputs;

            PrintStatistics(numOfZerosAvg, numOfOnesAvg, numOfNumbersPowOfTwo, numOfNumbersIncreaseSeries, oneDecNum, twoDecNum, treeDecNum, biggestInputNum, lowestInputNum);
        }

        private static int FindTheBiggest(int i_NumOne, int i_NumTwo, int i_NumTree)
        {
            int maxNum = i_NumOne;

            maxNum = Math.Max(maxNum, i_NumTwo);

            maxNum = Math.Max(maxNum, i_NumTree);

            return maxNum;
        }

        private static int FindTheLowest(int i_NumOne, int i_NumTwo, int i_NumTree)
        {
            int mimNum = i_NumOne;

            mimNum = Math.Min(mimNum, i_NumTwo);

            mimNum = Math.Min(mimNum, i_NumTree);

            return mimNum;
        }

        private static int IsIncreaseNum(int i_DecNum)
        {
            int rightDig = i_DecNum % 10;
            i_DecNum /= 10;
            int unityDigit, isIncreaseNum = 1;

            while (i_DecNum > 0 && isIncreaseNum == 1)
            {
                unityDigit = i_DecNum % 10;
                if (unityDigit >= rightDig)
                {
                    isIncreaseNum = 0;
                }
                else
                {
                    rightDig = unityDigit;
                }

                i_DecNum /= 10;
            }

            return isIncreaseNum;
        }

        private static int GetInput(int i_NumLen)
        {
            string inputNumStr = System.Console.ReadLine();
            int inputNum;
            bool isValidInputNum = int.TryParse(inputNumStr, out inputNum);

            if (isValidInputNum == true)
            {
                isValidInputNum = CheckIfValidBinaryNum(inputNum, i_NumLen);
            }

            while (!isValidInputNum || (inputNumStr != null && inputNumStr.Length != i_NumLen))
            {
                System.Console.WriteLine("Please try again with a valid input");
                inputNumStr = System.Console.ReadLine();
                isValidInputNum = int.TryParse(inputNumStr, out inputNum);
                if (isValidInputNum)
                {
                    isValidInputNum = CheckIfValidBinaryNum(inputNum, i_NumLen);
                }
            }
            return inputNum;
        }

        private static bool CheckIfValidBinaryNum(int i_BinNum, int i_NumLen)
        {
            bool isValidBinNum = true;
            int partialNum;

            for (int i = 0; i < i_NumLen; i++)
            {
                partialNum = i_BinNum % 10;

                if (partialNum != 1 && partialNum != 0)
                {
                    isValidBinNum = false;
                }

                i_BinNum /= 10;
            }

            return isValidBinNum;
        }

        private static int ConvertInputToDec(int i_BinNum, int i_NumLen)
        {
            int decResult = 0;

            for (int i = 0; i < i_NumLen; ++i)
            {
                int unityDigit = i_BinNum % 10;

                if (unityDigit == 1)
                {
                    decResult += unityDigit * (int)System.Math.Pow(2, i);
                }

                i_BinNum /= 10;
            }

            return decResult;
        }

        private static void PrintStatistics(float i_NumOfZerosAvg, float i_NumOfOnesAvg, int i_NumOfNumbersPowOfTwo, int i_NumOfNumbersIncreaseSeries, int i_OneDecNum, int i_TwoDecNum, int i_TreeDecNum, int i_BiggestInputNum, int i_LowestInputNum)
        {

            System.Console.WriteLine(@"The average number of zeros is: {0}
                The average number of ones is: {1}
                The number of numbers which are power of 2 is: {2} 
                The number of increase is: {3}.
                The dec numbers are {4}, {5}, {6}
                The max num is {7}
                The min num is {8}", i_NumOfZerosAvg, i_NumOfOnesAvg, i_NumOfNumbersPowOfTwo,
                i_NumOfNumbersIncreaseSeries, i_OneDecNum, i_TwoDecNum, i_TreeDecNum, i_BiggestInputNum, i_LowestInputNum);
        }

        private static int CountZeros(int i_BinNum, int i_NumLen)
        {
            int numberOfZeros = 0;

            for (int i = 0; i < i_NumLen; ++i)
            {
                int unityDigit = i_BinNum % 10;

                if (unityDigit == 0)
                {
                    numberOfZeros++;
                }

                i_BinNum /= 10;
            }

            return numberOfZeros;
        }

        private static int CountOnes(int i_BinNum, int i_NumLen)
        {
            int numberOfOnes = 0;

            for (int i = 0; i < i_NumLen; ++i)
            {
                int unityDigit = i_BinNum % 10;

                if (unityDigit == 1)
                {
                    numberOfOnes++;
                }

                i_BinNum /= 10;
            }

            return numberOfOnes;
        }

        private static int IsPowOfTwo(int i_DecNum)
        {
            double log = Math.Log(i_DecNum, 2);
            double pow = Math.Pow(2, Math.Round(log));
            int powOfTwo = 0;

            if (pow == i_DecNum)
            {
                powOfTwo = 1;
            }

            return powOfTwo;
        }
    }
}