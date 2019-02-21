using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{

    class FindClosestShareFather
    {
        public static NodeWithRight _mostCurrentRoot = null;
        public static NodeWithRight _aParent = null;
        public static NodeWithRight _bParenet = null;
        public static NodeWithRight GetClosestShareFather(NodeWithRight root, NodeWithRight a, NodeWithRight b)
        {
            if(root == null || root.lSon == null && root.rSon == null)
            {
                return null;
            }

            if (root.lSon == a || root.rSon == a)
            {
                _aParent = root;
            }

            if (root.rSon == b || root.lSon == b)
            {
                _bParenet = root;
            }

            GetClosestShareFather(root.lSon, a, b);
            GetClosestShareFather(root.rSon, a, b);

            if(_aParent == root.lSon || _aParent == root.rSon)
            {
                _aParent = root;
            }

            if(_bParenet == root.lSon || _bParenet == root.rSon)
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
            NodeWithRight node1 = new NodeWithRight(1, null, null);
            NodeWithRight node2 = new NodeWithRight(2, null, node1);
            NodeWithRight node3 = new NodeWithRight(3, null, null);
            NodeWithRight node4 = new NodeWithRight(4, node2, node3);
            NodeWithRight node5 = new NodeWithRight(5, null, null);
            NodeWithRight node6 = new NodeWithRight(6, node5, null);
            NodeWithRight root = new NodeWithRight(7, node4, node6);

            GetClosestShareFather(root, node4, node6);
            Console.WriteLine(_mostCurrentRoot._value);
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