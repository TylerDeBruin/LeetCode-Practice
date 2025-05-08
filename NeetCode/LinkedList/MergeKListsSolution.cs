using System;
using System.ComponentModel.DataAnnotations;
using ExpectedObjects;

namespace NeetCode.MergeKListsSolution
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

    public class MergeKListsSolution
    {

        //https://neetcode.io/problems/merge-k-sorted-linked-lists
        public ListNode MergeKLists(ListNode[] lists)
        {
            var minimumNumber = MinimumValue(lists);

            if (minimumNumber == null) return null;

            var result = new ListNode(minimumNumber.Value);

            var encounteredMinimum = false;
            var index = 0;

            foreach (var item in lists)
            {
                var nextNode = item;
                while (nextNode != null)
                {
                    if (!encounteredMinimum && minimumNumber == nextNode.val)
                    {
                        encounteredMinimum = true;
                        nextNode = nextNode.next;
                        continue;
                    }

                    MergeAtIndex(result, nextNode.val);

                    nextNode = nextNode.next;
                    index++;
                }
            }

            return result;
        }

        private int? MinimumValue(ListNode[] lists)
        {
            int? lowestNumber = null;

            foreach (ListNode l in lists)
            {
                lowestNumber = Math.Min(l.val, lowestNumber ?? int.MaxValue);
            }

            return lowestNumber;
        }

        private void MergeAtIndex(ListNode head, int value)
        {
            var intermediateNode = head;

            int mergeIndex = 0;

            while (true)
            {
                if (intermediateNode.next == null || value <= intermediateNode.next?.val)
                {
                    Splice(intermediateNode, value);
                    break;
                }

                mergeIndex++;
                intermediateNode = intermediateNode.next;
            }
        }

        private void Splice(ListNode spliceSource, int num)
        {
            var splice = new ListNode(num);

            var next = spliceSource.next;

            spliceSource.next = splice;
            splice.next = next;
        }

        private int[] IterateNodes(ListNode head)
        {
            var result = new List<int>();

            ListNode node = head;

            while (node != null)
            {
                result.Add(node.val);
                node = node.next;
            }

            return result.ToArray();
        }

        private ListNode CreateNodes(int[] array)
        {
            ListNode result = null;

            ListNode node = null;
            for (int i = 0; i < array.Length; i++)
            {
                if(i == 0)
                {
                    result = new ListNode(array[i]);
                    node = result;
                    continue;
                }

                node.next = new ListNode(array[i]);

                node = node.next;
            }

            return result;
        }

        [Fact]
        public void Test1()
        {
            var expected = new int[0];

            var actual = IterateNodes(null);

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Fact]
        public void Test2()
        {
            var expected = new int[] { 3, 6, 7 };

            var actual = IterateNodes(CreateNodes(new int[3] { 3, 6, 7 }));

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Fact]
        public void Test3()
        {
            var expected = new int[] { 1, 1, 2, 3, 3, 4, 5, 6 };

            var actual = IterateNodes(MergeKLists(new ListNode[3]
            {
                CreateNodes(new int[3]{ 1,2,4 }),
                CreateNodes(new int[3]{ 1,3,5 }),
                CreateNodes(new int[2]{ 3, 6 })
            }));

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [Fact]
        public void Test4()
        {
            var expected = new int[] { };

            var actual = IterateNodes(MergeKLists(new ListNode[0]));

            expected.ToExpectedObject().ShouldMatch(actual);
        }
    }
}