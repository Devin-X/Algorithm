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
        public static void Reset()
        {
            _maxWindow = int.MinValue;
            _L = 0;
            _R = 0;
        }

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
                {
                    t++;
                }

                if(t <= 0)
                {
                    t = 0;
                }
                else
                {
                    if (_maxWindow < t)
                    {
                        _maxWindow = t;
                        _L = i - t - 1;
                        _L = _L > 0 ? _L : 0;
                        _R = i;
                        Console.WriteLine("[{0}, {1}]", _L, _R);
                    }
                }
            }

            Console.WriteLine("[{0}, {1}]", _L, _R);
            return _maxWindow + numOfOne;
        }


        public static void Test()
        {
            int[] a =  {1, 0, 0, 1, 0, 0, 1 };
            Console.WriteLine(string.Join(",", a));
            Console.WriteLine(GetMaxWindow(a));

            Reset();
            int[] b = { 0,0,0,1,0,0,1,0,1,1 };
            Console.WriteLine(string.Join(",", b));
            Console.WriteLine(GetMaxWindow(b));

            Reset();
            int[] c = { 0, 0, 1, 1, 1, 1, 0, 0,0,0,0, 1, 0, 1 };
            Console.WriteLine(string.Join(",", c));
            Console.WriteLine(GetMaxWindow(c));
        }
    }
}
