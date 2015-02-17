using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class DecodingWays
    {
        /// <summary>
        /// A message containing letters from A-Z is being encoded to numbers using the following mapping: 
        ///'A' -> 1
        ///'B' -> 2
        ///...
        ///'Z' -> 26


        ///Given an encoded message containing digits, determine the total number of ways to decode it. 

        ///For example,
        /// Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12). 

        ///The number of ways decoding "12" is 2. 

        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int numDecodings(String s)
        {
            Console.WriteLine(s);
            if (s.Length == 1)
                return 1;
            if (s.Length == 2 && s.CompareTo("27") < 0 && s[s.Length-2] >= '1')
                return 2;
            else if (s.Length == 2)
                return 1;

            int[] a = new int[s.Length];
            if (a[s.Length - 1] != '0')
            {
                a[s.Length - 1] = 1;
            }
            else
            {
                a[s.Length - 1] = 0;
            }
            if (s.Substring(s.Length - 2, 2).CompareTo("27") < 0 && s[s.Length-2] >= '1' && s[s.Length-1] != '0')
            {
                a[s.Length - 2] = 2;
            }
            else if(s[s.Length-2] != '0')
            {
                a[s.Length - 2] = 1;
            }
            else
            {
                a[s.Length - 2] = 0;
            }

            for (int i = s.Length - 3; i >= 0; i--)
            {
                a[i] = a[i + 1];

                if (s[i] == '0')
                {
                    a[i] -= a[i + 1];
                    continue;
                }

                if (s.Substring(i, 2).CompareTo("27") < 0 && s[i] >= '1' && s[i+2] != '0')
                {
                    a[i] += a[i + 2];
                }
            }

            return a[0];
        }

        public static void Test()
        {
            Console.WriteLine(numDecodings("12"));
            Console.WriteLine(numDecodings("123"));
            Console.WriteLine(numDecodings("1234"));
            Console.WriteLine(numDecodings("12222"));

            Console.WriteLine(numDecodings("102"));
            Console.WriteLine(numDecodings("120"));
            Console.WriteLine(numDecodings("1203"));
            Console.WriteLine(numDecodings("102034"));
            Console.WriteLine(numDecodings("1020202020"));
            Console.WriteLine(numDecodings("102526")); 
            Console.WriteLine(numDecodings("342526"));
            Console.WriteLine(numDecodings("102526272020"));
        }
    }
}
