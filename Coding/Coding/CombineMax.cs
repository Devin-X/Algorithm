using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// Get the max value procuded by the combine int[] 
    /// </summary>
    public static class CombineMaxSolution
    {
        private static int compareInt(int x, int y)
        {
            string bigInt;
            string smallInt;
            bool isXSmaller = false;
            if (x == y)
                return 0;

            if(x > y)
            {
                bigInt = x.ToString();
                smallInt = y.ToString();
                isXSmaller = false;
            }
            else
            {
                bigInt = y.ToString();
                smallInt = x.ToString();
                isXSmaller = true;
            }

            if(!bigInt.StartsWith(smallInt))
            {
                if(bigInt.Length == smallInt.Length)
                    return x > y ? -1 : 1;
                if(bigInt.Length > smallInt.Length)
                {
                    int ret = bigInt.Substring(0, smallInt.Length).CompareTo(smallInt);
                    //Console.WriteLine(string.Format("{0} {1} {2}", bigInt, smallInt, ret));
                    if (isXSmaller)
                        return ret;
                    else
                        return -ret;
                }
            }

            string bigTail = bigInt.Substring(smallInt.Length);
            if(isXSmaller)
            {
                return compareInt(int.Parse(smallInt), int.Parse(bigTail));
            }
            else
            {
                return compareInt(int.Parse(bigTail), int.Parse(smallInt));
            }
        }

        public static string CombineMax(int[] array)
        {
            List<int> list = new List<int>(array);
            list.Sort(compareInt);
            Console.WriteLine(string.Join("", list));
            return string.Join("", list);
        }

        public static void Test()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 6, 7, 8, 9, 0 };
            int[] b = { 123412, 1234 };
            int[] c = { 987698, 9876};
            int[] d = { 123, 456, 789, 89, 89, 99, 99, 998, 0, 00 };
            int[] e = { 888889, 88, 8, 9 };
            int[] f = { 999998, 99, 8, 9 };

            CombineMax(a);
            CombineMax(b);
            CombineMax(c);
            CombineMax(d);
            CombineMax(e);
            CombineMax(f);
        }
    }
}


