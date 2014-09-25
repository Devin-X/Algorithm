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
        public static TreeNode _mostCurrentRoot = null;
        public static TreeNode _aParent = null;
        public static TreeNode _bParenet = null;
        public static TreeNode GetClosestShareFather(TreeNode root, TreeNode a, TreeNode b)
        {
            if(root == null || root.left == null && root.right == null)
            {
                return null;
            }

            if (root.left == a || root.right == a)
            {
                _aParent = root;
            }

            if (root.right == b || root.left == b)
            {
                _bParenet = root;
            }

            GetClosestShareFather(root.left, a, b);
            GetClosestShareFather(root.right, a, b);

            if(_aParent == root.left || _aParent == root.right)
            {
                _aParent = root;
            }

            if(_bParenet == root.left || _bParenet == root.right)
            {
                _bParenet = root;
            }

            if (_aParent == _bParenet && _aParent != null)
            {
                _mostCurrentRoot = _mostCurrentRoot == null ? _aParent : _mostCurrentRoot;
                return _mostCurrentRoot;
            }

            return _mostCurrentRoot;
        }

       
        public static void TestclosestFather()
        {
            TreeNode node1 = new TreeNode(1, null, null);
            TreeNode node2 = new TreeNode(2, null, node1);
            TreeNode node3 = new TreeNode(3, null, null);
            TreeNode node4 = new TreeNode(4, node2, node3);
            TreeNode node5 = new TreeNode(5, null, null);
            TreeNode node6 = new TreeNode(6, node5, null);
            TreeNode root = new TreeNode(7, node4, node6);

            GetClosestShareFather(root, node4, node6);
            Console.WriteLine(_mostCurrentRoot.val);
        }
    }
}


//private static int GetDepth(TreeNode root, TreeNode a)
//{
//    if (root == null)
//        return -1;
//    if(root == a)
//    {
//        return 0;
//    }

//    int left = GetDepth(root.left, a);
//    if (left != -1)
//        return left++;

//    int right = GetDepth(root.right, a);
//    if (right != -1)
//        return right++;

//    return -1;
//}

        //private static Boolean IsSameFather(TreeNode root, TreeNode a, TreeNode b)
        //{
        //    if ((root.left == a && root.right == b) || (root.right == a && root.left == b))
        //    {
        //        return true;
        //    }

        //    bool isARightSon = IsSon(root.right, a);
        //    bool isALeftSon = IsSon(root.left, a);
        //    bool isBRightSon = IsSon(root.right, b);
        //    bool isBLeftSon = IsSon(root.left, b);

        //    if (root.left == a && isBRightSon)
        //        return true;

        //    if (root.right == a && isBLeftSon)
        //        return true;

        //    if (root.left == b && isALeftSon)
        //        return true;

        //    if (root.right == b && isARightSon)
        //        return true;

        //    if (isALeftSon && isBRightSon)
        //        return true;

        //    if (isARightSon & isBLeftSon)
        //        return true;

        //    return false;
        //}

        //private static Boolean IsSon(TreeNode root, TreeNode son)
        //{
        //    if(root == null || son == null)
        //    {
        //        return false;
        //    }

        //    if (root.left == son || root.right == son)
        //        return true;

        //    if (IsSon(root.left, son))
        //        return true;
        //    if (IsSon(root.right, son))
        //        return true;

        //    return false;
        //}