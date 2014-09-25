using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class Permutation
    {
        private static int startIndex = 0;
        private static int combinationStartIndex = 0;
        private static List<char> ret = new List<char>();
        public static void FullPermutation(ref char[] str)
        {
            if(startIndex == str.Length-1)
            {
                Console.WriteLine(str);
                return;
            }

            for (int i = startIndex; i < str.Length; i++)
            {
                Swap(ref str, startIndex++, i);
                FullPermutation(ref str);
                Swap(ref str, --startIndex, i);
            }
        }

        public static void FullCombination(ref char[] str)
        {
            if(combinationStartIndex == str.Length)
            {
                Console.WriteLine("empty set");
                return;
            }

            for (int i = combinationStartIndex; i < str.Length; i++)
            {
                ret.Add(str[i]);
                Console.WriteLine(ret.ToArray());
                ret.Remove(str[i]);
            }

            ret.Add(str[combinationStartIndex++]);
            FullCombination(ref str);
        }


        private static void Swap(ref char[] str, int a, int b)
        {
            char c= str[b];
            str[b] = str[a];
            str[a] = c;
        }



        public static void TestFullPermutation()
        {
            char[] str = "abcd".ToCharArray();
            FullPermutation(ref str);
            FullCombination(ref str);
        }
    }
}
