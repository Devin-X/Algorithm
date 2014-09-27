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

        public static void FullCombinationRecursive(char[] str)
        {
            if (ret.Count == 0)
            {
                ret.Add(new HashSet<char>());
            }

            if (combinationStartIndex == str.Length)
                return;

            List<HashSet<char>> tempList = new List<HashSet<char>>();
            foreach (HashSet<char> set in ret)
            {
                HashSet<char> temp = new HashSet<char>(set.ToArray());
                temp.Add(str[combinationStartIndex]);
                tempList.Add(temp);
            }

            foreach (HashSet<char> set in tempList)
            {
                ret.Add(set);
            }

            combinationStartIndex++;
            FullCombinationRecursive(str);

        }


        private static int combinationStartIndexII = 0;
        public static List<List<int>> retII = new List<List<int>>();
        public static List<List<int>> retFinal = new List<List<int>>();
        /// <summary>
        /// The str is alredy sorted, as assumption
        /// </summary>
        /// <param name="str"></param>
        /// <param name="target"></param>
        public static List<List<int>> FullCombinationSum(int[] str, int target)
        {
            if (retII.Count == 0)
            {
                retII.Add(new List<int>());
            }

            if (combinationStartIndexII == str.Length)
                return retFinal;

            List<List<int>> tempList = new List<List<int>>();
            foreach (List<int> set in retII)
            {
                List<int> temp = new List<int>(set.ToArray());
                temp.Add(str[combinationStartIndexII]);
                tempList.Add(temp);
            }

            foreach (List<int> set in tempList)
            {
                retII.Add(set);
            }

            combinationStartIndexII++;
            FullCombinationSum(str, target);

            HashSet<int> unique = new HashSet<int>();
            if (combinationStartIndexII == str.Length && retFinal.Count == 0)
            {
                foreach (List<int> list in retII)
                {
                    int sum = 0;
                    int production = 1;
                    Hash(list, sum, production);
                    if (sum == target)
                    {
                        if (unique.Contains(production))
                            continue;
                        retFinal.Add(list.ToList<int>());
                        unique.Add(production);
                    }
                }
            }

            return retFinal;
        }

        private static bool Hash(List<int> array, int sum, int production)
        {
            sum = 0;
            production = 1;
            foreach(int a in array)
            {
                production = production * 10 + a;
                sum += a;
            }

            return true;
        }

        public static void TestFullCombination()
        {
            FullCombination("abc".ToCharArray());
            FullCombinationRecursive("abc".ToCharArray());

            foreach (HashSet<char> set in ret)
            {
                Console.WriteLine(set.ToArray());
            }

            int[] array = {10, 1, 2, 7, 6, 1, 5, 7, 7, 7};
            List<int> list = array.ToList<int>();
            list.Sort();

            FullCombinationSum(list.ToArray<int>(), 8);

            foreach (List<int> set in retFinal)
            {
                foreach (int i in set)
                    Console.Write("{0} ", i);
                Console.WriteLine();
            }
        }
    }
}
