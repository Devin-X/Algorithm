using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using Coding.Array;
using Coding.Tree;
namespace Coding
{

public class Solution
{
        public bool IsPowerOfThree(int n)
        {
            int maxP3 = 1162261467;
                if (n > maxP3 || n <= 0 || n > int.MaxValue)
                return false;
            return maxP3 % n == 0;
        }


        public bool CanWinNim(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = 0;
            }

            return !CanWinHelper(n - 1, ref array) || !CanWinHelper(n - 2, ref array) || !CanWinHelper(n - 3, ref array);
        }

        private bool CanWinHelper(int n, ref int[] array)
        {
            if (n <= 0)
                return false;
            if (array[n - 1] != 0)
                return array[n - 1] > 0;
            if (!CanWinHelper(n - 1, ref array) || !CanWinHelper(n - 2, ref array) || !CanWinHelper(n - 3, ref array))
            {
                array[n - 1] = 1;
                return true;
            }

            array[n - 1] = -1;
            return false;
        }


        public bool CanWinNim2(int n)
        {
            bool[] cache = new bool[4];
            if (n < 3) return true;
            for (int i = 0; i < 3; i++)
            {
                cache[i] = true;
            }

            for (int i = 3; i < n; i++)
            {
                if (cache[0] && cache[1] && cache[2])
                {
                    cache[3] = false;
                }
                else {
                    cache[3] = true;
                }

                cache[0] = cache[1];
                cache[1] = cache[2];
                cache[2] = cache[3];
            }

            return cache[3];
        }


        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;

            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;
            InvertTree(root.left);
            InvertTree(root.right);
            return root;
        }



        // Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements. 

        // For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0]. 

        // Note:

        // 1.You must do this in-place without making a copy of the array.
        // 2.Minimize the total number of operations.



        public void MoveZeroes(int[] nums)
        {
            int countOfZeros = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i - countOfZeros] = nums[i];
                if (nums[i] == 0) countOfZeros++;
            }
            for (; countOfZeros > 0; countOfZeros--)
            {
                nums[nums.Length - countOfZeros] = 0;
            }
        }


        // Given two binary trees, write a function to check if they are equal or not. 

        // Two binary trees are considered equal if they are structurally identical and the nodes have the same value. 

        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;
            if (p.val == q.val)
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
            else {
                return false;
            }
        }


        // Given two strings s and t, write a function to determine if t is an anagram of s.

        // For example,
        // s = "anagram", t = "nagaram", return true.
        // s = "rat", t = "car", return false. 

        // Note:
        //  You may assume the string contains only lowercase alphabets.

        // Follow up:
        //  What if the inputs contain unicode characters? How would you adapt your solution to such case?

        public bool IsAnagram(string s, string t)
        {
            int[] index = new int[26];
            for (int i = 0; i < 26; i++) index[i] = 0;
            foreach (char a in s)
            {
                index[a - 'a']++;
            }
            foreach (char c in t)
            {
                index[c - 'a']--;
            }
            foreach (int i in index)
            {
                if (i != 0) return false;
            }
            return true;
        }



        // Related to question Excel Sheet Column Title

        // Given a column title as appear in an Excel sheet, return its corresponding column number.

        // For example:
        //     A -> 1
        //     B -> 2
        //     C -> 3
        //     ...
        //     Z -> 26
        //     AA -> 27
        //     AB -> 28 



        public int TitleToNumber(string s)
        {
            int ret = 0;
            foreach (char c in s)
            {
                ret *= 26;
                ret += (c - 'A' + 1);
            }
            return ret;
        }



        // Given an array of integers, find if the array contains any duplicates. 
        // Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct. 



        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> dict = new HashSet<int>();
            foreach (int i in nums)
            {
                if (!dict.Add(i)) return true;
            }
            return false;
        }



        // Given an array of size n, find the majority element. The majority element is the element that appears more than ⌊ n/2 ⌋ times.

        // You may assume that the array is non-empty and the majority element always exist in the array.

        // Credits:
        // Special thanks to @ts for adding this problem and creating all test cases.


        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int maxCount = 0;
            int num = 0;
            foreach (int i in nums)
            {
                if (map.ContainsKey(i)) map[i]++;
                else map.Add(i, 1);

                if (map[i] > maxCount)
                {
                    maxCount = map[i];
                    num = i;
                }
            }

            return num;
        }


        // Reverse a singly linked list.

        // click to show more hints.


        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public ListNode ReverseList(ListNode head)
        {
            if (head == null) return null;
            ListNode tHead = head;
            ListNode last = null;
            while (tHead.next != null)
            {
                ListNode temp = tHead.next;
                tHead.next = last;
                last = tHead;
                tHead = temp;
            }
            tHead.next = last;
            return tHead;
        }



        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode head;
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val > l2.val)
            {
                head = l2;
                l2 = l2.next;
            }
            else {
                head = l1;
                l1 = l1.next;
            }
            ListNode tP = head;

            while (l1 != null && l2 != null)
            {
                if (l1.val > l2.val)
                {
                    tP.next = l2;
                    l2 = l2.next;
                    tP = tP.next;
                }
                else {
                    tP.next = l1;
                    l1 = l1.next;
                    tP = tP.next;
                }
            }

            if (l2 == null)
            {
                tP.next = l1;
            }
            else {
                tP.next = l2;
            }
            return head;
        }



        // Implement the following operations of a queue using stacks. 
        // • push(x) -- Push element x to the back of queue. 
        // • pop() -- Removes the element from in front of queue. 
        // • peek() -- Get the front element. 
        // • empty() -- Return whether the queue is empty. 
        // Notes:
        // •You must use only standard operations of a stack -- which means only push to top, peek/pop from top, size, and is empty operations are valid.
        // •Depending on your language, stack may not be supported natively. You may simulate a stack by using a list or deque (double-ended queue), as long as you use only standard operations of a stack.
        // •You may assume that all operations are valid (for example, no pop or peek operations will be called on an empty queue).



        // You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

        // Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.

        // Credits:
        // Special thanks to @ifanchu for adding this problem and creating all test cases. Also thanks to @ts for adding additional test cases.




        public int Rob(int[] nums)
        {
            int[] ret = new int[nums.Length];
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            if (nums.Length == 2) return Math.Max(nums[0], nums[1]);
            ret[0] = nums[0];
            ret[1] = Math.Max(nums[0], nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                ret[i] = Math.Max(ret[i - 2] + nums[i], ret[i - 1]);
            }
            return ret[nums.Length - 1];
        }




        // Given a binary tree, determine if it is height-balanced. 

        // For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1. 





        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */
        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            bool isB = true;
            FromRoot(root, 0, ref isB);
            return isB;
        }

        private int FromRoot(TreeNode root, int dep, ref bool isBalanced)
        {
            if (root == null) return dep - 1;
            if (!isBalanced) return 0;

            int left = FromRoot(root.left, dep + 1, ref isBalanced);
            int right = FromRoot(root.right, dep + 1, ref isBalanced);

            if (isBalanced && (left - right > 1 || left - right < -1)) isBalanced = false;
            return Math.Max(left, right);
        }



        // Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

        // For example, this binary tree is symmetric: 
        //     1
        //    / \
        //   2   2
        //  / \ / \
        // 3  4 4  3



        // But the following is not:

        //     1
        //    / \
        //   2   2
        //    \   \
        //    3    3



        // Note:
        //  Bonus points if you could solve it both recursively and iteratively. 

        // confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.



        // Subscribe to see which companies asked this question
        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsMirror(root.left, root.right);

        }

        private bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null && right != null) return false;
            if (left != null && right == null) return false;
            if (left.val == right.val)
            {
                return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
            }
            return false;
        }

        //Given a binary tree, return the bottom-up level order traversal of its nodes' values. (ie, from left to right, level by level from leaf to root).

        // For example:
        //  Given binary tree {3,9,20,#,#,15,7},

        //     3
        //    / \
        //   9  20
        //     /  \
        //    15   7



        // return its bottom-up level order traversal as:

        // [
        //   [15,7],
        //   [9,20],
        //   [3]
        // ]



        // confused what "{1,#,2,3}" means? > read more on how binary tree is serialized on OJ.



        // Subscribe to see which companies asked this question


        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> ret = new List<IList<int>>(0);

            LevelOrderHelper(root, 0, ret);
            IList<IList<int>> finalRet = new List<IList<int>>(0);
            for (int i = ret.Count() - 1; i >= 0; i--)
            {
                finalRet.Add(ret[i]);
            }

            return finalRet;
        }

        private void LevelOrderHelper(TreeNode root, int dep, IList<IList<int>> cache)
        {
            if (root == null) return;
            if (cache.Count < dep + 1) cache.Add(new List<int>());
            cache[dep].Add(root.val);
            LevelOrderHelper(root.left, dep + 1, cache);
            LevelOrderHelper(root.right, dep + 1, cache);
            return;
        }


        // Given a sorted linked list, delete all duplicates such that each element appear only once. 

        // For example,
        //  Given 1->1->2, return 1->2.
        //  Given 1->1->2->3->3, return 1->2->3. 




        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;

            ListNode t = head;
            while (t.next != null)
            {
                if (t.val == t.next.val) t.next = t.next.next;
                else t = t.next;
            }

            return head;
        }


        // Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).

        // For example, the 32-bit integer ’11' has binary representation 00000000000000000000000000001011, so the function should return 3.

        public int HammingWeight(uint n)
        {
            int ret = 0;
            uint one = 1;
            while (n > 0)
            {
                if ((n & one) == 1) ret++;
                n = n >> 1;
            }
            return ret;
        }



        // Given a singly linked list, group all odd nodes together followed by the even nodes. Please note here we are talking about the node number and not the value in the nodes.

        // You should try to do it in place. The program should run in O(1) space complexity and O(nodes) time complexity.



        // Example:
        //  Given 1->2->3->4->5->NULL,
        //  return 1->3->5->2->4->NULL. 

        // Note:
        //  The relative order inside both the even and odd groups should remain as it was in the input. 
        //  The first node is considered odd, the second node even and so on ... 

        // Credits:
        // Special thanks to @DjangoUnchained for adding this problem and creating all test cases.


        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            if (head.next.next == null) return head;
            ListNode oddH = head;
            ListNode evenH = head.next;
            ListNode evenHOri = head.next;
            ListNode temp = oddH;
            int i = 0;
            while (oddH != null && evenH != null)
            {
                if (i % 2 == 0)
                {
                    oddH.next = evenH.next;
                    temp = oddH;
                    oddH = oddH.next;

                }
                else {
                    evenH.next = oddH.next;
                    evenH = evenH.next;
                }
                i++;
            }

            if (oddH == null) temp.next = evenHOri;
            if (evenH == null) oddH.next = evenHOri;
            return head;
        }



        // You are climbing a stair case. It takes n steps to reach to the top.

        // Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top? 

        public int ClimbStairs(int n)
        {
            if (n < 1) return 0;
            if (n == 1) return 1;
            if (n == 2) return 2;
            int[] ret = new int[n];
            ret[0] = 1;
            ret[1] = 2;
            for (int i = 2; i < n; i++)
            {
                ret[i] = ret[i - 2] + ret[i - 1];
            }
            return ret[n - 1];
        }

        // Write a program to check whether a given number is an ugly number. 

        // Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. For example, 6, 8 are ugly while 14 is not ugly since it includes another prime factor 7. 

        // Note that 1 is typically treated as an ugly number. 

        public bool IsUgly(int num)
        {
            if (num <= 0) return false;
            if (num == 1) return true;
            if (num % 2 == 0) return IsUgly(num / 2);
            if (num % 3 == 0) return IsUgly(num / 3);
            if (num % 5 == 0) return IsUgly(num / 5);
            if (num % 6 == 0 || num % 10 == 0 || num % 15 == 0) return true;
            return false;
        }

        // Given an array and a value, remove all instances of that value in place and return the new length. 

        // Do not allocate extra space for another array, you must do this in place with constant memory.

        // The order of elements can be changed. It doesn't matter what you leave beyond the new length.

        // Example:
        //  Given input array nums = [3,2,2,3], val = 3 

        // Your function should return length = 2, with the first two elements of nums being 2.


        public int RemoveElement(int[] nums, int val)
        {
            int cntOfV = 0;
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                nums[i - cntOfV] = nums[i];
                if (nums[i] == val) cntOfV++;
            }

            return n - cntOfV;
        }



        // Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

        // Do not allocate extra space for another array, you must do this in place with constant memory. 

        // For example,
        //  Given input array nums = [1,1,2], 

        // Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively. It doesn't matter what you leave beyond the new length

        public int RemoveDuplicates(int[] nums)
        {

            int cntOfDup = 0;
            int n = nums.Length;
            if (n == 1 || n == 0) return n;

            for (int i = 1; i < n; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    cntOfDup++;
                }
                else {
                    nums[i - cntOfDup] = nums[i];
                }
            }

            return n - cntOfDup;
        }



        // Given a non-negative number represented as an array of digits, plus one to the number.

        // The digits are stored such that the most significant digit is at the head of the list.

        public int[] PlusOne(int[] digits)
        {
            int n = digits.Length;
            int[] ret = new int[digits.Length];
            bool isUp = true;
            for (int i = n - 1; i >= 0; i--)
            {
                if (isUp)
                {
                    digits[i] = digits[i] + 1;
                    i++;
                    isUp = false;
                }
                else if (digits[i] >= 10)
                {
                    ret[i] = digits[i] % 10;
                    isUp = true;
                }
                else {
                    ret[i] = digits[i];
                }
            }

            if (isUp)
            {
                int[] newRet = new int[n + 1];
                for (int i = ret.Length - 1; i > 0; i--) newRet[i] = ret[i - 1];
                newRet[0] = 1;
                return newRet;
            }

            return ret;
        }

        // Given numRows, generate the first numRows of Pascal's triangle.

        // For example, given numRows = 5,
        //  Return 
        // [
        //      [1],
        //     [1,1],
        //    [1,2,1],
        //   [1,3,3,1],
        //  [1,4,6,4,1]
        // ]


        public IList<IList<int>> Generate(int numRows)
        {
            if (numRows < 1) return new List<IList<int>>();
            IList<IList<int>> ret = new List<IList<int>>();
            ret.Add(new List<int>());
            ret[0].Add(1);
            for (int i = 1; i < numRows; i++)
            {
                ret.Add(new List<int>());
                ret[i].Add(1);
                for (int j = 1; j < i; j++)
                {
                    ret[i].Add(ret[i - 1][j - 1] + ret[i - 1][j]);
                }
                ret[i].Add(1);
            }

            return ret;
        }


        // Given an array of integers, every element appears twice except for one. Find that single one.

        // Note:
        //  Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

        public int SingleNumber(int[] nums)
        {
            int a = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                a ^= nums[i];
            }
            return a;
        }



        // Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice. Find the two elements that appear only once. 

        // For example: 

        // Given nums = [1, 2, 1, 3, 2, 5], return [3, 5]. 

        // Note:

        // 1.The order of the result is not important. So in the above example, [5, 3] is also correct.
        // 2.Your algorithm should run in linear runtime complexity. Could you implement it using only constant space complexity?

        public int[] SingleNumber2(int[] nums)
        {

            int aXb = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                aXb ^= nums[i];
            }

            int ub = aXb & (~aXb + 1);
            int[] ret = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] & ub) > 0) ret[0] ^= nums[i];
                else ret[1] ^= nums[i];
            }

            return ret;
        }

        public IList<int> GetRow(int rowIndex)
        {
            IList<int> ret = new List<int>();
            IList<int> temp = new List<int>();
            ret.Add(1);
            for (int i = 1; i < rowIndex + 1; i++)
            {
                temp.Clear();
                temp.Add(1);
                for (int j = 1; j < i; j++)
                {
                    temp.Add(ret[j - 1] + ret[j]);
                }
                temp.Add(1);

                IList<int> tt = ret;
                ret = temp;
                temp = tt;
            }

            return ret;
        }



        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            LevelOrderHelper(root, 0, ref ret);
            return ret;
        }

        private void LevelOrderHelper(TreeNode root, int level, ref IList<IList<int>> ret)
        {
            if (root == null) return;
            if (ret.Count < level + 1) ret.Add(new List<int>());
            ret[level].Add(root.val);
            LevelOrderHelper(root.left, level + 1, ref ret);
            LevelOrderHelper(root.right, level + 1, ref ret);
            return;
        }




        // Given an array of n integers where n > 1, nums, return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

        // Solve it without division and in O(n).

        // For example, given [1,2,3,4], return [24,12,8,6]. 



        public int[] ProductExceptSelf(int[] nums)
        {

            int n = nums.Length;
            if (n <= 1) return nums;
            if (n == 2) return new int[] { nums[1], nums[0] };

            int[] left = new int[n];
            left[0] = 1;
            int l = nums[0]; int r = nums[n - 1];

            for (int i = 1; i < n; i++)
            {
                left[i] = l;
                l *= nums[i];
            }

            for (int i = n - 2; i > 0; i--)
            {
                left[i] *= r;
                r *= nums[i];
            }

            left[0] = r;
            return left;
        }




        // Given a string array words, find the maximum value of length(word[i]) * length(word[j]) where the two words do not share common letters. You may assume that each word will contain only lower case letters. If no such two words exist, return 0. 

        // Example 1:


        // Given ["abcw", "baz", "foo", "bar", "xtfn", "abcdef"]
        //  Return 16
        //  The two words can be "abcw", "xtfn". 

        // Example 2:


        // Given ["a", "ab", "abc", "d", "cd", "bcd", "abcd"]
        //  Return 4
        //  The two words can be "ab", "cd". 

        // Example 3:


        // Given ["a", "aa", "aaa", "aaaa"]
        //  Return 0
        //  No such pair of words. 





        public int MaxProduct(string[] words)
        {
            int[] bits = new int[words.Length];
            int[] bitMap = new int[26];

            for (int i = 0; i < 26; i++)
            {
                bitMap[i] = 1 << 26 - i;
            }

            for (int w = 0; w < words.Length; w++)
            {
                bits[w] = 0;
                for (int i = 0; i < 26; i++)
                {
                    if (words[w].IndexOf((char)('a' + i)) >= 0)
                    {
                        bits[w] = bits[w] | bitMap[i];
                    }
                }
            }

            int max = 0;
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words.Length; j++)
                {
                    if ((i != j))
                    {
                        if ((bits[i] & bits[j]) == 0)
                        {
                            max = Math.Max(max, words[i].Length * words[j].Length);
                        }
                    }
                }
            }

            return max;
        }



        // Determine whether an integer is a palindrome. Do this without extra space.

        public bool IsPalindrome(int x)
        {
            int t = x;
            int k = 0;
            while (t > 0)
            {
                k = k * 10 + t % 10;
                t = t / 10;
            }

            return k == x;
        }



        // Given a binary tree and a sum, determine if the tree has a root-to-leaf path such that adding up all the values along the path equals the given sum. 
        // For example:
        //  Given the below binary tree and sum = 22,               5
        //              / \
        //             4   8
        //            /   / \
        //           11  13  4
        //          /  \      \
        //         7    2      1


        // return true, as there exist a root-to-leaf path 5->4->11->2 which sum is 22.


        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;
            int ret = 0;
            return SumHelper(root, sum, ref ret);
        }

        private bool SumHelper(TreeNode root, int sum, ref int ret)
        {
            ret += root.val;
            if (root.left == null && root.right == null && sum == ret) return true;


            if (root.left != null)
            {
                if (SumHelper(root.left, sum, ref ret)) return true;
            }
            if (root.right != null)
            {
                if (SumHelper(root.right, sum, ref ret)) return true;
            }

            ret -= root.val;
            return false;
        }



        public int MinDepth(TreeNode root)
        {
            int level = 1;
            int min = int.MaxValue;
            if (root == null) return 0;
            MDHelper(root, ref level, ref min);

            return min;
        }

        private void MDHelper(TreeNode root, ref int level, ref int min)
        {
            if (root.left == null && root.right == null)
            {
                min = Math.Min(min, level);
                return;
            }

            level++;
            if (root.left != null) MDHelper(root.left, ref level, ref min);
            if (root.right != null) MDHelper(root.right, ref level, ref min);

            level--;
            return;
        }



        public int MissingNumber(int[] nums)
        {

            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                if (i != nums[i])
                {
                    int temp = nums[i];
                    if (nums[i] == n)
                    {
                        continue;
                    }
                    else {
                        nums[i] = nums[nums[i]];
                        nums[temp] = temp;
                    }
                    i--;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (i != nums[i]) return i;
            }

            return n;
        }




        public int[] CountBits(int num)
        {

            int[] ret = new int[num + 1];
            if (num == 0)
            {
                ret[0] = 0;
                return ret;
            }

            int level = 1;
            for (; level <= num;)
            {
                level = level * 2;
                int j = 0;
                for (int i = level / 2; i < level && i <= num; i++, j++)
                {
                    ret[i] = 1 + ret[j];
                }

            }

            return ret;
        }




        //Given an array of integers, every element appears three times except for one. Find that single one. 

        // Note:
        //  Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory? 


        public int SingleNumber3(int[] nums)
        {
            int mask = 1 << 30;
            int ret = 0;
            int count;
            for (int i = 0; i < 31; i++)
            {
                count = 0;
                int k = mask >> i;
                for (int j = 0; j < nums.Length; j++)
                {
                    if ((nums[j] & k) > 0)
                    {
                        count++;
                    }
                }

                if (count % 3 != 0) ret |= k;
            }

            mask = 1 << 31;
            count = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if ((nums[i] & mask) != 0) count++;
            }

            if (count % 3 != 0) ret |= mask;

            return ret;
        }

        // Given n, how many structurally unique BST's (binary search trees) that store values 1...n?

        // For example,
        //  Given n = 3, there are a total of 5 unique BST's. 
        //    1         3     3      2      1
        //     \       /     /      / \      \
        //      3     2     1      1   3      2
        //     /     /       \                 \
        //    2     1         2                 3

        public int NumTrees(int n)
        {

            if (n == 0) return 0;
            if (n == 1) return 1;
            int[] cache = new int[n + 1];
            cache[0] = 1;
            cache[1] = 1;
            cache[2] = 2;
            for (int i = 3; i <= n; i++)
            {
                cache[i] = 0;
                for (int j = 0; j < i; j++)
                {
                    cache[i] += cache[j] * cache[i - j - 1];
                }
            }

            return cache[n];
        }


        // Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.

        // You may assume no duplicates in the array.

        // Here are few examples.
        // [1,3,5,6], 5 → 2
        // [1,3,5,6], 2 → 1
        // [1,3,5,6], 7 → 4
        // [1,3,5,6], 0 → 0 



        public int SearchInsert(int[] nums, int target)
        {
            int index = QuickFind(nums, 0, nums.Length - 1, target);
            return index;
        }

        private int QuickFind(int[] nums, int start, int end, int target)
        {
            if (start >= end)
            {
                if (nums[start] < target) return start + 1;
                else if (nums[start] >= target) return start;
            }
            int middle = start + (end - start) / 2;
            if (nums[middle] == target) return middle;
            //if(nums[middle] > target && middle == 0) return 0;
            //if(nums[middle] < target && middle == nums.Length-1) return nums.Length;
            //if(nums[middle] < target && nums[middle] > target) return middle+1;
            if (nums[middle] < target) return QuickFind(nums, middle + 1, end, target);
            else return QuickFind(nums, start, middle - 1, target);
        }



        // Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

        public TreeNode SortedArrayToBST(int[] nums)
        {

            TreeNode root = GetRoot(nums, 0, nums.Length - 1);
            return root;
        }

        private TreeNode GetRoot(int[] nums, int start, int end)
        {
            if (start > end) return null;
            int middle = start + (end - start) / 2;
            TreeNode root = new TreeNode(nums[middle]);
            root.left = GetRoot(nums, start, middle - 1);
            root.right = GetRoot(nums, middle + 1, end);
            return root;

        }




        // Given a linked list, determine if it has a cycle in it. 

        // Follow up:
        //  Can you solve it without using extra space? 


        public bool HasCycle(ListNode head)
        {
            ListNode p = head;
            ListNode pp = head;

            while (p != null && pp != null)
            {
                p = p.next;
                if (pp.next == null) return false;
                pp = pp.next.next;

                if (p == pp) return true;
            }

            return false;
        }



        public int KthSmallest(TreeNode root, int k)
        {

            bool isB = false;
            int ret = 0;
            KHelper(root, ref k, ref isB, ref ret);
            return ret;
        }

        private void KHelper(TreeNode root, ref int k, ref bool isBottom, ref int ret)
        {

            if (!isBottom && root == null) isBottom = true;
            if (root == null) return;

            KHelper(root.left, ref k, ref isBottom, ref ret);
            if (k == 0) return;


            k--;
            if (k == 0 && isBottom)
            {
                ret = root.val;
                return;
            }

            KHelper(root.right, ref k, ref isBottom, ref ret);
            if (k == 0) return;

        }




        public IList<string> GenerateParenthesis(int n)
        {

            List<string> ret = new List<string>();
            char[] str = new char[n + n]; ;
            int open = 0;
            int close = 0;

            int i = 0;

            helper(ret, str, i, open, close, n);

            return ret;

        }

        private void helper(List<string> ret, char[] str, int i, int open, int close, int n)
        {
            if (open < close || open > n || close > n) return;
            if (open == n && close == n)
            {
                ret.Add(new string(str));
                return;
            }

            if (open < n)
            {
                str[i++] = '(';
                helper(ret, str, i, open + 1, close, n);
                i--;
            }

            str[i++] = ')';
            helper(ret, str, i, open, close + 1, n);

        }


        // Suppose a sorted array is rotated at some pivot unknown to you beforehand.

        // (i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

        // Find the minimum element.

        // You may assume no duplicate exists in the array.


        public int FindMin(int[] nums)
        {
            if (nums == null) return 0;
            return FHelper(nums, 0, nums.Length - 1);
        }

        private int FHelper(int[] nums, int start, int end)
        {
            if (start + 1 == end)
            {
                if (nums[end] < nums[start]) return nums[end];
                return nums[start];
            }

            if (start >= end)
            {
                if (nums[start] > nums[end]) return nums[end];
                else return nums[start];
            }

            int middle = start + (end - start) / 2;

            if (nums[middle] > nums[start] && nums[middle] > nums[end])
            {
                return FHelper(nums, middle, end);
            }

            return FHelper(nums, start, middle);

        }



        // The gray code is a binary numeral system where two successive values differ in only one bit.

        // Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code. A gray code sequence must begin with 0.

        // For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:
        // 00 - 0
        // 01 - 1
        // 11 - 3
        // 10 - 2


        // Note:
        //  For a given n, a gray code sequence is not uniquely defined. 

        // For example, [0,2,3,1] is also a valid gray code sequence according to the above definition.

        // For now, the judge is able to judge based on one instance of gray code sequence. Sorry about that.


        public IList<int> GrayCode(int n)
        {
            HashSet<int> dic = new HashSet<int>();
            Backtrack(dic, n, (int)Math.Pow(2, n), 0);
            return dic.ToList<int>();
        }

        private void Backtrack(HashSet<int> dic, int n, int sum, int last)
        {
            if (dic.Count == sum) return;

            dic.Add(last);
            for (int i = 0; i < n; i++)
            {
                int nVal = last ^ 1 << i;
                if (!dic.Contains(nVal))
                {
                    Backtrack(dic, n, sum, nVal);
                }
            }

            return;
        }




        // Given a collection of distinct numbers, return all possible permutations. 

        // For example,
        // [1,2,3] have the following permutations:
        // [1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1]. 


        public IList<IList<int>> Permute(int[] nums)
        {

            IList<IList<int>> ret = new List<IList<int>>();

            Backtrack(ret, nums, 0);
            return ret;

        }

        private void Backtrack(IList<IList<int>> ret, int[] nums, int step)
        {
            if (step == nums.Length)
            {
                ret.Add(nums.ToList<int>());
                return;
            }

            for (int i = step; i < nums.Length; i++)
            {
                int temp = nums[step];
                nums[step] = nums[i];
                nums[i] = temp;
                Backtrack(ret, nums, step + 1);
                temp = nums[step];
                nums[step] = nums[i];
                nums[i] = temp;
            }

            return;
        }




        // Given a collection of numbers that might contain duplicates, return all possible unique permutations. 

        // For example,
        // [1,1,2] have the following unique permutations:
        // [1,1,2], [1,2,1], and [2,1,1]. 



        public IList<IList<int>> PermuteUnique(int[] nums)
        {


            IList<IList<int>> ret = new List<IList<int>>();

            BacktrackPermutation(ret, nums, 0);
            return ret;
        }

        private void BacktrackPermutation(IList<IList<int>> ret, int[] nums, int step)
        {
            if (step == nums.Length)
            {
                ret.Add(nums.ToList<int>());
                return;
            }

            HashSet<int> cache = new HashSet<int>();
            for (int i = step; i < nums.Length; i++)
            {
                if (!cache.Add(nums[i])) continue;
                int temp = nums[step];
                nums[step] = nums[i];
                nums[i] = temp;
                Backtrack(ret, nums, step + 1);
                temp = nums[step];
                nums[step] = nums[i];
                nums[i] = temp;
            }

            return;
        }


        // Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

        // If such arrangement is not possible, it must rearrange it as the lowest possible order(ie, sorted in ascending order). 

        // The replacement must be in-place, do not allocate extra memory.

        // Here are some examples.Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
        // 1,2,3 → 1,3,2
        // 3,2,1 → 1,2,3
        // 1,1,5 → 1,5,1


        private List<int> _Min = new List<int>();

        public void NextPermutation(int[] nums)
        {

            int n = nums.Length;

            for (int end = n - 1; end >= 0; end--)
            {
                for (int i = n - 1; i >= end; i--)
                {
                    if (nums[i] > nums[end])
                    {
                        int temp = nums[i];
                        nums[i] = nums[end];
                        nums[end] = temp;

                        for (int f = end + 1; f < n; f++)
                        {
                            _Min.Add(nums[f]);
                        }

                        _Min.Sort();

                        //NextPH(nums, i+1, i+1,  min);
                        for (int f = 0; f + end + 1 < n; f++)
                        {
                            nums[f + end + 1] = _Min[f];
                        }
                        return;
                    }
                }
            }
            
            System.Array.Sort(nums);
            return;
        }



        // Given a set of candidate numbers(C) and a target number(T), find all unique combinations in C where the candidate numbers sums to T.

        // The same repeated number may be chosen from C unlimited number of times. 


        // Note:

        // •All numbers (including target) will be positive integers.
        // •Elements in a combination (a1, a2, … , ak) must be in non-descending order. (ie, a1 ≤ a2 ≤ … ≤ ak).
        // •The solution set must not contain duplicate combinations.


        // For example, given candidate set 2,3,6,7 and target 7,
        //  A solution set is: 
        // [7]
        // [2, 2, 3]


        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {

            IList<IList<int>> fret = new List<IList<int>>();
            List<int> ret = new List<int>();
            System.Array.Sort(candidates);
            BT(candidates, ret, fret, target, 0);

            return fret;
        }

        private void BT(int[] can, List<int> ret, IList<IList<int>> fret, int target, int step)
        {

            if (target == 0)
            {
                List<int> t = ret.ToList<int>();
                fret.Add(t);
                return;
            }

            if (target < 0 || step >= can.Length) return;

            int i = target / can[step];
            for (int j = 0; j < i; j++) ret.Add(can[step]);
            for (; i > 0; i--)
            {

                BT(can, ret, fret, target - i * can[step], step + 1);
                ret.RemoveAt(ret.Count - 1);
            }

            BT(can, ret, fret, target, step + 1);

            return;
        }




        // ind all possible combinations of k numbers that add up to a number n, given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.

        // Ensure that numbers within the set are sorted in ascending order.



        // Example 1:

        // Input: k = 3, n = 7

        // Output: 

        // [[1,2,4]]




        // Example 2:

        // Input: k = 3, n = 9

        // Output: 

        // [[1,2,6], [1,3,5], [2,3,4]]

        public IList<IList<int>> CombinationSum3(int k, int n)
        {

            IList<IList<int>> fret = new List<IList<int>>();
            List<int> ret = new List<int>();
            int[] can = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            BT(can, ret, fret, n, k, 0);

            return fret;
        }

        private void BT(int[] can, List<int> ret, IList<IList<int>> fret, int target, int count, int step)
        {

            if (target == 0 && count == 0)
            {
                List<int> t = ret.ToList<int>();
                fret.Add(t);
                return;
            }

            if (target < 0 || step >= can.Length || count < 0) return;

            count -= 1;
            ret.Add(can[step]);

            BT(can, ret, fret, target - can[step], count, step + 1);
            ret.RemoveAt(ret.Count - 1);
            count++;


            BT(can, ret, fret, target, count, step + 1);

            return;
        }




        // Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

        // Note: You can only move either down or right at any point in time.


        public int MinPathSum(int[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    int left = j > 0 ? grid[i, j - 1] + grid[i, j] : grid[i, j];
                    int top = i > 0 ? grid[i - 1, j] + grid[i, j] : grid[i, j];

                    if (j == 0) grid[i, j] = top;
                    else if (i == 0) grid[i, j] = left;
                    else grid[i, j] = Math.Min(left, top);
                }
            }

            return grid[grid.GetLength(0) - 1, grid.GetLength(1) - 1];
        }


        // Given a linked list, swap every two adjacent nodes and return its head.

        // For example,
        //  Given 1->2->3->4, you should return the list as 2->1->4->3. 

        // Your algorithm should use only constant space.You may not modify the values in the list, only nodes itself can be changed. 

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null) return head;


            ListNode hN = head.next;
            ListNode t = head.next.next;
            head.next = head.next.next;
            hN.next = head;
            ListNode nH = hN;
            ListNode pH = hN.next;

            while (t != null && t.next != null)
            {
                hN = t.next;
                t.next = t.next.next;
                pH.next = hN;
                hN.next = t;
                pH = t;
                t = t.next;
            }

            return nH;
        }



        public Vertex CloneGraph(Vertex a)
        {
            Queue<Vertex> q = new Queue<Vertex>();
            q.Enqueue(a);

            Vertex a1 = new Vertex(a.value);

            Dictionary<int, Vertex> map = new Dictionary<int, Vertex>();
            map.Add(a1.value, a1);

            //{a}, {aV, a1};
            //{b}, {[av, a1], [bv, b1]}
            //{c, d}, {[av, a1], [bv, b1], [cv, c1]. [dv. d1]}
            //{d}, {[av, a1], [bv, b1], [cv, c1], [dv. d1]}
            //{}, {[av, a1], [bv, b1], [cv, c1], [dv. d1]}
            while (q.Any())
            {
                Vertex current = q.Dequeue();
                Vertex cur2;
                map.TryGetValue(current.value, out cur2);

                foreach (Vertex nb in current.neighbours)
                { 
                    if (!map.ContainsKey(nb.value))
                    {
                        Vertex clone = new Vertex(nb.value);
                        cur2.neighbours.Add(clone);
                        q.Enqueue(nb);
                        map.Add(clone.value, clone);
                    }
                    else {
                        Vertex clone;
                        if (map.TryGetValue(nb.value, out clone))
                        {
                            cur2.neighbours.Add(clone);
                        }
                    }
                }
            }

            return a1;
        }



        // Implement an iterator over a binary search tree(BST). Your iterator will be initialized with the root node of a BST.

        // Calling next() will return the next smallest number in the BST.

        // Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree


        /**
         * Definition for binary tree
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */

        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!This is a very bad solution for the problem.
        /**
         * Your BSTIterator will be called like this:
         * BSTIterator i = new BSTIterator(root);
         * while (i.HasNext()) v[f()] = i.Next();
         */

        public bool SearchMatrix(int[,] matrix, int target)
        {

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int j = BinarySearch(matrix, false, target, 0, m - 1, 0);
            int i = 0;

            if (j < 0) return false;

            if (j >= m) j = m - 1;
            if (matrix[0, j] == target) return true;

            i = BinarySearch(matrix, true, target, 0, n - 1, j);

            if (i > 0 && i < n && matrix[i, j] == target) return true;


            i = BinarySearch(matrix, true, target, 0, n - 1, 0);

            if (i < 0) return false;
            if (i >= n) i = n - 1;

            if (matrix[i, 0] == target) return true;

            j = BinarySearch(matrix, false, target, 0, m - 1, i);

            if (j < m && matrix[i, j] == target) return true;

            while (--i > 0)
            {
                j = BinarySearch(matrix, false, target, 0, m - 1, i);
                if (j < m && matrix[i, j] == target) return true;
            }

            return false;

        }

        private int BinarySearch(int[,] m, bool v, int target, int start, int end, int i)
        {

            if (start + 1 == end)
            {
                if (v)
                {
                    if (m[start, i] < target && target < m[end, i]) return start;
                    if (m[start, i] > target) return start - 1 > 0 ? start - 1 : 0;
                    if (m[end, i] < target) return end;
                }
                else
                {
                    if (m[i, start] < target && target < m[i, end]) return start;
                    if (m[i, start] > target) return start - 1 > 0 ? start - 1 : 0;
                    if (m[i, end] < target) return end;
                }
            }

            if (start == end) return start;

            int middle = start + (end - start) / 2;

            if (v)
            {
                if (m[middle, i] < target) return BinarySearch(m, v, target, middle + 1, end, i);
                else if (m[middle, i] > target) return BinarySearch(m, v, target, start, middle - 1, i);
                return middle;
            }
            else {
                if (m[i, middle] < target) return BinarySearch(m, v, target, middle + 1, end, i);
                else if (m[i, middle] > target) return BinarySearch(m, v, target, start, middle - 1, i);
                return middle;
            }
        }


        public bool SearchMatrix2(int[,] matrix, int target)
        {

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int i = 0;
            for (; i < m; i++)
            {
                if (matrix[0, i] > target) break;
            }

            if (i == 0) return false;

            while (--i >= 0)
            {
                int j = BinarySearch(matrix, target, 0, n - 1, i);
                if (j < n && j >= 0 && matrix[j, i] == target) return true;
            }

            return false;
        }

        private int BinarySearch(int[,] m, int target, int start, int end, int i)
        {

            if (start > end) return start - 1;

            int middle = start + (end - start) / 2;

            if (m[middle, i] < target) return BinarySearch(m, target, middle + 1, end, i);
            else if (m[middle, i] > target) return BinarySearch(m, target, start, middle - 1, i);
            return middle;

        }


        // Given an integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

        // For example,
        //  Given n = 3,
        // You should return the following matrix: [
        //  [ 1, 2, 3 ],
        //  [ 8, 9, 4 ],
        //  [ 7, 6, 5 ]
        // ]



        public int[,] GenerateMatrix(int n)
        {

            int[,] ret = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    ret[i, j] = 0;
                }
            }

            int sq = n * n;
            bool v = false;
            bool r = false;
            int ii = 0;
            int jj = 0;
            for (int i = 0; i < sq;)
            {
                if (!v)
                {
                    if (!r)
                    {
                        while (jj < n && ret[ii, jj] == 0)
                        {
                            ret[ii, jj++] = i + 1;
                            i++;
                        }

                        jj = jj - 1;
                        ii++;
                        v = !v;
                        continue;
                    }
                    if (r)
                    {
                        while (jj > -1 && ret[ii, jj] == 0)
                        {
                            ret[ii, jj--] = i + 1;
                            i++;
                        }

                        jj = jj + 1;
                        ii--;
                        v = !v;
                        continue;
                    }

                }
                else {
                    if (!r)
                    {
                        while (ii < n && ret[ii, jj] == 0)
                        {
                            ret[ii++, jj] = i + 1;
                            i++;
                        }
                        ii = ii - 1;
                        jj--;
                        r = !r;
                        v = !v;
                        continue;
                    }
                    if (r)
                    {
                        while (ii > -1 && ret[ii, jj] == 0)
                        {
                            ret[ii--, jj] = i + 1;
                            i++;
                        }

                        ii = ii + 1;
                        jj++;
                        r = !r;
                        v = !v;
                        continue;
                    }
                }

                if (i == sq - 1) break;
            }

            return ret;
        }


        // You are given an n x n 2D matrix representing an image.

        // Rotate the image by 90 degrees (clockwise).

        // Follow up:
        //  Could you do this in-place?

        public void Rotate(int[,] matrix)
        {

            int n = matrix.GetLength(0);

            for (int i = 0; i < (n + 1) / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[n - j - 1, i];
                    matrix[n - j - 1, i] = matrix[n - 1 - i, n - 1 - j];
                    matrix[n - 1 - i, n - 1 - j] = matrix[j, n - 1 - i];
                    matrix[j, n - 1 - i] = temp;
                }
            }

            return;
        }



        // Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.

        // For example,
        //  If n = 4 and k = 2, a solution is: 
        // [
        //   [2,4],
        //   [3,4],
        //   [2,3],
        //   [1,2],
        //   [1,3],
        //   [1,4],
        // ]

        public IList<IList<int>> Combine(int n, int k)
        {
            if (k > n) return null;

            IList<IList<int>> ret = new List<IList<int>>();
            IList<IList<int>> final = new List<IList<int>>();

            List<int> t = new List<int>();
            ret.Add(t);

            for (int i = 1; i <= n; i++)
            {
                int len = ret.Count;
                for (int j = 0; j < len; j++)
                {
                    t = ret[j].ToList<int>();
                    t.Add(i);

                    if (t.Count == k)
                    {
                        final.Add(t);
                    }
                    else {
                        ret.Add(t);
                    }
                }
            }
            return final;
        }




        // Given a string of numbers and operators, return all possible results from computing all the different possible ways to group numbers and operators.The valid operators are +, - and*.

        // Example 1 
        // Input: "2-1-1".
        // ((2-1)-1) = 0
        // (2-(1-1)) = 2
        // Output: [0, 2]

        // Example 2 
        // Input: "2*3-4*5"
        // (2*(3-(4*5))) = -34
        // ((2*3)-(4*5)) = -14
        // ((2*(3-4))*5) = -10
        // (2*((3-4)*5)) = -10
        // (((2*3)-4)*5) = 10
        // Output: [-34, -14, -10, -10, 10]


        public IList<int> DiffWaysToCompute(string input)
        {
            if (input == null) return null;
            List<int> nums = new List<int>();
            List<char> op = new List<char>();
            Parse(input, nums, op);

            List<int>[,] cache = new List<int>[nums.Count, nums.Count];
            return Dp(nums, op, 0, nums.Count - 1, cache);
        }


        private void Parse(string input, List<int> nums, List<char> op)
        {

            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if (c == '-' || c == '+' || c == '*')
                {
                    op.Add(c);
                    nums.Add(int.Parse(sb.ToString()));
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }

            nums.Add(int.Parse(sb.ToString()));
            return;
        }

        private List<int> Dp(List<int> nums, List<char> op, int start, int end, List<int>[,] cache)
        {
            if (cache[start, end] != null) return cache[start, end];
            List<int> cur = new List<int>();
            if (start == end)
            {
                cur.Add(nums[start]);
                cache[start, end] = cur;
                return cache[start, end];
            }
            else {
                for (int i = start; i < end; i++)
                {
                    List<int> left = Dp(nums, op, start, i, cache);
                    List<int> right = Dp(nums, op, i + 1, end, cache);

                    foreach (int l in left)
                    {
                        foreach (int r in right)
                        {
                            if (op[i] == '-')
                            {
                                cur.Add(l - r);

                            }
                            else if (op[i] == '+')
                            {
                                cur.Add(l + r);

                            }
                            else if (op[i] == '*')
                            {
                                cur.Add(l * r);
                            }
                        }
                    }
                }

                cache[start, end] = cur;
            }

            return cache[start, end];
        }



        // Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.

        // A region is captured by flipping all 'O's into 'X's in that surrounded region.

        // For example,

        // X X X X
        // X O O X
        // X X O X
        // X O X X



        // After running your function, the board should be: 
        // X X X X
        // X X X X
        // X X X X
        // X O X X


        public void Solve(char[,] board)
        {

            int n = board.GetLength(0);
            int m = board.GetLength(1);


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i, j] == 'O')
                    {
                        Search(board, i, j, n, m);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i, j] == 'L')
                    {
                        board[i, j] = 'O';
                    }
                }
            }
            return;
        }

        private bool Search(char[,] board, int i, int j, int n, int m)
        {

            Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
            Queue<KeyValuePair<int, int>> visited = new Queue<KeyValuePair<int, int>>();
            q.Enqueue(new KeyValuePair<int, int>(i, j));
            bool isDead = true;
            while (q.Any())
            {
                KeyValuePair<int, int> p = q.Dequeue();
                i = p.Key;
                j = p.Value;
                if (board[i, j] == 'O')
                {
                    board[i, j] = '!';
                    if (i == 0 || i == n - 1 || j == 0 || j == m - 1)
                    {
                        isDead = false;
                    }
                    else {
                        if (i > 0 && board[i - 1, j] == 'O') q.Enqueue(new KeyValuePair<int, int>(i - 1, j));
                        else if (i > 0 && board[i - 1, j] == 'L') { board[i, j] = 'L'; isDead = false; }
                        if (j > 0 && board[i, j - 1] == 'O') q.Enqueue(new KeyValuePair<int, int>(i, j - 1));
                        else if (j > 0 && board[i, j - 1] == 'L') { board[i, j] = 'L'; isDead = false; }
                        if (i + 1 < n && board[i + 1, j] == 'O') q.Enqueue(new KeyValuePair<int, int>(i + 1, j));
                        else if (i + 1 < n && board[i + 1, j] == 'L') { board[i, j] = 'L'; isDead = false; }
                        if (j + 1 < m && board[i, j + 1] == 'O') q.Enqueue(new KeyValuePair<int, int>(i, j + 1));
                        else if (j + 1 < m && board[i, j + 1] == 'L') { board[i, j] = 'L'; isDead = false; }
                    }
                }

                visited.Enqueue(p);
            }

            if (isDead)
            {
                while (visited.Any())
                {
                    KeyValuePair<int, int> p = visited.Dequeue();
                    board[p.Key, p.Value] = 'X';
                }
            }
            else {
                while (visited.Any())
                {
                    KeyValuePair<int, int> p = visited.Dequeue();
                    board[p.Key, p.Value] = 'L';
                }
            }

            return isDead;
        }



        // Given an unsorted array return whether an increasing subsequence of length 3 exists or not in the array. 

        // Formally the function should:


        // Return true if there exists i, j, k  
        //  such that arr[i] < arr[j] < arr[k] given 0 ≤ i < j < k ≤ n-1 else return false. 


        // Your algorithm should run in O(n) time complexity and O(1) space complexity. 

        // Examples:
        //  Given [1, 2, 3, 4, 5],
        //  return true. 

        // Given [5, 4, 3, 2, 1],
        //  return false. 



        public bool IncreasingTriplet(int[] nums)
        {
            if (nums.Length < 3) return false;

            //int left = 0;
            //int right = nums.Length-1;
            //bool[] biggerLeft = new bool[nums.Length];

            //for(int i = 1; i < nums.Length; i++){
            //    if(nums[i] < nums[left])  left = i;
            //    if(nums[i]>nums[left]) biggerLeft[i] = true;
            //}

            //for(int i = nums.Length-2; i > 0; i--){
            //    if(nums[i] > nums[right]){
            //      right = i;
            //    }

            //    if(nums[i] < nums[right] && biggerLeft[i]) return true;
            //}


            int min = nums[0]; int mid = int.MaxValue;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < min) min = nums[i];

                if (nums[i] > min && nums[i] < mid)
                {
                    mid = nums[i];
                }

                if (nums[i] > mid) return true;
            }
            return false;
        }



        // Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place. 

        // click to show follow up.

        // Follow up: 
        // Did you use extra space?
        //  A straight forward solution using O(mn) space is probably a bad idea.
        //  A simple improvement uses O(m + n) space, but still not the best solution.
        //  Could you devise a constant space solution? 


        public void SetZeroes(int[,] matrix)
        {

            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();

            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            foreach (int r in rows)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[r, j] = 0;
                }
            }

            foreach (int c in cols)
            {
                for (int i = 0; i < n; i++)
                {
                    matrix[i, c] = 0;
                }
            }
            return;
        }



        // Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

        // Example 1:
        // 11110
        // 11010
        // 11000
        // 00000

        // Answer: 1

        // Example 2:
        // 11000
        // 11000
        // 00100
        // 00011

        // Answer: 3



        public int NumIslands(char[,] grid)
        {

            int n = grid.GetLength(0);
            int m = grid.GetLength(1);
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i, j] == '1')
                    {
                        sum += BFS(grid, i, j, n, m);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (grid[i, j] == '2')
                    {
                        grid[i, j] = '1';
                    }
                }
            }

            return sum;
        }

        private int BFS(char[,] grid, int i, int j, int n, int m)
        {

            Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
            q.Enqueue(new KeyValuePair<int, int>(i, j));
            while (q.Any())
            {
                KeyValuePair<int, int> top = q.Dequeue();
                int x = top.Key;
                int y = top.Value;
                if (grid[x, y] != '1') continue;

                if (x > 0 && grid[x - 1, y] == '1') q.Enqueue(new KeyValuePair<int, int>(x - 1, y));
                if (y > 0 && grid[x, y - 1] == '1') q.Enqueue(new KeyValuePair<int, int>(x, y - 1));
                if (x < n - 1 && grid[x + 1, y] == '1') q.Enqueue(new KeyValuePair<int, int>(x + 1, y));
                if (y < m - 1 && grid[x, y + 1] == '1') q.Enqueue(new KeyValuePair<int, int>(x, y + 1));

                grid[x, y] = '2';
            }

            return 1;
        }




        // Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element. 

        // For example,
        //  Given [3,2,1,5,6,4] and k = 2, return 5. 

        // Note: 
        //  You may assume k is always valid, 1 ≤ k ≤ array's length.



        public int FindKthLargest(int[] nums, int k)
        {
            List<int> kL = new List<int>(k);

            for (int i = 0; i < k; i++)
            {
                kL.Add(nums[i]);
            }

            kL.Sort();

            for (int j = k; j < nums.Length; j++)
            {
                if (nums[j] > kL[0])
                {
                    QuickAdjust(kL, 0, k - 1, nums[j]);
                }
            }

            return kL[0];
        }


        private void QuickAdjust(List<int> kL, int start, int end, int target)
        {
            if (start >= end)
            {
                if (start > 0 && start < kL.Count)
                {
                    for (int i = 0; i < start; i++)
                    {
                        kL[i] = kL[i + 1];
                    }
                }
                if (kL[start] < target) kL[start] = target;
                if (kL[start] > target && start > 0) kL[start - 1] = target;
                return;
            }

            int middle = start + (end - start) / 2;

            if (target < kL[middle])
            {
                QuickAdjust(kL, start, middle - 1, target);
            }
            else {
                QuickAdjust(kL, middle + 1, end, target);
            }
        }



        // Write a program to find the nth super ugly number.

        // Super ugly numbers are positive numbers whose all prime factors are in the given prime list primes of size k. For example, [1, 2, 4, 7, 8, 13, 14, 16, 19, 26, 28, 32]  is the sequence of the first 12 super ugly numbers given primes = [2, 7, 13, 19] of size 4. 

        // Note:
        //  (1) 1 is a super ugly number for any given primes.
        //  (2) The given numbers in primes are in ascending order.
        //  (3) 0 < k ≤ 100, 0 < n ≤ 106, 0 < primes[i] < 1000. 


        public int NthSuperUglyNumber(int n, int[] primes)
        {
            int k = primes.Length;
            int[] ret = new int[n];

            int[] index = new int[k];
            int[] factor = new int[k];

            for (int i = 0; i < k; i++)
            {
                index[i] = 0;
                factor[i] = primes[i];
            }

            ret[0] = 1;

            for (int i = 1; i < n; i++)
            {
                int min = int.MaxValue;

                for (int j = 0; j < k; j++)
                {
                    if (min > factor[j]) min = factor[j];
                }

                ret[i] = min;

                for (int j = 0; j < k; j++)
                {
                    if (factor[j] == min) factor[j] = primes[j] * ret[++index[j]];
                }
            }

            return ret[n - 1];
        }


        // Write a program to find the n-th ugly number.

        // Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. For example, 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers.

        // Note that 1 is typically treated as an ugly number.



        public int NthUglyNumber(int n)
        {
            int[] ret = new int[n];

            ret[0] = 1;

            int i2 = 0; int i3 = 0; int i5 = 0;

            int f1 = 2; int f2 = 3; int f3 = 5;

            for (int i = 1; i < n; i++)
            {

                int min = int.MaxValue;

                if (min > f1) min = f1;
                if (min > f2) min = f2;
                if (min > f3) min = f3;

                ret[i] = min;

                if (min == f1) f1 = 2 * ret[++i2];
                if (min == f2) f2 = 3 * ret[++i3];
                if (min == f3) f3 = 5 * ret[++i5];
            }

            return ret[n - 1];
        }


        public int Search(int[] nums, int target)
        {
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;
            return bs(nums, target, 0, nums.Length - 1);
        }

        private int bs(int[] nums, int target, int start, int end)
        {
            if (start > end) return -1;
            int middle = start + (end - start) / 2;
            int ret = -1;
            if (nums[middle] >= nums[start] && nums[middle] <= nums[end])
            {
                if (nums[middle] > target)
                {
                    ret = bs(nums, target, start, middle - 1);
                }
                else if (nums[middle] < target)
                {
                    ret = bs(nums, target, middle + 1, end);
                }
                else if (nums[middle] == target) return middle;
            }
            else {
                ret = bs(nums, target, middle + 1, end);
                if (ret != -1) return ret;
                ret = bs(nums, target, start, middle);
            }

            return ret;
        }



        public int NumSquares(int n)
        {

            if (n == 1) return 1;
            int[] dp = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = 0;
            }

            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                int min = int.MaxValue;
                for (int k = 1; k * k <= i; k++)
                {
                    min = Math.Min(1 + dp[i - k * k], min);
                }

                dp[i] = min;
            }

            return dp[n];
        }



        public ListNode DetectCycle(ListNode head)
        {
            ListNode p = head;
            ListNode pp = head;
            int hh = 0;

            while (p != null && pp != null)
            {
                p = p.next; hh++;
                if (pp.next == null) return null;
                pp = pp.next.next;

                if (p == pp) break;
            }

            if (pp == null) return null;

            int ah = hh / 2;
            pp = head;
            while (ah > 0)
            {
                pp = pp.next.next;
                ah--;
            }

            if (hh % 2 != 0) pp = pp.next;
            p = head;

            while (hh >= 0)
            {
                if (p == pp) return p;
                p = p.next;
                pp = pp.next;
                hh--;
            }

            return null;
        }



        // Given an array of citations (each citation is a non-negative integer) of a researcher, write a function to compute the researcher's h-index. 

        // According to the definition of h-index on Wikipedia: "A scientist has index h if h of his/her N papers have at least h citations each, and the other N − h papers have no more than h citations each." 

        // For example, given citations = [3, 0, 6, 1, 5], which means the researcher has 5 papers in total and each of them had received 3, 0, 6, 1, 5 citations respectively. Since the researcher has 3 papers with at least 3 citations each and the remaining two with no more than 3 citations each, his h-index is 3. 

        // Note: If there are several possible values for h, the maximum one is taken as the h-index. 


        public int HIndex(int[] citations)
        {
            int n = citations.Length;
            return bs(citations, 0, n - 1);
        }

        private int bs(int[] c, int start, int end)
        {
            if (start > end) return 0;
            int middle = start + (end - start) / 2;

            int h = c.Length - middle;
            int max = 0;
            if (h <= c[middle])
            {
                max = Math.Max(bs(c, start, middle - 1), h);
            }
            else {
                max = bs(c, middle + 1, end);
            }

            return max;
        }


        // Follow up for "Search in Rotated Sorted Array":
        //  What if duplicates are allowed?

        // Would this affect the run-time complexity? How and why?

        // Write a function to determine if a given target is in the array.



        public bool SearchRotated(int[] nums, int target)
        {
            return bsRotated(nums, target, 0, nums.Length - 1) == -1 ? false : true;
        }

        private int bsRotated(int[] nums, int target, int start, int end)
        {
            if (start > end) return -1;
            while (start < end && nums[start] == nums[end]) start++;
            int middle = start + (end - start) / 2;
            int ret = -1;
            int lM = middle;
            int rM = middle;

            while (lM > start && nums[lM] == nums[lM - 1]) lM--;
            while (rM < end && nums[rM] == nums[rM + 1]) rM++;

            if (nums[middle] >= nums[start] && nums[middle] <= nums[end])
            {
                if (nums[middle] > target)
                {
                    ret = bs(nums, target, start, lM - 1);
                }
                else if (nums[middle] < target)
                {
                    ret = bs(nums, target, rM + 1, end);
                }
                else if (nums[middle] == target) return lM;
            }
            else {
                ret = bs(nums, target, rM + 1, end);
                if (ret != -1) return ret;
                ret = bs(nums, target, start, lM);
            }
            return ret;
        }




        public ListNode MergeKLists(ListNode[] lists)
        {
            return MergeK(lists, 0, lists.Length - 1);
        }

        private ListNode MergeK(ListNode[] lists, int start, int end)
        {

            if (start > end) return null;
            if (start == end) return lists[start];
            if (start + 1 == end) return Merge(lists[start], lists[end]);

            int middle = start + (end - start) / 2;

            ListNode a = MergeK(lists, start, middle);
            ListNode b = MergeK(lists, middle + 1, end);
            return Merge(a, b);
        }

        private ListNode Merge(ListNode a, ListNode b)
        {
            ListNode head = new ListNode(-1);

            ListNode ret = head;
            while (a != null && b != null)
            {
                if (a.val < b.val)
                {
                    head.next = a;
                    a = a.next;
                }
                else {
                    head.next = b;
                    b = b.next;
                }

                head = head.next;
            }

            if (a == null) head.next = b;
            else head.next = a;
            return ret.next;
        }




        // Given a collection of integers that might contain duplicates, nums, return all possible subsets.

        // Note:

        // •Elements in a subset must be in non-descending order.
        // •The solution set must not contain duplicate subsets.


        // For example,
        //  If nums = [1, 2, 2], a solution is: 
        // [
        //   [2],
        //   [1],
        //   [1,2,2],
        //   [2,2],
        //   [1,2],
        //   []
        // ]

        public IList<IList<int>> Subsets(int[] nums)
        {
            List<int> last = new List<int>();
            System.Array.Sort(nums);
            IList<IList<int>> ret = new List<IList<int>>();
            ret.Add(last);
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                int len = ret.Count;
                for (int j = 0; j < len; j++)
                {
                    last = ret[j].ToList<int>();
                    last.Add(nums[i]);
                    ret.Add(last);
                }
            }

            return ret;
        }


        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<int> last = new List<int>();
            System.Array.Sort(nums);
            IList<IList<int>> ret = new List<IList<int>>();
            ret.Add(last);
            int len = ret.Count;
            int n = nums.Length;
            int j = 0;
            for (int i = 0; i < n; i++)
            {

                if (i > 0 && nums[i] == nums[i - 1])
                {
                    j = len;
                }
                else {
                    j = 0;
                }

                len = ret.Count;
                for (; j < len; j++)
                {
                    last = ret[j].ToList<int>();
                    last.Add(nums[i]);
                    ret.Add(last);
                }
            }

            return ret;
        }

        // Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */

        public TreeNode SortedListToBST(ListNode head)
        {
            ListNode t = head;
            int count = 0;
            if (head == null) return null;

            while (t != null)
            {
                t = t.next;
                count++;
            }

            List<TreeNode> ltr = new List<TreeNode>(count);
            for (int i = 0; i < count; i++)
            {
                ltr.Add(new TreeNode(int.MinValue));
            }

            TreeNode root = ConstructTree(ltr, 0, count - 1);
            DFS(root, ref head);
            return root;
        }

        private TreeNode ConstructTree(List<TreeNode> ltr, int start, int end)
        {
            if (start > end) return null;

            int middle = start + (end - start) / 2;
            TreeNode root = ltr[middle];
            root.left = ConstructTree(ltr, start, middle - 1);
            root.right = ConstructTree(ltr, middle + 1, end);

            return root;
        }

        private void DFS(TreeNode root, ref ListNode head)
        {
            if (root == null) return;

            DFS(root.left, ref head);
            root.val = head.val;
            head = head.next;
            DFS(root.right, ref head);
        }




        // Given a range[m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.

        // For example, given the range[5, 7], you should return 4. 


        public int RangeBitwiseAnd(int m, int n)
        {
            int sum = m;
            int lgM = (int)Math.Log(m, 2);
            int lgN = (int)Math.Log(n, 2);
            if (lgM == lgN)
            {
                for (int i = m; i <= n; i++)
                {
                    sum = sum & i;
                    if (i == n) break;
                }
                return sum;
            }

            sum = RangeBitwiseAnd(0, n - (int)Math.Pow(2, lgN)) & (int)Math.Pow(2, lgN);
            return sum;
        }



        // A message containing letters from A-Z is being encoded to numbers using the following mapping: 
        // 'A' -> 1
        // 'B' -> 2
        // ...
        // 'Z' -> 26


        // Given an encoded message containing digits, determine the total number of ways to decode it. 

        // For example,
        //  Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12). 



        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            if (s[0] == '0') return 0;
            int[] ret = new int[s.Length + 1];
            int n = s.Length;
            for (int i = 0; i <= n; i++)
            {
                ret[i] = 0;
            }

            ret[0] = 1;
            ret[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                if (s[i - 1] == '0' && s[i - 2] != '1' && s[i - 2] != '2') return 0;
                if (s[i - 1] != '0') ret[i] += ret[i - 1];
                if ((s[i - 2] == '1' || s[i - 2] == '2' && s[i - 1] <= '6'))
                {
                    ret[i] += ret[i - 2];
                }
            }

            return ret[n];
        }



        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */


        public IList<TreeNode> GenerateTrees(int n)
        {
            List<TreeNode>[,] cache = new List<TreeNode>[n + 2, n + 2];
            if (n == 0) return new List<TreeNode>();
            for (int len = 1; len <= n; len++)
            {
                for (int i = 1; i <= n - len + 1; i++)
                {
                    for (int j = i; j < i + len; j++)
                    {
                        List<TreeNode> left = cache[i, j - 1];
                        List<TreeNode> right = cache[j + 1, i + len - 1];
                        if (left == null) { left = new List<TreeNode>(); left.Add(null); }
                        if (right == null) { right = new List<TreeNode>(); right.Add(null); }
                        if (cache[i, i + len - 1] == null) cache[i, i + len - 1] = new List<TreeNode>();
                        for (int lni = 0; lni < left.Count; lni++)
                        {
                            for (int rni = 0; rni < right.Count; rni++)
                            {
                                TreeNode l = null;
                                l = CopyTree(left[lni], ref l);
                                TreeNode r = null;
                                r = CopyTree(right[rni], ref r);
                                TreeNode root = new TreeNode(j);
                                root.left = l;
                                root.right = r;
                                cache[i, i + len - 1].Add(root);
                            }
                        }
                    }
                }
            }
            return cache[1, n];
        }

        private TreeNode CopyTree(TreeNode root, ref TreeNode copy)
        {
            if (root == null) { copy = null; return copy; }

            copy = new TreeNode(root.val);
            copy.left = null;
            copy.right = null;
            CopyTree(root.left, ref copy.left);
            CopyTree(root.right, ref copy.right);

            return copy;
        }




        // Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.
        // For example, given the following triangle
        // [
        //      [2],
        //    [3,4],
        //    [6,5,7],
        //   [4,1,8,3]
        // ]
        // The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11). 

        // 2
        // 3, 4
        // 6, 5, 7
        // 4, 1, 8, 3

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle == null || triangle.Count == 0 || triangle[0].Count == 0) return 0;
            int n = triangle.Count;
            int m = triangle[n - 1].Count;
            int[] ret = new int[m];
            int[] previous = new int[m];
            int minPath = int.MaxValue;
            previous[0] = triangle[0][0];

            for (int i = 1; i < n; i++)
            {
                ret[0] = triangle[i][0] + previous[0];
                ret[i] = triangle[i][i] + previous[i - 1];
                for (int j = 1; j < i; j++)
                {
                    ret[j] = Math.Min(triangle[i][j] + previous[j], triangle[i][j] + previous[j - 1]);
                }

                previous = ret;
                ret = new int[m];
            }

            for (int i = 0; i < m; i++)
            {
                minPath = Math.Min(previous[i], minPath);
            }

            return minPath;
        }
        //     public class ListNode {
        //         public int val;
        //         public ListNode next;
        //         public ListNode(int x) { val = x; }
        //     }


        //   Input: [3,4,1]
        // Output: [1,3]
        // Expected: [1,3,4]

        public ListNode SortList(ListNode head)
        {
            if (head == null) return null;
            ListNode end = head;
            int len = 1;
            while (end.next != null) { end = end.next; len++; }
            return Sort(head, end, len);
        }

        private ListNode Sort(ListNode head, ListNode end, int len)
        {
            if (head == null || end == null) return head;
            if (head == end)
            {
                head.next = null;
                return head;
            }

            int m = len / 2;
            ListNode mNode = head;
            while (m > 1) { mNode = mNode.next; m--; }
            ListNode b = Sort(mNode.next, end, len - len / 2);
            ListNode a = Sort(head, mNode, len / 2);
            return Merge(a, b);
        }

        private ListNode MergeSorte(ListNode a, ListNode b)
        {
            ListNode head = new ListNode(-1);
            ListNode hh = head;
            while (a != null && b != null)
            {
                if (a.val < b.val)
                {
                    head.next = a;
                    a = a.next;
                    head = head.next;
                }
                else {
                    head.next = b;
                    b = b.next;
                    head = head.next;
                }
            }
            if (a == null) head.next = b;
            else head.next = a;
            return hh.next;
        }
        
        
        
        // Find the contiguous subarray within an array (containing at least one number) which has the largest product. 

        // For example, given the array [2,3,-2,4],
        // the contiguous subarray [2,3] has the largest product = 6. 
        public int MaxProductInt(int[] nums) {
            int n = nums.Length;
            List<int> num = new List<int>();
            int ret = nums[0];
            int cnt = 0;
            int cntP = 0;
            for(int i = 0; i < n; i++){ 
                ret = Math.Max(nums[i], ret);
                if(nums[i] == 1) {cntP++;continue;}
                else if(nums[i] == -1){cnt++; continue;}
                else {
                  if(cnt > 0){
                      if(cnt%2 == 0) num.Add(1);
                      else num.Add(-1);
                      cnt = 0;
                  }else if(cntP > 0){
                      num.Add(1);
                      cntP = 0;
                  }
                  num.Add(nums[i]);
                }
            }
            
            if(cnt > 0){
                if(cnt%2 == 0) num.Add(1);
                else num.Add(-1);
                cnt = 0;
            }else if(cntP > 0){
                 num.Add(1);
                 cntP = 0;
            }
            
            n = num.Count;
            nums = num.ToArray();
            int[,] dp = new int[n,n];
            for(int i = 0; i < n; i++){
                for(int j = 0; j < n; j++){
                    dp[i,j] = 1;
                }
                dp[i,i] = nums[i];
                ret = Math.Max(nums[i], ret);
            }

            for(int i = 2; i <= n; i++){
                for(int start = 0; start <= n-i; start++){
                        int end = start+i-1;
                        dp[start,end] = dp[start,start] * dp[start+1, end];
                        ret = Math.Max(dp[start,end], ret);
                }
            }
            return ret;
        }
        
        public int MaxProductIntOn(int[] nums){
            int n = nums.Length;
            int ret = int.MinValue;
            List<int> maxP = new List<int>();
            List<int> minP = new List<int>();
            
            maxP.Add(nums[0]);
            minP.Add(nums[0]);
            
            for(int i = 1; i < n; i++){
                maxP.Add(Math.Max(Math.Max(nums[i], nums[i]*maxP[i-1]), nums[i]*minP[i-1]));
                minP.Add(Math.Min(Math.Min(nums[i], nums[i]*minP[i-1]), nums[i]*maxP[i-1]));
            }
            
            foreach(int i in maxP){
                ret = Math.Max(i,ret);
            }
            return ret;
        }
        
        
        // Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.

        // Example:

        // Given nums = [-2, 0, 3, -5, 2, -1]

        // sumRange(0, 2) -> 1
        // sumRange(2, 5) -> -1
        // sumRange(0, 5) -> -3



        // Note:

        // 1.You may assume that the array does not change.
        // 2.There are many calls to sumRange function.
        
        //private int[,] rangeSumCache = new int[n, n];
        private int[] rangeCacheRight;
        private int[] rangeCacheLeft;
        private int rangeSumCache = 0;
        private int rangeSumLen;
        public void NumArray(int[] nums) {
            int n = nums.Length;
            rangeSumLen = n;
            if(n == 0) return;
            rangeCacheLeft = new int[n];
            rangeCacheRight = new int[n];
            rangeCacheLeft[0] = nums[0];
            rangeCacheRight[n-1] = nums[n-1];
            rangeSumCache += nums[0];
            for(int i = 1; i < n; i++){
                rangeSumCache += nums[i];
                rangeCacheLeft[i] = rangeCacheLeft[i-1] + nums[i];
                rangeCacheRight[n-1-i] = rangeCacheRight[n-i] + nums[n-1-i];
            }
        }

        public int SumRange(int i, int j) {
            if(rangeSumLen == 0) return 0;
            if(i == 0 && j == rangeSumLen-1) return rangeSumCache;
            else if(i==0) return rangeSumCache-rangeCacheRight[j+1];
            else if(j == rangeSumLen-1) return rangeSumCache-rangeCacheLeft[i-1];
            else return rangeSumCache-rangeCacheLeft[i-1]-rangeCacheRight[j+1];
        }
        
        // Given a 2D binary matrix filled with 0's and 1's, find the largest square containing all 1's and return its area. 

        // For example, given the following matrix: 
        // 1 0 1 0 0
        // 1 0 1 1 1
        // 1 1 1 1 1
        // 1 0 0 1 0

        // Return 4.
        
        public int MaximalSquare(char[,] matrix) {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] ret = new int[n,m];
            int max = 0;
            if(n==0 && m == 0) return 0;
            
            for(int i = 0; i < n; i++){
                ret[i, 0] = matrix[i,0] == '1' ? 1 : 0;
                max = Math.Max(ret[i,0], max);
            } 
            
            for(int j = 0; j < m; j++){
                ret[0, j] = matrix[0,j] == '1' ? 1 : 0;
                max = Math.Max(ret[0,j], max);
            }
            
            if(n == 1 || m == 1) return max;
            
            for(int i = 1; i < n; i++){
                for(int j = 1; j < m; j++){
                    if(matrix[i,j] == '0'){ret[i,j] = 0; continue;} 
                    else if(matrix[i-1,j-1] == '0'){ret[i,j] = 1; continue;}
                    
                    int shortSide = (int)Math.Min(Math.Sqrt(ret[i-1,j]), Math.Sqrt(ret[i,j-1]));
                    int min = (int)Math.Sqrt(ret[i-1,j-1]);
                    if(min >= shortSide) ret[i,j] = (shortSide+1)*(shortSide+1);
                    else ret[i,j] = ret[i-1, j-1] + 2 * min + 1;   
                    
                    max = Math.Max(ret[i,j], max);
                }
            }
            
            return max;
        }
        
        //[
        //    "1010",
        //    "1011",
        //    "1011",
        //    "1111"
        //]
        public int MaximalRectangle(char[,] matrix){
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[,] yCache = new int[n,m];
            int max = 0;
            if(n==0 && m == 0) return 0;
                  
            for(int j = 0; j < m; j++){
                if(matrix[0,j] == '1') yCache[0,j] = 1;
                else yCache[0,j] = 0;
                for(int i = 1; i < n ; i++){
                    if(matrix[i,j] == '1') yCache[i,j] = yCache[i-1,j] + 1;
                    else yCache[i,j] = 0;
                }
            }

            int h;
            int v;
            for(int i = 0; i < n; i++){
                for(int start = 0; start < m; start++){
                    h = 0;
                    v = int.MaxValue;
                    for (int j = start; j < m; j++){
                        if(matrix[i,j] == '1'){
                            h++;
                            v = Math.Min(yCache[i,j], v);
                                max = Math.Max(max, v*h);
                        }else{
                            h = 0;v = int.MaxValue;
                        }
                    }
                }
            }           
            return max;
        }
        
        public int MaxRectangle(char[,] matrix){
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int[] left = new int[m];
            int[] right = new int[m];
            int[] h = new int[m];
            if(n == 0 || m == 0 ) return 0;
            for(int i = 0; i < m; i++) right[i] = m;
            int area = 0;
            for(int i = 0; i < n; i++){
                int l = 0;
                int r = m;
                for(int j = 0; j < m; j++){
                    if(matrix[i,j] == '1'){
                        h[j]++;
                        left[j] = Math.Max(l, left[j]);
                    }else{
                        l = j+1;
                        h[j] = 0;
                        left[j] = 0;
                    }
                }
                
                for(int j = m-1; j > -1; j--){
                    if(matrix[i,j] == '1'){
                        right[j] = Math.Min(r, right[j]);
                        area = Math.Max(area, h[j] * (right[j] - left[j]));
                    }else{
                        right[j] = m;
                        r = j;
                    }
                }
            }
            
            return area;
        }
        
// Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram. 




// Above is a histogram where width of each bar is 1, given height = [2,1,5,6,2,3].





// The largest rectangle is shown in the shaded area, which has area = 10 unit.


// For example,
//  Given heights = [2,1,5,6,2,3],
//                   0, 0, 2, 3, 3, 5
//  return 10. 

        public int LargestRectangleArea(int[] heights) {
            int area = 0;
            int n = heights.Length;
            if(n == 0) return 0;
            int[] left = new int[n];
            int[] right = new int[n];
            left[0] = -1;
            right[n-1] = n;
            
            for(int i = 1; i < n; i++){
                if(heights[i] > heights[i-1]){
                    left[i] = i-1;
                }else{
                    int j = i-1;
                    while(j >= 0 && heights[i] <= heights[j]) j = left[j];
                    left[i] = j;
                }
            }
            
            area = Math.Max(area,heights[n-1]*(right[n-1]-left[n-1]-1));
            
            for(int i = n-2; i > -1; i--){
                if(heights[i] > heights[i+1]){
                    right[i] = i+1;
                }else{
                    int j = i+1;
                    while(j < n && heights[i] <= heights[j])j = right[j];
                    right[i] = j;
                }
                
                area = Math.Max(area, heights[i]*(right[i]-left[i]-1));
            }
            
            return area;
        }
}



    public class Queue
    {
        private Stack<int> _front = new Stack<int>();
        private Stack<int> _rear = new Stack<int>();
        // Push element x to the back of queue.
        public void Push(int x)
        {
            _rear.Push(x);
        }

        // Removes the element from front of queue.
        public void Pop()
        {
            if (_front.Count > 0) _front.Pop();
            else {
                while (_rear.Count > 0)
                {
                    int val = _rear.Pop();
                    _front.Push(val);
                }
                _front.Pop();
            }
        }

        // Get the front element.
        public int Peek()
        {
            if (_front.Count > 0) return _front.Peek();
            else if (_rear.Count > 0)
            {
                while (_rear.Count > 0)
                {
                    int val = _rear.Pop();
                    _front.Push(val);
                }
                return _front.Peek();
            }

            return 0;
        }

        // Return whether the queue is empty.
        public bool Empty()
        {
            return _front.Count == 0 && _rear.Count == 0;
        }
    }


    public class BSTIterator
    {

        private Stack<TreeNode> _stack = new Stack<TreeNode>();

        public BSTIterator(TreeNode root)
        {

            TreeNode it = root;
            while (it != null)
            {
                _stack.Push(it);
                it = it.left;
            }
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            if (_stack.Count > 0) return true;
            return false;

        }

        /** @return the next smallest number */
        public int Next()
        {
            if (_stack.Count > 0)
            {
                TreeNode f = _stack.Pop();
                TreeNode it = f.right;
                while (it != null)
                {
                    _stack.Push(it);
                    it = it.left;
                }
                return f.val;
            }

            return -1;
        }
    }
}