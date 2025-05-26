using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace NeetCode.LinkedList
{
    public class RemoveNthFromEndSolution
    {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val=0, ListNode next=null) {
                this.val = val;
                this.next = next;
            }
        }


        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode result = null;

            if(head != null)
            {
                result = RemoveNthFromEndIterative(head, n);
            }

            return result;
        }

        private ListNode RemoveNthFromEndIterative(ListNode head, int n)
        {
            var lookup = new SortedList<int, ListNode>();

            ListNode node = head;
            int i = 0;
            while(node != null)
            {
                lookup.Add(i, node);

                i++;
                node = node.next;
            }

            int nodeToSplice = lookup.Count - 1 - n;

            if (nodeToSplice >= 0 )
            {
                int nodeToRemove = lookup.Count - n;

                lookup[nodeToSplice].next = lookup[nodeToRemove].next;

                return head;
            }
            else
            {
                return head.next;
            }
        }
    }
}