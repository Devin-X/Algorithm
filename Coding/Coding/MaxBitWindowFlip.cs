using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class MaxBitWindowFlip
    {
        public static int _maxWindow = int.MinValue;
        public static int _L = 0;
        public static int _R = 0;

        public static int GetMaxWindow(int[] array)
        {
            int t = 0;
            int numOfOne = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 1)
                {
                    t--;
                    numOfOne++;
                }
                else
                    t++;

                if(t < 0)
                {
                    _L = i;
                    t = 0;
                }
                else
                {
                    if (_maxWindow < t)
                    {
                        _maxWindow = t;
                        _L = i - t;
                    }
                }
            }

            return _maxWindow + numOfOne;
        }


        public static void Test()
        {
            int[] a =  {1, 0, 0, 1, 0, 0, 1 };
            Console.WriteLine(GetMaxWindow(a));
        }
    }
}
