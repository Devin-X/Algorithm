using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    /// <summary>
    /// Unique Binary Search Trees Total Accepted: 25459 Total Submissions: 69640 My Submissions 
    /// Given n, how many structurally unique BST's (binary search trees) that store values 1...n?
    /// For example,
    /// Given n = 3, there are a total of 5 unique BST's. 
    /// 1         3     3      2      1
    ///  \       /     /      / \      \
    ///   3     2     1      1   3      2
    ///   /     /       \                 \
    ///  2     1         2                 3

    /// </summary>
    /// 

    public class UBSTNode
    {
        public int _d;
        public UBSTNode left;
        public UBSTNode right;
        public UBSTNode(int d, UBSTNode l, UBSTNode r)
        {
            _d = d;
            left = l;
            right = r;
        }
    }

    class UniqueBST
    {
        public static int numOfUniqueBST(int n)
        {
            if (n == 1)
                return 1;
            if (n == 0)
                return 1;

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += numOfUniqueBST(i) * numOfUniqueBST(n - i - 1);
            }

            return sum;
        }

        public static Dictionary<int, Dictionary<int, List<UBSTNode>>> dict = new Dictionary<int, Dictionary<int, List<UBSTNode>>>();
        public static List<UBSTNode> generateTrees(int n)
        {
            return generateSubTrees(n, 1);
        }

        public static List<UBSTNode> generateSubTrees(int n, int start)
        {
            Dictionary<int, List<UBSTNode>> subDcit = new Dictionary<int, List<UBSTNode>>();
            if (n == 0)
            {
                UBSTNode root = new UBSTNode(0, null, null);
                List<UBSTNode> lNode = new List<UBSTNode>();
                lNode.Add(root);
                return lNode;
            }
            if (n == 1)
            {
                UBSTNode root = new UBSTNode(start, null, null);
                List<UBSTNode> lNode = new List<UBSTNode>();
                lNode.Add(root);
                return lNode;
            }

            if (n == 2)
            {
                UBSTNode root = new UBSTNode(start, null, new UBSTNode(start + 1, null, null));
                List<UBSTNode> lNode = new List<UBSTNode>();
                lNode.Add(root);
                root = new UBSTNode(start + 1, new UBSTNode(start, null, null), null);
                lNode.Add(root);
                return lNode;
            }


            if (dict.TryGetValue(n, out subDcit))
                if (subDcit.ContainsKey(start))
                {
                    return subDcit[start];
                }

            List<UBSTNode> nodes = new List<UBSTNode>();

            for (int i = 0; i < n; i++)
            {
                List<UBSTNode> leftSons;
                if (dict.ContainsKey(i) && dict[i].ContainsKey(1))
                {
                    leftSons = dict[i][1];
                }
                else
                {
                    leftSons = generateSubTrees(i, 1);
                }

                List<UBSTNode> rightSons;
                if (dict.ContainsKey(n-i-1) && dict[n-i-1].ContainsKey(i+2))
                {
                    rightSons = dict[n - i - 1][i+2];
                }
                else
                {
                    rightSons = generateSubTrees(n - i - 1, i + 2);
                }

                if (!dict.ContainsKey(i))
                {
                    Dictionary<int, List<UBSTNode>> d = new Dictionary<int, List<UBSTNode>>();
                    d[1] = leftSons;
                    dict[i] = d;
                }
                if(!dict.ContainsKey(n-i-1))
                {
                    Dictionary<int, List<UBSTNode>> d = new Dictionary<int, List<UBSTNode>>();
                    d[i+2] = rightSons;
                    dict[n-i-1] = d;
                }

                foreach (UBSTNode ln in leftSons)
                {
                    foreach (UBSTNode rn in rightSons)
                    {
                        UBSTNode newRoot = new UBSTNode(i + 1, null, null);
                        newRoot.left = ln;
                        newRoot.right = rn;
                        nodes.Add(newRoot);
                    }
                }


            }

            return nodes;
        }


        public static void TestNumOfUniqueBST()
        {
            Console.WriteLine(numOfUniqueBST(3));
            Console.WriteLine(numOfUniqueBST(1));
            Console.WriteLine(numOfUniqueBST(2));
            Console.WriteLine(numOfUniqueBST(4));

            List<UBSTNode> root = generateTrees(0);
            root = generateTrees(1);
            root = generateTrees(2);
            root = generateTrees(3);
            root = generateTrees(4);
            root = generateTrees(100);
        }
    }
}