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
        public static TreeNode _aParent;
        public static TreeNode _bParenet;
        public static int _travelDepth = 0;
        public static int _aDepth = -1;
        public static int _bDepth = -1;

        public static TreeNode GetClosestShareFather(TreeNode root, TreeNode a, TreeNode b)
        {
            if (root != null)
                _travelDepth++;

            if (root.left == a && root.right == b || root.right == a && root.left == b)
                return root;

            TreeNode ret = null;

            if (root.left == a || root.right == a)
            {
                _aDepth = _travelDepth;
            }

            if (root.right == b || root.left == b)
            {
                _bDepth = _travelDepth;
            }

            if(_aDepth != -1 && _bDepth == -1)
            {
                GetClosestShareFather(root.left, a, b);
                if (_bDepth != -1)
                    return root;
                else
                {
                    GetClosestShareFather(root.right, a, b);
                    if(_bDepth != -1)
                        return root;
                    else 
                        return null;
            }

            if (_aDepth == -1 && _bDepth != -1)
            {
                GetClosestShareFather(root.left, a, b);
                if (_aDepth != -1)
                    return root;
                else
                {
                    GetClosestShareFather(root.right, a, b);
                    if(_aDepth != -1)
                        return root;
                    else 
                        return null;
                }
            }

            if(_aDepth == -1 && _bDepth == -1)
            {
                ret = GetClosestShareFather(root.left, a, b);
                if (ret != null)
                    return ret;
                else
                    return GetClosestShareFather(root.right, a, b);
            }


            return null;
        }

        private static int GetDepth(TreeNode root, TreeNode a)
        {
            if (root == null)
                return -1;
            if(root == a)
            {
                return 0;
            }

            int left = GetDepth(root.left, a);
            if (left != -1)
                return left++;

            int right = GetDepth(root.right, a);
            if (right != -1)
                return right++;

            return -1;
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
