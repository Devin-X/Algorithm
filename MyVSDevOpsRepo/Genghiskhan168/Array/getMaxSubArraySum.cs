using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class MaxSumOfSubArray
    {
        public static int maxSubArray(int[] A)
        {
            Console.WriteLine(string.Join(",", A));
            if (A.Length == 0)
                return 0;
            int max = A[0];
            for (int i = 1; i < A.Length; i++)
            {
                A[i] = Math.Max(A[i - 1] + A[i], A[i]);

                max = Math.Max(max, A[i]);
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
