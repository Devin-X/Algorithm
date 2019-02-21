using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// Follow up for problem "Populating Next Right Pointers in Each Node".
    ///         1
    ///        / \
    ///       2   3
    ///      / \   \
    ///     4   5   7
    /// </summary>
    public class NodeWithRight
    {
        public int _value;
        public NodeWithRight lSon;
        public NodeWithRight rSon;
        public NodeWithRight rightBrother;

        public NodeWithRight(int value, NodeWithRight l, NodeWithRight r)
        {
            _value = value;
            lSon = l;
            rSon = r;
        }
    }
    class TreeNextRightPointers
    {
        public static List<NodeWithRight> ret = new List<NodeWithRight>();
        public static int index = 0;
        public static int height = 0;
        public static void CompleteTheTree(NodeWithRight root)
        {
            ret.Add(root);
            height = 1;

            while (index < ret.Count)
            {
                NodeWithRight node = ret[index++];
                if ((Math.Pow(2, height) - 1) == ret.Count)
                {
                    height++;
                }
                if (node != null)
                {
                    ret.Add(node.lSon);
                    ret.Add(node.rSon);
                }
            }

            int tempH = 1;
            ret[0].rightBrother = null;
            for (; tempH < height; tempH++)
            {
                int i = (int)(Math.Pow(2, tempH) - 1);
                int current = i;
                int end = (int)(Math.Pow(2, tempH) + i - 1);
                while (i < end)
                {
                    if (ret[current] != null && ret[i + 1] != null)
                    {
                        ret[current].rightBrother = ret[i + 1];
                        current = i + 1;
                    }

                    i++;
                }

                if (i < ret.Count && ret[i] != null)
                {
                    ret[i].rightBrother = null;
                }
            }
        }

        /// <summary>
        /// for this implementation, I am not going to make the tree a complete binary tree
        /// </summary>
        /// <param name="root"></param>
        public static List<NodeWithRight> BFSTree(NodeWithRight root)
        {
            int h = 1;
            int count = 0;
            List<NodeWithRight> result = new List<NodeWithRight>();
            List<int> levelEdge = new List<int>();
            NodeWithRight current;
            result.Add(root);
            root.rightBrother = null;
            int index = 0;
            count++;

            while (index < result.Count)
            {
                if (count == (Math.Pow(2, h) - 1))
                {
                    result.Add(null);
                    h++;
                }

                current = result[index++];
                if (current != null)
                {
                    if (current.lSon != null)
                    {
                        result.Add(current.lSon);
                    }
                    if (current.rSon != null)
                    {
                        result.Add(current.rSon);
                    }

                    count += 2;
                }
            }
            result.Add(null);

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] == null)
                {
                    continue;
                }

                result[i].rightBrother = result[i + 1];
            }

            return result;
        }


        public static void FindAllNodesRight(NodeWithRight root)
        {
            if (root == null)
                return;
            NodeWithRight temp = root.rightBrother;
            NodeWithRight uncleSon = null;
            while (temp != null)
            {
                if (temp.lSon != null || temp.rSon != null)
                {
                    uncleSon = temp.lSon == null ? temp.rSon : temp.lSon;
                    break;
                }
                else
                {
                    temp = temp.rightBrother;
                }
            }


            if (root.rSon != null)
            {
                root.rSon.rightBrother = uncleSon;
            }

            if (root.lSon != null)
            {
                root.lSon.rightBrother = root.rSon == null ? uncleSon : root.rSon;
            }

            FindAllNodesRight(root.lSon);
            FindAllNodesRight(root.rSon);
            
            if (root != null)
            {
                Console.Write("{0} --->",root._value);
                if (root.rightBrother != null)
                    Console.Write(root.rightBrother._value);
                else
                    Console.WriteLine("null");
            }
        }

        public static void Test()
        {
            NodeWithRight l2 = new NodeWithRight(4, null, null);
            NodeWithRight r2 = new NodeWithRight(5, null, null);
            NodeWithRight r22 = new NodeWithRight(7, null, null);

            NodeWithRight l1 = new NodeWithRight(2, l2, null);
            NodeWithRight r1 = new NodeWithRight(3, null, r22);
            NodeWithRight root = new NodeWithRight(1, l1, r1);

            //CompleteTheTree(root);

            //foreach (NodeWithRight node in ret)
            //{
            //    if (node != null)
            //    {
            //        Console.Write("{0} ---> ", node._value);
            //        Console.WriteLine(node.rightBrother == null ? "null" : node.rightBrother._value.ToString());
            //    }
            //}


            List<NodeWithRight> bfst = BFSTree(root);

            foreach (NodeWithRight node in bfst)
            {
                if (node != null)
                {
                    Console.Write("{0} ---> ", node._value);
                    Console.WriteLine(node.rightBrother == null ? "null" : node.rightBrother._value.ToString());
                }
            }

            Console.WriteLine();
            root.rightBrother = null;
            FindAllNodesRight(root);
        }
    }
}
