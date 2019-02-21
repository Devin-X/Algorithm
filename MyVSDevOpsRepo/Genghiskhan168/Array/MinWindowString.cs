using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class MinWindowString
    {
        public static string MinWindow(string s, string t)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char c in t)
            {
                if (!map.ContainsKey(c))
                {
                    map.Add(c, 1);
                }
                else
                {
                    map[c]++;
                }
            }

            int uniqueCount = map.Count;
            int pos_head = 0;
            int pos_end = 0;
            int minLen = int.MaxValue;
            int min_head = 0;

            foreach (char c in s)
            {
                if (map.ContainsKey(c) && --map[c] == 0)
                {
                    uniqueCount--;
                }

                pos_end++;
                if (uniqueCount > 0)
                    continue;

                bool windowFound = true;
                while (windowFound)
                {
                    char head = s[pos_head];
                    if (map.ContainsKey(head))
                    {
                        ++map[head];
                        if (map[head] > 0)
                        {
                            uniqueCount++;
                            windowFound = false;
                        }

                        if (minLen > pos_end - pos_head)
                        {
                            min_head = pos_head;
                            minLen = pos_end - min_head;
                        }
                    }

                    pos_head++;
                }
            }

            return minLen == int.MaxValue ? string.Empty : s.Substring(min_head, minLen);
        }

        public static void Test()
        {
            Console.WriteLine(MinWindow("ADOBECODEBANC", "AABCBC"));
        }
    }
}
