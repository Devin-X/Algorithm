using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// https://oj.leetcode.com/problems/triangle/
    /// </summary>
    class Triangle
    {
        private static int min = int.MaxValue;
        private static int minCache = 0;
        private static Stack<KeyValuePair<int, int>> cache = new Stack<KeyValuePair<int, int>>();
        public static int minimumTotal(List<List<int>> triangle)
        {
            cache.Push(new KeyValuePair<int, int>(0, 0));
            minimumTotalHelper( triangle);
            return min;
        }

        private static int minimumTotalHelper(List<List<int>> triangle)
        {
            KeyValuePair<int, int> pos = cache.Pop();
            minCache += triangle[pos.Key][pos.Value];
            cache.Push(pos);
            if(cache.Count == triangle.Count)
            {
                min = Math.Min(min, minCache);
                return min;
            }

            if (pos.Key < triangle.Count - 1)
            {
                cache.Push(new KeyValuePair<int, int>(pos.Key + 1, pos.Value));
                minimumTotalHelper( triangle);
                cache.Pop();
                minCache -= triangle[pos.Key+1][pos.Value];
                cache.Push(new KeyValuePair<int, int>(pos.Key + 1, pos.Value + 1));
                minimumTotalHelper( triangle);
                cache.Pop();
                minCache -= triangle[pos.Key + 1][pos.Value+1];
            }
            return min;
        }

        public static void TestTriangle()
        {
            List<int> row1 = new List<int>();
            List<List<int>> triangle = new List<List<int>>();
            row1.Add(2);
            triangle.Add(new List<int>(row1));
            //row1.Clear(); row1.Add(3); row1.Add(1);
            //triangle.Add(new List<int>(row1));

            //row1.Clear(); row1.Add(6); row1.Add(5); row1.Add(1);
            //triangle.Add(new List<int>(row1));

            //row1.Clear(); row1.Add(4); row1.Add(1); row1.Add(8); row1.Add(1);
            //triangle.Add(new List<int>(row1));

            Console.WriteLine(minimumTotal( triangle));

            
        }
    }
}
