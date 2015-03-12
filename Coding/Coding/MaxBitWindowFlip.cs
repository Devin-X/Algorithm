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

        public static int GetMaxSpaceO1(int[] array)
        {
            Console.WriteLine(string.Join(",", array));
            int oneCount = 0;
            int zeroCount = 0;
            int totalone = 0;
            int max = 0, L = -1, R = -1;
            if(array[0] == 0)
            {
                L = 0;
                R = 0;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0 && array[i] != array[i - 1] && oneCount > 0 && zeroCount > 0)
                {
                    if (array[i] == 1)
                    {
                        if (max + zeroCount - oneCount > zeroCount && max + zeroCount - oneCount > max)
                        {
                            max += zeroCount - oneCount;
                            R = i - 1;
                        }
                        else if (max < zeroCount)
                        {
                            max = zeroCount;
                            L = i - zeroCount;
                            R = i - 1;
                        }

                        oneCount = 0;
                    }
                    else if(array[i] == 0)
                    {
                        zeroCount = 0;
                    }
                }

                if (array[i] == 1)
                {
                    oneCount++;
                    totalone++;
                }
                else zeroCount++;

                if (array[i] == 0 && oneCount == 0)
                {
                    max = zeroCount;
                    R = i;
                }
            }

            if (max + zeroCount - oneCount > zeroCount && max + zeroCount - oneCount > max)
            {
                max += zeroCount - oneCount;
                R = array.Length - 1;
            }
            else if (max < zeroCount)
            {
                max = zeroCount;
                L = array.Length - zeroCount;
                R = array.Length - 1;
            }


            Console.WriteLine("[{0}, {1}]", L, R);
            return max;
        }

        public static int GetMax(int[] array)
        {
            Console.WriteLine(string.Join(",", array));
            int[] cache = new int[array.Length];
            int[] lIndexes = new int[array.Length];
            int[] rIndexes = new int[array.Length];
            int cacheIndex = 0;
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                cache[i] = -1;
                lIndexes[i] = i;
                rIndexes[i] = array.Length - 1;

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

            if (cache[cacheIndex] == -1)
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
<<<<<<< HEAD
                    if (_maxWindow < t)
                    {
                        _maxWindow = t;
                        _L = i - t - 1;
                        _L = _L > 0 ? _L : 0;
                        _R = i;
                        Console.WriteLine("[{0}, {1}]", _L, _R);
                    }
=======
                    cache[i] += cache[i - 1];
                    lIndexes[i] = lIndexes[i - 1];
                    rIndexes[i - 1] = rIndexes[i];
                }

                if (cache[i] > max)
                {
                    L = lIndexes[i];
                    max = cache[i];
                    R = rIndexes[i];
>>>>>>> 8c60c1bd0843cc544545c1d1ef8fb987b66aae0a
                }
            }

            Console.WriteLine("[{0}, {1}]", L, R);
            return max;
        }

        public static void Test()
        {
<<<<<<< HEAD
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
=======
            int[] a = { 1, 0, 0, 1, 0, 0, 1 };
            //Console.WriteLine(GetMaxWindow(a));
            Console.WriteLine(GetMax(a));
            Console.WriteLine(GetMaxSpaceO1(a));

            Reset();
            int[] b = { 0, 0, 0, 1, 0, 0, 1, 0, 1, 1 };
            //Console.WriteLine(GetMaxWindow(b));
            Console.WriteLine(GetMax(b));
            Console.WriteLine(GetMaxSpaceO1(b));

            Reset();
            int[] c = { 0, 0, 1, 1, 0, 1, 0, 1, 0, 1 };
            //Console.WriteLine(GetMaxWindow(c));
            Console.WriteLine(GetMax(c));
            Console.WriteLine(GetMaxSpaceO1(c));

            Reset();
            c = new int[] { 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 1, 0, 1, 1, 0 };
            //Console.WriteLine(GetMaxWindow(c));
            Console.WriteLine(GetMax(c));
            Console.WriteLine(GetMaxSpaceO1(c));

            Reset();
            c = new int[] { 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0 };
            //Console.WriteLine(GetMaxWindow(c));
            Console.WriteLine(GetMax(c));
            Console.WriteLine(GetMaxSpaceO1(c));
>>>>>>> 8c60c1bd0843cc544545c1d1ef8fb987b66aae0a
        }
    }
}
