using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node(int value, Node l, Node r)
        {
            val = value;
            left = l;
            right = r;
        }
    }

    public class MaxTreeNodePathSum
    {
        public static int _maxSum = int.MinValue;
        public static int FindMaxPathSum(Node root)
        {
            int maxSum = int.MinValue;
            int leftSum = 0;
            int rightSum = 0;

            if (root == null)
            {
                return maxSum;
            }

            if (root.left == null && root.right == null)
            {
                _maxSum = Math.Max(_maxSum, root.val);
                return root.val;// > 0 ? root.val : 0;
            }

            if (root.left != null)
            {
                leftSum = FindMaxPathSum(root.left);
                maxSum = Math.Max(root.val, leftSum + root.val);
            }

            if (root.right != null)
            {
                rightSum = FindMaxPathSum(root.right);
                maxSum = Math.Max(maxSum, rightSum + root.val);
            }
            
            _maxSum = Math.Max(maxSum, _maxSum);
            _maxSum = Math.Max(_maxSum, leftSum + rightSum + root.val);

            return maxSum;
        }


        public static void TestFindMaxPath()
        {
            Node node6 = new Node(-1, null, null);
            Node node1 = new Node(1, null, node6);
            Node node2 = new Node(3, null, null);
            Node node3 = new Node(-2, node1, node2);
            Node node4 = new Node(-2, null, null);
            Node node5 = new Node(-3, node4, null);
            Node root = new Node(-1, node3, node5);

            Console.WriteLine(FindMaxPathSum(root));
            Console.WriteLine(_maxSum);
        }
    }
}



    //private int maxPathSumhelper(TreeNode root) {
    //    int leftmax, rightmax;
    //    if (root.left == null && root.right == null){
    //    if (root.val > maxpathsum)
    //        maxpathsum = root.val;
    //        return root.val;
    //    }

    //    if (root.left != null)
    //        leftmax = maxPathSumhelper(root.left);
    //    else
    //        leftmax = 0;
    //    if (root.right != null)
    //        rightmax = maxPathSumhelper(root.right);
    //    else
    //        rightmax = 0;

    //    int localmax = max(root.val, root.val + leftmax, root.val + rightmax);
    //    if (localmax > maxpathsum)
    //        maxpathsum = localmax;
    //    if (root.val + leftmax + rightmax > maxpathsum)
    //        maxpathsum = root.val + leftmax + rightmax;
    //    return localmax;
    //}




//class Solution {
//public:
//    int _maxSum = INT_MIN;
//    int maxPathSum(TreeNode *root) {
//            if(root == NULL)
//            {
//                return _maxSum;
//            }
            
//        maxPathLeper(root);
//        return _maxSum;
//    }
    
//    int maxPathLeper(TreeNode *root){
            
//            int maxSum;
//            int leftSum = 0;
//            int rightSum = 0;
            
//            if(root->left == NULL && root->right == NULL)
//            {
//                _maxSum = _maxSum > root->val ? _maxSum : root->val;
//                return root->val;
//            }

//            if(root->left != NULL)
//            {
//                leftSum = maxPathSum(root->left);
//            }

//            //maxSum = root->val > leftSum + root->val ? root->val : leftSum + root->val;
            
//            if (root->right != NULL)
//            {
//                rightSum = maxPathSum(root->right);
//            }
            
//            //maxSum = maxSum > rightSum + root->val? maxSum : rightSum + root->val;
            
//            maxSum = max(root->val, leftSum + root->val, rightSum + root->val);
            
//            _maxSum = maxSum > _maxSum ? maxSum : _maxSum;
            
//            _maxSum = leftSum + rightSum + root->val > _maxSum ? leftSum + rightSum + root->val : _maxSum;

//            return maxSum;
//    }
    
//    int max(int a, int b, int c){
//    if (a >= b && a >=c)
//        return a;
//    else if (b>=c)
//        return b;
//    else
//        return c;
//    }
// };   