using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class RegexMatch
    {
        public static bool isMatch(string source, string express)
        {
            bool[,] dpCache = new bool[source.Length+1, express.Length+1];
            for (int i = 0; i <= source.Length; i++)
            {
                dpCache[i, 0] = false;
            }

            for (int i = 0; i <= express.Length; i++)
            {
                dpCache[0, i] = false;
            }

            dpCache[1, 1] = false;
            dpCache[0, 0] = true;


            for (int i = 1; i <= source.Length; i++)
            {
                for (int j = 1; j <= express.Length ; j++)
                {
                    if (express[j - 1] == source[i - 1])
                    {
                        dpCache[i, j] = dpCache[i - 1,j - 1];
                    }
                    else if(express[j-1] == '?')
                    {
                        dpCache[i, j] = dpCache[i - 1, j - 1];
                    }
                    else if(express[j-1] == '*')
                    {
                        if (i > 1 && source[i - 1] == source[i - 2])
                        {
                            dpCache[i, j] = dpCache[i - 1, j] | dpCache[i - 1, j - 1] | dpCache[i, j - 1];
                            
                        }
                        else if(j==1)
                            dpCache[i, j] = true;
                        else
                        {
                            dpCache[i, j] = dpCache[i - 1, j - 1] || dpCache[i, j - 1];
                        }
                    }  
                }  
            } 

            return dpCache[source.Length, express.Length];
        }

        public static void Test()
        {
            string source;
            string expre;

            source = "abbd";
            expre = "*bd";
            Console.WriteLine(string.Format("{0} --> {1} : {2}", source, expre, isMatch(source, expre)));

            source = "ab";
            expre = "a*b*";
            Console.WriteLine(string.Format("{0} --> {1} : {2}", source, expre, isMatch(source, expre)));

            source = "aaa";
            expre = "aa";
            Console.WriteLine(string.Format("{0} --> {1} : {2}", source, expre, isMatch(source, expre)));


            source = "aa";
            expre = "*";
            Console.WriteLine(string.Format("{0} --> {1} : {2}", source, expre, isMatch(source, expre)));

            source = "aa";
            expre = "a*";
            Console.WriteLine(string.Format("{0} --> {1} : {2}", source, expre, isMatch(source, expre)));

            source = "aa";
            expre = "?*";
            Console.WriteLine(string.Format("{0} --> {1} : {2}", source, expre, isMatch(source, expre)));

            source = "aab";
            expre = "c*a*b";
            Console.WriteLine(string.Format("{0} --> {1} : {2}", source, expre, isMatch(source, expre)));
        }
    }
}
