using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Array
{
    class ProductExceptItselfSolution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] ret = new int[nums.Length];
            int[] retLeft = new int[nums.Length];
            int[] retRight = new int[nums.Length];

            retLeft[0] = nums[0];
            retRight[nums.Length - 1] = nums[nums.Length - 1];

            for (int i = 1; i < ret.Length-1; i++)
            {
                retLeft[i] = nums[i]*retLeft[i - 1];
            }

            for (int i = ret.Length - 2; i > -1; i--)
            {
                retRight[i] = nums[i] * retRight[i + 1];
            }

            for (int i = 0; i < nums.Length; i ++)
            {
                ret[i] = (i > 0 ? retLeft[i - 1] : 1)* (i < nums.Length-1 ? retRight[i + 1] : 1);
            }

            return ret;
        }


        public int[] ProductExceptSelfSlowVersion(int[] nums)
        {
            int[] ret = new int[nums.Length];
            int[] retLeft = new int[nums.Length];
            int[] retRight = new int[nums.Length];

            retLeft[0] = nums[0];
            retRight[nums.Length - 1] = nums[nums.Length - 1];

            for (int i = 1; i < ret.Length - 1; i++)
            {
                retLeft[i] = nums[i] * retLeft[i - 1];
                retRight[ret.Length - i - 1] = nums[ret.Length - i - 1] * retRight[ret.Length - i];
            }

            if (nums.Length > 2)
            {
                retLeft[ret.Length - 1] = nums[ret.Length - 1] * retLeft[ret.Length - 2];
                retRight[0] = nums[0] * retRight[1];
            }

            //for (int i = ret.Length - 2; i > -1; i--)
            //{
            //    retRight[i] = nums[i]*retRight[i + 1];
            //}

            for (int i = 0; i < nums.Length; i++)
            {
                ret[i] = (i > 0 ? retLeft[i - 1] : 1) * (i < nums.Length - 1 ? retRight[i + 1] : 1);
            }

            return ret;
        }
    }
}
