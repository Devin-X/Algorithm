using System;
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
        public static  int MaxArea(int[] height)
        {
            int n = height.Length;
            List<int> copy = new List<int>();
            for (int i = 0; i < n; i++)
            {
                copy.Add(height[i]);
            }

            copy.Sort();
            int[] ranking = new int[n];
            int[] reverseIndex = new int[n];

            int max = 0;

            for (int i = 0; i < n; i++)
            {
                ranking[i] = bS(copy, 0, n - 1, height[i]);
                reverseIndex[ranking[i]] = i;
            }


            for (int i = 0; i < n; i++)
            {
                int rank = ranking[i];
                if (rank == 0) continue;

                int shorter = reverseIndex[rank - 1];
                //taller = reverseIndex[rank+1];
                //if(i > 0 && i < n-1){
                //    shorter = reverseIndex[rank-1];
                //    taller = reverseIndex[rank+1];

                max = Math.Max(max, (height[shorter] * Math.Abs(i - shorter)));

                //}else if(i == 0 || i == n-1){
                //    max = Maxh.Max(max, )

                //}else if(i == n-1){

            }
            return max;
        }


        private static  int bS(List<int> copy, int start, int end, int target)
        {
            if (start >= end) return start;
            int middle = start + (end - start) / 2;
            if (copy[middle] == target) return middle;
            else if (copy[middle] > target) return bS(copy, start, middle - 1, target);
            return bS(copy, middle + 1, end, target);
        }
        static void Main(string[] args)
        {
            MaxSlidingWindowSolution.Test();
            MinWindowString.Test();
            LCABST.Test();

            int[] height = { 1, 1 };

            MaxArea(height);

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
