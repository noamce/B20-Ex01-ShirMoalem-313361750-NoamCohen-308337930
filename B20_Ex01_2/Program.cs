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
            int k_numOfAshteriskInLine = 5;
            int k_numOfSpacesInLine = 0;
            StringBuilder sandClock = new StringBuilder();
            BuildSandClock(k_numOfAshteriskInLine, k_numOfSpacesInLine, sandClock);
            System.Console.WriteLine(sandClock);
        }

        private static void BuildSandClock(int i_NumOfAshtrikInLine, int i_NumOfSpaces, StringBuilder o_SandClock)
        {
            if (i_NumOfAshtrikInLine >= 1)
            {
                for (int i = 0; i < i_NumOfSpaces; i++)
                {
                    o_SandClock.Append(' ');
                }

                for (int i = 0; i < i_NumOfAshtrikInLine; i++)
                {
                    o_SandClock.Append('*');
                }

                o_SandClock.Append('\n');
                BuildSandClock(i_NumOfAshtrikInLine - 2, i_NumOfSpaces + 1, o_SandClock);
            }

            if (i_NumOfAshtrikInLine - 2 >= 1)
            {
                for (int i = 0; i < i_NumOfSpaces; i++)
                {
                    o_SandClock.Append(' ');
                }

                for (int i = 0; i < i_NumOfAshtrikInLine; i++)
                {
                    o_SandClock.Append('*');
                }

                o_SandClock.Append('\n');
            }
        }
    }
}
