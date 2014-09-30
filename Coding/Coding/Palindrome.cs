using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class Palindrome
    {
        /// <summary>
        /// http://collabedit.com/27afr
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsPalindrom(string s)
        {
            StringBuilder sTemp = new StringBuilder(s.ToLower());
            int head = 0;
            int tail = sTemp.Length - 1;

            while (head != tail && head != tail - 1)
            {
                if (IsLetter(sTemp[head]) && IsLetter(sTemp[tail]))
                {
                    if (sTemp[head] == sTemp[tail])
                    {
                        head++;
                        tail--;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (!IsLetter(sTemp[head]))
                    {
                        head++;
                    }

                    if (!IsLetter(sTemp[tail]))
                    {
                        tail--;
                    }
                }
            }

            return true;
        }

        private static int _maxPalindrome = 1;

        public static int GetLeastNumToConvert(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return 0;

            int[] leastNum = new int[s.Length];

            for (int j = s.Length; j > 0; j--) 
            {
                for (int i = 0; i <= s.Length - j; i++)
                {
                    if (IsPalindrom(s.Substring(i, j)))
                    {
                        _maxPalindrome = j;
                        Console.WriteLine(MakePalindrome(s, i, j));
                        return (s.Length - _maxPalindrome);
                    }
                }
            }

            return (s.Length - _maxPalindrome);
        }


        public static string MakePalindrome(string s, int i, int j)
        {
            StringBuilder sb = new StringBuilder();
            int start = 0;
            int end = s.Length - 1;

            if (i == 0)
            {
                while(end > i + j-1)
                {
                    sb.Append(s[end--]);
                }

                sb.Append(s);
                return sb.ToString();
            }

            if(end == i + j-1)
            {
                sb.Append(s);
                while(start < i)
                {
                    sb.Append(s[start++]);
                }
                
                return sb.ToString();
            }

            while (start < i && end > j - 1)
            {
                if (s[start] != s[end])
                {
                    sb.Append(s[end]);
                    end--;
                }
                else
                {
                    sb.Append(s[end]);
                    start++;
                    end--;
                }
            }

            return sb.Append(s.Substring(i, j)).ToString();
        }

        private static bool IsLetter(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return true;
            }

            if (c >= '0' && c <= '9')
            {
                return true;
            }

            if (c >= 'A' && c <= 'Z')
            {
                return true;
            }

            return false;
        }


        public static void Test()
        {
            string s = "ab";
            //Console.WriteLine(s);
            //Console.WriteLine(GetLeastNumToConvert(s));

            s = "abbbb";
            Console.WriteLine(s); 
            Console.WriteLine(GetLeastNumToConvert(s));

            s = "a";
            Console.WriteLine(s);
            Console.WriteLine(GetLeastNumToConvert(s));

            s = "abacadaeaf";
            Console.WriteLine(s);
            Console.WriteLine(GetLeastNumToConvert(s));
        }
    }
}
