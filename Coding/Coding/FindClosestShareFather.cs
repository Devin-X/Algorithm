using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    //public class TreeNode
    //{
    //    public int val;
    //    public TreeNode left;
    //    public TreeNode right;

    //    public TreeNode(int value, TreeNode l, TreeNode r)
    //    {
    //        val = value;
    //        left = l;
    //        right = r;
    //    }
    //}
    class FindClosestShareFather
    {
        public static TreeNode _mostCurrentRoot;
        public static TreeNode GetClosestShareFather(TreeNode root, TreeNode a, TreeNode b)
        {
            if(IsSameFather(root, a, b))
            {
                _mostCurrentRoot = root;
                return root;
            }

            if(IsSameFather(root.left, a, b))
            {
                _mostCurrentRoot = root.left;
                return root.left;
            }

            if(IsSameFather(root.right, a, b))
            {
                _mostCurrentRoot = root.right;
                return root.right;
            }

            return null;
        }

        private static Boolean IsSameFather(TreeNode root, TreeNode a, TreeNode b)
        {
            if ((root.left == a && root.right == b) || (root.right == a && root.left == b))
            {
                return true;
            }

            bool isARightSon = IsSon(root.right, a);
            bool isALeftSon = IsSon(root.left, a);
            bool isBRightSon = IsSon(root.right, b);
            bool isBLeftSon = IsSon(root.left, b);

            if (root.left == a && isBRightSon)
                return true;

            if (root.right == a && isBLeftSon)
                return true;

            if (root.left == b && isALeftSon)
                return true;

            if (root.right == b && isARightSon)
                return true;

            if (isALeftSon && isBRightSon)
                return true;

            if (isARightSon & isBLeftSon)
                return true;

            return false;
        }

        private static Boolean IsSon(TreeNode root, TreeNode son)
        {
            if(root == null || son == null)
            {
                return false;
            }

            if (root.left == son || root.right == son)
                return true;

            if (IsSon(root.left, son))
                return true;
            if (IsSon(root.right, son))
                return true;

            return false;
        }

        public static void TestclosestFather()
        {
            TreeNode node6 = new TreeNode(-1, null, null);
            TreeNode node1 = new TreeNode(1, null, node6);
            TreeNode node2 = new TreeNode(3, null, null);
            TreeNode node3 = new TreeNode(-2, node1, node2);
            TreeNode node4 = new TreeNode(-2, null, null);
            TreeNode node5 = new TreeNode(-3, node4, null);
            TreeNode root = new TreeNode(-1, node3, node5);

            GetClosestShareFather(root, node3, node4);
            Console.WriteLine(_mostCurrentRoot.val);
        }
    }
}
