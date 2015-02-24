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
                    }
                }
            }

            Console.WriteLine("[{0}, {1}]", _L, _R);
            return _maxWindow + numOfOne;
        }

        public static int GetMax(int[] array)
        {
            Console.WriteLine(string.Join(",", array));
            int[] cache = new int[array.Length];
            int[] lIndexes = new int[array.Length];
            int[] rIndexes = new int[array.Length];
            int cacheIndex = 0;
            int count = 0;

            for(int i = 0; i < array.Length; i++)
            {
                cache[i] = -1;
                lIndexes[i] = i;
                rIndexes[i] = array.Length-1;

                if (i > 0 && array[i] != array[i - 1])
                {
                    cache[cacheIndex] = count;
                    count = 0;
                    rIndexes[cacheIndex] = i - 1;
                    lIndexes[++cacheIndex] = i;
                }

                if (array[i] == 1)
                    count--;
                else count++;
            }
            
            if(cache[cacheIndex] == -1)
            {
                cache[cacheIndex] = count;
                rIndexes[cacheIndex] = array.Length - 1;
            }

            int max = cache[0];
            int L = lIndexes[0];
            int R = rIndexes[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (cache[i] + cache[i - 1] > cache[i])
                {
                    cache[i] += cache[i - 1];
                    lIndexes[i] = lIndexes[i - 1];
                    rIndexes[i - 1] = rIndexes[i];
                }

                if (cache[i] > max)
                {
                    L = lIndexes[i];
                    max = cache[i];
                    R = rIndexes[i];
                }
            }

            Console.WriteLine("[{0}, {1}]", L, R);
            return max;
        }

        public static void Test()
        {
            int[] a =  {1, 0, 0, 1, 0, 0, 1 };
            //Console.WriteLine(GetMaxWindow(a));
            Console.WriteLine(GetMax(a));

            Reset();
            int[] b = { 0,0,0,1,0,0,1,0,1,1 };
            //Console.WriteLine(GetMaxWindow(b));
            Console.WriteLine(GetMax(b));

            Reset();
            int[] c = { 0, 0, 1, 1, 0, 1, 0, 1, 0, 1 };
            //Console.WriteLine(GetMaxWindow(c));
            Console.WriteLine(GetMax(c));

            Reset();
            c =new int[] { 0,0,1,1,0,0,0,1,1,1,0,1,0,1,1,0};
            //Console.WriteLine(GetMaxWindow(c));
            Console.WriteLine(GetMax(c));

            Reset();
            c = new int[] { 0,0,1,0,0,0,1,1,0,0,0,0,1,1,1,0,0,0,0,0 };
            //Console.WriteLine(GetMaxWindow(c));
            Console.WriteLine(GetMax(c));
        }
    }
}
