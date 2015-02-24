using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle.TestTriangle();
            MaxSumOfSubArray.Test();
            //MousesandHoles.Test();
            //UniqueBST.Test();
            BASH_Brace.Test();
            Calculator.Test();
            MaxSubProduction.TestMaxSubProduction();
            DecodingWays.Test();

            //MousesandHoles.Test();
            //FindMaxSubArraySumWithDuplicate.Test();
            //FindConnectedGraph.Test();
            //H2O.Simulate();
            WordsLadderLength.TestGetLadderLength();
            UniquePath.Test();
            MinPath.Test();

            Interleave.Test();

            DistinctSubSequences.Test();
            PrintParathesies.Test();
            MaxRectangle.Test();
            RegexMatch.Test();
            SumRootToLeafNumbers.Test();
            ValidateBST.Test();
            MaxBitWindowFlip.Test();
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
