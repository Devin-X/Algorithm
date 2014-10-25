using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
//Mice and holes are placed in a straight line. There are n holes on this line. Each hole can accomodate only 1 mouse. A mouse can stay at his position, move one step right from x to x+1, or move one step left from x to x−1. Any of these moves consumes 1 minute. 
//Assign mice to holes so that the time when the last mouse gets inside a hole is minimized. 

//for example if there are 3 mice positions of mice are: 
//4 -4 2 
//positions of holes are: 
//4 0 5 

//the answer should be 4 
//because: 
//Assign mouse at position x=4 to hole at position x=4 : Time taken is 0 minutes 
//Assign mouse at postion x=-4 to hole at position x=0 : Time taken is 4 minutes 
//Assign mouse at postion x=2 to hole at postion x=5 : Time taken is 3 minutes 
//After 4 minutes all of the mice are in the holes.

    public class Slot
    {
        public int data;
        public bool isMouse;
        public bool isVisited = false;
        public Slot(int d, bool ism)
        {
            data = d;
            isMouse = ism;
        }
    }

    public class MousesandHoles
    {
        public static int GetMinDistanceDP(int[] mouses, int[] holes)
        {
            if (mouses == null || holes == null)
                return 0;
            Array.Sort(mouses);
            Array.Sort(holes);

            int[,] dp = new int[mouses.Length, holes.Length];
            dp[0,0] = Math.Abs(mouses[0]-holes[0]);
            int min = dp[0,0];

            for(int i = 0; i < holes.Length; i++)
            {
                dp[0, i] = min = Math.Min(min, Math.Abs(mouses[0]-holes[i]));
            }

            for(int i = 1; i < mouses.Length; i++)
            {
                dp[i, i] = Math.Max(dp[i-1, i-1], Math.Abs(mouses[i]-holes[i]));
            }

            for(int i =1; i < mouses.Length; i++)
            {
                for(int j = i+1; j < mouses.Length; j++)
                {
                    dp[i, j] = Math.Min(dp[i,j-1], Math.Max(dp[i-1,j-1], Math.Abs(mouses[i]-holes[j])));
                }
            }

            return dp[mouses.Length-1,holes.Length-1];
        
        }

        

        public static void Test()
        {
            int[] m1 = { 1, 2, 3 };
            int[] h1 = { -5, -4, -3, -2, -1, 0, 1 };
            int[] m2 = { -1, 3, 6 };
            int[] h2 = { -40, -20, 0, 1, 4, 5, 6, 7, 8 };

            int[] m3 = { 2, 0, -4 };
            int[] h3 = { 3, 1, 2, -1 };

            int[] m4 = { 1, 2, 3 };
            int[] h4 = { -5, -4, -3, -2, -1, 5 };

            int[] m5 = {1,4,7,10};
            int[] h5 = { -100, 2, 5, 8, 20 };

            int[] m7 = { 64, 82, 95, 152, 166 };
            int[] h7 = { 9, 25, 28, 36, 54, 118, 119, 172, 189, 195 };

            Console.WriteLine(string.Join(",", m1));
            Console.WriteLine(string.Join(",", h1));
            Console.WriteLine(GetMinDistanceDP(m1, h1));
            Console.WriteLine(string.Join(",", m2));
            Console.WriteLine(string.Join(",", h2));
            Console.WriteLine(GetMinDistanceDP(m2, h2));

            Console.WriteLine(string.Join(",", m3));
            Console.WriteLine(string.Join(",", h3));
            Console.WriteLine(GetMinDistanceDP(m3, h3));

            Console.WriteLine(string.Join(",", m4));
            Console.WriteLine(string.Join(",", h4));
            Console.WriteLine(GetMinDistanceDP(m4, h4));

            Console.WriteLine(string.Join(",", m5));
            Console.WriteLine(string.Join(",", h5));
            Console.WriteLine(GetMinDistanceDP(m5, h5));

            Console.WriteLine(string.Join(",", m7));
            Console.WriteLine(string.Join(",", h7));
            Console.WriteLine(GetMinDistanceDP(m7, h7));
        }
    }


    //private static int FindMax(List<Slot> l)
    //    {
    //        int max = int.MinValue;
    //        int im = 0;
    //        while (im < l.Count)
    //        {
    //            if (l[im].isMouse)
    //            {
    //                int ib = im;
    //                int back = -1;
    //                int forward = -1;
    //                while (ib >= 0)
    //                {
    //                    if (!l[ib].isMouse && !l[ib].isVisited)
    //                    {
    //                        break;
    //                    }
    //                    ib--;
    //                }

    //                if (ib >= 0)
    //                {
    //                    back = l[im].data > l[ib].data ? l[im].data - l[ib].data : l[ib].data - l[im].data;
    //                }

    //                int iforward = im;
    //                while (iforward < l.Count)
    //                {
    //                    if (!l[iforward].isMouse && !l[iforward].isVisited)
    //                    {
    //                        break;
    //                    }
    //                    iforward++;
    //                }

    //                if (iforward < l.Count)
    //                {
    //                    forward = l[im].data > l[iforward].data ? l[im].data - l[iforward].data : l[iforward].data - l[im].data;
    //                }

    //                if (forward == -1)
    //                {
    //                    max = Math.Max(max, back);
    //                    l[ib].isVisited = true;
    //                }
    //                else if (back == -1)
    //                {
    //                    max = Math.Max(max, forward);
    //                    l[iforward].isVisited = true;
    //                }
    //                else
    //                    if (back < forward)
    //                    {
    //                        max = Math.Max(max, back);
    //                        l[ib].isVisited = true;
    //                    }
    //                    else
    //                    {
    //                        max = Math.Max(max, forward);
    //                        l[iforward].isVisited = true;
    //                    }
    //            }

    //            im++;
    //        }
    //        return max;
    //    }
    //    public static int GetMinDistance(int[] mouses, int[] holes)
    //    {
    //        int ret = 0;
    //        List<Slot> l = new List<Slot>();
    //        foreach (int i in mouses)
    //        {
    //            l.Add(new Slot(i, true));
    //        }
    //        foreach(int i in holes)
    //        {
    //            l.Add(new Slot(i, false));
    //        }

    //        List<Slot> lDesc = new List<Slot>();
    //        l = l.OrderByDescending(S => S.data).ToList();
    //        foreach (Slot s in l)
    //            lDesc.Add(new Slot(s.data, s.isMouse));
    //        List<Slot> lAcces = new List<Slot>();
    //        l = l.OrderBy(S => S.data).ToList();
    //        foreach (Slot s in l)
    //            lAcces.Add(new Slot(s.data, s.isMouse));
    //        int a = FindMax(lDesc);
    //        int b = FindMax(lAcces);

    //        return a > b ? b : a;
    //    }

    //    public static int GetMinDistanceCombiSolution(int[] mouses, int[] holes)
    //    {
    //        int ret = int.MaxValue;
    //        List<int> l = new List<int>();
    //        int i = 0;
    //        for (; i < mouses.Length; i++)
    //            l.Add(holes[i]);
    //        while(i < holes.Length)
    //        {
    //            l.Add(holes[i]);
    //            ret = Math.Min(ret, GetMinDistance(mouses, l.ToArray()));
    //            l.Remove(holes[i - mouses.Length]);
    //            i++;
    //        }

    //        return ret;
    //    }
}
