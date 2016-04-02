﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using Coding.Array;
using Coding.Tree;

namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxSlidingWindowSolution.Test();
            MinWindowString.Test();
            LCABST.Test();

            int[] height = { 1, 1 };
            IList<IList<int>> triangle = new List<IList<int>>();
            triangle.Add(new List<int>());
            triangle.Add(new List<int>());
            triangle.Add(new List<int>());
            triangle.Add(new List<int>());
            triangle[0].Add(2);
            triangle[1].Add(3); triangle[1].Add(4);
            triangle[2].Add(6); triangle[2].Add(5); triangle[2].Add(7);
            triangle[3].Add(4); triangle[3].Add(1); triangle[3].Add(8); triangle[3].Add(3);


            Solution sl = new Solution();
            sl.MinimumTotal(triangle);


            Coding.ListNode head = new Coding.ListNode(3);
            head.next = new Coding.ListNode(4);

            head.next.next = new Coding.ListNode(1);
            //head.next.next.next = new Array.ListNode(4);
            head = sl.SortList(head);
            //sl.GenerateTrees(4);
            //MinStack ms = new MinStack();
            //ms.Push(-2);
            //ms.Push(0);
            //ms.Push(-1);
            //Console.WriteLine(ms.GetMin());
            //Console.WriteLine(ms.Top());
            //ms.Pop();
            //Console.WriteLine(ms.GetMin());
            //Triangle.TestTriangle();
            //MaxSumOfSubArray.Test();
            //MousesandHoles.Test();
            //UniqueBST.Test();
            //BASH_Brace.Test();
            //Calculator.Test();
            //MaxSubProduction.TestMaxSubProduction();
            //DecodingWays.Test();

            //MousesandHoles.Test();
            //FindMaxSubArraySumWithDuplicate.Test();
            //FindConnectedGraph.Test();
            //H2O.Simulate();
            //WordsLadderLength.TestGetLadderLength();
            //UniquePath.Test();
            //MinPath.Test();

            //Interleave.Test();

            //DistinctSubSequences.Test();
            //PrintParathesies.Test();
            //MaxRectangle.Test();
            //RegexMatch.Test();
            //SumRootToLeafNumbers.Test();
            //ValidateBST.Test();
            //MaxBitWindowFlip.Test();
            //Console.WriteLine(Palindrome.IsPalindrom("a b c d e f gGrF!,ED C B A"));
            //Stock.TestMaxProfit();
            //ReverseWordsInString.TestReverseWordsInString();
            //MaxTreeNodePathSum.TestFindMaxPath();
            //FindClosestShareFather.TestclosestFather();
            //Permutation.TestFullPermutation();
            //MaxSubProduction.TestMaxSubProduction();
            //Combination.TestFullCombination();
            //SubSet.TestSubSet();
            //Triangle.TestTriangle();
            //Parethesis.TestValidParathesisString();
            //UniqueBST.TestNumOfUniqueBST();
            //MaxNumOfCars.TestMaxNumOfCars();
            //Sorting.Test();
            //Palindrome.Test();
            //MaxBitWindowFlip.Test();
            //HighestInterval.Test();
            //TreeNextRightPointers.Test();
            //GroupNumbers.Test();
            //MakeChange.Test();
            //FirstMissingInteger.Test();
            //MaxAccendingSubSeq.Test();

            //CloneGraphI.Test();

            //SortLinkedList.Test();
            //WordBreaker.Test();

            //CombineMaxSolution.Test();
        }
    }
}


//public class Solution
//{
//    public IList<TreeNode> GenerateTrees(int n)
//    {
//        List<TreeNode>[,] cache = new List<TreeNode>[n + 2, n + 2];

//        for (int i = 0; i <= n+1; i++)
//        {
//            for (int j = 0; j <= n+1; j++)
//            {
//                //cache[i, j] = null;
//            }
//        }

//        if (n == 0) return cache[0, 0];

//        for (int len = 1; len <= n; len++)
//        {
//            for (int i = 1; i <= n - len + 1; i++)
//            {
//                for (int j = i; j < i + len; j++)
//                {

//                    List<TreeNode> left;
//                    List<TreeNode> right;
//                    left = cache[i, j-1];
//                    if (left == null) { left = new List<TreeNode>(); left.Add(null); }
//                    right = cache[j + 1, i + len - 1];
//                    if (right == null) { right = new List<TreeNode>(); right.Add(null); }

