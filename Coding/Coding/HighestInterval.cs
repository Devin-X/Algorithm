using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// Given a set of entries, each containing a time index and a int count value, 
    //class Entry 
    //{ 
    //time:int 
    //count:int 
    //} 

    //write a function that will give the time interval with the highest count together, 

    //ie, 
    //if we had entries 
    //100, 2 
    //100, 1 
    //110, 10 
    //200, 4 
    //1000, 3 
    //1200, 8 

    //and we ran something like 
    //int highestInterval(int interval_range) 
    //highestInterval( 50 ) 
    //it would return 100, because in 100-150, you have counts 2, 1, and 10. 
    /// </summary>
    public class Entry
    {
        public int time;
        public int count;
        public Entry(int t, int c)
        {
            time = t;
            count = c;
        }
    }
    class HighestInterval
    {

        public static int maxValue = int.MinValue;
        public static int GetHighestInterval(List<Entry> list, int highest)
        {
            int localMax = list[0].count;
            int window = 0;
            int lastTimeIndex = 0;
            int retIndex = 0;
            for(int i = 1; i < list.Count; i++)
            {
                window += list[i].time - list[i - 1].time;
                if(window <= highest)
                {
                    localMax += list[i].count;
                }else
                {
                    while(window > highest && lastTimeIndex < i)
                    {
                        localMax -= list[lastTimeIndex++].count;
                        window -= list[lastTimeIndex].time - list[lastTimeIndex-1].time;
                    }

                    localMax += list[i].count;
                }

                if (maxValue < localMax)
                { 
                    maxValue = localMax;
                    retIndex = lastTimeIndex;
                }
            }

            return list[retIndex].time;
        }

        /// <summary>
            //100, 2 
    //100, 1 
    //110, 10 
    //200, 4 
    //1000, 3 
    //1200, 8 
        /// </summary>
        public static void Test()
        {
            List<Entry> list = new List<Entry>();
            list.Add(new Entry(100, 2));
            list.Add(new Entry(100, 1));
            list.Add(new Entry(110, 10));
            list.Add(new Entry(200, 400));
            list.Add(new Entry(1000, 3));
            list.Add(new Entry(1200, 80));

            Console.WriteLine(GetHighestInterval(list, 50));
        }
    }
}
