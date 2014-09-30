using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class Sorting
    {
        /// <summary>
        /// http://en.wikipedia.org/wiki/Heapsort
        /// http://en.wikipedia.org/wiki/Red%E2%80%93black_tree
        /// </summary>
        /// <param name="array"></param>
        public static void HeapSort(int[] array)
        {
            HeapifyShiftDown(array);

            int end = array.Length - 1;
            
            while(end > 0)
            {
                Swap(array, 0, end);
                end--;
                ShiftDown(array, 0, end);
            }
        }

        public static void HearpSortUp(int[] array)
        {
            HeapifyShiftUp(array);
            int start = 0;
            int end = array.Length - 1;
            while (start < end)
            {
                Swap(array, start, end--);
                ShiftUp(array, start, end);
                int temp = 1;
                while (temp <= end)
                {
                    ShiftUp(array, start, 1);
                    temp++;
                }
            }
        }

        private static void HeapifyShiftDown(int[] array)
        {
            int start = (array.Length - 2) / 2;

            while(start >= 0)
            {
                ShiftDown(array, start, array.Length-1);
                start--;
            }
        }

        private static void ShiftDown(int[] array, int start, int end)
        {
            int root = start;
            int toSwap;
            int child = 0;

            while(root*2+1 <= end)
            {
                toSwap = root;
                child = root*2+1;

                if(array[toSwap] < array[child])
                {
                    toSwap = child;
                }
                if(child+1 <= end && array[toSwap] < array[child+1])
                {
                    toSwap = child + 1;
                }

                if (array[toSwap] != array[root])
                {
                    Swap(array, root, toSwap);
                    root = toSwap; // Only shift down the node where we just swapped.
                }
                else
                {
                    return;
                }
            }
        }

        private static void HeapifyShiftUp(int[] array)
        {
            int end = 1;

            while(end < array.Length)
            {
                ShiftUp(array, 0, end);
                end++;
            }
        }

        private static void ShiftUp(int[] array, int start, int end)
        {
            int parent = (end - 1) / 2;
            int child = end;
            while(parent >= start)
            {
                parent = (child - 1) / 2;
                if(array[parent] < array[child])
                {
                    Swap(array, parent, child);
                    child = parent;
                }
                else
                    return;
            }
        }

        private static void Swap(int[] array, int a, int b) 
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        public static void Test()
        {
            int[] a = { 4, 5, 6, 1, 2, 10, 4, 8, 3, 11, 1, 0 };
            HearpSortUp(a);

            foreach (int i in a)
            {
                Console.Write("{0}, ", i);
            }
            Console.WriteLine();
        }
    }
}
