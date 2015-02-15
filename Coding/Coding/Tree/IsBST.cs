using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Tree
{

    public class Node
    {
        public Node lSon;
        public Node rSon;
        public int value;
    }
    //          4
    //    2          8
    //1       5
    public class ValidateBST
    {
        public static Node lastParent = null;
        public static int MaxLeftSon = int.MinValue;
        public static int MinRightSon = int.MaxValue;
        public static bool IsBST(Node root)
        {
            if (root == null)
                return true;
            if (root.lSon.value > root.value)
                return false;
            if (root.rSon.value < root.value)
                return false;


            MaxLeftSon = int.MinValue;
            bool isLeftBST = IsBST(root.lSon);
            if (root.value < MaxLeftSon)
                return false;

            MinRightSon = int.MaxValue;
            bool isRightBST = IsBST(root.rSon);
            if (root.value > MinRightSon)
                return false;

            MaxLeftSon = Math.Max(MaxLeftSon, Math.Max(root.lSon.value, root.rSon.value));
            MinRightSon = Math.Min(MinRightSon, Math.Min(root.lSon.value, root.rSon.value));

            if (!isLeftBST || !isRightBST)
            {
                return false;
            }


            return true;
        }
    }

}
