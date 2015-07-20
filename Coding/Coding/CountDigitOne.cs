using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class CountDigitOneSolution
    {
        public static int CountDigitOne(int n)
        {
            int count = 0;
            for (long k = 1; k <= n; k *= 10)
            {
                long r = n / k, m = n % k;
                count +=(int)((r + 8) / 10 * k + (r % 10 == 1 ? m + 1 : 0));
                Console.WriteLine("r: {0}, m: {1}, count : {2}", r, m, count);
            }

            return count;
        }

        public static void Test()
        {
            Console.WriteLine("{0} count ot => {1}", 1, CountDigitOne(1));
            Console.WriteLine("{0} count ot => {1}", 11, CountDigitOne(11));
            Console.WriteLine("{0} count ot => {1}", 55, CountDigitOne(55));
        }

        public static int Count(int n)
        {
            int ret = 0;
            while (n > 0)
            {
                if (n%10 == 1)
                    ret++;
                n = n/10;
            }

            return ret;
        }
    }
}
