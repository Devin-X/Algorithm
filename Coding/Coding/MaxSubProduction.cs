using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class MaxSubProduction
    {
        public static int max = 1;

        public static int GetMaxSubProductionFast(int[] array)
        {
            if (array.Length == 1)
                return array[0];

            List<int> tempList = new List<int>();
            int localMax = 1;
            int neCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    localMax *= array[i];
                }
                else
                {
                    if(localMax != 1)
                    {
                        tempList.Add(localMax);
                        max *= localMax;
                        localMax = 1;
                    }
                    
                    tempList.Add(array[i]);
                    max *= array[i];
                    neCount++;
                }
            }

            if (localMax != 1)
            {
                tempList.Add(localMax);
                max *= localMax;
                localMax = 1;
            }

            if (neCount%2 == 0)
                return max;

            int localMax2 = max;
            foreach (int i in tempList)
            {
                localMax *= i;
                localMax2 = i == 0 ? 0 : localMax2/i;
                max = Math.Max(max, Math.Max(localMax, localMax2));
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
            int[] array = {-2, -3, 0, 4, 5};
            //Console.WriteLine(GetMaxSubProduction(array));

            Console.WriteLine(GetMaxSubProductionFast(array));
        }
    }
}
