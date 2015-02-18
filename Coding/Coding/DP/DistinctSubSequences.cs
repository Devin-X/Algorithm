using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class DistinctSubSequences
    {
        public static int numDistinct(string s, string t)
        {
            int[,] cache = new int[t.Length + 1, s.Length + 1];
            for (int i = 0; i <= t.Length; i++)
            {
                for (int j = 0; j <= s.Length; j++)
                {
                    cache[i, j] = 0;
                }
            }

            for (int i = 1; i <= t.Length; i++)
            {
                int first = 0;
                for (int j = 1; j <= s.Length; j++)
                {
                    if (s[j-1] == t[i-1])
                    {
                        cache[i, j] = cache[i-1, j-1] + cache[i-1, j];
                        if (cache[i, j] == 0)
                            cache[i, j] = 1;

                        if (first == 0)
                            first = j;
                    }
                    else
                    {
                        cache[i, j] = cache[i - 1, j-1];
                    }
                }

                s = s.Substring(first+1);
            }

            return cache[0,0];
        }

        public static void Test()
        {
            string s, t;

            s = "itiittt";
            t = "it";
            Console.WriteLine(string.Format("{0} <==> {1}, Num: {2}", s, t, numDistinct(s, t)));

            s = "bbbitiittt";
            t = "bbit";
            Console.WriteLine(string.Format("{0} <==> {1}, Num: {2}", s, t, numDistinct(s, t)));

            s = "abbbitiittt";
            t = "bbit";
            Console.WriteLine(string.Format("{0} <==> {1}, Num: {2}", s, t, numDistinct(s, t)));

            s = "rabbbitiittt";
            t = "rabbit";
            Console.WriteLine(string.Format("{0} <==> {1}, Num: {2}", s, t, numDistinct(s, t)));
        }
    }
}
