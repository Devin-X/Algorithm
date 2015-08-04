using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class Interval
    {
        public int start;
        public int end;
        public Interval() { start = 0; end = 0; }
        public Interval(int s, int e) { start = s; end = e; }
    }

    public class InsertIntervalSolution
    {
        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            List<Interval> result = new List<Interval>();

            int index = 0;
            for (; index < intervals.Count; index++)
            {
                if (newInterval.start <= intervals[index].end)
                {
                    break;
                }

                result.Add(intervals[index]);
            }

            if (intervals.Count == 0)
            {
                result.Add(newInterval);
            }
            if (index == 0)
            {
                if (newInterval.end < intervals[index].start - 1 && newInterval.start < intervals[index].start)
                {
                    result.Add(newInterval);
                }
                else if (newInterval.end == intervals[index].start - 1 && newInterval.start < intervals[index].start)
                {
                    result.Add(new Interval(newInterval.start, intervals[index].end));
                    index++;
                }
            }else
            if (index == intervals.Count - 1)
            {
                result.Add(new Interval(intervals[index].start < newInterval.start ? intervals[index].start : newInterval.start, newInterval.end > intervals[index].end ? newInterval.end : intervals[index].end));
                index++;
            }
            else if (index < intervals.Count - 1)
            {
                if (newInterval.end <= intervals[index].end)
                {
                    index++;
                }
                else if (newInterval.end > intervals[index + 1].start || newInterval.end == intervals[index+1].start-1)
                {
                    result.Add(new Interval(intervals[index].start < newInterval.start ? intervals[index].start : newInterval.start, intervals[++index].end));
                    index++;
                }
                else
                {
                    result.Add(new Interval(intervals[index].start < newInterval.start ? intervals[index].start : newInterval.start, newInterval.end));
                    index++;
                }
            }
            else if (index == intervals.Count)
            {
                result.Add(newInterval);
            }
            

            for (; index < intervals.Count; index++)
            {
                result.Add(intervals[index]);
            }

            return result;
        }
    }
}

