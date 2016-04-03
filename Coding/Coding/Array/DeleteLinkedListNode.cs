using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Array
{

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
