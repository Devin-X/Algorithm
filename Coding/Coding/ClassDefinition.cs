    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Coding
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            this.val = x;
            next = null;
        }
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value, TreeNode l, TreeNode r)
        {
            val = value;
            left = l;
            right = r;
        }

        public TreeNode(int v)
        {
            val = v;
        }
    }

    public class Vertex
    {
        public int value;
        public List<Vertex> neighbours;
        public Vertex(int v)
        {
            value = v;
        }
    }
}
    