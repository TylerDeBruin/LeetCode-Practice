using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace NeetCode.LinkedList
{
    public class CopyRandomListSolution
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        public Node copyRandomList(Node head)
        {
            Node result = null;

            if (head != null)
            {
                result = IterateList(head);
            }

            return result;
        }


        private Node IterateList(Node head)
        {
            var nodeMap = new Dictionary<Node, Node>();

            //Iterate through, creating the Map between the Original and the Copy.
            Node current = head;
            while (current != null)
            {
                nodeMap[current] = new Node(current.val);
                current = current.next;
            }

            //Using that Map, point to the correct copied pointer.
            current = head;
            while (current != null)
            {
                Node copyNode = nodeMap[current];
                copyNode.next = current.next != null ? nodeMap[current.next] : null;
                copyNode.random = current.random != null ? nodeMap[current.random] : null;
                current = current.next;
            }

            return nodeMap[head];
        }

        [Fact]
        public void Test1()
        {
            var node = new Node(3);
            node.random = null;

            node.next = new Node(1);
            node.random = node;

            var result = copyRandomList(node);
        }
    }
}