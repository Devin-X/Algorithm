using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Combination
    {
        private static int combinationStartIndex = 0;
        public static List<HashSet<char>> ret = new List<HashSet<char>>();

        public static void FullCombination(char[] str)
        {
            if (ret.Count == 0)
            {
                ret.Add(new HashSet<char>());
            }

            if (combinationStartIndex == str.Length)
                return;

            for (int i = combinationStartIndex; i < str.Length; i++)
            {
                List<HashSet<char>> tempList = new List<HashSet<char>>();
                foreach (HashSet<char> set in ret)
                {
                    HashSet<char> temp = new HashSet<char>(set.ToArray());
                    temp.Add(str[i]);
                    tempList.Add(temp);
                }

                foreach (HashSet<char> set in tempList)
                {
                    ret.Add(set);
                }

                combinationStartIndex++;
            }
        }


        public static void TestFullCombination()
        {
            FullCombination("abc".ToCharArray());

            foreach (HashSet<char> set in ret)
            {
                Console.WriteLine(set.ToArray());
            }
        }
    }
}
