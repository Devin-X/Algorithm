using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class MinStack
    {
        private Stack<int> _stack = new Stack<int>();
        private Stack<int> _min = new Stack<int>();

        public void Push(int x)
        {
            _stack.Push(x);
            if (_min.Count == 0)
            {
                _min.Push(x);
            }
            else
            {
                int min = _min.Pop();
                _min.Push(min);
                _min.Push(min < x ? min : x);
            }
        }

        public void Pop()
        {
            _stack.Pop();
            _min.Pop();
        }

        public int Top()
        {
            return _stack.Peek();
        }

        public int GetMin()
        {
            return _min.Peek();
        }
    }

    
}
