using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// ((())) – true
    /// ()()() – true
    /// ((()) – false 3 left and 2 right
    /// )( – false right before a left
    /// An answer in either C++ or Java would be fine.
    /// </summary>
    class Parethesis
    {
        public static bool IsValidParathesis(string str)
        {
            int countOpen = 0;
            int countClose = 0;

            foreach(char c in str)
            {
                if(c == '(')
                {
                    countOpen++;
                }
                else if(c == ')')
                {
                    countClose++;
                }

                if (countClose > countOpen)
                    return false;
            }

            if (countClose == countOpen)
            {
                return true;
            }

            return false;
        }

        public static void TestValidParathesisString()
        {
            string str = "((()))";
            Console.WriteLine(IsValidParathesis(str));
            str = "()()()";
            Console.WriteLine(IsValidParathesis(str));
            str = "((())";
            Console.WriteLine(IsValidParathesis(str));
            str = ")(";
            Console.WriteLine(IsValidParathesis(str));
        }
    }
}
