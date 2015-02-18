using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class RegexMatch
    {
        public static bool isMatch(string source, string express)
        {

            int exIndex = 0;
            bool[,] dpCache = new bool[source.Length+1, express.Length+1];
            for (int i = 0; i <= source.Length; i++)
            {
                dpCache[i, 0] = true;
            }

            for (int i = 0; i <= express.Length; i++)
            {
                dpCache[0, i] = true;
            }

            dpCache[1, 1] = false;


            for (int i = 1; i <= source.Length; i++)
            {
                for (int j = 1; j <= i ; j++)
                {
                    if (express[j - 1] == source[i - 1])
                    {
                        dpCache[i, j] = dpCache[i - 1,j - 1];
                    }
                }
            }

                return false;
        }
    }
}
