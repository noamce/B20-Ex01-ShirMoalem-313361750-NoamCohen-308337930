using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex01_2
{
    public class Program
    {
        public const int k_numOfAsterisksInLine = 5;

        public static void Main()
        {
            PrintHourGlassOfAsterisks(k_numOfAsterisksInLine);
        }

        public static void PrintHourGlassOfAsterisks(int i_HourGlassHeight)
        {
            int numOfSpacesInLine = 0;
            StringBuilder hourGlassString = new StringBuilder();
            BuildHourGlass(i_HourGlassHeight, numOfSpacesInLine, hourGlassString);
            System.Console.WriteLine(hourGlassString);
        }

        private static void BuildHourGlass(int i_NumOfAsterisksInLine, int i_NumOfSpaces, StringBuilder o_HourGlassString)
        {
            if (i_NumOfAsterisksInLine >= 1)
            {
                for (int i = 0; i < i_NumOfSpaces; i++)
                {
                    o_HourGlassString.Append(' ');
                }

                for (int i = 0; i < i_NumOfAsterisksInLine; i++)
                {
                    o_HourGlassString.Append('*');
                }

                o_HourGlassString.Append('\n');
                BuildHourGlass(i_NumOfAsterisksInLine - 2, i_NumOfSpaces + 1, o_HourGlassString);
            }

            if (i_NumOfAsterisksInLine - 2 >= 1)
            {
                for (int i = 0; i < i_NumOfSpaces; i++)
                {
                    o_HourGlassString.Append(' ');
                }

                for (int i = 0; i < i_NumOfAsterisksInLine; i++)
                {
                    o_HourGlassString.Append('*');
                }

                o_HourGlassString.Append('\n');
            }
        }
    }
}
