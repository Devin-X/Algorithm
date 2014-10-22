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
            int maxSum = 0;
            int windowStart = 0;
            int sum = array[0];
            dupCache.Add(array[0], array[0]);

            for(int i = 1; i < array.Length; i++)
            {
                if(dupCache.ContainsKey(array[i]))
                {
                    int cutMax;
                    dupCache.TryGetValue(array[i], out cutMax);
                    if((sum - cutMax + array[i]) >= sum - array[i])
                    {
                        sum = sum - cutMax + array[i];
                        int cutWindow = windowStart;
                        while(cutWindow < i && array[cutWindow] != array[i])
                        {
                            dupCache.Remove(array[cutWindow]);
                            cutWindow++;
                        }

                        cutWindow++;
                        windowStart = cutWindow;

                        List<int> keys = dupCache.Select(p => p.Key).ToList();
                        foreach(int k in keys)
                        {
                            dupCache[k] = dupCache[k] - cutMax;
                        }
                        dupCache[array[i]] = sum;
                    }
                    else
                    {
                        sum -= array[i];
                        dupCache[array[i]] = sum;
                    }
                }
                else
                {
                    sum += array[i];
                    dupCache.Add(array[i], sum);
                }
                
                maxSum = Math.Max(maxSum, sum);
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
            int[] f = new int[] { 11, 5, 7, 4, 11, 7, 4, 2, 2, 5, 9, 4, 5, 11, 5, 1 };

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
