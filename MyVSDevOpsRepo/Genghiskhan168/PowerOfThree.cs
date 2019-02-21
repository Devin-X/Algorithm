using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class PowerOfThree
    {
        public bool IsPowerOfThree(int n)
        {
            int maxP3 = 1162261467;
            if (n > maxP3 || n <= 0 || n > int.MaxValue)
                return false;
            return maxP3 % n == 0;
        }
    }

}
