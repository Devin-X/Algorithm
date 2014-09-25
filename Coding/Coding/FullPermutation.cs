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
        private static int uniqueIndex = 0;
        private static int uniqueCount = 0;
        private static HashSet<string> retCollection = new HashSet<string>();
        public static HashSet<int[]> retCollectionArray = new HashSet<int[]>();

        private static List<char> ret = new List<char>();
        public static void FullPermutation(ref char[] str)
        {
            if (startIndex == str.Length - 1)
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
            if (combinationStartIndex == str.Length)
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

        public static void UniquePermutations(ref char[] str)
        {
            if (uniqueIndex == str.Length - 1)
            {
                int count = retCollection.Count;
                retCollection.Add(new string(str));
                if (retCollection.Count > count)
                {
                    Console.WriteLine(str);
                    return;
                }
            }

            for (int i = uniqueIndex; i < str.Length; i++)
            {
                Swap(ref str, uniqueIndex++, i);
                UniquePermutations(ref str);
                Swap(ref str, --uniqueIndex, i);
            }
        }

        /// <summary>
        /// Assume the arry is already sorted, but there are duplicate in the array. 
        /// </summary>
        /// <param name="array"></param>
        public static void UniquePermutatiaonsInt(ref int[] array)
        {
            if (uniqueIndex == array.Length)
            {
                retCollectionArray.Add(array.ToArray());
                return;
            }

            bool skip = true;
            int i = uniqueIndex;

            while (skip && i < array.Length - 1)
            {
                skip = array[i++] == array[uniqueIndex];
            }

            if (i == array.Length)
                return;

            int temp = uniqueIndex;
            uniqueIndex = i;
            i = temp;

            for (; i < array.Length; i++)
            {
                Swap(ref array, uniqueIndex++, i);
                UniquePermutatiaonsInt(ref array);
                Swap(ref array, --uniqueIndex, i);
            }
        }

        private static void Swap(ref char[] str, int a, int b)
        {
            char c = str[b];
            str[b] = str[a];
            str[a] = c;
        }

        private static bool Swap(ref int[] str, int a, int b)
        {

            int c = str[b];
            str[b] = str[a];
            str[a] = c;

            if (str[b] == str[a])
                return true;
            return false;
        }

        public static void TestFullPermutation()
        {
            char[] str = "abcd".ToCharArray();
            //FullPermutation(ref str);
            //FullCombination(ref str);


            //str = "1112".ToCharArray();
            //UniquePermutations(ref str);
            int[] array = { 1, 1, 1, 2, 2 };

            UniquePermutatiaonsInt(ref array);

            foreach (int[] s in retCollectionArray)
            {
                foreach (int a in s)
                    Console.Write(a);
                Console.WriteLine();
            }
        }

    }
}
