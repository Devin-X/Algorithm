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
                    if(!IsLetter(sTemp[head]))
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
    }
}
