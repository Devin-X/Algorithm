using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{

    public class Ticket : IComparable<Ticket>
    {
        public int PlateNumber;
        public DateTime EntryTime;
        public DateTime ExitTime;

        public Ticket(int num, DateTime entry, DateTime exit)
        {
            PlateNumber = num;
            EntryTime = entry;
            ExitTime = exit;
        }

        public int CompareTo(Ticket toCompare)
        {
            if (toCompare == null)
                return 1;
            if (this.EntryTime.CompareTo(toCompare.EntryTime) > 0)
                return 1;
            if (this.EntryTime.CompareTo(toCompare.EntryTime) == 0)
                return 0;

            return -1;
        }
    }

    public class MaxNumOfCars
    {

        public static int MaxNum = int.MinValue;

        //This funtion will sort the tickets in the accending order using the entry time
        private static Ticket[] SortTicketByEntryTime(Ticket[] tickets)
        {
            List<Ticket> temp = new List<Ticket>(tickets);
            List<Ticket> Sorted = temp.OrderBy(t => t.EntryTime).ToList();
            foreach (Ticket ticket in Sorted)
            {
                Console.Write("{0}, {1}", ticket.EntryTime, ticket.ExitTime);
            }

            return Sorted.ToArray();
        }

        private static Ticket[] SortTicketByExitTime(Ticket[] tickets)
        {
            List<Ticket> temp = new List<Ticket>(tickets);
            List<Ticket> Sorted = temp.OrderBy(t => t.ExitTime).ToList();
            foreach (Ticket ticket in Sorted)
            {
                Console.Write("{0}, {1}", ticket.EntryTime, ticket.ExitTime);
            }

            return Sorted.ToArray();
        }

        public static int GetMaxNumOfCars(int[] entryTime, int[] exitTime)
        {
            List<int> sortedEntryTickets = new List<int>(entryTime);
            List<int> sortedExitTickts = new List<int>(exitTime);
            sortedEntryTickets.Sort();
            sortedExitTickts.Sort();
            int indexEntry = 0;
            int indexExit = 0;

            int count = 0;
            for (; indexEntry < sortedEntryTickets.Count; indexEntry++)
            {

                count++;

                while (sortedEntryTickets[indexEntry] >= sortedExitTickts[indexExit])
                {
                    //By this time, we have one car that enter the slot where another car has left.
                    //We need to continue this loop until we find that by the time the current car enter the slot
                    //the indexExit points to the last car which has a exit time less than the current enter time
                    //The worst case is indexExit == indexEntry, since all previous car might all have left.
                    count--;
                    indexExit++;
                }

                MaxNum = Math.Max(count, MaxNum);
            }

            return MaxNum;
        }

        public static void TestMaxNumOfCars()
        {
            int[] entry = { 0, 1, 2,  4, 6 };
            int[] exit = { 7, 5, 3, 9, 8};
            Console.WriteLine(GetMaxNumOfCars(entry, exit));

            int[] entry1 = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] exit1 =  { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(GetMaxNumOfCars(entry1, exit1));

            int[] entry2 = {10, 10, 10, 10, 10, 10, 10, 10, 10 };
            int[] exit2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(GetMaxNumOfCars(exit2, entry2));
        }
    }
}
