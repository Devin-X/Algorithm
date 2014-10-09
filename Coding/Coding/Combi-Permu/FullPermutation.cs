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
        private static HashSet<string> retCollection = new HashSet<string>();
        public static List<int[]> retCollectionArray = new List<int[]>();

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

        public static int Fullpermutation(string s, int start)
        {
            if (start == s.Length)
            {
                Console.WriteLine(s);
                return 0;
            }

            char[] cArray = s.ToCharArray();

            for (int i = start; i < cArray.Length; i++)
            {
                char temp = cArray[i];
                cArray[i] = cArray[start];
                cArray[start] = temp;
                string ss = new string(cArray);
                Fullpermutation(ss, start + 1);
                temp = cArray[i];
                cArray[i] = cArray[start];
                cArray[start] = temp;
            }

            return 0;
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

        public static void UniquePermurationPhilip(ref int[] array)
        {
            if (array.Length <= 0)
                return;
            bool[] visit = new bool[array.Length];
            List<int> solution = new List<int>();
            PhilipInner(ref array, ref solution, ref visit);

            return;
        }
        private static void PhilipInner(ref int[] array, ref List<int> solution, ref bool[] visit)
        {
            if(array.Length == solution.Count)
            {
                retCollectionArray.Add(solution.ToArray());
            }

            int previous = int.MaxValue;
            for(int i = 0; i < array.Length; i++)
            {
                if (!visit[i] && array[i] != previous)
                {
                    visit[i] = true;
                    solution.Add(array[i]);
                    PhilipInner(ref array, ref solution, ref visit);
                    solution.Remove(array[i]);
                    visit[i] = false;
                    previous = array[i];
                }
            }
        }

        /// <summary>
        /// Assume the arry is already sorted, but there are duplicate in the array. 
        /// </summary>
        /// <param name="array"></param>
        public static void UniquePermutatiaonsInt(ref int[] array)
        {
            if (startIndex == array.Length - 1)
            {
                retCollectionArray.Add(array.ToArray());
                return;
            }

            HashSet<int> map = new HashSet<int>();

            for (int i = startIndex; i < array.Length; i++)
            {
                if (!map.Contains(array[i]))
                {
                    Swap(ref array, startIndex++, i);
                    UniquePermutatiaonsInt(ref array);
                    Swap(ref array, --startIndex, i);
                    map.Add(array[i]);
                }
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

        //https://oj.leetcode.com/problems/next-permutation/
        public static void TestFullPermutation()
        {
            char[] str = "abcd".ToCharArray();
            //FullPermutation(ref str);
            //FullCombination(ref str);
            Console.WriteLine("Above is the full permutatin for {0} --> !!{1}", "abcd", Fullpermutation("abcd", 0));
            Console.WriteLine("Above is the full permutatin for {0} --> !!{1}", "ab", Fullpermutation("ab", 0));
            Console.WriteLine("Above is the full permutatin for {0} --> !!{1}", "abc", Fullpermutation("abc", 0));

            //str = "1112".ToCharArray();
            //UniquePermutations(ref str);
            int[] array = {1, 2, 2, 1 };

            UniquePermutatiaonsInt(ref array);

            foreach (int[] s in retCollectionArray)
            {
                foreach (int a in s)
                    Console.Write(a);
                Console.WriteLine();
            }

            UniquePermurationPhilip(ref array);
        }

    }
}
