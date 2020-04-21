using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B20_Ex01_2
{
    class Program
    {
        public static void Main()
        {
            int numOfAshtrikInLine = 5;
            int numOfSpaces = 0;
            //StringBuilder represents a mutable string of characters.
            StringBuilder sandClock = new StringBuilder();
            //System.Text.StringBuilder sandClock = new System.Text.StringBuilder(string.Empty);
            buildSandClock(numOfAshtrikInLine, numOfSpaces, sandClock);
            System.Console.WriteLine(sandClock);
            
        }

        private static void buildSandClock(int i_NumOfAshtrikInLine, int i_NumOfSpaces, StringBuilder SandClock)
        {
            if (i_NumOfAshtrikInLine >= 1)
            {
                for (int i = 0; i < i_NumOfSpaces; i++)
                {
                    SandClock.Append(' ');
                }

                for (int i = 0; i < i_NumOfAshtrikInLine; i++)
                {
                    SandClock.Append('*');
                }

                SandClock.Append('\n');
                buildSandClock(i_NumOfAshtrikInLine - 2, i_NumOfSpaces + 1, SandClock);
            }

            if (i_NumOfAshtrikInLine <= -1)
            {
                for (int i = 0; i < -(i_NumOfSpaces); i++)
                {
                    SandClock.Append(' ');
                }

                for (int i = 0; i < -(i_NumOfAshtrikInLine); i++)
                {
                    SandClock.Append('*');
                }

                SandClock.Append('\n');
                buildSandClock(i_NumOfAshtrikInLine - 2, i_NumOfSpaces - 1, SandClock);
            }

        }
    }
}
