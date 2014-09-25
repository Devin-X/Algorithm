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

        private static void Swap(ref char[] str, int a, int b)
        {
            char c= str[b];
            str[b] = str[a];
            str[a] = c;
        }

        public static void TestFullPermutation()
        {
            char[] str = "aBcD".ToCharArray();
            FullPermutation(ref str);

        }
    }
}
