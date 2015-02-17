using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2. 

    ///For example,
    /// Given:
    ///s1 = "aabcc",
    ///s2 = "dbbca", 

    ///When s3 = "aadbbcbcac", return true.
    /// When s3 = "aadbbbaccc", return false. 

    /// </summary>
    class Interleave
    {
        private static int[,] dpCache;

        public static bool IsInterLeaveCaller(String s1, String s2, String s3)
        {
            dpCache = new int[s1.Length + 1, s2.Length + 1];
            for (int i = 0; i <= s1.Length; i++)
                for (int j = 0; j <= s2.Length; j++)
                    dpCache[i, j] = 0;

            Console.WriteLine(string.Format("{0} {1} --> {2} ? ", s1, s2, s3));
            return isInterleave(s1, s2, s3);
        }
        public static bool isInterleave(String s1, String s2, String s3)
        {
            if (s3.Length != s1.Length + s2.Length)
                return false;

            //if (dpCache[s1.Length, s2.Length] == 1)
            //    return true;
            //else if (dpCache[s1.Length, s2.Length] == -1)
            //    return false;

            if (s1 == string.Empty)
            {
                if (s2.CompareTo(s3) == 0)
                {
                    dpCache[s1.Length, s2.Length] = 1;
                    return true;
                }
                else
                {
                    dpCache[s1.Length, s2.Length] = -1;
                    return true;
                }
            }

            if (s2 == string.Empty)
            {
                if (s1.CompareTo(s3) == 0)
                {
                    dpCache[s1.Length, s2.Length] = 1;
                    return true;
                }
                else
                {
                    dpCache[s1.Length, s2.Length] = -1;
                    return true;
                }
            }

            if (s3[0] == s1[0] && s3[0] != s2[0])
            {
                if (isInterleave(s1.Substring(1), s2, s3.Substring(1)))
                {
                    dpCache[s1.Length, s2.Length] = 1;
                    return true;
                }
                else
                {
                    dpCache[s1.Length, s2.Length] = -1;
                    return false;
                }
            }
            else if (s3[0] == s2[0] && s3[0] != s1[0])
            {
                if (isInterleave(s1, s2.Substring(1), s3.Substring(1)))
                {
                    dpCache[s1.Length, s2.Length] = 1;
                    return true;
                }
                else
                {
                    dpCache[s1.Length, s2.Length] = -1;
                    return false;
                }
            }
            else if (s3[0] != s2[0] && s3[0] != s1[0])
            {
                dpCache[s1.Length, s2.Length] = -1;
                return false;
            }
            else
            {
                if (isInterleave(s1.Substring(1), s2, s3.Substring(1)))
                {
                    dpCache[s1.Length, s2.Length] = 1;
                    return true;
                }
                if (isInterleave(s1, s2.Substring(1), s3.Substring(1)))
                {
                    dpCache[s1.Length, s2.Length] = 1;
                    return true;
                }

                dpCache[s1.Length, s2.Length] = -1;
                return false;
            }
        }

        public static void Test()
        {
            Console.WriteLine(string.Format("{0}",
               IsInterLeaveCaller("aabcc", "dbbca", "aadbbcbcac")));
            Console.WriteLine(string.Format("{0}",
               IsInterLeaveCaller("aabcc", "dbbca", "aadbbbaccc")));

            Console.WriteLine(string.Format("{0}",
   IsInterLeaveCaller("aabcc123456789", "dbbca123456789", "aadbbcbcac123456789123456789")));
            Console.WriteLine(string.Format("{0}",
               IsInterLeaveCaller("aabcc123456789", "dbbca123456789", "aadbbbaccc123456789123456789")));

            Console.WriteLine(string.Format("{0}",
IsInterLeaveCaller("aabcc123456789", "dbbca123456789", "aadbbcbcac123456781234567899")));
            Console.WriteLine(string.Format("{0}",
IsInterLeaveCaller("aabcczzzzzzzzzzzzzzzzzzzz", "dbbcazzzzzzzzzzzzzzzzzzzz", "aadbbcbcaczzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzza")));


            Console.WriteLine(string.Format("{0}",
IsInterLeaveCaller("aabcc123456789123456789123456789", "dbbca123456789123456789123456789", "aadbbcbcac123456789123456789123456789123456789123456789123456789")));
            Console.WriteLine(string.Format("{0}",
               IsInterLeaveCaller("aabcc123456789123456789123456789", "dbbca123456789123456789123456789", "aadbbbaccc123456789123456789123456789123456789123456789123456789")));
        }
    }
}
