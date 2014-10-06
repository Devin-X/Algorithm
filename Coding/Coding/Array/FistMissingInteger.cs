using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class FirstMissingInteger
    {
        public static int FindFirstMissingInteger(int[] array)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int count = 0;
            int sum = 0;

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    count++;
                    sum += array[i];
                    if (array[i] > max )
                        max = array[i];
                    if (array[i] < min )
                        min = array[i];
                }
            }

            if (count == 0)
                return 1;

            if(max-min == count - 1)
            {
                return min > 1 ? 1 : max + 1;
            }

            return (max + min) * (count +1)/ 2 - sum;
        }

        public static void Test()
        {
            int[] a = { -1 };
            Console.WriteLine("First missing integer is {0}", FindFirstMissingInteger(a));

            int[] b = { 2 };
            Console.WriteLine("First missing integer is {0}", FindFirstMissingInteger(b));

            int[] c = { 3, 4, -1, 1 };
            Console.WriteLine("First missing integer is {0}", FindFirstMissingInteger(c));
        }
    }
}
