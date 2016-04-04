using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Array
{

    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class DeleteLinkedListNode
    {
        public void DeleteNode(ListNode node)
        {
            if (node == null || node.next == null)
            {
                node = null;
                return;
            }

            node.val = node.next.val;
            node.next = node.next.next;
            return;
        }
    }
}
