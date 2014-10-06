using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{

    public class MakeChange
    {
        private static int[] changes = {1, 5, 10, 25};
        public static int MakeChanges(int target, int coinIndex)
        {
            if (coinIndex == 0)
                return 1;

            int sum = 0;
            for(int i = 0; i <= target / changes[coinIndex]; i++)
            {
                sum += MakeChanges(target - i * changes[coinIndex], coinIndex - 1);
            }

            return sum;
        }

        public static void Test()
        {
            Console.WriteLine("Make change for {0} is {1}", 21, MakeChanges(21, 3));
            Console.WriteLine("Make change for {0} is {1}", 11, MakeChanges(11, 3));
            Console.WriteLine("Make change for {0} is {1}", 1, MakeChanges(1, 3));
            Console.WriteLine("Make change for {0} is {1}", 5, MakeChanges(5, 3));
            Console.WriteLine("Make change for {0} is {1}", 10, MakeChanges(10, 3));
            Console.WriteLine("Make change for {0} is {1}", 25, MakeChanges(25, 3));
        }
    }
}
