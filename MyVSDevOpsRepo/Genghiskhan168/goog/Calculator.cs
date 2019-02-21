using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>

    //Evaluate the value of an arithmetic expression in Reverse Polish Notation. 

    //Valid operators are +, -, *, /. Each operand may be an integer or another expression. 

    //Some examples:

    //  ["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
    //  ["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6


    /// </summary>
    public class Calculator
    {
        public static int EvalRPN(string[] tokens)
        {
            Stack<int> workingStack = new Stack<int>();
            int left;
            int right;
            foreach (string s in tokens)
            {
                switch (s)
                {
                    case "+":
                        right = workingStack.Pop();
                        left = workingStack.Pop();
                        workingStack.Push(left + right);
                        break;

                    case "*":
                        right = workingStack.Pop();
                        left = workingStack.Pop();
                        workingStack.Push(left * right);
                        break;
                    case "/":
                        right = workingStack.Pop();
                        left = workingStack.Pop();
                        workingStack.Push(left / right);
                        break;
                    case "-":
                        right = workingStack.Pop();
                        left = workingStack.Pop();
                        workingStack.Push(left - right);

                        break;
                    default:
                        workingStack.Push(int.Parse(s));
                        break;
                }
            }

            return workingStack.Pop();
        }

        public static void Test()
        {
            string[] expre = { "2", "1", "+", "3", "*" };
            Console.WriteLine(string.Join(",", expre));
            Console.WriteLine(EvalRPN(expre));

            expre = new string[] { "4", "13", "5", "/", "+" };
            Console.WriteLine(string.Join(",", expre));
            Console.WriteLine(EvalRPN(expre));

            expre = new string[] { "2", "1", "3", "-", "+", "3", "*" };
            Console.WriteLine(string.Join(",", expre));
            Console.WriteLine(EvalRPN(expre));
        }
    }
}
