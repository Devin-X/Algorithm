using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.DP
{
    public class HouseRobber
    {
        public int Rob(int[] nums)
        {
            int[] ret = new int[nums.Length];
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
            if (nums.Length == 3) return Math.Max(Math.Max(nums[0], nums[1]), nums[2]);

            int n = nums.Length;
            ret[0] = nums[0];
            ret[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < n - 1; i++)
            {
                ret[i] = Math.Max(ret[i - 2] + nums[i], ret[i - 1]);
            }

            int final1 = ret[n - 2];

            ret[1] = nums[1];
            ret[2] = Math.Max(nums[2], nums[1]);
            for (int i = 3; i < n; i++)
            {
                ret[i] = Math.Max(ret[i - 2] + nums[i], ret[i - 1]);
            }

            return Math.Max(final1, ret[n - 1]);

        }
    }
}
