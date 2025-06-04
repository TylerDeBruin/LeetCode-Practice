using System.Numerics;
using System.Text;

namespace NeetCode.LinkedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class AddTwoNumbersSolution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var numberOne = new List<int>();
            ListNode node = l1;
            while (node != null)
            {
                numberOne.Add(node.val);
                node = node.next;
            }

            var numberTwo = new List<int>();
            node = l2;
            while (node != null)
            {
                numberTwo.Add(node.val);
                node = node.next;
            }

            var result = new List<int>();
            var carry = 0;
            for (int i = 0; i < Math.Max(numberOne.Count, numberTwo.Count); i++)
            {
                var sumOne = 0;
                if(i < numberOne.Count)
                {
                    sumOne = numberOne[i];
                }

                var sumTwo = 0;
                if (i < numberTwo.Count)
                {
                    sumTwo = numberTwo[i];
                }

                var total = (sumOne + sumTwo + carry);
                carry = 0;
                if(total > 9)
                {
                    carry = 1;
                }

                result.Add(total % 10);
            }

            if(carry == 1)
            {
                result.Add(1);
            }

            ListNode head = null;
            node = null;
            for(int i = 0; i < result.Count; i++)
            {
                if(node != null)
                {
                    node.next = new ListNode(result[i]);
                    node = node.next;
                }
                else
                {
                    node = new ListNode(result[i]);
                }

                if (i == 0)
                {
                    head = node;
                }
            }


            return head;
        }

        ////https://neetcode.io/problems/add-two-numbers
        //public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        //{
        //    var currentNodeL1 = TraverseList(l1);
        //    var currentNodeL2 = TraverseList(l2);
        //    //579
        //    var resultNumber = currentNodeL1 + currentNodeL2;
        //    //5,7,9
        //    var resultChartacters = resultNumber.ToString().ToCharArray();

        //    //
        //    var resultArray = resultChartacters.Reverse().Select(x => int.Parse(x.ToString())).ToArray();

        //    var result = CreateLinkedList(resultArray);

        //    return result;
        //}


        private int TraverseList(ListNode listnode)
        {
            var currentNode = listnode;

            var result = new List<int>();

            while (currentNode != null)
            {
                result.Add(currentNode.val);

                currentNode = currentNode.next;
            }

            result.Reverse();

            var numbers = result.Select(x => x.ToString()).ToArray();

            return int.Parse(string.Join("", numbers));
        }

        private ListNode CreateLinkedList(int[] listArray )
        {
            ListNode result = new ListNode(listArray[0], null);

            var headNode = result;

            for (int i = 1; i < listArray.Length; i++ )
            {
                result.next = new ListNode(listArray[i], null);

                result = result.next;
            }

            return headNode;
        }

        [Fact]
        public void Test3()
        {
            var l1 = CreateLinkedList([1, 2, 3]);

            var result = TraverseList(l1);

            Assert.Equal(321, result);
        }

        [Fact]
        public void Test4()
        {
            var l1 = CreateLinkedList([1, 2, 3]);

            Assert.Equal(1, l1.val);
            Assert.Equal(2, l1.next.val);
            Assert.Equal(3, l1.next.next.val);
        }

        [Fact]
        public void Test1()
        {
            var l1 = CreateLinkedList([1, 2, 3]);
            var l2 = CreateLinkedList([4, 5, 6]);

            var actual = AddTwoNumbers(l1, l2);

            Assert.Equal(5, actual.val);
            Assert.Equal(7, actual.next.val);
            Assert.Equal(9, actual.next.next.val);
        }

        [Fact]
        public void Test2()
        {
            var l1 = CreateLinkedList([9]);
            var l2 = CreateLinkedList([9]);

            var actual = AddTwoNumbers(l1, l2);

            Assert.Equal(8, actual.val);
            Assert.Equal(1, actual.next.val);
        }
    }
}