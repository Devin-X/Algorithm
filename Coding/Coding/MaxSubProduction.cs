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
            int[] array = { 1, 2, -3, -4, -5, -6 };
            Console.WriteLine(GetMaxSubProduction(array));
        }
    }
}
