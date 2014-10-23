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
        public static int GetMinDistance(int[] mouses, int[] holes)
        {
            int max = int.MinValue;
            List<Slot> l = new List<Slot>();
            foreach (int i in mouses)
            {
                l.Add(new Slot(i, true));
            }
            foreach(int i in holes)
            {
                l.Add(new Slot(i, false));
            }

            if (mouses[mouses.Length - 1] > holes[holes.Length/2 - 1])
            {
                l = l.OrderByDescending(S => S.data).ToList();
            }
            else
            {
                l = l.OrderBy(S => S.data).ToList();
            }

            int im = 0;
            while(im < l.Count)
            {
                if(l[im].isMouse)
                {
                    int ib = im;
                    int back = -1;
                    int forward = -1;
                    while(ib >= 0)
                    {
                        if( !l[ib].isMouse && !l[ib].isVisited)
                        {
                            break;
                        }
                        ib--;
                    }

                    if(ib >= 0)
                    {
                        back = l[im].data > l[ib].data ? l[im].data - l[ib].data : l[ib].data - l[im].data;
                    }

                    int iforward = im;
                    while (iforward < l.Count )
                    {
                        if( !l[iforward].isMouse && !l[iforward].isVisited)
                        {
                            break;
                        }
                        iforward++;
                    }

                    if (iforward < l.Count)
                    {
                        forward = l[im].data > l[iforward].data ? l[im].data - l[iforward].data : l[iforward].data - l[im].data;
                    }
                    
                    if(forward == -1)
                    {
                        max = Math.Max(max, back);
                        l[ib].isVisited = true;
                    }
                    else if (back == -1)
                    {
                        max = Math.Max(max, forward);
                        l[iforward].isVisited = true;
                    }else
                    if(back < forward)
                    {
                        max = Math.Max(max, back);
                        l[ib].isVisited = true;
                    }
                    else
                    {
                        max = Math.Max(max, forward);
                        l[iforward].isVisited = true;
                    }
                }

                im++;
            }

            return max;
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

            int[] m5 = {1, 5, 10};
            int[] h5 = { 0, 3, 6, 11};

            Console.WriteLine(string.Join(",", m1));
            Console.WriteLine(string.Join(",", h1));
            Console.WriteLine(GetMinDistance(m1, h1));
            Console.WriteLine(string.Join(",", m2));
            Console.WriteLine(string.Join(",", h2));
            Console.WriteLine(GetMinDistance(m2, h2));

            Console.WriteLine(string.Join(",", m3));
            Console.WriteLine(string.Join(",", h3));
            Console.WriteLine(GetMinDistance(m2, h3));

            Console.WriteLine(string.Join(",", m4));
            Console.WriteLine(string.Join(",", h4));
            Console.WriteLine(GetMinDistance(m4, h4));

            Console.WriteLine(string.Join(",", m5));
            Console.WriteLine(string.Join(",", h5));
            Console.WriteLine(GetMinDistance(m5, h5));
        }
    }
}
