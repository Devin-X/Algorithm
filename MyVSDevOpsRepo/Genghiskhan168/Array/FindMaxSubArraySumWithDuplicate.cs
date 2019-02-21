using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    
    /// <summary>
    /// Find the max sum of a sub array in a array with positive intergers, if in an sub array there are duplicate integers
    /// Need to eliminate 
    /// </summary>
    public class FindMaxSubArraySumWithDuplicate
    {
        public static int GetMaxSum(int[] array)
        {
            Dictionary<int, int> dupCache = new Dictionary<int, int>();
            int[] dpCache = new int[array.Length];
            int maxSum = 0;

            dpCache[0] = array[0];

            for(int i = 1; i < array.Length; i++)
            {
                if(dupCache.ContainsKey(array[i]))
                {
                    int count;
                    dupCache.TryGetValue(array[i], out count);
                    if(count == 1)
                    {
                        if(array[i] >= dpCache[i-1] - array[i])
                        {
                            dpCache[i] = array[i];
                            dupCache.Clear();
                            dupCache.Add(array[i], 1);
                        }else
                        {
                            dpCache[i] = dpCache[i-1] - array[i];
                            dupCache[array[i]]++;
                        }
                    }
                    else
                    {
                        if(array[i] >= dpCache[i-1])
                        {
                            dpCache[i] = array[i];
                            dupCache.Clear();
                            dupCache.Add(array[i], 1);
                        }
                        else
                        {
                            dpCache[i] = dpCache[i - 1];
                            dupCache[array[i]]++;
                        }
                    }
                }
                else
                {
                    dpCache[i] = dpCache[i-1] + array[i];
                    dupCache.Add(array[i], 1);
                }
                
                maxSum = Math.Max(maxSum, dpCache[i]);
            }

            return maxSum;
        }

        public static void Test()
        {
            int[] a = new int[]{ 100, 8, 1, 3, 8, 8};
            int[] b = new int[] { 2, 8, 1, 3, 8, 8 };
            int[] c = new int[] { 1, 2, 3, 2, 2 };
            int[] d = new int[] { 1, 2, 3, 3, 2, 2, 4};
            int[] e = new int[] { 100, 2, 3, 3, 2, 2 };
            int[] f = new int[] { 11, 5, 7, 4, 11, 7, 4, 2, 2, 5, 9, 4, 5, 11, 5, 1};

            Console.WriteLine(string.Join(",", a));
            Console.WriteLine(GetMaxSum(a));
            Console.WriteLine(string.Join(",", b));
            Console.WriteLine(GetMaxSum(b));
            Console.WriteLine(string.Join(",", c));
            Console.WriteLine(GetMaxSum(c));
            Console.WriteLine(string.Join(",", d));
            Console.WriteLine(GetMaxSum(d));
            Console.WriteLine(string.Join(",", e));
            Console.WriteLine(GetMaxSum(e));
            Console.WriteLine(string.Join(",", f));
            Console.WriteLine(GetMaxSum(f));
        }
    }
}
