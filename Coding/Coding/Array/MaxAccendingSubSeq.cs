using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class MaxAccendingSubSeq
    {
        public static int GetMaxAccessendingSubSeqCount(int[] array)
        {
            int[] dpCache = new int[array.Length];
            int ret = 1;

            dpCache[0] = 1;

            for(int i = 1; i < array.Length; i++)
            {
                dpCache[i] = 1;


                int j = i - 1;
                while (j >= 0)
                {
                    dpCache[i] = array[i] > array[j] ? Math.Max(dpCache[i], dpCache[j] + 1) : dpCache[i];
                    j--;
                }

                ret = Math.Max(dpCache[i], ret);
            }

            return ret;
        }


        public static int GetMaxIncreaingSubSeqNlgN(int[] array)
        {
            int[] dpCache = new int[array.Length];
            int max = 1;
            for(int i = 0; i < dpCache.Length; i++)
            {
                dpCache[i] = int.MaxValue;
            }

            dpCache[0] = array[0];

            for (int i = 1; i < dpCache.Length; i++)
            {
                dpCache[BinarySearch(dpCache, array[i], 0, i)] = array[i];
            }

            for(int i = dpCache.Length-1; i >=0; i--)
            {
                if (dpCache[i] != int.MaxValue)
                {
                    max = i + 1;
                    break;
                }
            }

            return max;
        }


        private static int BinarySearch(int[] array, int target,int start, int end)
        {
            if(start == end || start > end)
            {
                if(array[start] < target)
                {
                    return start + 1;
                }
                else
                    if (array[start] >= target)
                    {
                        return start;
                    }
            }

            int middle = (end - start) / 2 + start;
            if(array[middle] < target)
            {
                return BinarySearch(array, target, middle+1, end);
            }

            return BinarySearch(array, target, start, middle-1);
        }


        public static void Test()
        {
            int[] a = { 1, 4, 2, 3, 7, 5, 6, 7 };

            Console.WriteLine("{0}  --> {1}", string.Join(",", a), GetMaxAccessendingSubSeqCount(a));
            Console.WriteLine("{0}  --> {1}", string.Join(",", a), GetMaxIncreaingSubSeqNlgN(a));

            int[] b = {9, 8, 7, 6, 5, 4, 3, 2, 1};

            Console.WriteLine("{0}  --> {1}", string.Join(",", b), GetMaxAccessendingSubSeqCount(b));
            Console.WriteLine("{0}  --> {1}", string.Join(",", b), GetMaxIncreaingSubSeqNlgN(b));


            int[] c = { 1 };

            Console.WriteLine("{0}  --> {1}", string.Join(",", c), GetMaxAccessendingSubSeqCount(c));
            Console.WriteLine("{0}  --> {1}", string.Join(",", c), GetMaxIncreaingSubSeqNlgN(c));


            int[] d = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("{0}  --> {1}", string.Join(",", d), GetMaxAccessendingSubSeqCount(d));
            Console.WriteLine("{0}  --> {1}", string.Join(",", d), GetMaxIncreaingSubSeqNlgN(d));
        }
    }
}
