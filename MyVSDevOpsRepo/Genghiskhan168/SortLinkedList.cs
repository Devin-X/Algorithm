using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{


    public class SortLinkedList
    {
        public static ListNode MergeSortLinkList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode preHead = new ListNode(0);
            ListNode left = null;
            ListNode right = null;
            ListNode leftW = null;
            ListNode rightW = null;
            ListNode walker = head.next;
            preHead.next = head;
            while(walker != null)
            {
                if(walker.val < head.val)
                {
                    if(left == null)
                    {
                        left = walker;
                        leftW = left;
                    }
                    else
                    {
                        leftW.next = walker;
                        leftW = leftW.next;
                    }
                }
                else
                {
                    if(right == null)
                    {
                        right = walker;
                        rightW = walker;
                    }
                    else
                    {
                        rightW.next = walker;
                        rightW = rightW.next;
                        
                    }
                }
                
                walker = walker.next;
            }

            if (leftW != null)
            {
                leftW.next = head;
                head.next = null;
            }
            else
            {
                left = head;
                head.next = null;
            }

            if(rightW != null)
                rightW.next = null;
            
            
            leftW = MergeSortLinkList(left);
            rightW = MergeSortLinkList(right);

            return Merge(leftW, rightW);
        }

        private static ListNode Merge(ListNode left, ListNode right)
        {
            ListNode h = new ListNode(0);
            ListNode hw = h;
            ListNode lW = left;
            ListNode rW = right;
            while(lW != null && rW != null)
            {
                if(lW.val < rW.val)
                {
                    hw.next = lW;
                    lW = lW.next;
                }
                else
                {
                    hw.next = rW;
                    rW = hw.next;
                }

                hw = hw.next;
            }

            if (lW == null)
                hw.next = rW;
            if (rW == null)
                hw.next = lW;

            return h.next;
        }


        public static ListNode SortLinkList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode end = head;
            while (end.next != null)
            {
                end = end.next;
            }

            ListNode prehead = new ListNode(0);
            prehead.next = head;
            SortLinkListHelper(head, end, prehead);

            return prehead.next;
        }

        private static ListNode SortLinkListHelper(ListNode head, ListNode end, ListNode preHead)
        {
            ListNode pre = head;
            ListNode walker = head;
            ListNode post = end;
            if (head == end)
                return end;

            while (walker != end)
            {
                if (walker.val > end.val)
                {
                    if (preHead.next == walker)
                    {
                        preHead.next = walker.next;
                        pre = walker.next;
                        post.next = walker;
                        walker = walker.next;
                        post = post.next;
                        post.next = null;
                    }
                    else
                    {
                        post.next = walker;
                        pre.next = walker.next;
                        post = post.next;
                        walker = walker.next;
                        post.next = null;
                    }
                    
                    continue;
                }
                else
                {
                    pre = walker;
                    walker = walker.next;
                }
            }

            ListNode newTailI = SortLinkListHelper(preHead.next, pre, preHead);
            ListNode newTailII;
            if (post != end)
            {
                newTailII = SortLinkListHelper(end.next, post, end);
            }
            else
            {
                newTailII = SortLinkListHelper(end, post, end);
            }

            if(newTailI != end)
            {
                newTailI.next = end;
            }

            return newTailII;
        }

        public static void Test()
        {
            ListNode head = new ListNode(0);
            ListNode walker = head;
            Random k = new Random();
            Console.Write(head.val);
            walker = head;
            for(int i = 0; i < 10; i++)
            {

                ListNode node = new ListNode(k.Next(100));
                walker.next = node;

                Console.Write("--> {0}  ", walker.next.val);
                walker = walker.next;
            }
            Console.WriteLine();

            //walker = SortLinkList(head);
            walker = MergeSortLinkList(head.next);

            while(walker != null)
            {
                Console.Write("{0}  --> ", walker.val);
                walker = walker.next;
            }
            
        }
    }
}

