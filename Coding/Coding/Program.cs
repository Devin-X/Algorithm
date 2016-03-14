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
        static void Main(string[] args)
        {
            MaxSlidingWindowSolution.Test();
            MinWindowString.Test();
            LCABST.Test();

            int k = 1;
            int j = 0; 
            while (true)
            {
                j++;
                k *= 3;
                if (k > int.MaxValue/3)
                    break;
            }

            Console.WriteLine(j);
            Console.WriteLine(k);
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
