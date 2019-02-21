using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{

    //public class Node
    //{
    //    public Node lSon;
    //    public Node rSon;
    //    public int value;
    //}
    //          4
    //    2          8
    //1       5
    public class ValidateBST
    {
        public static Node lastParent = null;
        public static int maxSon = int.MinValue;
        public static int minSon = int.MaxValue;


        public static bool IsBST(TreeNode root, ref int max, ref int min)
        {
            if (root == null)
            {
                return true;
            }

            max = int.MinValue;
            if (IsBST(root.left, ref max, ref min) == false)
                return false;

            if (maxSon > root.val)
                return false;

            min = int.MaxValue;
            if (IsBST(root.right, ref max, ref min) == false)
                return false;

            if (minSon < root.val)
                return false;

            max = root.val > max ? root.val : max;
            min = root.val < min ? root.val : min;

            return true;

        }

        public static void Test()
        {
            TreeNode root = new TreeNode(5, null, null);
            TreeNode node1 = new TreeNode(1, null, null);
            TreeNode node2 = new TreeNode(2, null, null);
            TreeNode node3 = new TreeNode(3, null, null);
            TreeNode node4 = new TreeNode(4, null, null);
            TreeNode node6 = new TreeNode(6, null, null);
            TreeNode node7 = new TreeNode(7, null, null);
            TreeNode node8 = new TreeNode(1, null, null);


            root.left = node3;
            root.right = node8;
            node3.left = node1;
            node3.right = node4;
            node1.right = node2;
            node8.left = node7;

            Console.WriteLine(IsBST(root, ref maxSon, ref minSon));
        }
        //public static bool IsBST(Node root)
        //{
        //    if (root == null)
        //        return true;
        //    if (root.lSon.value > root.value)
        //        return false;
        //    if (root.rSon.value < root.value)
        //        return false;


        //    MaxLeftSon = int.MinValue;
        //    bool isLeftBST = IsBST(root.lSon);
        //    if (root.value < MaxLeftSon)
        //        return false;

        //    MinRightSon = int.MaxValue;
        //    bool isRightBST = IsBST(root.rSon);
        //    if (root.value > MinRightSon)
        //        return false;

        //    MaxLeftSon = Math.Max(MaxLeftSon, Math.Max(root.lSon.value, root.rSon.value));
        //    MinRightSon = Math.Min(MinRightSon, Math.Min(root.lSon.value, root.rSon.value));

        //    if (!isLeftBST || !isRightBST)
        //    {
        //        return false;
        //    }


        //    return true;
        //}
    }

}
