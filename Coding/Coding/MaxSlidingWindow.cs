using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class MaxSlidingWindowSolution
    {
        public static  int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums.Length == 0 || k == 0)
            {
                return new int[0];
            }

            Dictionary<int, int> dict = new Dictionary<int, int>();
            SortedSet<int> kSet = new SortedSet<int>();

            int[] ret = new int[nums.Length- k + 1];

            int step = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                kSet.Add(nums[i]);
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
                if (i < k)
                    continue;

                kSet.Remove(nums[i - k]);
                dict[nums[i - k]]--;
                if (dict[nums[i - k]] >= 1)
                {
                    kSet.Add(nums[i - k]);
                }

                ret[step++] = kSet.Max;
            }

            return ret;
        }

        public static void Test()
        {
            int[] nums = { 1, 3, -1, -3, 5, 3, 6, 7 };

            int[] ret = MaxSlidingWindow(nums, 3);

            Console.WriteLine(string.Join(",", ret));

            ret = MaxSlidingWindow(nums, 1);

            Console.WriteLine(string.Join(",", ret));

            ret = MaxSlidingWindow(nums, 8);

            Console.WriteLine(string.Join(",", ret));

            int[] num2 = {-7, -8, 7, 5, 7, 1, 6, 0};
            ret = MaxSlidingWindow(num2, 4);

            Console.WriteLine(string.Join(",", ret));

        }
    }
}
