using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode (int value, TreeNode l, TreeNode r)
        {
            val = value;
            left = l;
            right = r;
        }
    }

    public class MaxTreeNodePathSum
    {
        public static int _maxSum = int.MinValue;
        public static int FindMaxPathSum(TreeNode root)
        {
            int maxSum = int.MinValue;
            int leftSum = 0;
            int rightSum = 0;

            if(root.left == null && root.right == null)
            {
                _maxSum = _maxSum > root.val ? _maxSum : root.val;
                return root.val;
            }

            if(root.left != null)
            {
                leftSum = FindMaxPathSum(root.left);
                leftSum += root.val;
                maxSum = root.val > leftSum ? root.val : leftSum;
            }

            if (root.right != null)
            {
                rightSum = FindMaxPathSum(root.right);
                rightSum += root.val;
                maxSum = root.val > rightSum ? root.val : rightSum;
            }

            if(root.left != null)
            {
                int leftSumToRoot = FindMaxPathToRoot(root.left);
                _maxSum = leftSumToRoot + rightSum > _maxSum ? leftSumToRoot + rightSum : _maxSum;
                //maxSum = leftSumToRoot + root.val > maxSum ? leftSumToRoot + root.val : maxSum;
            }

            if(root.right != null)
            {
                int rightSumToRoot = FindMaxPathToRoot(root.right);
                _maxSum = leftSum + rightSumToRoot > _maxSum ? leftSum + rightSumToRoot : _maxSum;
                //maxSum = root.val + rightSumToRoot > maxSum ? leftSum + root.val : maxSum;
            }

            _maxSum = maxSum > _maxSum ? maxSum : _maxSum;
            return maxSum;
        }

        private static int FindMaxPathToRoot(TreeNode root)
        {
            int sum = int.MinValue;
            int left = 0;
            int right = 0;

            if(root.left == null && root.right == null)
            {
                return root.val;
            }

            if(root.left != null)
            {
                left = FindMaxPathToRoot(root.left);
            }

            if(root.right != null)
            {
                right = FindMaxPathToRoot(root.right);
            }

            sum = left > right ? left + root.val : right + root.val;
            sum = sum > root.val ? sum : root.val;
            sum = sum > 0 ? sum : 0;

            return sum;
        }

        public static void TestFindMaxPath()
        {
            TreeNode node1 = new TreeNode(1, null, null);
            TreeNode node2 = new TreeNode(3, null, null);
            TreeNode node3 = new TreeNode(-1, node1, node2);
            TreeNode node4 = new TreeNode(4, null, null);
            TreeNode root = new TreeNode(-1, node3, node4);

            Console.WriteLine(FindMaxPathSum(root));
            Console.WriteLine(_maxSum);
        }
    }
}
