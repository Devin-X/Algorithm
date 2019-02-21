using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    class SumRootToLeafNumbers
    {
        public static int sumNumbers(TreeNode root)
        {
            int sum = 0;
            return travelTree(root, 0, ref sum);
        }

        public static int travelTree(TreeNode root, int parent, ref int sum)
        {
            if (root == null)
            {
                return 0;
            }

            Console.WriteLine(string.Format("{0} left-{1} right{2}", root.val, root.left != null ? root.left.val : -1, root.right != null ? root.right.val : -1));
            int currentRoot = parent * 10 + root.val;

            if (root.left == null && root.right == null)
            {
                sum += currentRoot;
                Console.WriteLine(string.Format("Current root to leaf: {0}, new sum {1}", currentRoot, sum));
            }

            travelTree(root.left, currentRoot, ref sum);
            travelTree(root.right, currentRoot, ref sum);

            return sum;
        }

        public static void Test()
        {
            TreeNode root = new TreeNode(1, null, null);
            TreeNode l1 = new TreeNode(2, null, null);
            TreeNode r1 = new TreeNode(3, null, null);

            TreeNode l2 = new TreeNode(4, null, null);
            TreeNode r2 = new TreeNode(5, null, null);
            TreeNode r3 = new TreeNode(6, null, null);

            TreeNode r4 = new TreeNode(7, null, null);
            TreeNode r5 = new TreeNode(0, null, null);
            TreeNode r6 = new TreeNode(0, null, null);


            root.left = l1; root.right = r1;
            l1.left = l2;
            r1.left = r2;
            r1.right = r3;
            r3.right = r4;
            r4.right = r5;
            r5.right = r6;

            Console.WriteLine(sumNumbers(root));
        }
    }
}
