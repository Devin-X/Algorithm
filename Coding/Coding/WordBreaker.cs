using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class WordBreaker
    {
        public static HashSet<string> dict = new HashSet<string>();
        public static int[] dpcache = null;

        public static bool wordBreak(string s, int len)
        {
            if (s == "")
                return true;
            if(dpcache == null)
            {
                dpcache = new int[len];
                for (int i = 0; i < len; i++)
                    dpcache[i] = -1;
                int index = -1;

                for(int i = s.Length -1 ; i >= 0; i--)
                {
                    if(dict.Contains(s.Substring(i)))
                    {
                        index = i;
                    }

                    dpcache[i] = index;
                }
            }

            for(int i = 1; i <= s.Length; i++)
            {
                if (dict.Contains(s.Substring(0, i)) && dpcache[len - s.Length + i - 1] != -1)
                {
                    bool ret = wordBreak(s.Substring(i), len);
                    if (ret)
                        return ret;
                }
            }

            return false;
        }

        private static List<string> temp = new List<string>();
        private static int totalLen = 0;
        public static bool wordBreakII(string s, int len)
        {
            if (s == "")
                return true;
            if (dpcache == null)
            {
                dpcache = new int[len];
                for (int i = 0; i < len; i++)
                    dpcache[i] = -1;
                int index = -1;

                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (dict.Contains(s.Substring(i)))
                    {
                        index = i;
                    }

                    dpcache[i] = index;
                }
            }

            for (int i = 1; i <= s.Length; i++)
            {
                if (dict.Contains(s.Substring(0, i)) && dpcache[len - s.Length + i - 1 ] != -1)
                {
                    temp.Add(s.Substring(0, i));
                    totalLen += i;
                    bool ret = wordBreakII(s.Substring(i), len);
                    if (ret)
                    {
                        totalLen -= i;
                        if (totalLen > 0)
                            return true;
                        else
                        {
                            Console.WriteLine(string.Join(",", temp));
                            temp.Clear();
                            temp.Add(s.Substring(0, i));
                            totalLen += i;
                        }
                    }

                    totalLen -= i;
                    temp.Remove(s.Substring(0, i));
                }
            }

            return false;
        }

        public static void Test()
        {
            string[] data = { "a", "b", "bbb", "bbbb", "leet", "cod", "e","dde", "co", "de", "aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"};
            dict = new HashSet<string>(data);
            Console.WriteLine();
            Console.WriteLine("{0}", wordBreak("bb", 2));
            dpcache = null;
            Console.WriteLine("{0}", wordBreak("leetcode", 8));
            wordBreakII("leetcode", 8);

            dpcache = null;
            string s = "baaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            Console.WriteLine("{0}", wordBreak(s, s.Length));

        }
    }
}
