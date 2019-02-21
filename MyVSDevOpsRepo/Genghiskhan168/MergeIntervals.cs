using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{

     
    public class MergeInterval
    {
        public static List<KeyValuePair<int, int>> Merge(int[] start, int[] end, int newStart, int newEnd)
        {
            int s = 0;
            int e = 0;
            List<KeyValuePair<int, int>> ret = new List<KeyValuePair<int, int>>();

            for (int i = 0; i < start.Length - 1; i++)
            {
                if (newStart > start[i] && newStart < start[i + 1])
                {
                    s = i;
                    break;
                }
            }

            for (int j = 0; j < end.Length - 1; j--)
            {
                if (newEnd > start[j] && newEnd < start[j + 1])
                {
                    e = j;
                    break;
                }
            }

            int index = 0;
            for(index = 0 ; index < s; index++)
            {
                ret.Add(new KeyValuePair<int,int>(start[index], end[index]));
            }

            int nexts;
            int nexte;
            if (end[s] > newStart)
            {
                // s is in the middle of a pair, s should be gone. 
                nexts = start[s];
            }
            else
            {
                nexts = newStart;
            }

            if (start[e] < newEnd)
            {
                // e is in the middle of a pair, e shoudl be gone too
                nexte  = end[e];
            }
            else
            {
                nexte = newEnd;
            }

            ret.Add(new KeyValuePair<int,int>(nexts, nexte));


            for (index = e; index < end.Length; index++)
            {
                ret.Add(new KeyValuePair<int,int>(start[index], end[index]));
            }

            return ret;
        }
    }
}