//                    for (int lni = 0; lni < left.Count; lni++)
//                    {
//                        for (int rni = 0; rni < right.Count; rni++)
//                        {
//                            TreeNode l = null;
//                            l = CopyTree(left[lni], ref l);
//                            //while (l.right != null) l = l.right;
//                            //l.right = right[rni];
//                            if (cache[i, i + len - 1] == null) cache[i, i + len - 1] = new List<TreeNode>();
//                            //cache[i, i + len - 1].Add(temp);

//                            TreeNode r = null;

//                            r = CopyTree(right[rni], ref r);
//                            TreeNode root = new TreeNode(j);
//                            root.left = l;
//                            root.right = r;
//                            //while (temp.left != null) temp = temp.left;
//                            //temp.left = left[lni];
//                            //if (cache[i, i + len - 1] == null) cache[i, i + len - 1] = new List<TreeNode>();
//                            cache[i, i + len - 1].Add(root);

//                        }
//                    }
//                }
//            }
//        }
//        return cache[1, n];
//    }

//    private TreeNode CopyTree(TreeNode root, ref TreeNode copy)
//    {
//        if (root == null) { copy = null; return copy; }

//        copy = new TreeNode(root.val);
//        copy.left = null;
//        copy.right = null;
//        CopyTree(root.left, ref copy.left);
//        CopyTree(root.right, ref copy.right);

//        return copy;
//    }


//    public int MinimumTotal(IList<IList<int>> triangle)
//    {
//        if (triangle == null || triangle.Count == 0 || triangle[0].Count == 0) return 0;
//        int n = triangle.Count;
//        int m = triangle[n - 1].Count;
//        int[] ret = new int[m];
//        int[] previous = new int[m];
//        int minPath = int.MaxValue;
//        previous[0] = triangle[0][0];

//        for (int i = 1; i < n; i++)
//        {
//            ret[0] = triangle[i][0] + previous[0];
//            ret[i] = triangle[i][i] + previous[i - 1];
//            for (int j = 1; j < i; j++)
//            {
//                ret[j] = Math.Min(triangle[i][j] + previous[j], triangle[i][j] + previous[j - 1]);
//            }

//            previous = ret;
//            ret = new int[m];
//        }

//        for (int i = 1; i < m; i++)
//        {
//            minPath = Math.Min(previous[i], minPath);
//        }

//        return minPath;
//    }


//    public ListNode SortList(ListNode head)
//    {
//        if (head == null) return null;
//        ListNode end = head;
//        int len = 1;
//        while (end.next != null) { end = end.next; len++; }
//        return Sort(head, end, len);
//    }

//    private ListNode Sort(ListNode head, ListNode end, int len)
//    {
//        if (head == null || end == null) return head;
//        if(head== end)
//        {
//            head.next = null;
//            return head;
//        }

//        int m = len / 2;
//        ListNode mNode = head;
//        while (m > 1) { mNode = mNode.next; m--; }
//        ListNode b = Sort(mNode.next, end, len - len / 2);
//        ListNode a = Sort(head, mNode, len / 2);
//        mNode.next = null;
//        end.next = null;
//        return Merge(a, b);
//    }

//    private ListNode Merge(ListNode a, ListNode b)
//    {
//        ListNode head = new ListNode(-1);
//        ListNode hh = head;
//        while (a != null && b != null)
//        {
//            if (a.val < b.val)
//            {
//                head.next = a;
//                a = a.next;
//                head = head.next;
//            }
//            else {
//                head.next = b;
//                b = b.next;
//                head = head.next;
//            }
//        }
//        if (a == null) head.next = b;
//        else head.next = a;
//        return hh.next;
//    }
//}

//WebRequestTest.Test();
//            Regex pattern = new Regex("(x)(n--[0-9a-z]*)-([0-9a-f]{14})-([0-9a-z]+\\.)", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

//            string ret;
//            string replacement = "|2|-app-|4";
//            Match m = pattern.Match("n--ca-f585de7457e969-fxb.sharepoint.com");
//            if (m.Success)
//            {
//                Console.WriteLine("success");
//            }
//            string[] groups = replacement.Split('|');
//            StringBuilder sb = new StringBuilder();
//            foreach (string s in groups)
//            {
//                int gIndex = 0;
//                if (int.TryParse(s, out gIndex))
//                {
//                    sb.Append(m.Groups[gIndex]);
//                }
//                else
//                {
//                    sb.Append(s);
//                }
//            }

//            ret = sb.ToString();
