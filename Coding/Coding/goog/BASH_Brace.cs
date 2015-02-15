using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    //  Write code that would parse an expression that is similar to BASH brace expansion. 
    //  Best illustrated with an example: the expression "(a,b,cy)n,m" would be parsed into an array of the following strings: 
    //  an 
    //  bn 
    //  cyn 
    //  m 

    //You can assume that the input will always be valid. 

    //Hint: the expression can nest. Therefore, "((a,b)o(m,n)p,b)" parses into: 
    //aomp 
    //aonp 
    //bomp 
    //bonp 
    //b
    /// </summary>
    class BASH_Brace
    {
        private static List<string> finalResult = new List<string>();
        private static List<string> tempResult = new List<string>();
        private static int depth = 0;
        private static int index = 0;

        public static void Reset()
        {
            finalResult.Clear();
            tempResult.Clear();
            depth = 0;
            index = 0;
        }

        public static List<string> getAllCombination(string s)
        {
            while (index < s.Length)
            {
                if (s[index] == '(')
                {
                    depth++;
                    index++;
                    getAllCombination(s);
                }
                else if (s[index] == ')')
                {
                    depth--;
                    index++;
                    if (depth == 0)
                    {
                        foreach(string ss in tempResult)
                        {
                            finalResult.Add(ss);
                        }

                        
                        return finalResult;
                    }

                    return tempResult;
                }
                else if (s[index] == ',' && depth == 1)
                {
                    foreach (string ss in tempResult)
                    {
                        finalResult.Add(ss);
                    }

                    tempResult.Clear();
                    index++;
                }
                else
                {
                    List<string> t = new List<string>();
                    while(s[index] != '(' && s[index] != ')')
                    {
                        if(s[index] != ',')
                            t.Add(s[index].ToString());
                        if (s[index] == ',' && depth == 1)
                        {
                            break;
                        }
                        index++;
                    }

                    if (tempResult.Count == 0)
                    {
                        foreach(string tt in t)
                        {
                            tempResult.Add(tt.ToString());
                        }

                        continue;
                    }

                    List<string> ttResult = new List<string>();
                    for (int j = 0; j < t.Count; j++) 
                    {
                        for (int i = 0; i < tempResult.Count; i++)
                        {
                            ttResult.Add(tempResult[i] + t[j]);
                        }
                    }

                    tempResult = ttResult;

                    continue;
                }
            }

            return finalResult;
        }

        public static void Test()
        {
            string s = "((a,b)o(m,n)p,b)";
            Reset();
            getAllCombination(s);

            Console.WriteLine(string.Format("{0} --->", s));
            Console.WriteLine(string.Join(",", finalResult));

            s = "((((a,b))))";
            Reset();
            getAllCombination(s);

            Console.WriteLine(string.Format("{0} --->", s));
            Console.WriteLine(string.Join(",", finalResult));

            s = "((a,b)o(m,n)(p,b)(q,i))";
            Reset();
            getAllCombination(s);

            Console.WriteLine(string.Format("{0} --->", s));
            Console.WriteLine(string.Join(",", finalResult));

            s = "((a,b)o(m,n)p,b(a,b)o(m,n)p)";
            Reset();
            getAllCombination(s);

            Console.WriteLine(string.Format("{0} --->", s));
            Console.WriteLine(string.Join(",", finalResult));

        }
    }
}
