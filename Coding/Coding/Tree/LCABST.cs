using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Tree
{
    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class LCABST
    {
        public TreeNode LowestCommonAncestorBST(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;

            if ((root.val >= p.val && root.val <= q.val)
                || (root.val <= p.val && root.val >= q.val))
            {
                return root;
            }

            if (root.val >= p.val && root.val >= q.val)
            {
                return LowestCommonAncestorBST(root.left, p, q);
            }
            else
            {
                return LowestCommonAncestorBST(root.right, p, q);
            }
        }

        public static  TreeNode LowestCommonAncestorBinaryTree(TreeNode root, TreeNode p, TreeNode q)
        {
            if (Ischild(p.left, q) || Ischild(p.right, q))
                return p;
            if (Ischild(q.left, p) || Ischild(q.right, p))
                return q;
            List<int> preTravel = new List<int>();
            List<int> middleTravel = new List<int>();

            PreTravelTree(root, ref preTravel);
            MiddleTravelTree(root, ref middleTravel);

            int preRoot = -1, preP = -1, preQ = -1, middleRoot = 0, middleP = -1, middleQ = -1;

            for (int i = 0; i    < middleTravel.Count; i++)
            {
                if (middleTravel[i] == p.val) middleP = i;
                if (middleTravel[i] == q.val) middleQ = i;
            }

            middleRoot = 0;
            int target = int.MinValue;

            for (int i = 0; i < preTravel.Count; i++)
            {
                if (preTravel[i] == middleTravel[middleRoot]) preRoot = i;
                if (preTravel[i] == p.val && preP == -1) preP = i;
                if (preTravel[preTravel.Count - 1 - i] == q.val && preQ == -1) preQ = preTravel.Count - 1 - i; 
            }

            Coding.Tree.TreeNode ret = null;
            int leastLevelIndex = 0;

            while (target == int.MinValue && middleRoot < middleTravel.Count)
            {
                //if (preRoot <= preP && preRoot >= preQ || preRoot >= preP && preRoot <= preQ)
                //    target = preTravel[preRoot];
                //else
                {
                    //preRoot = preTravel.IndexOf(middleTravel[middleRoot++]);
                    for (int i = 0; i < preTravel.Count; i++)
                    {
                        if (preTravel[i] == middleTravel[middleRoot])
                        {
                            preRoot = i;
                            if (preRoot < preP && preRoot > preQ || preRoot > preP && preRoot < preQ)
                            {
                                target = preTravel[preRoot];

                                if (middleRoot >= leastLevelIndex)
                                {
                                    leastLevelIndex = middleRoot;
                                    ret = FindNode(root, target);
                                }
                            }

                        }
                    }

                    middleRoot++;
                }
            }

            if(ret != null)
                return ret;
            return null;
        }

        public static bool Ischild(TreeNode root, TreeNode son)
        {
            if (root == null) return false;
            if (root.val == son.val && root.left == son.left && root.right == son.right)
                return true;
            bool ret = Ischild(root.left, son);
            if (ret) return true;
            ret = Ischild(root.right, son);
            if (ret) return true;
            return false;
        }

        public static TreeNode FindNode(TreeNode root, int target)
        {
            if (root == null)
                return null;
            if (root.val == target)
                return root;
            TreeNode ret = FindNode(root.left, target);
            if (ret != null)
                return ret;
            ret = null;
            ret = FindNode(root.right, target);
            if (ret != null)
                return ret;

            return null;
        }

        public static void PreTravelTree(TreeNode root, ref List<int> result)
        {
            if (root == null)
                return;
            PreTravelTree(root.left, ref result);
            result.Add(root.val);
            PreTravelTree(root.right, ref result);
        }

        public static void MiddleTravelTree(TreeNode root, ref List<int> result)
        {
            if (root == null)
                return;
            result.Add(root.val);
            MiddleTravelTree(root.left, ref result);
            MiddleTravelTree(root.right, ref result);
        }

        public static void Test()
        {
            Coding.Tree.TreeNode root = new Coding.Tree.TreeNode(-1);
            Coding.Tree.TreeNode left = new Coding.Tree.TreeNode(2);
            Coding.Tree.TreeNode right = new Coding.Tree.TreeNode(3);
            root.left = left;
            root.right = right;

            //Coding.Tree.TreeNode left1 = new Coding.Tree.TreeNode(-2);
            //Coding.Tree.TreeNode right1 = new Coding.Tree.TreeNode(4);
            ////Coding.Tree.TreeNode right2 = new Coding.Tree.TreeNode(48);
            //left.left = left1;
            //left.right = right1;
            ////right.right = right2;

            //Coding.Tree.TreeNode right3 = new Coding.Tree.TreeNode(8);
            //left1.left = right3;

            //Coding.Tree.TreeNode right4left = new Coding.Tree.TreeNode(-71);
            //Coding.Tree.TreeNode right4right = new Coding.Tree.TreeNode(-22);
            //right3.left = right4left;
            //right3.right = right4right;

            //Coding.Tree.TreeNode right5right = new Coding.Tree.TreeNode(8);
            //right4right.right = right5right;
            LowestCommonAncestorBinaryTree(root, left, right);
        }
    }



}
