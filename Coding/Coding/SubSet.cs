using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class SubSet
    {
        private static int combinationStartIndex = 0;

        public static List<List<int>> ret = new List<List<int>>();

        public static void FullCombination(int[] str)
        {
            if (ret.Count == 0)
            {
                ret.Add(new List<int>());
            }

            if (combinationStartIndex == str.Length)
                return;

            for (int i = combinationStartIndex; i < str.Length; i++)
            {
                List<List<int>> tempList = new List<List<int>>();
                foreach (List<int> set in ret)
                {
                    List<int> temp = new List<int>(set.ToArray());
                    temp.Add(str[i]);
                    tempList.Add(temp);
                }

                foreach (List<int> set in tempList)
                {
                    ret.Add(set);
                }

                combinationStartIndex++;
            }
        }

        public static void FullCombinationRecursive(int[] str)
        {
            if (ret.Count == 0)
            {
                ret.Add(new List<int>());
            }

            if (combinationStartIndex == str.Length)
                return;

            List<List<int>> tempList = new List<List<int>>();
            foreach (List<int> set in ret)
            {
                List<int> temp = new List<int>(set.ToArray());
                temp.Add(str[combinationStartIndex]);
                tempList.Add(temp);
            }

            foreach (List<int> set in tempList)
            {
                ret.Add(set);
            }

            combinationStartIndex++;
            FullCombinationRecursive(str);

        }

        public static void FullCombinationRecursiveWithDup(int[] str)
        {
            if (ret.Count == 0)
            {
                ret.Add(new List<int>());
            }

            if (combinationStartIndex == str.Length)
                return;

            if (combinationStartIndex > 0 && str[combinationStartIndex] == str[combinationStartIndex - 1])
            {
                List<int> temp = new List<int>(ret.Last<List<int>>());
                temp.Add(str[combinationStartIndex]);
                ret.Add(temp);
            }
            else
            {
                List<List<int>> tempList = new List<List<int>>();
                foreach (List<int> set in ret)
                {
                    List<int> temp = new List<int>(set.ToArray());
                    temp.Add(str[combinationStartIndex]);
                    tempList.Add(temp);
                }

                foreach (List<int> set in tempList)
                {
                    ret.Add(set);
                }
            }

            combinationStartIndex++;
            FullCombinationRecursiveWithDup(str);

        }
        public static void TestSubSet()
        {
            int[] a = { 1, 1, 2, 3, 3 };

            //FullCombination(a);
            //FullCombinationRecursive(a);
            FullCombinationRecursiveWithDup(a);

            foreach (List<int> l in ret)
            {
                foreach (int t in l)
                    Console.Write(t);
                Console.WriteLine();
            }
        }
    }
}
