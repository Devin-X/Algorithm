using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class QuickSortSlution
    {
        public static void Main()
        {
            int[] array = { 1, 2, 1, 5, 1, 7, 1 };

            QuickSort(array, 0, array.Length - 1);

            foreach (int i in array)
            {
                Console.Write("{0} ", i);
            }
        }

        public static void QuickSort(int[] array, int start, int end)
        {
            if (start < 0 || end > array.Length - 1 || start >= end)
                return;
            int pivot = end;
            int head = start;
            int tail = end - 1;


            while (head <= tail)
            {
                if (array[head] > array[pivot])
                {
                    // what happens to array[pivot] after this line?
                    swap(array, head, tail--);

                }
                else if (array[head] <= array[pivot])
                {
                    head++;
                }
            }

            swap(array, head, pivot);

            QuickSort(array, start, head - 1);
            QuickSort(array, head, end);
        }

        public static void swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

    }
}