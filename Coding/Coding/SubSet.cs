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

        public static List<List<int>> previous = new List<List<int>>();
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
                foreach (List<int> temp in previous)
                {
                    temp.Add(str[combinationStartIndex]);
                    ret.Add(new List<int>(temp));
                }
            }
            else
            {
                previous.Clear();
                foreach (List<int> set in ret)
                {
                    List<int> temp = new List<int>(set.ToArray());
                    temp.Add(str[combinationStartIndex]);
                    previous.Add(temp);
                }

                foreach (List<int> set in previous)
                {
                    ret.Add(new List<int>(set));
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

            combinationStartIndex = 0;
            previous.Clear();
            ret.Clear();
            int[] b = { 1 };
            FullCombinationRecursiveWithDup(b);
            foreach (List<int> l in ret)
            {
                foreach (int t in l)
                    Console.Write(t);
                Console.WriteLine();
            }

            combinationStartIndex = 0;
            previous.Clear();
            ret.Clear();
            int[] c = {1, 1, 1, 2, 2, 2};
            FullCombinationRecursiveWithDup(c);
            foreach (List<int> l in ret)
            {
                foreach (int t in l)
                    Console.Write(t);
                Console.WriteLine();
            }
        }
    }
}
