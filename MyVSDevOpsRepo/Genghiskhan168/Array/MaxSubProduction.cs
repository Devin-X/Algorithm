using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class MaxSubProduction
    {
        public static int max = int.MinValue;

        public static int GetMaxSubProductionFast(int[] array)
        {
            Console.WriteLine(string.Join(",", array));
            int leftMax = int.MinValue;
            int rightMax = int.MinValue;
            max = int.MinValue;

            int totalLeft = 1;
            int totalRight = 1;
            bool hasZeroleft = false;
            bool hasZeroRight = false;

            for (int i = 0; i < array.Length; i++)
            {
                hasZeroleft = false;
                hasZeroRight = false;
                if(array[i] == 0)
                {
                    totalLeft = 1;
                    hasZeroleft = true;
                }

                if (array[array.Length-1-i] == 0)
                {
                    totalRight = 1;
                    hasZeroRight = true;
                }

                if (!hasZeroleft)
                {
                    totalLeft *= array[i];
                    leftMax = Math.Max(totalLeft, leftMax);
                }

                if (!hasZeroRight)
                {
                    totalRight *= array[array.Length - 1 - i];
                    rightMax = Math.Max(totalRight, rightMax);
                }

                max = Math.Max(max, Math.Max(rightMax, leftMax));
                max = Math.Max(max, array[i]);
            }

            return max;
        }

        public static int GetMaxSubProductionDP(int[] array)
        {
            if(array.Length == 1)
                return array[0];

            int[] b = array.ToArray();
            int max = int.MinValue;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i-1] == 0)
                    continue;
                array[i] = Math.Max(array[i]*(array[i - 1]), array[i]);
                b[i] = Math.Min(b[i] * b[i - 1], b[i]);

                max = Math.Max(max, array[i]);
                max = Math.Max(max, b[i]);
            }

            return max;
        }

        public static  int GetMaxSubProduction(int[] array)
        {
            for(int i = 1; i < array.Length; i++)
            {
                MaxSubProductionHelper(array, i);
            }
            
            return max;
        }

        private static int MaxSubProductionHelper(int[] array, int count)
        {
            int localMax = 0;
            int followIndex = 0;
            for(int i = 0; i < count; i++)
            {
                localMax += array[i];
            }

            for(int i = count; i < array.Length; i++)
            {
                max = Math.Max(localMax,max);
                localMax -= array[followIndex++];
                localMax += array[i];
            }

            return max;
        }

        public static void TestMaxSubProduction()
        {
            int[] array = {-1, 2, 3, 0, 4, 5, 0, -3, -6};
            Console.WriteLine(GetMaxSubProductionFast(array));

            int[] array1 = { 0 };
            Console.WriteLine(GetMaxSubProductionFast(array1));

            int[] array2 = { -2 };
            Console.WriteLine(GetMaxSubProductionFast(array2));

            int[] array3 = { -1, 2, 3, -8, 4, 5, 0, -3, -6 };
            Console.WriteLine(GetMaxSubProductionFast(array3));

            int[] array4 = { -1, 2, 0, 3, -8, 4, 5, -1, 0, -3, -6, 0, 1000};
            Console.WriteLine(GetMaxSubProductionFast(array4));
        }
    }
}
