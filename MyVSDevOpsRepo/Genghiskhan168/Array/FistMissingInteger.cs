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
            int index = 0;

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == i + 1)
                    continue;

                if(array[i] > 0 && array[i] <= array.Length)
                {
                    int temp = array[i];
                    array[i] = array[temp -1];
                    array[temp-1] = temp;
                    i--;
                }
            }

            for(index = 0; index < array.Length; index++)
            {
                if(index != array[index]-1)
                {
                    break;
                }
            }

            if (index == array.Length)
                return array.Length+1;

            return index + 1;
        }

        public static void Test()
        {
            int[] a = { -1, -2};
            Console.WriteLine("First missing integer is {0}", FindFirstMissingInteger(a));

            int[] b = { 2, 3, 4, 1, 5, 6, 7 };
            Console.WriteLine("First missing integer is {0}", FindFirstMissingInteger(b));

            int[] c = { 3, 4, -1, 1 };
            Console.WriteLine("First missing integer is {0}", FindFirstMissingInteger(c));
        }
    }
}
