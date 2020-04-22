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
            int BinaryNumInput, numOfOnes = 0, numOfZeros = 0 ,decInputNum , numOfNumbersPowOfTwo = 0, numOfNumbersIncreaseSeries = 0, biggestInputNum, lowestInputNum, oneDecNum = -1, twoDecNum = -1, treeDecNum = -1;
            float numOfZerosAvg = 0, numOfOnesAvg = 0;

            for (int i = 0; i < i_RequestedNumOfInputs; ++i)
            {
                BinaryNumInput = getInput(i_RequestedLen);

                numOfOnes += countOnes(BinaryNumInput, i_RequestedLen);
                numOfZeros += countZeros(BinaryNumInput, i_RequestedLen);

                decInputNum = convertInputToDec(BinaryNumInput, i_RequestedLen);

                numOfNumbersIncreaseSeries += isIncreaseNum(decInputNum);

                //numOfNumbersIncreaseSeries += isIncreaseNum(BinaryNumInput, i_RequestedLen);
                if (i == 0)
                {
                    oneDecNum = decInputNum;
                    //oneDecNum = convertInputToDec(BinaryNumInput, i_RequestedLen);
                    numOfNumbersPowOfTwo += isPowOfTwo(oneDecNum);
                }
                else if (i == 1)
                {
                    twoDecNum = decInputNum;
                    numOfNumbersPowOfTwo += isPowOfTwo(twoDecNum);
                }
                else 
                {
                    treeDecNum = decInputNum;
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

            maxNum = Math.Max(maxNum,i_NumTwo);

            maxNum = Math.Max(maxNum,i_NumTree);

            return maxNum;
        }

        private static int findTheLowest(int i_NumOne, int i_NumTwo, int i_NumTree)
        {
           int mimNum = i_NumOne;

           mimNum = Math.Min(mimNum, i_NumTwo);

           mimNum = Math.Min(mimNum, i_NumTree);

            return mimNum;
        }

       /* private static int isIncreaseNum(int i_Num, int i_RequestedLen)
        {
            int DecNum = convertInputToDec(i_Num, i_RequestedLen);
            int rightDig = DecNum % 10;
            DecNum /= 10;
            int unityDigit, FlagIsIncrease = 1;

            while (DecNum > 0 && FlagIsIncrease == 1)
            {
                unityDigit = DecNum % 10; ;
                if (unityDigit >= rightDig)
                {
                    FlagIsIncrease = 0;
                }
                else
                {
                    rightDig = unityDigit;
                }
                DecNum /= 10;
            }
            return FlagIsIncrease;
        }*/

        private static int isIncreaseNum(int i_DecNum)
        {
            int rightDig = i_DecNum % 10;
            i_DecNum /= 10;
            int unityDigit, isIncreaseNum = 1;

            while (i_DecNum > 0 && isIncreaseNum == 1)
            {
                unityDigit = i_DecNum % 10; ;
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

        private static int getInput(int i_NumLen)
        {
            string inputNumStr = System.Console.ReadLine();
            int inputNum;
            bool isValidInputNum = int.TryParse(inputNumStr, out inputNum);

            if(isValidInputNum == true)
            {
                isValidInputNum = checkIfValidBinaryNum(inputNum, i_NumLen);
            }
            /*
            if(!isValidInputNum || inputNumStr.Length != i_NumLen)
            {
                System.Console.WriteLine("Please try again with a valid input");
               // getInput(i_NumLen);
               inputNum = -1;
            }
            */

            while (!isValidInputNum || (inputNumStr != null && inputNumStr.Length != i_NumLen))
            {
                System.Console.WriteLine("Please try again with a valid input");
                inputNumStr = System.Console.ReadLine();
                isValidInputNum = int.TryParse(inputNumStr, out inputNum);
                if (isValidInputNum)
                {
                    isValidInputNum = checkIfValidBinaryNum(inputNum, i_NumLen);
                }
            }

            return inputNum;
        }

        private static bool checkIfValidBinaryNum(int i_BinNum, int i_NumLen)
        {
            bool isValidBinNum = true;
            int partialNum;


            for(int i = 0; i < i_NumLen; i++)
            {
                partialNum = i_BinNum % 10;

                if(partialNum != 1 && partialNum != 0)
                {
                    isValidBinNum = false;
                }

                i_BinNum /= 10;
            }

            return isValidBinNum;
        }

        private static int convertInputToDec(int i_BinNum, int i_NumLen)
        {
            int decResult = 0;

            for(int i = 0; i < i_NumLen; ++i)
            {
                int unityDigit = i_BinNum % 10;

                if(unityDigit == 1)
                {
                    decResult += unityDigit * (int)System.Math.Pow(2, i);

                }
                i_BinNum /= 10;
            }

            return decResult;
        }

        //private static void printTheDecNum(int i_DecNum){ }

        //private static void printStatistics(int i_DecNum){ }

        private static int countZeros(int i_BinNum, int i_NumLen)
        {
            int numberOfZeros = 0;

            for(int i = 0; i < i_NumLen; ++i)
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

        private static int countOnes(int i_BinNum, int i_NumLen)
        {
            int numberOfOnes = 0;

            for(int i = 0; i < i_NumLen; ++i)
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

        private static int isPowOfTwo(int i_DecNum)
        {
            double log = Math.Log(i_DecNum, 2);
            double pow = Math.Pow(2, Math.Round(log));
            int powOfTwo = 0;

            if(pow == i_DecNum)
                powOfTwo = 1;

            return powOfTwo;
        }
    }
}

