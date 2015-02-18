using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// 2.       Print all correct parenthesizations of length N.

    /// N=2 => ()

    /// N=4 => ()(), (())

    /// N=6 => ()()(), ()(()), (())(), ((())), (()()), 

    /// </summary>
    public class PrintParathesies
    {
        public static int[,] _cache;
        public static int CountSolution(int n)
        {
            int opening = 1;
            int closing = 0;
            _cache = new int[n / 2+1, n / 2+1];

            for (int i = 0; i < n / 2 + 1; i++)
                for (int j = 0; j < n / 2 + 1; j++)
                    _cache[i, j] = 0;

            return CountSub(n/2, opening, closing);
        }

        public static int CountSub(int n, int open, int close)
        {
            if (_cache[open, close] > 0)
                return _cache[open, close];

            if (open < close)
                return 0;

            if (open >= n)
                return 1;

            if (open > close)
            {
                _cache[open + 1, close] += CountSub(n, open + 1, close);
                _cache[open, close + 1] += CountSub(n, open, close + 1);
                _cache[open, close] = _cache[open + 1, close] + _cache[open, close + 1];
            }else
            {
                _cache[open, close] += CountSub(n, open+1, close);

            }

            return _cache[open, close];
        }

        public static void Test()
        {
            Console.WriteLine(string.Format("{0} --> {1}", 2, CountSolution(2)));
            Console.WriteLine(string.Format("{0} --> {1}", 4, CountSolution(4)));
            Console.WriteLine(string.Format("{0} --> {1}", 6, CountSolution(6)));
            Console.WriteLine(string.Format("{0} --> {1}", 200, CountSolution(200)));
        }
    }
}





//int[][] M = int[MAX_OPEN][MAX_CLOSE];



//public int CountSolution(int n)

//{

//   int opening = 1;

//   int closing = 0;



//   int ret = CountSub(n, opening, closing);

//}



//public int CountSub(int n, int opening, int closing)

//{

//   if(m[opening][closing] > 0)

//       return m[opening][closing];

//   int subSumb = 0;

//   if(opening >= n/2)

//   { 

//       M[opening][closing] = 1;

//   }



//   if(opening > closing)

//   {



//       m[opening][closing+1] += CountSub(n, opening, closing+1);

//       m[opening+1][closing] += CountSub(n, opening+1, closing);



//       subSum = m[opening][closing+1] + m[opening+1][closing];

//   }



//   else if(opening == closing)

//   {

//       m[opening+1][closing] = CountSub(n, opening+1, closing);

//       subSum = m[opening+1][closing]；

//   }



//   return subSum;    

//}
