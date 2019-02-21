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

            int first = s.IndexOf(t[0]);
            if (first < 0) return 0;
            s = s.Substring(first);

            for (int j = 1; j <= s.Length; j++)
            {
                if (s[j - 1] == t[0])
                    cache[1, j] = cache[1, j - 1] + 1;
                else
                    cache[1, j] = cache[1, j - 1];
            }

            for (int i = 2; i <= t.Length; i++)
            {
                for (int j = i; j <= s.Length; j++)
                {
                    if (s[j - 1] == t[i - 1])
                    {
                        cache[i, j] = cache[i, j - 1] + cache[i - 1, j - 1];
                    }
                    else
                    {
                        cache[i, j] = cache[i, j - 1];
                    }
                }
            }

            for (int i = 0; i <= t.Length; i++)
            {
                for (int j = 0; j <= s.Length; j++)
                {
                    Console.Write(cache[i, j] + "\t");
                }
                Console.WriteLine();
            }

            return cache[t.Length, s.Length];
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

            s = "aaabbbitiittt";
            t = "abbit";
            Console.WriteLine(string.Format("{0} <==> {1}, Num: {2}", s, t, numDistinct(s, t)));
        }
    }
}
