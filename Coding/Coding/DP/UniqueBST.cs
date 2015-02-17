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
        public static UBSTNode DeepCopyIncrease(UBSTNode n, int d)
        {
            if (n == null)
                return null;
            UBSTNode newRoot = new UBSTNode(n._d+d, null, null);
            newRoot.left = DeepCopyIncrease(n.left, d);
            newRoot.right = DeepCopyIncrease(n.right, d);
            return newRoot;
        }

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


        public static Dictionary<int, List<UBSTNode>> _dict = new Dictionary<int, List<UBSTNode>>();
        public static List<UBSTNode> generateTrees(int n)
        {
            List<UBSTNode> ls = new List<UBSTNode>();
            ls.Add(null);
            _dict[0] = ls;

            ls = new List<UBSTNode>();
            ls.Add(new UBSTNode(1, null, null));
            _dict[1] = ls;


            for(int i = 2; i <= n; i ++)
            {
                ls = new List<UBSTNode>();
                for(int j = 1; j <=i; j++)
                {
                    foreach (UBSTNode left in _dict[j - 1])
                    {
                        foreach (UBSTNode right in _dict[i - j])
                        {
                            UBSTNode nRoot = new UBSTNode(j, null, null);
                            nRoot.left = left;
                            nRoot.right = DeepCopyIncrease(right, j);
                            ls.Add(nRoot);
                        }
                    }
                }

                _dict[i] = ls;
            }

            return _dict[n];
        }

        //public static List<UBSTNode> generateSubTrees(int n, int start)
        //{



        //    if (dict.TryGetValue(n, out subDcit))
        //        if (subDcit.ContainsKey(start))
        //        {
        //            return subDcit[start];
        //        }

        //    List<UBSTNode> nodes = new List<UBSTNode>();

        //    for (int i = 0; i < n; i++)
        //    {
        //        List<UBSTNode> leftSons;
        //        if (dict.ContainsKey(i) && dict[i].ContainsKey(1))
        //        {
        //            leftSons = dict[i][1];
        //        }
        //        else
        //        {
        //            leftSons = generateSubTrees(i, 1);
        //        }

        //        List<UBSTNode> rightSons;
        //        if (dict.ContainsKey(n-i-1) && dict[n-i-1].ContainsKey(i+2))
        //        {
        //            rightSons = dict[n - i - 1][i+2];
        //        }
        //        else
        //        {
        //            rightSons = generateSubTrees(n - i - 1, i + 2);
        //        }

        //        if (!dict.ContainsKey(i))
        //        {
        //            Dictionary<int, List<UBSTNode>> d = new Dictionary<int, List<UBSTNode>>();
        //            d[1] = leftSons;
        //            dict[i] = d;
        //        }
        //        if(!dict.ContainsKey(n-i-1))
        //        {
        //            Dictionary<int, List<UBSTNode>> d = new Dictionary<int, List<UBSTNode>>();
        //            d[i+2] = rightSons;
        //            dict[n-i-1] = d;
        //        }

        //        foreach (UBSTNode ln in leftSons)
        //        {
        //            foreach (UBSTNode rn in rightSons)
        //            {
        //                UBSTNode newRoot = new UBSTNode(i + 1, null, null);
        //                newRoot.left = ln;
        //                newRoot.right = rn;
        //                nodes.Add(newRoot);
        //            }
        //        }


        //    }

        //    return nodes;
        //}


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