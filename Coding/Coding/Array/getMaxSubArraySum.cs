using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class MaxSumOfSubArray
    {
        public static int maxSubArray(int[] array)
        {
            Console.WriteLine(string.Join(",", array));
            int max = int.MinValue;
            for (int i = 1; i < array.Length; i++)
            {
                array[i] = Math.Max(array[i - 1] + array[i], array[i]);

                max = Math.Max(max, array[i]);
            }

            return max;
        }


        public static void Test()
        {
            int[] array = new int[]{-2,1,-3,4,-1,2,1,-5,4};
            Console.WriteLine(maxSubArray(array));

            array = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 6 };
            Console.WriteLine(maxSubArray(array));


            array = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 9 };
            Console.WriteLine(maxSubArray(array));


            array = new int[] { -2, 1, -3, 4, -1, 2, 1, -100, 4 };
            Console.WriteLine(maxSubArray(array));
        }
    }
}
