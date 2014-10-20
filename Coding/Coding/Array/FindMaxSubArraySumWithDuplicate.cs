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
            HashSet<int> duphash = new HashSet<int>();
            int[] sumCache = new int[array.Length];
            int maxSum = 0;

            for(int i = 0 ; i < array.Length; i++)
            {
                maxSum += array[i];
                sumCache[i] = maxSum;
            }
            maxSum = 0;

            for(int i = 1; i < array.Length; i++)
            {
                if(dupCache.ContainsKey(array[i]))
                {
                    int index;
                    dupCache.TryGetValue(array[i], out index);
                    if (!duphash.Contains(array[i]))
                    {
                        //the current integer is duplicate
                        sumCache[i] = Math.Max((sumCache[i-1] - array[i]), (sumCache[i] - sumCache[index]));
                        duphash.Add(array[i]);
                    }
                    else
                    {
                        //the current integer is more than duplicate
                        sumCache[i] = Math.Max((sumCache[i-1]), (sumCache[i] - sumCache[index]));
                        //duphash.Add(array[i]);
                    }

                    dupCache[array[i]] = index;

                }
                else
                {
                    sumCache[i] = sumCache[i-1] + array[i];
                    dupCache.Add(array[i], i);
                }
                
                maxSum = Math.Max(maxSum, sumCache[i]);
            }

            return maxSum;
        }

        public static void Test()
        {
            int[] a = new int[]{ 100, 8, 1, 3, 8, 8};
            int[] b = new int[] { 2, 8, 1, 3, 8, 8 };

            Console.WriteLine(string.Join(",", a));
            Console.WriteLine(GetMaxSum(a));
            Console.WriteLine(string.Join(",", b));
            Console.WriteLine(GetMaxSum(b));
        }
    }
}
