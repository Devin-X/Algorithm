using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    public class LinkList
    {
        public static bool IsPalindrome(ListNode head)
        {
            ListNode end = head;
            int len = 0;
            while (end != null)
            {
                end = end.next;
                len++;
            }

            if (len == 1 || len == 0) return true;
            if (len == 2) return head.val == head.next.val;
            if (len == 3) return head.val == head.next.next.val;

            if (len % 2 == 1)
            {
                len = len / 2 + 1;
            }
            else
            {
                len = len / 2;
            }

            end = head;
            for (int i = 0; i < len - 1; i++)
            {
                end = end.next;
            }

            ListNode pre;
            ListNode post;
            pre = end;
            post = end.next == null ? null : end.next.next;
            end.next.next = pre;
            end = pre.next;

            while (end != null && post != null)
            {
                pre = end;
                end = post;
                post = post.next;
                end.next = pre;
            }

            while (head.val == end.val)
            {
                head = head.next;
                end = end.next;
                len--;
                if (len == 0 || head == end)
                    return true;
                if (len < 0)
                    return false;
            }

            return false;
        }
    }
}
