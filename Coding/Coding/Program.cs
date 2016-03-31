using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.Runtime.InteropServices;
using Coding.Array;
using Coding.Tree;

namespace Coding
{
    class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }

        public class TreeNoden
        {
            public int val;
            public TreeNoden left;
            public TreeNoden right;

            public TreeNoden(int x)
            {
                val = x;
            }
        }
        public static IList<TreeNode> GenerateTrees(int n) {
        List<TreeNode>[,] cache = new List<TreeNode>[n+1,n+1];
        
        for(int i = 0; i <= n; i++){
            cache[i,i]= new List<TreeNode>();
            cache[i,i].Add(new TreeNode(i));
        }
        if(n == 0) return cache[0,0]; 
        
        for(int i = 1; i <= n ; i++){
            for(int j = 1; j <= i; j++){
                
                List<TreeNode> left;
                List<TreeNode> right;
                if(j-1 >=1) left = cache[1,j-1];
                else {left = new List<TreeNode>(); left.Add(null);}
                if(j+1 <= i) right = cache[j+1, i];
                else {right = new List<TreeNode>(); right.Add(null);}                
                
                foreach (TreeNode ln in left){
                    foreach (TreeNode rn in right){
                        TreeNode root = new TreeNode(j);
                        root.left = ln;
                        root.right = rn;
                        
                        if(cache[1, j] == null) cache[1,j] = new List<TreeNode>();
                        
                        cache[1,j].Add(root);
                    }
                }
            }
        }
        
        return cache[1,n];
    }
        private static void bt(TreeNoden root, int sum, int s, List<int> current, IList<IList<int>> final)
        {
        current.Add(root.val);
        s += root.val;
        
        if(root.left == null && root.right == null){
            if(sum == s){
                final.Add(new List<int>(current));
            }
        }
        
        if(root.left != null) bt(root.left, sum, s, current, final);
        if(root.right != null) bt(root.right, sum, s, current, final);
        
        current.Remove(current.Count-1);
        s -= root.val;
    }
        static void Main(string[] args)
        {
            MaxSlidingWindowSolution.Test();
            MinWindowString.Test();
            LCABST.Test();
            
             IList<IList<int>> final = new List<IList<int>>(1000);
             List<int> current = new List<int>();
            int s = 0;

            TreeNoden root = new TreeNoden(0);
            TreeNoden r = root;
            for (int i = 0; i < 5000; i++)
            {
                TreeNoden newNode = new TreeNoden(1);
                root.left = newNode;
                root.right = null;
                root = root.left;
            }
            

        
             bt(r, 5000, s, current, final);

            Console.Write(final.Count);

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
