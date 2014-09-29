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


        public static void TestNumOfUniqueBST()
        {
            Console.WriteLine(numOfUniqueBST(3));
            Console.WriteLine(numOfUniqueBST(1));
            Console.WriteLine(numOfUniqueBST(2));
            Console.WriteLine(numOfUniqueBST(4));

        }
    }
}