using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class GroupNumbers
    {
        private static bool IsLow(int a)
        {
            if (a < 20)
                return true;
            return false;
        }

        private static bool IsMedium(int a)
        {
            if (a >= 20 && a <= 40)
                return true;
            return false;
        }

        private static bool IsHigh(int a)
        {
            if (a > 40)
                return true;
            return false;
        }

        public static void GroupArrayNumbers(int[] array)
        {
            int index = 0;
            int low = 0;
            int high = array.Length - 1;

            while(index >= low && index <= high)
            {
                if(IsLow(array[index]))
                {
                    int temp = array[index];
                    array[index] = array[low];
                    array[low] = temp;
                    low++;
                }else if(IsHigh(array[index]))
                {
                    int temp = array[index];
                    array[index] = array[high];
                    array[high] = temp;
                    high--;
                }
                else
                {
                    index++;
                }
            }
        }

        public static void Test()
        {
            int[] a = { 200, 30, 25, 67, 43, 10, 9, 8, 119, 1100, 4, 50, 30, 20, 26 };

            GroupArrayNumbers(a);

            foreach(int i in a)
            {
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();


            int[] b = {100, 30, 10 };

            GroupArrayNumbers(b);

            foreach (int i in b)
            {
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();
        }
    }
}
